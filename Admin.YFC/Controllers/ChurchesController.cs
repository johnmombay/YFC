using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Admin.YFC.Controllers
{
	public class ChurchesController : Controller
	{
		private readonly ChurchServices _churchServices;
		private readonly FileUploadServices _fileUploadServices;

		public ChurchesController(ChurchServices churchServices,
			FileUploadServices fileUploadServices)
		{
			_churchServices = churchServices;
			_fileUploadServices = fileUploadServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetChurches()
		{
			var churches = await _churchServices.GetChurches();
			return Json(new { data = churches });
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(IFormFile file, [Bind("Title,Picture,,Description, URL")] Church Church)
		{
			Church.Picture = file.FileName;
			if (file != null)
			{
				var newChurch = await _churchServices.AddChurch(Church);
				if (newChurch.ChurchId > 0)
				{
					await _fileUploadServices.Upload(file, "Churches/" + newChurch.ChurchId + "/", file.FileName);
					return RedirectToAction("Index");
				}
			}
			return View(Church);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var Church = await _churchServices.GetChurchById(id);
			return View(Church);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(IFormFile file, int id, [Bind("ChurchId,Picture,,Title,Description,URL")] Church Church)
		{
			if (file != null)
			{
				await _fileUploadServices.Upload(file, "Churches/" + Church.ChurchId + "/", file.FileName);
				await _fileUploadServices.Remove("Churches", Church.ChurchId.ToString(), Church.Picture);
				Church.Picture = file.FileName;
			}
			await _churchServices.UpdateChurch(Church);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Remove(int id)
		{
			var Church = await _churchServices.GetChurchById(id);
			return View(Church);
		}

		public async Task<IActionResult> Delete([Bind("ChurchId,Picture,Title,Description,URL")] Church Church)
		{
			await _fileUploadServices.Remove("Churches", Church.ChurchId.ToString(), Church.Picture);
			await _churchServices.DeleteChurch(Church.ChurchId);
			return RedirectToAction("Index");
		}
	}
}
