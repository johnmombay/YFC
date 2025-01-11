using Microsoft.AspNetCore.Mvc;
using Web.YFC.Services;

namespace Web.YFC.Components
{
	public class MinistryComponent : ViewComponent
	{
		private readonly MinistryServices _ministryServices;

		public MinistryComponent(MinistryServices ministryServices)
		{
			_ministryServices = ministryServices;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var ministries = await _ministryServices.GetMinistries();
			return View(ministries);
		}
	}
}
