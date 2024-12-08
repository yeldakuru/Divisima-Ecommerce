using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Divisima.Tools;
using Divisima.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Divisima.WebUI.Controllers
{
    public class HomeController : Controller
    {
        MSSQLRepo<Slide> repoSlide;
        MSSQLRepo<Product> repoProduct;
		public HomeController(MSSQLRepo<Slide> _repoSlide, MSSQLRepo<Product> _repoProduct)
        {
            repoSlide = _repoSlide;
            repoProduct = _repoProduct;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Slides = repoSlide.GetAll().OrderBy(o => o.RecDate).ToList(),
                LastProducts = repoProduct.GetAll().Include(i => i.ProductImages).OrderBy(o => o.RecDate).Take(8),
                SalesProducts = repoProduct.GetAll().Include(i => i.ProductImages).OrderBy(o => o.RecDate).Skip(8).Take(8),
			};
            return View(homeVM);
        }

        [Route("/urun/ara")]
        public JsonResult SearchProduct(string _text)
        {
            IEnumerable<Product> products = repoProduct.GetAll(x => x.Name.ToLower().Contains(_text.ToLower())).Include(i => i.ProductImages);

            return Json(products.Select(s => new
            {
                Ad = s.Name,
                Link = "/urun/" + GeneralTool.UrlConvert(s.Name) + "/" + s.ID.ToString(),
                Resim = s.ProductImages.Any() ? s.ProductImages.FirstOrDefault().Path : "/product/nopicture.jpg/",
            }));
        }
    }
}
