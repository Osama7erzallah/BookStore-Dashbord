using Microsoft.AspNetCore.Mvc;
using project1.Data;
using project1.ViewModel;
using project1.Models;
using Microsoft.EntityFrameworkCore;


namespace project1.Controllers
{
    public class AuthersController : Controller
    {

        public ApplicationDbContext context;

        public AuthersController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var Auther=context.Authers.ToList();
            var authersVM = Auther.Select(auther => new AutherVM()
            {
                Id = auther.Id,
                Name = auther.Name
            }).ToList(); 




           
            return View( authersVM);
        }
       
        [HttpGet]
        public IActionResult Create()
        {
return View();
        }

        [HttpPost]
        public IActionResult Create(AutherFormVM authervm)
        {
            if (authervm is null) { 
            return NotFound();
            }

            if (!ModelState.IsValid) {
                authervm.Id = -1;
                return View("Create",authervm);
            }


        Auther auther = new Auther()
        {
            Id= authervm.Id,
            Name= authervm.Name
        };
        try{
                context.Authers.Add(auther);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                ModelState.AddModelError("Name", "This Name already exists");
                authervm.Id = -1;
                return View("Create", authervm);
            }
            return RedirectToAction("Index");



        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var auther =context.Authers.Find(id);
            if(auther is null)
            {
                return NotFound();
            }
            AutherFormVM authervm = new AutherFormVM()
            {
                Id = auther.Id,
                Name = auther.Name,
            };
            return View("Create", authervm);
        }

        [HttpPost]
        public IActionResult Edit(AutherFormVM authervm) {
            if (!ModelState.IsValid)
            {
                return View("Create", authervm);
            }
            if (authervm is null)
            {
                return NotFound();
            }
            var auther = context.Authers.Find(authervm.Id);

            try
            {
            auther.Name = (authervm.Name);
                auther.UpdateTime = DateTime.Now;
               context.SaveChanges();
            return RedirectToAction("Index");
            }
            catch
            {

                ModelState.AddModelError("Name", "This Name already exists");
                return View("Create",authervm);

            }

        }

        public IActionResult Detales(int id)
        {
            var auther = context.Authers.Find(id);
            if (auther is null) { return NotFound(); }
            var authervm = new AutherVM()
            {
                Id = auther.Id,
                Name = auther.Name,
                UpdateTime = auther.UpdateTime,
                CreateTime = auther.CreateTime,
            };
            return View("Detales", authervm);


        }


        public IActionResult Delete(int id) {

            var auther = context.Authers.Find(id);
            if(auther is null) { return NotFound(); }
            context.Authers.Remove(auther);
            context.SaveChanges();
            return Ok();

        }


        [HttpPost]
        public IActionResult checkName([FromBody] CategoryVM categoryVM)
        {
            var isExists = context.Categories.Any(category => category.Name == categoryVM.Name);
            return Json(!isExists);
        }

    }
}
