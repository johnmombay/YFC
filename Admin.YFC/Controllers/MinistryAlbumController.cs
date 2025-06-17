using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.YFC.Controllers
{
	public class MinistryAlbumController : Controller
	{
		private readonly MinistryAlbumServices _ministryAlbumServices;
		private readonly MinistryServices _ministryServices;

		public MinistryAlbumController(MinistryAlbumServices ministryAlbumServices,
			MinistryServices ministryServices)
		{
			_ministryAlbumServices = ministryAlbumServices;
			_ministryServices = ministryServices;
		}
		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> Create()
		{
			var ministries = await _ministryServices.GetMinistries();
			ViewBag.Ministries = new SelectList(ministries, "MinistryId", "Name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind()] MinistryAlbum album)
		{
			if(ModelState.IsValid)
			{
				var newAlbum = await _ministryAlbumServices.AddMinistryAlbum(album);
				var ministries = await _ministryServices.GetMinistries();
				ViewBag.Ministries = new SelectList(ministries, "MinistryId", "Name");
				if (newAlbum.MinistryAlbumId > 0)
				{
					return RedirectToAction("Index");
				}
				return RedirectToAction("Index");
			}
			return View(album);
		} 

		public async Task<IActionResult> Edit(int id)
		{
			var album = await _ministryAlbumServices.GetMinistryAlbumById(id);
			var ministries = await _ministryServices.GetMinistries();
			ViewBag.Ministries = new SelectList(ministries, "MinistryId", "Name");
			if (album == null)
			{
				return NotFound();
			}
			return View(album);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("MinistryAlbumId,AlbumId,MinistryId")] MinistryAlbum album)
		{
			if (id != album.MinistryAlbumId)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				var updatedAlbum = await _ministryAlbumServices.UpdateMinistryAlbum(album);
				var ministries = await _ministryServices.GetMinistries();
				ViewBag.Ministries = new SelectList(ministries, "MinistryId", "Name");
				if (updatedAlbum.MinistryAlbumId > 0)
				{
					return RedirectToAction("Index");
				}
			}
			return View(album);
		}

		public async Task<IActionResult> Remove(int id)
		{
			var album = await _ministryAlbumServices.GetMinistryAlbumById(id);
			var ministries = await _ministryServices.GetMinistries();
			ViewBag.Ministries = new SelectList(ministries, "MinistryId", "Name");
			if (album == null)
			{
				return NotFound();
			}
			return View(album);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed([Bind("MinistryAlbumId,AlbumId,MinistryId")] MinistryAlbum ministryalbum)
		{
			var album = await _ministryAlbumServices.GetMinistryAlbumById(ministryalbum.MinistryAlbumId);
			var ministries = await _ministryServices.GetMinistries();
			ViewBag.Ministries = new SelectList(ministries, "MinistryId", "Name");
			if (album == null)
			{
				return NotFound();
			}
			await _ministryAlbumServices.DeleteMinistryAlbum(ministryalbum.MinistryAlbumId);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> GetMinistryAlbums()
		{
			var albums = await _ministryAlbumServices.GetMinistryAlbums();
			return Json(new { data = albums });
		}
	}
}
