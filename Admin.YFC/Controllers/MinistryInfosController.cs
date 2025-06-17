using Admin.YFC.Models;
using Admin.YFC.Services;
using Admin.YFC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.YFC.Controllers
{
	public class MinistryInfosController : Controller
	{
		private readonly MinistryInfoServices _ministryInfoServices;
		private readonly MinistryServices _ministryServices;

		public MinistryInfosController(MinistryInfoServices ministryInfoServices,
			MinistryServices ministryServices)
		{
			_ministryInfoServices = ministryInfoServices;
			_ministryServices = ministryServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetMinistryInfos()
		{
			var ministryInfos = await _ministryInfoServices.GetMinistryInfos();
			var ministries = await _ministryServices.GetMinistries();
			List<MinistryInfoViewModel> ministryInfosViewModel = new List<MinistryInfoViewModel>();
			foreach (var ministryInfo in ministryInfos)
			{
				var ministry = ministries.FirstOrDefault(c => c.MinistryId == ministryInfo.MinistryId);
				ministryInfosViewModel.Add(new MinistryInfoViewModel
				{
					MinistryInfoId = ministryInfo.MinistryInfoId,
					MinistryId = ministryInfo.MinistryId,
					Ministry = ministry?.Name, // Map the ministry name explicitly
					Content = ministryInfo.Content
				});
			}
			return Json(new { data = ministryInfosViewModel });
		}

		public async Task<IActionResult> Create()
		{
			var ministries = await _ministryServices.GetMinistries();
			ViewBag.Ministries = new SelectList(ministries, "MinistryId", "Name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("MinistryId,Content")] MinistryInfo ministryInfo)
		{
			if (ModelState.IsValid)
			{
				await _ministryInfoServices.AddMinistryInfo(ministryInfo);
				return RedirectToAction("Index");
			}
			return View(ministryInfo);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var ministryInfo = await _ministryInfoServices.GetMinistryInfoById(id);
			var ministries = await _ministryServices.GetMinistries();
			ViewBag.Ministries = new SelectList(ministries, "MinistryId", "Name", ministryInfo.MinistryId);
			return View(ministryInfo);
		}

		[HttpPost]
		public async Task<IActionResult> Edit([Bind("MinistryInfoId,MinistryId,Content")] MinistryInfo ministryInfo)
		{
			if (ModelState.IsValid)
			{
				await _ministryInfoServices.UpdateMinistryInfo(ministryInfo);
				return RedirectToAction("Index");
			}
			return View(ministryInfo);
		}

		public async Task<IActionResult> Remove(int id)
		{
			var ministryInfo = await _ministryInfoServices.GetMinistryInfoById(id);
			var ministries = await _ministryServices.GetMinistries();
			ViewBag.Ministries = new SelectList(ministries, "MinistryId", "Name", ministryInfo.MinistryId);
			return View(ministryInfo);
		}

		public async Task<IActionResult> Delete([Bind("MinistryInfoId,MinistryId,Content")] MinistryInfo ministryInfo)
		{
			await _ministryInfoServices.DeleteMinistryInfo(ministryInfo.MinistryInfoId);
			return RedirectToAction("Index");
		}
	}
}