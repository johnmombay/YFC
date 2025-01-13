using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.YFC.Controllers
{
	public class MinistryEventsController : Controller
	{
		private readonly MinistryEventServices _ministryEventServices;
		private readonly MinistryServices _ministryServices;
		private readonly FileUploadServices _fileUploadServices;

		public MinistryEventsController(MinistryEventServices ministryEventServices,
			MinistryServices ministryServices,
			FileUploadServices fileUploadServices)
		{
			_ministryEventServices = ministryEventServices;
			_ministryServices = ministryServices;
			_fileUploadServices = fileUploadServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetMinistryEvents()
		{
			var ministryEvents = await _ministryEventServices.GetMinistryEvents();
			return Json(new { data = ministryEvents });
		}

		public async Task<IActionResult> Create()
		{
			var ministries = await _ministryServices.GetMinistries();
			ViewBag.Ministries = new SelectList(ministries, "MinistryId", "Name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(IFormFile file, [Bind("MinistryId,Picture,Title,Description,EventDate")] MinistryEvent ministryEvent)
		{
			ministryEvent.Picture = file.FileName;
			if (file != null)
			{
				var newMinistryEvent = await _ministryEventServices.AddMinistryEvent(ministryEvent);
				if (newMinistryEvent.MinistryEventId > 0)
				{
					await _fileUploadServices.Upload(file, "MinistryEvents/" + newMinistryEvent.MinistryEventId + "/", file.FileName);
					return RedirectToAction("Index");
				}
			}
			return View(ministryEvent);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var ministryEvent = await _ministryEventServices.GetMinistryEventById(id);
			var ministries = await _ministryServices.GetMinistries();
			ViewBag.Ministries = new SelectList(ministries, "MinistryId", "Name", ministryEvent.MinistryId);
			return View(ministryEvent);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(IFormFile file, [Bind("MinistryEventId,MinistryId,Picture,Title,Description,EventDate")] MinistryEvent ministryEvent)
		{
			if (file != null)
			{
				await _fileUploadServices.Upload(file, "MinistryEvents/" + ministryEvent.MinistryEventId + "/", file.FileName);
				await _fileUploadServices.Remove("MinistryEvents", ministryEvent.MinistryEventId.ToString(), ministryEvent.Picture);
			}
			await _ministryEventServices.UpdateMinistryEvent(ministryEvent);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Remove(int id)
		{
			var ministryEvent = await _ministryEventServices.GetMinistryEventById(id);
			var ministries = await _ministryServices.GetMinistries();
			ViewBag.Ministries = new SelectList(ministries, "MinistryId", "Name", ministryEvent.MinistryId);
			return View(ministryEvent);
		}

		[HttpPost]
		public async Task<IActionResult> Delete([Bind("MinistryEventId,MinistryId,Picture,Title,Description,EventDate")] MinistryEvent ministryEvent)
		{
			await _fileUploadServices.Remove("MinistryEvents", ministryEvent.MinistryEventId.ToString(), ministryEvent.Picture);
			await _ministryEventServices.DeleteMinistryEvent(ministryEvent.MinistryEventId);
			return RedirectToAction("Index");
		}

	}
}
