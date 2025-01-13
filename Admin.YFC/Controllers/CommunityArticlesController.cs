using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.YFC.Controllers
{
	public class CommunityArticlesController : Controller
	{
		private readonly CommunityArticleServices _communityArticleServices;
		private readonly CommunityServices _communityServices;

		public CommunityArticlesController(CommunityArticleServices communityArticleServices,
			CommunityServices communityServices)
		{
			_communityArticleServices = communityArticleServices;
			_communityServices = communityServices;
		}
		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetCommunityArticles()
		{
			var communityArticles = await _communityArticleServices.GetCommunityArticles();
			return View(new { data = communityArticles });
		}

		public async Task<IActionResult> Create()
		{
			var communities = await _communityServices.GetCommunities();
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("CommunityId,Title,Content")] CommunityArticle communityArticle)
		{
			if (ModelState.IsValid)
			{
				await _communityArticleServices.AddCommunityArticle(communityArticle);
				return RedirectToAction("Index");
			}
			return View(communityArticle);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var communityArticle = await _communityArticleServices.GetCommunityArticleById(id);
			var communities = await _communityServices.GetCommunities();
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name",communityArticle.CommunityId);
			return View(communityArticle);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("CommunityArticleId,CommunityId,Title,Content")] CommunityArticle communityArticle)
		{
			if (id != communityArticle.CommunityArticleId)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				await _communityArticleServices.UpdateCommunityArticle(communityArticle);
				return RedirectToAction("Index");
			}
			return View(communityArticle);
		}

		public async Task<IActionResult> Remove(int id)
		{
			var communityArticle = await _communityArticleServices.GetCommunityArticleById(id);
			return View(communityArticle);
		}

		public async Task<IActionResult> Delete(int id)
		{
			await _communityArticleServices.DeleteCommunityArticle(id);
			return RedirectToAction("Index");
		}
	}
