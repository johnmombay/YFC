using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Admin.YFC.Controllers
{
	public class HeadlinesController : Controller
	{
		private readonly HeadlineServices _headlineServices;
		private readonly FileUploadServices _fileUploadServices;

		public HeadlinesController(HeadlineServices headlineServices,
			FileUploadServices fileUploadServices)
		{
			_headlineServices = headlineServices;
			_fileUploadServices = fileUploadServices;
		}
		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetHeadlines()
		{
			var headlines = await _headlineServices.GetHeadlines();
			return Json(new { data = headlines });
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(IFormFile file, [Bind("Title,Subtitle,Description,Picture,Url,Enable")] Headline headline)
		{
			if (ModelState.IsValid)
			{
				if (file != null)
				{
					await _fileUploadServices.Upload(file, "Headlines/" + headline.HeadlineId + "/", file.FileName);
					await _headlineServices.AddHeadline(headline);
					return RedirectToAction("Index");
				}
			}
			return View(headline);
		}

		public async Task<IActionResult> Edit(int id)
		{
			ViewBag.HeadlineId = id;
			var headline = await _headlineServices.GetHeadlineById(id);
			return View(headline);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(IFormFile file, int id, [Bind("HeadlineId,Title,Subtitle,Description,Picture,Url,Enable")] Headline headline)
		{
			if (ModelState.IsValid)
			{
				if (file != null)
				{
					await _fileUploadServices.Upload(file, "Headlines/" + headline.HeadlineId + "/", file.FileName);
				}
				await _headlineServices.UpdateHeadline(headline);
				return RedirectToAction("Index");
			}
			return View(headline);
		}

		public async Task<IActionResult> Remove(int id)
		{
			ViewBag.HeadlineId = id;
			var headline = await _headlineServices.GetHeadlineById(id);
			return View(headline);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var headline = await _headlineServices.GetHeadlineById(id);
			await _fileUploadServices.Remove("Headlines", headline.HeadlineId.ToString(), headline.Picture);
			await _headlineServices.DeleteHeadline(id);
			return RedirectToAction("Index");
		}
	}
}
