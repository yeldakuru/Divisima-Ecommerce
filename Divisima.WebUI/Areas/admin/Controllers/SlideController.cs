using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Divisima.WebUI.Areas.admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Divisima.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize, Route("/admin/[controller]/[action]/{id?}")]
    public class SlideController : Controller
    {
        MSSQLRepo<Slide> repoSlide;
        private readonly IWebHostEnvironment webHostEnvironment;
        public SlideController(MSSQLRepo<Slide> _repoSlide, IWebHostEnvironment _webHostEnvironment)
        {
            repoSlide = _repoSlide;
            webHostEnvironment = _webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(repoSlide.GetAll().OrderBy(o => o.RecDate));
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(SlideVM model)
        {

            // SlidePath bir /wwwroot/slide oluştur
            string SlidePath = Path.Combine(webHostEnvironment.WebRootPath, "slide");

            // Eğer ki /slide dizini mevcut değilse, bizim için oluştur.
            if (!Directory.Exists(SlidePath)) Directory.CreateDirectory(Path.Combine(SlidePath));

            // Yeni benzersiz bir isim oluştur (6 karakter resim isminin başına ata)
            string filePath = string.Concat(Guid.NewGuid().ToString().AsSpan(0,6), model.Picture.FileName);

            // /wwwroot/slide içinde oluşturulan yeni bir dosya adıyla bir dosya akışı açılır ve serbest bırakılır.
            using (var stream = new FileStream(Path.Combine(webHostEnvironment.WebRootPath, "slide", filePath), FileMode.Create))
            {
                // Yüklenen resim dosyasının akışını kopyala (kaydet).
                model.Picture.CopyTo(stream);
            }

            // Slide klasörüne, yeni eklenen resim yolunun dosyasını ekle
            model.Slide.Picture = "/slide/" + filePath;

            repoSlide.Add(model.Slide);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            SlideVM slideVM = new SlideVM
            {
                Slide = repoSlide.GetBy(g => g.ID == id),
            };
            return View(slideVM);
        }

        public IActionResult Update(SlideVM model)
        {
            if (model.Picture != null)
            {
                string slidePath = Path.Combine(webHostEnvironment.WebRootPath, "slide");
                if (!Directory.Exists(slidePath)) Directory.CreateDirectory(Path.Combine(slidePath));

                string filePath = string.Concat(Guid.NewGuid().ToString().AsSpan(0, 6), model.Picture.FileName);
                using (var stream = new FileStream(Path.Combine(webHostEnvironment.WebRootPath, "slide", filePath), FileMode.Create))
                {
                    model.Picture.CopyTo(stream);
                }
                model.Slide.Picture = "/slide/" + filePath;

                var slide = repoSlide.GetByAsNoTracking(c => c.ID == model.Slide.ID);

                FileInfo fi = new FileInfo(webHostEnvironment.WebRootPath + slide?.Picture ?? string.Empty);
                if (fi.Exists)
                {
                    fi.Delete();
                }
            }

            repoSlide.Update(model.Slide);
            return RedirectToAction("Index");
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }

        public string Delete(int _id)
        {
            string rtn = "";
            Slide Slide = repoSlide.GetBy(g => g.ID == _id) ?? null;
            if (Slide != null)
            {
                repoSlide.Delete(Slide);
                FileInfo fi = new FileInfo(webHostEnvironment.WebRootPath + Slide.Picture ?? string.Empty);
                if (fi.Exists)
                {
                    fi.Delete();
                }
                rtn = "OK";
            }
            return rtn;
        }
    }
}
