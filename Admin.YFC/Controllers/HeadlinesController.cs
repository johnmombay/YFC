using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Admin.YFC.Controllers
{
	public class HeadlinesController : Controller
	{
		private readonly HeadlineServices _headlineServices;

		public HeadlinesController(HeadlineServices headlineServices)
		{
			_headlineServices = headlineServices;
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

		public async Task<IActionResult> Create([Bind("Title,Subtitle,Description,Url,Enable")] Headline headline)
		{
			if (ModelState.IsValid)
			{
				await _headlineServices.AddHeadline(headline);
				return RedirectToAction("Index");
			}
			return View(headline);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var headline = await _headlineServices.GetHeadlineById(id);
			return View(headline);
		}

		public async Task<IActionResult> Edit(int id, [Bind("HeadlineId,Title,Subtitle,Description,Url,Enable")] Headline headline)
		{
			if (ModelState.IsValid)
			{
				await _headlineServices.UpdateHeadline(headline);
				return RedirectToAction("Index");
			}
			return View(headline);
		}

		public async Task<IActionResult> Remove(int id)
		{
			var headline = await _headlineServices.GetHeadlineById(id);
			return View(headline);
		}

		public async Task<IActionResult> Delete(int id)
		{
			await _headlineServices.DeleteHeadline(id);
			return RedirectToAction("Index");
		}
	}
}
