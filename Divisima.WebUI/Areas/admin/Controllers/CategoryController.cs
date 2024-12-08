using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Divisima.WebUI.Areas.admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Divisima.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize, Route("/admin/[controller]/[action]/{id?}")]
    public class CategoryController : Controller
    {
        MSSQLRepo<Category> repoCategory;
        private readonly IWebHostEnvironment webHostEnvironment;
        public CategoryController(MSSQLRepo<Category> _repoCategory, IWebHostEnvironment _webHostEnvironment)
        {
            repoCategory = _repoCategory;
            webHostEnvironment = _webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(repoCategory.GetAll().OrderBy(o => o.DisplayIndex));
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(Category model)
        {         

            repoCategory.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
			
            return View(repoCategory.GetBy(g => g.ID == id));
        }

        public IActionResult Update(Category model)
        {            
            repoCategory.Update(model);
            return RedirectToAction("Index");
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }

        public string Delete(int _id)
        {
            string rtn = "";
            Category Category = repoCategory.GetBy(g => g.ID == _id) ?? null;
            if (Category != null)
            {
                repoCategory.Delete(Category);                
                rtn = "OK";
            }
            return rtn;
        }
    }
}
