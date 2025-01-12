using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.YFC.Common;
using Web.YFC.Models;
using Web.YFC.Services;

namespace Web.YFC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly HeadlineServices _headlineServices;
		private readonly TeachingServices _teachingServices;
		private readonly EventServices _eventServices;

		public HomeController(ILogger<HomeController> logger,
			HeadlineServices headlineServices,
			TeachingServices teachingServices,
			EventServices eventServices)
		{
			_logger = logger;
			_headlineServices = headlineServices;
			_teachingServices = teachingServices;
			_eventServices = eventServices;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.ImageUrl = AppSettings.ImageUrl;
			ViewData["Headlines"] = await _headlineServices.GetHeadlines();
			ViewData["Teachings"] = await _teachingServices.GetTeachings();
			ViewData["Events"] = await _eventServices.GetEvents();

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
