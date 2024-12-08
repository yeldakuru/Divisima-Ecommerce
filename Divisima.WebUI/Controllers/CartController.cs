using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Divisima.WebUI.Models;
using Divisima.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Divisima.WebUI.Controllers
{
	public class CartController : Controller
	{
		MSSQLRepo<Product> repoProduct;
        public CartController(MSSQLRepo<Product> _repoProduct)
        {
            repoProduct = _repoProduct;
        }

		[Route("/sepetim/")]
		public IActionResult Index()
		{
			// SepetCookie'nin varlığını kontrol et
			var cartCookie = Request.Cookies["SepetCookie"];
			List<Cart> cartList = new List<Cart>();

			if (cartCookie != null)
			{
				try
				{
					// Çerezi deserialize ederken null değer dönerse boş liste olarak ata
					cartList = JsonConvert.DeserializeObject<List<Cart>>(cartCookie) ?? new List<Cart>();
				}
				catch (JsonException)
				{
					// JSON deserialization hatası durumunda boş bir liste döndür
					cartList = new List<Cart>();
				}
			}

			CartVM cartVM = new CartVM
			{
				Carts = cartList,
				Products = repoProduct.GetAll().Include(i => i.ProductImages).OrderBy(o => Guid.NewGuid()).Take(4),
			};
			return View(cartVM);
		}

		public string AddProduct(int _productID, int _quantity)
		{
			// 1. AŞAMA: URUNLERI GETIR
			Product product = repoProduct.GetAll(g => g.ID == _productID).Include(i => i.ProductImages).FirstOrDefault() ?? null;

			// 2. AŞAMA: GELEN URUNLERI CART LISTESIYLE ESLESTIRMEK ICIN BIR CART MODELI OLUSTURDUK 
			// 2. AŞAMA: ARDINDAN DATABASE'DEN GELEN URUNLERLE EŞLESECEK COOKIE'NIN MODELINI OLUSTURDUK
			List<Cart> carts;
			string firtstPicture = product.ProductImages.FirstOrDefault().Path;
			if (string.IsNullOrEmpty(firtstPicture)) { firtstPicture = "/product/nopicture.jpg"; };

			Cart cart = new Cart
			{
				ProductID = product.ID,
				ProductName = product.Name,
				ProductPrice = Convert.ToDecimal(product.Price),
				Quantity = _quantity,
				ProductPicture = firtstPicture,
			};

			// EGER URUN BILGILERI BOS DEGILSE BUNU UYGULA
			if (product != null)
			{
				// 3. AŞAMA: SITEDE DAHA ONCE BIR COOKIE YOKSA YENI OLUSTUR
				if (Request.Cookies["SepetCookie"] == null)
				{
					carts = new List<Cart>();
					carts.Add(cart);
				}

				// 5. AŞAMA: EGER SITEDE DAHA ONCE COOKIE VARSA VEYA YENI OLUSTURULDU ISE BURAYI UYGULA
				else
				{
					// OLUSTURULAN CART LISTESINI JSON FORMATINDA SITEDE TUTULMASI ICIN COOKIE'YE EKLE
					carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["SepetCookie"]);

					// DAHA ONCE COOKI'YE EKLENEN URUNUN MIKTARINI GUNCELLE
					bool varmi = false;
					foreach (Cart c in carts)
					{
						if (c.ProductID == _productID)
						{
							c.Quantity = _quantity;
							varmi = true;
						}
					}
					if (varmi == false) carts.Add(cart);
				}

				// 4. AŞAMA: COOKIE SURESINI BELIRLE
				CookieOptions cookieOptions = new CookieOptions(); //! BİR COOKIE OLURTUR 
				cookieOptions.Expires = DateTime.Now.AddDays(1);  //! COOKIE'NIN SURESI 1 GUNLUK OLSUN
																  //! CART LISTESINI COOKIEYE EKLE
				Response.Cookies.Append("SepetCookie", JsonConvert.SerializeObject(carts), cookieOptions);
				return product.Name; //! ICERIGINE GELEN URUNUN ISMINI YAZDIR
			}
			else return "";
		}

		// 6. AŞAMA: SEPETENE EKLENEN SAYIYI BELIRLE
		public int GetProductCount()
		{
			//! EGER COOKIE BOSSA GERIYE 0 MIKTAR DONDUR
			if (Request.Cookies["SepetCookie"] == null) return 0;

			//! BOS DEGILSE GERIYE CART ICINDEKI MIKTARI DONDURSUN
			else
			{
				List<Cart> carts = JsonConvert.DeserializeObject<List<Cart>>(Request.Cookies["SepetCookie"]);
				return carts.Sum(s => s.Quantity);
			}
		}
	}
}
