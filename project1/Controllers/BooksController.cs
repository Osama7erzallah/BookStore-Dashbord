using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project1.Data;
using project1.Models;
using project1.ViewModel;



namespace project1.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment WepHost;

        public BooksController( ApplicationDbContext context, IWebHostEnvironment WepHost)
        {
            this.context = context;
            this.WepHost = WepHost;
        }
        public IActionResult Index()
        {
            var books = context.Books.
                Include(book => book.Auther).
                Include(book=>book.Categories).
                ThenInclude(book=>book.Category).ToList();

            var bookvm = books.Select(book => new BookVM
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Publisher = book.Publisher,
                PublisherDate = book.PublisherDate,
                Auther = book.Auther.Name,
                imageURL = book.imageURL,
                Categories = book.Categories.Select(book => book.Category.Name).ToList()
            }).ToList(); 
            




            return View(bookvm);
        }

        [HttpGet]
        public IActionResult Create() {
        
            var authers =context.Authers.OrderBy(Auther=>Auther.Name).ToList();
            var authersList = new List<SelectListItem>();

            var Category = context.Categories.OrderBy(Category => Category.Name).ToList();
            var categoriesList = new List<SelectListItem>();

            foreach (var auther in authers)
            {
                authersList.Add(new SelectListItem()
                {
                    Value = auther.Id.ToString(),
                    Text = auther.Name
                });
            }
            foreach (var category in Category)
            {
                categoriesList.Add(new SelectListItem()
                {
                    Value = category.Id.ToString(),
                    Text = category.Name
                });
            }
            var viewModel = new BookFormVM()
            {
                Authers = authersList,
                Categories= categoriesList,
                Id=-1
            };


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(BookFormVM  bookFormVM)
        {
            if (!ModelState.IsValid)
            {
                return View(bookFormVM);
            }

            String imageName = "";
            if (bookFormVM.imageURL != null)
            {
            

                imageName = $"{bookFormVM.Title}_" + Path.GetFileName(bookFormVM.imageURL.FileName);
                var path = Path.Combine($"{WepHost.WebRootPath}/image/Books", imageName);
                var stream = System.IO.File.Create(path);
                bookFormVM.imageURL.CopyTo(stream);

            }

            var book = new Book()
            {
                AutherId = bookFormVM.AutherId,
                Title = bookFormVM.Title,
                Description = bookFormVM.Description,
                Publisher = bookFormVM.Publisher,
                PublisherDate = bookFormVM.PublisherDate,
                imageURL = imageName,
                Categories = bookFormVM.SelectedCategories.Select(Id => new BookCategory { CategoryId = Id }).ToList(),
            };
           

            context.Books.Add(book);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        }
    }
