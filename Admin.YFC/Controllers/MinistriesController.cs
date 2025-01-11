using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Admin.YFC.Controllers
{
	public class MinistriesController : Controller
	{
		private readonly MinistryServices _ministryServices;

		public MinistriesController(MinistryServices ministryServices)
		{
			_ministryServices = ministryServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetMinistries()
		{
			var ministries = await _ministryServices.GetMinistries();
			return Json(new { data = ministries });
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("Name,Enabled")] Ministry ministry)
		{
			if (ModelState.IsValid)
			{
				await _ministryServices.AddMinistry(ministry);
				return RedirectToAction("Index");
			}
			return View(ministry);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var ministry = await _ministryServices.GetMinistryById(id);
			if (ministry == null)
			{
				return NotFound();
			}
			return View(ministry);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("MinistryId,Name,Enabled")] Ministry ministry)
		{
			if (id != ministry.MinistryId)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				await _ministryServices.UpdateMinistry(ministry);
				return RedirectToAction("Index");
			}
			return View(ministry);
		}

		public async Task<IActionResult> Remove(int id)
		{
			var ministry = await _ministryServices.GetMinistryById(id);
			if (ministry == null)
			{
				return NotFound();
			}
			return View(ministry);
		}

		public async Task<IActionResult> Delete([Bind("MinistryId,Name,Enabled")] Ministry ministry)
		{
			await _ministryServices.DeleteMinistry(ministry.MinistryId);
			return RedirectToAction("Index");
		}

	}
}
