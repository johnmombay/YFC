using Admin.YFC.Models;
using Admin.YFC.Services;
using Admin.YFC.ViewModels;
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
			var communities = await _communityServices.GetCommunities();
			List<CommunityArticleViewModel> communityArticleViewModels = new List<CommunityArticleViewModel>();
			foreach (var communityArticle in communityArticles)
			{
				var community = communities.FirstOrDefault(c => c.CommunityId == communityArticle.CommunityId);
				communityArticleViewModels.Add(new CommunityArticleViewModel
				{
					CommunityArticleId = communityArticle.CommunityArticleId,
					CommunityId = communityArticle.CommunityId,
					Community = community?.Name, // Map the community name explicitly
					Title = communityArticle.Title,
					Content = communityArticle.Content
				});
			}
			return Json(new { data = communityArticleViewModels });
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
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name", communityArticle.CommunityId);
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
			var communities = await _communityServices.GetCommunities();
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name", communityArticle.CommunityId);
			return View(communityArticle);
		}

		public async Task<IActionResult> Delete([Bind("CommunityArticleId,CommunityId,Title,Content")] CommunityArticle communityArticle)
		{
			await _communityArticleServices.DeleteCommunityArticle(communityArticle.CommunityArticleId);
			return RedirectToAction("Index");
		}
	}
}
