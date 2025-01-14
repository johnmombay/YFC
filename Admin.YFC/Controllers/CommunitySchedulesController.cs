using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.YFC.Controllers
{
	public class CommunitySchedulesController : Controller
	{
		private readonly CommunityScheduleServices _communityScheduleServices;
		private readonly CommunityServices _communityServices;

		public CommunitySchedulesController(CommunityScheduleServices communityScheduleServices,
			CommunityServices communityServices)
		{
			_communityScheduleServices = communityScheduleServices;
			_communityServices = communityServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetCommunitySchedules()
		{
			var communitySchedules = await _communityScheduleServices.GetCommunitySchedules();
			return Json(new { data = communitySchedules });
		}

		public async Task<IActionResult> Create()
		{
			var communities = await _communityServices.GetCommunities();
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name");
			ViewBag.Days = new SelectList(new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("CommunityId,Title,Description,Day,Time")] CommunitySchedule communitySchedule)
		{
			if (ModelState.IsValid)
			{
				var newCommunitySchedule = await _communityScheduleServices.AddCommunitySchedule(communitySchedule);
				if (newCommunitySchedule.CommunityScheduleId > 0)
				{
					return RedirectToAction("Index");
				}
			}
			return View(communitySchedule);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var communitySchedule = await _communityScheduleServices.GetCommunityScheduleById(id);
			var communities = await _communityServices.GetCommunities();
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name", communitySchedule.CommunityId);
			ViewBag.Days = new SelectList(new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" },communitySchedule.Day);
			return View(communitySchedule);
		}

		[HttpPost]
		public async Task<IActionResult> Edit([Bind("CommunityScheduleId,CommunityId,Title,Description,Day,Time")] CommunitySchedule communitySchedule)
		{
			if (ModelState.IsValid)
			{
				var newCommunitySchedule = await _communityScheduleServices.UpdateCommunitySchedule(communitySchedule);
				if (newCommunitySchedule.CommunityScheduleId > 0)
				{
					return RedirectToAction("Index");
				}
			}
			return View(communitySchedule);
		}

		public async Task<IActionResult> Remove(int id)
		{
			var communitySchedule = await _communityScheduleServices.GetCommunityScheduleById(id);
			var communities = await _communityServices.GetCommunities();
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name", communitySchedule.CommunityId);
			ViewBag.Days = new SelectList(new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" }, communitySchedule.Day);
			return View(communitySchedule);
		}


		public async Task<IActionResult> Delete([Bind("CommunityScheduleId,CommunityId,Title,Description,Day,Time")] CommunitySchedule communitySchedule)
		{
			var result = await _communityScheduleServices.DeleteCommunitySchedule(communitySchedule.CommunityScheduleId);
			return RedirectToAction("Index");
		}
	}
}