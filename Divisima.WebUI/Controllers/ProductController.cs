using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Divisima.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Divisima.WebUI.Controllers
{
	public class ProductController : Controller
	{
		MSSQLRepo<Product> repoProduct;
		public ProductController(MSSQLRepo<Product> _repoProduct)
		{
			repoProduct = _repoProduct;
		}

		public IActionResult Index()
		{
			return View();
		}

		[Route("/urun/{name}/{id}")]
		public IActionResult Detail(string name, int id)
		{
			Product product = repoProduct.GetAll(g => g.ID == id).Include(i => i.Category).Include(i => i.ProductImages).FirstOrDefault() ?? null;
			
			if (product != null)
			{
				ProductVM productVM = new ProductVM
				{
					Product = product,
					Products = repoProduct.GetAll(g => g.ID != product.ID && g.CategoryID == product.CategoryID).Include(i => i.ProductImages).Take(8).ToList()
				};
				return View(productVM);
			}
			else return RedirectToAction("/");
		}
	}
}
