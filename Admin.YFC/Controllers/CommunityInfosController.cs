using Admin.YFC.Models;
using Admin.YFC.Services;
using Admin.YFC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.YFC.Controllers
{
	public class CommunityInfosController : Controller
	{
		private readonly CommunityInfoServices _communityInfoServices;
		private readonly CommunityServices _communityServices;

		public CommunityInfosController(CommunityInfoServices communityInfoServices,
			CommunityServices communityServices)
		{
			_communityInfoServices = communityInfoServices;
			_communityServices = communityServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetCommunityInfos()
		{
			var communityInfos = await _communityInfoServices.GetCommunityInfos();
			var communities = await _communityServices.GetCommunities();
			List<CommunityInfoViewModel> communityInfoViewModel = new List<CommunityInfoViewModel>();
			foreach (var communityInfo in communityInfos)
			{
				var community = communities.FirstOrDefault(c => c.CommunityId == communityInfo.CommunityId);
				communityInfoViewModel.Add(new CommunityInfoViewModel
				{
					CommunityInfoId = communityInfo.CommunityInfoId,
					CommunityId = communityInfo.CommunityId,
					Community = community?.Name, // Map the community name explicitly
					Content = communityInfo.Content
				});
			}
			return Json(new { data = communityInfoViewModel });
		}

		public async Task<IActionResult> Create()
		{
			var communities = await _communityServices.GetCommunities();
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("CommunityId,Content")] CommunityInfo communityInfo)
		{
			if (ModelState.IsValid)
			{
				var newCommunityInfo = await _communityInfoServices.AddCommunityInfo(communityInfo);
				if (newCommunityInfo.CommunityInfoId > 0)
				{
					return RedirectToAction("Index");
				}
			}
			return View(communityInfo);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var communityInfo = await _communityInfoServices.GetCommunityInfoById(id);
			var communities = await _communityServices.GetCommunities();
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name", communityInfo.CommunityId);
			return View(communityInfo);
		}

		[HttpPost]
		public async Task<IActionResult> Edit([Bind("CommunityInfoId,CommunityId,Content")] CommunityInfo communityInfo)
		{
			if (ModelState.IsValid)
			{
				var updatedCommunityInfo = await _communityInfoServices.UpdateCommunityInfo(communityInfo);
				if (updatedCommunityInfo.CommunityInfoId > 0)
				{
					return RedirectToAction("Index");
				}
			}
			return View(communityInfo);
		}

		public async Task<IActionResult> Remove(int id)
		{
			var communityInfo = await _communityInfoServices.GetCommunityInfoById(id);
			var communities = await _communityServices.GetCommunities();
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name", communityInfo.CommunityId);
			return View(communityInfo);
		}

		[HttpPost]
		public async Task<IActionResult> Delete([Bind("CommunityInfoId,CommunityId,Content")] CommunityInfo communityInfo)
		{
			var result = await _communityInfoServices.DeleteCommunityInfo(communityInfo.CommunityInfoId);
			return RedirectToAction("Index");
		}

	}
}
