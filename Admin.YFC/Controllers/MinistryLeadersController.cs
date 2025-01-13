using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.YFC.Controllers
{
	public class MinistryLeadersController : Controller
	{
		private readonly MinistryLeaderServices _ministryLeaderServices;
		private readonly MinistryServices _ministryServices;

		public MinistryLeadersController(MinistryLeaderServices ministryLeaderServices,
			MinistryServices ministryServices)
		{
			_ministryLeaderServices = ministryLeaderServices;
			_ministryServices = ministryServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetMinistryLeaders()
		{
			var ministryLeaders = await _ministryLeaderServices.GetMinistryLeaders();
			return Json(new { data = ministryLeaders });
		}

		public async Task<IActionResult> Create()
		{
			var ministries = await _ministryServices.GetMinistries();
			ViewBag.Ministries = new SelectList(ministries, "MinistryId", "Name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(IFormFile file, [Bind("MinistryId,Name,Email")] MinistryLeader ministryLeader)
		{
			if (ModelState.IsValid)
			{
				await _ministryLeaderServices.AddMinistryLeader(ministryLeader);
				return RedirectToAction("Index");
			}
			return View(ministryLeader);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var ministryLeader = await _ministryLeaderServices.GetMinistryLeaderById(id);
			var ministries = await _ministryServices.GetMinistries();
			ViewBag.Ministries = new SelectList(ministries, "MinistryId", "Name", ministryLeader.MinistryId);
			return View(ministryLeader);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(IFormFile file, [Bind("MinistryLeaderId,MinistryId,Name,Email")] MinistryLeader ministryLeader)
		{
			if (ModelState.IsValid)
			{
				await _ministryLeaderServices.UpdateMinistryLeader(ministryLeader);
				return RedirectToAction("Index");
			}
			return View(ministryLeader);
		}

		public async Task<IActionResult> Remove(int id)
		{
			var ministryLeader = await _ministryLeaderServices.GetMinistryLeaderById(id);
			var ministries = await _ministryServices.GetMinistries();
			ViewBag.Ministries = new SelectList(ministries, "MinistryId", "Name", ministryLeader.MinistryId);
			return View(ministryLeader);
		}

		public async Task<IActionResult> Delete([Bind("MinistryLeaderId,MinistryId,Name,Email")] MinistryLeader ministryLeader)
		{
			await _ministryLeaderServices.DeleteMinistryLeader(ministryLeader.MinistryLeaderId);
			return RedirectToAction("Index");
		}
	}
}
