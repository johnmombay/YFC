using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.YFC.Controllers
{
	public class CommunityAlbumController : Controller
	{
		private readonly CommunityAlbumServices _communityAlbumServices;
		private readonly CommunityServices _communityServices;

		public CommunityAlbumController(CommunityAlbumServices communityAlbumServices,
			CommunityServices communityServices)
		{
			_communityAlbumServices = communityAlbumServices;
			_communityServices = communityServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> Create()
		{
			var communities = await _communityServices.GetCommunities();
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("AlbumId,CommunityId")] CommunityAlbum album)
		{
			if (ModelState.IsValid)
			{
				var newAlbum = await _communityAlbumServices.AddCommunityAlbum(album);
				var communities = await _communityServices.GetCommunities();
				ViewBag.Communities = new SelectList(communities, "CommunityId", "Name");
				if (newAlbum.CommunityAlbumId > 0)
				{
					return RedirectToAction("Index");
				}
			}
			return View(album);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var album = await _communityAlbumServices.GetCommunityAlbumById(id);
			var communities = await _communityServices.GetCommunities();
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name");
			if (album == null)
			{
				return NotFound();
			}
			return View(album);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("CommunityAlbumId,AlbumId,CommunityId")] CommunityAlbum album)
		{
			if (id != album.CommunityAlbumId)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				var updatedAlbum = await _communityAlbumServices.UpdateCommunityAlbum(album);
				var communities = await _communityServices.GetCommunities();
				ViewBag.Communities = new SelectList(communities, "CommunityId", "Name");
				if (updatedAlbum.CommunityAlbumId > 0)
				{
					return RedirectToAction("Index");
				}
			}
			return View(album);
		}

		public async Task<IActionResult> Remove(int id)
		{
			var album = await _communityAlbumServices.GetCommunityAlbumById(id);
			var communities = await _communityServices.GetCommunities();
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name");
			if (album == null)
			{
				return NotFound();
			}
			return View(album);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed([Bind("CommunityAlbumId,AlbumId,CommunityId")] CommunityAlbum communityalbum)
		{
			var album = await _communityAlbumServices.GetCommunityAlbumById(communityalbum.CommunityAlbumId);
			var communities = await _communityServices.GetCommunities();
			ViewBag.Communities = new SelectList(communities, "CommunityId", "Name");
			if (album == null)
			{
				return NotFound();
			}
			await _communityAlbumServices.DeleteCommunityAlbum(communityalbum.CommunityAlbumId);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> GetCommunityAlbums()
		{
			var albums = await _communityAlbumServices.GetCommunityAlbums();
			return Json(new { data = albums });
		}
	}
}
