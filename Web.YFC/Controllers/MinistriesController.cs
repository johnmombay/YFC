using Microsoft.AspNetCore.Mvc;
using Web.YFC.Services;

namespace Web.YFC.Controllers
{
	public class MinistriesController : Controller
	{
		private readonly MinistryInfoServices _ministryInfoServices;

		public MinistriesController(MinistryInfoServices ministryInfoServices)
		{
			_ministryInfoServices = ministryInfoServices;
		}

		public async Task<IActionResult> Index(int id)
		{
			var ministry = await _ministryInfoServices.GetMinistryInfoByMinistryId(id);
			return View();
		}
	}
}
