using Admin.YFC.Models;
using Admin.YFC.Services;
using Admin.YFC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.YFC.Controllers
{
	public class MinistrySchedulesController : Controller
	{
		private readonly MinistryScheduleServices _ministryScheduleServices;
		private readonly MinistryServices _ministryServices;

		public MinistrySchedulesController(MinistryScheduleServices ministryScheduleServices,
			MinistryServices ministryServices)
		{
			_ministryScheduleServices = ministryScheduleServices;
			_ministryServices = ministryServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetMinistrySchedules()
		{
			var ministrySchedules = await _ministryScheduleServices.GetMinistrySchedules();
			var ministries = await _ministryServices.GetMinistries();
			List<MinistryScheduleViewModel> ministrySchedulesViewModel = new List<MinistryScheduleViewModel>();
			foreach (var ministrySchedule in ministrySchedules)
			{
				var ministry = ministries.FirstOrDefault(c => c.MinistryId == ministrySchedule.MinistryId);
				ministrySchedulesViewModel.Add(new MinistryScheduleViewModel
				{
					MinistryScheduleId = ministrySchedule.MinistryScheduleId,
					MinistryId = ministrySchedule.MinistryId,
					Ministry = ministry?.Name, // Map the ministry name explicitly
					Title = ministrySchedule.Title,
					Description = ministrySchedule.Description,
					Day = ministrySchedule.Day,
					Time = ministrySchedule.Time
				});
			}
			return Json(new { data = ministrySchedulesViewModel });
		}

		public async Task<IActionResult> Create()
		{
			var ministries = await _ministryServices.GetMinistries();
			ViewBag.Ministries = new SelectList(ministries, "MinistryId", "Name");
			ViewBag.Days = new SelectList(new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("MinistryId,Title,Description,Day,Time")] MinistrySchedule ministrySchedule)
		{
			if (ModelState.IsValid)
			{
				await _ministryScheduleServices.AddMinistrySchedule(ministrySchedule);
				return RedirectToAction("Index");
			}
			return View(ministrySchedule);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var ministrySchedule = await _ministryScheduleServices.GetMinistryScheduleById(id);
			var ministries = await _ministryServices.GetMinistries();
			ViewBag.Ministries = new SelectList(ministries, "MinistryId", "Name", ministrySchedule.MinistryId);
			ViewBag.Days = new SelectList(new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" }, ministrySchedule.Day);
			return View(ministrySchedule);
		}

		[HttpPost]
		public async Task<IActionResult> Edit([Bind("MinistryScheduleId,MinistryId,Title,Description,Day,Time")] MinistrySchedule ministrySchedule)
		{
			if (ModelState.IsValid)
			{
				await _ministryScheduleServices.UpdateMinistrySchedule(ministrySchedule);
				return RedirectToAction("Index");
			}
			return View(ministrySchedule);
		}

		public async Task<IActionResult> Remove(int id)
		{
			var ministrySchedule = await _ministryScheduleServices.GetMinistryScheduleById(id);
			var ministries = await _ministryServices.GetMinistries();
			ViewBag.Ministries = new SelectList(ministries, "MinistryId", "Name", ministrySchedule.MinistryId);
			ViewBag.Days = new SelectList(new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" }, ministrySchedule.Day);
			return View(ministrySchedule);
		}

		[HttpPost]
		public async Task<IActionResult> Delete([Bind("MinistryScheduleId,MinistryId,Title,Description,Day,Time")] MinistrySchedule ministrySchedule)
		{
			await _ministryScheduleServices.DeleteMinistrySchedule(ministrySchedule.MinistryScheduleId);
			return RedirectToAction("Index");
		}
	}
}
