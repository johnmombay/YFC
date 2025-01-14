using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.YFC.Controllers
{
	public class CommunityLeadersController : Controller
	{
		private readonly CommunityServices _communityServices;
		private readonly CommunityLeaderServices _communityLeaderServices;

		public CommunityLeadersController(CommunityLeaderServices communityLeaderServices,
			CommunityServices communityServices)
		{
			_communityServices = communityServices;
			_communityLeaderServices = communityLeaderServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetCommunityLeaders()
		{
			var communityLeaders = await _communityLeaderServices.GetCommunityLeaders();
			return Json(new { data = communityLeaders });
		}

		public async Task<IActionResult> Create()
		{
			var communities = await _communityServices.GetCommunities();
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("CommunityId,Name,Email")] CommunityLeader communityLeader)
		{
			if (ModelState.IsValid)
			{
				var newCommunityLeader = await _communityLeaderServices.AddCommunityLeader(communityLeader);
				if (newCommunityLeader.CommunityLeaderId > 0)
				{
					return RedirectToAction("Index");
				}
			}
			return View(communityLeader);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var communityLeader = await _communityLeaderServices.GetCommunityLeaderById(id);
			var communities = await _communityServices.GetCommunities();
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name", communityLeader.CommunityId);
			return View(communityLeader);
		}

		[HttpPost]
		public async Task<IActionResult> Edit([Bind("CommunityLeaderId,CommunityId,Name,Email")] CommunityLeader communityLeader)
		{
			if (ModelState.IsValid)
			{
				var updatedCommunityLeader = await _communityLeaderServices.UpdateCommunityLeader(communityLeader);
				if (updatedCommunityLeader.CommunityLeaderId > 0)
				{
					return RedirectToAction("Index");
				}
			}
			return View(communityLeader);
		}

		public async Task<IActionResult> Remove(int id)
		{
			var communityLeader = await _communityLeaderServices.GetCommunityLeaderById(id);
			var communities = await _communityServices.GetCommunities();
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name", communityLeader.CommunityId);
			return View(communityLeader);
		}

		public async Task<IActionResult> Delete([Bind("CommunityLeaderId,CommunityId,Name,Email")] CommunityLeader communityLeader)
		{
			var result = await _communityLeaderServices.DeleteCommunityLeader(communityLeader.CommunityLeaderId);
			return RedirectToAction("Index");
		}
	}
}