using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Admin.YFC.Controllers
{
	public class CommunitiesController : Controller
	{
		private readonly CommunityServices _communityServices;

		public CommunitiesController(CommunityServices communityServices)
		{
			_communityServices = communityServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetCommunities()
		{
			var communities = await _communityServices.GetCommunities();
			return Json(new { data = communities });
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("Name,Enabled")] Community community)
		{
			if (ModelState.IsValid)
			{
				await _communityServices.AddCommunity(community);
				return RedirectToAction("Index");
			}
			return View(community);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var community = await _communityServices.GetCommunityById(id);
			if (community == null)
			{
				return NotFound();
			}
			return View(community);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("CommunityId, Name,Enabled")] Community community)
		{
			if (id != community.CommunityId)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				await _communityServices.UpdateCommunity(community);
				return RedirectToAction("Index");
			}
			return View(community);
		}

		public async Task<IActionResult> Remove(int id)
		{
			var community = await _communityServices.GetCommunityById(id);
			if (community == null)
			{
				return NotFound();
			}
			return View(community);
		}

		public async Task<IActionResult> Delete([Bind("CommunityId, Name,Enabled")] Community community)
		{
			await _communityServices.DeleteCommunity(community.CommunityId);
			return RedirectToAction("Index");
		}
	}
}
