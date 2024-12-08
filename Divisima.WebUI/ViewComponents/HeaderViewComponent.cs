using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Divisima.WebUI.ViewComponents
{
	public class HeaderViewComponent: ViewComponent
	{
		MSSQLRepo<Category> repoCategory;
        public HeaderViewComponent(MSSQLRepo<Category> _repoCategory)
        {
            repoCategory = _repoCategory;
        }

        public IViewComponentResult Invoke()
		{			
			return View(repoCategory.GetAll().OrderBy(o => o.DisplayIndex));
		}
	}
}
