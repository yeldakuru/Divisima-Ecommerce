using Divisima.DAL.Entities;

namespace Divisima.WebUI.Areas.admin.ViewModels
{
    public class SlideVM
    {
        public Slide Slide { get; set; }
        public IFormFile Picture { get; set; }
    }
}
