using Divisima.BL.Repositories;
using Divisima.DAL.Entities;
using Divisima.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Divisima.WebUI.ViewComponents
{
	public class FooterViewComponent : ViewComponent
	{
		MSSQLRepo<SiteInfo> repoSiteInfo;
        public FooterViewComponent(MSSQLRepo<SiteInfo> _repoSiteInfo)
        {
            repoSiteInfo = _repoSiteInfo;
        } 
        public IViewComponentResult Invoke()
		{
			FooterVM footerVM = new FooterVM
			{
				SocialInfo = repoSiteInfo.GetBy(x => x.ESiteInfo == ESiteInfo.Sosyal),
				MetaInfo = repoSiteInfo.GetBy(x => x.ESiteInfo == ESiteInfo.Meta),
				ContactInfo = repoSiteInfo.GetBy(x => x.ESiteInfo == ESiteInfo.Contact),
            };
			return View(footerVM);
		}
	}
}
