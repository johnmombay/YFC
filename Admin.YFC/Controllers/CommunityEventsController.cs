using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.YFC.Controllers
{
	public class CommunityEventsController : Controller
	{
		private readonly CommunityEventServices _communityEventServices;
		private readonly CommunityServices _communityServices;
		private readonly FileUploadServices _fileUploadServices;

		public CommunityEventsController(CommunityEventServices communityEventServices,
			CommunityServices communityServices,
			FileUploadServices fileUploadServices)
		{
			_communityEventServices = communityEventServices;
			_communityServices = communityServices;
			_fileUploadServices = fileUploadServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetCommunityEvents()
		{
			var communityEvents = await _communityEventServices.GetCommunityEvents();
			return View(new { data = communityEvents });
		}

		public async Task<IActionResult> Create()
		{
			var communities = await _communityServices.GetCommunities();
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(IFormFile file, [Bind("CommunityId,Picture,Title,Description,EventDate")] CommunityEvent communityEvent)
		{
			communityEvent.Picture = file.FileName;
			if (file != null)
			{
				var newCommunityEvent = await _communityEventServices.AddCommunityEvent(communityEvent);
				if (newCommunityEvent.CommunityEventId > 0)
				{
					await _fileUploadServices.Upload(file, "CommunityEvents/" + newCommunityEvent.CommunityEventId + "/", file.FileName);
					return RedirectToAction("Index");
				}
			}
			return View(communityEvent);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var communityEvent = await _communityEventServices.GetCommunityEventById(id);
			var communities = await _communityServices.GetCommunities();
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name",communityEvent.CommunityId);
			return View(communityEvent);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, IFormFile file, [Bind("CommunityEventId,CommunityId,Picture,Title,Description,EventDate")] CommunityEvent communityEvent)
		{
			if (file != null)
			{
				await _fileUploadServices.Upload(file, "CommunityEvents/" + communityEvent.CommunityEventId + "/", file.FileName);
				await _fileUploadServices.Remove("CommunityEvents", communityEvent.CommunityEventId.ToString(), communityEvent.Picture);
			}
			await _communityEventServices.UpdateCommunityEvent(communityEvent);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Remove(int id)
		{
			var communityEvent = await _communityEventServices.GetCommunityEventById(id);
			return View(communityEvent);
		}

		public async Task<IActionResult> Delete([Bind("CommunityEventId,CommunityId,Picture,Title,Description,EventDate")] CommunityEvent communityEvent)
		{
			await _fileUploadServices.Remove("CommunityEvents", communityEvent.CommunityEventId.ToString(), communityEvent.Picture);
			await _communityEventServices.DeleteCommunityEvent(communityEvent.CommunityEventId);
			return RedirectToAction("Index");
		}

	}
}
