using Microsoft.AspNetCore.Mvc;
using project1.Data;
using project1.Models;
using project1.ViewModel;


namespace project1.Controllers
{
    public class CategoriesController : Controller
    {
        public ApplicationDbContext context;

        public CategoriesController(ApplicationDbContext context) {
            this.context = context;
        }
       
        
        public IActionResult Index()
        {
            var Categories = context.Categories.ToList();
            var categoryVM = Categories.Select(category => new CategoryVM
            {
                Id = category.Id,
                Name = category.Name,
            }).ToList();

            return View("Index", Categories);
        }
       
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(CategoryVM CategoryVM)
        {

            if (!ModelState.IsValid)
            {
                CategoryVM.Id = -1;

                return View("Create", CategoryVM);
            }

            Category category = new Category();
            category.Name = CategoryVM.Name;
            try
            {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
            }
            catch
            {

                ModelState.AddModelError("Name", "This Name already exists");
                CategoryVM.Id = -1;
return View( CategoryVM);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Category categore = context.Categories.Find(id);
            if (categore is null)
            {
                return NotFound();
            }
            var viewModle = new CategoryVM()
            {
                Id = categore.Id,
                Name = categore.Name
            };
            return View("Create",viewModle);
        }


        [HttpPost]
        public IActionResult Edit(CategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
            {

                return View("Create", categoryVM);

            }
            Category category = context.Categories.Find(categoryVM.Id);

            if (category is null)
            {
                return NotFound();
            }
           
            try{
                category.Name = categoryVM.Name;
                category.UpdateTime = DateTime.Now;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {

                ModelState.AddModelError("Name", "This Name already exists");
                return View("Create",categoryVM);

            }


        }


        public IActionResult Detales(int id)
        {

Category category = context.Categories.Find(id);
            if (category is null)
            {
                return NotFound();
            }
            var viewModle = new CategoryVM()
            {
                Id = category.Id,
                Name = category.Name,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now

            };

            return View("Detales",viewModle);

        }



       public IActionResult Delete(int id)
        {
            var category = context.Categories.Find(id);
            if (category is null)
            {
                return NotFound();
            }
            context.Categories.Remove(category);
            context.SaveChanges();
            return Ok();

        }


        public IActionResult checkName(CategoryVM categoryVM)
        {
            var isExists=context.Categories.Any(category=>category.Name==categoryVM.Name);
            return Json(!isExists);

        }
           

        }
    }
