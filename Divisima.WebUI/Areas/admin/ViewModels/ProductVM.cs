using Divisima.DAL.Entities;

namespace Divisima.WebUI.Areas.admin.ViewModels
{
	public class ProductVM
	{
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
       

    }
}
