using Admin.YFC.Models;
using Admin.YFC.Services;
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
			return Json(new { data = communityInfos });
		}

		public async Task<IActionResult> Create()
		{
			var communities = await _communityServices.GetCommunities();
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("CommunityId,About,Leaders,News,Calendar")] CommunityInfo communityInfo)
		{
			if (ModelState.IsValid)
			{
				await _communityInfoServices.AddCommunityInfo(communityInfo);
				return RedirectToAction("Index");
			}
			return View(communityInfo);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var communityInfo = await _communityInfoServices.GetCommunityInfoById(id);
			if (communityInfo == null)
			{
				return NotFound();
			}
			var communities = await _communityServices.GetCommunities();
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name",communityInfo.CommunityId);
			return View(communityInfo);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("CommunityInfoId,CommunityId,About,Leaders,News,Calendar")] CommunityInfo communityInfo)
		{
			if (id != communityInfo.CommunityInfoId)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				await _communityInfoServices.UpdateCommunityInfo(communityInfo);
				return RedirectToAction("Index");
			}
			return View(communityInfo);
		}

		public async Task<IActionResult> Remove(int id)
		{
			var communityInfo = await _communityInfoServices.GetCommunityInfoById(id);
			if (communityInfo == null)
			{
				return NotFound();
			}
			var communities = await _communityServices.GetCommunities();
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name", communityInfo.CommunityId);
			return View(communityInfo);
		}

		public async Task<IActionResult> Delete([Bind("CommunityInfoId,CommunityId,About,Leaders,News,Calendar")] CommunityInfo communityInfo)
		{
			await _communityInfoServices.DeleteCommunityInfo(communityInfo.CommunityInfoId);
			return RedirectToAction("Index");
		}
	}
}
