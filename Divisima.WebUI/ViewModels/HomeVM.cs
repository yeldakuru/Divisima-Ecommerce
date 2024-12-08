using Divisima.DAL.Entities;

namespace Divisima.WebUI.ViewModels
{
	public class HomeVM
	{
        public IEnumerable<Slide> Slides { get; set; }
        public IEnumerable<Product> LastProducts { get; set; }
        public IEnumerable<Product> SalesProducts { get; set; }
	}
}
