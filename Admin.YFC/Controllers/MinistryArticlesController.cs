using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.YFC.Controllers
{
	public class MinistryArticlesController : Controller
	{
		private readonly MinistryArticleServices _ministryArticleServices;
		private readonly MinistryServices _ministryServices;

		public MinistryArticlesController(MinistryArticleServices ministryArticleServices,
			MinistryServices ministryServices)
		{
			_ministryArticleServices = ministryArticleServices;
			_ministryServices = ministryServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetMinistryArticles()
		{
			var ministryArticles = await _ministryArticleServices.GetMinistryArticles();
			return Json(new { data = ministryArticles });
		}

		public async Task<IActionResult> Create()
		{
			var ministries = await _ministryServices.GetMinistries();
			ViewBag.Ministries = new SelectList(ministries, "MinistryId", "Name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("MinistryId,Title,Content")] MinistryArticle ministryArticle)
		{
			if (ModelState.IsValid)
			{
				await _ministryArticleServices.AddMinistryArticle(ministryArticle);
				return RedirectToAction("Index");
			}
			return View(ministryArticle);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var ministryArticle = await _ministryArticleServices.GetMinistryArticleById(id);
			var ministries = await _ministryServices.GetMinistries();
			ViewBag.Ministries = new SelectList(ministries, "MinistryId", "Name",ministryArticle.MinistryId);
			return View(ministryArticle);
		}

		[HttpPost]
		public async Task<IActionResult> Edit([Bind("MinistryArticleId,MinistryId,Title,Content")] MinistryArticle ministryArticle)
		{
			if (ModelState.IsValid)
			{
				await _ministryArticleServices.UpdateMinistryArticle(ministryArticle);
				return RedirectToAction("Index");
			}
			return View(ministryArticle);
		}

		public async Task<IActionResult> Remove(int id)
		{
			var ministryArticle = await _ministryArticleServices.GetMinistryArticleById(id);
			var ministries = await _ministryServices.GetMinistries();
			ViewBag.Ministries = new SelectList(ministries, "MinistryId", "Name", ministryArticle.MinistryId);
			return View(ministryArticle);
		}

		[HttpPost]
		public async Task<IActionResult> Delete([Bind("MinistryArticleId,MinistryId,Title,Content")] MinistryArticle ministryArticle)
		{
			await _ministryArticleServices.DeleteMinistryArticle(ministryArticle.MinistryArticleId);
			return RedirectToAction("Index");
		}
	}
}
