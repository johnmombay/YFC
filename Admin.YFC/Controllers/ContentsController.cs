using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Admin.YFC.Controllers
{
	public class ContentsController : Controller
	{
		private readonly ContentServices _contentServices;

		public ContentsController(ContentServices contentServices)
		{
			_contentServices = contentServices;
		}
		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetContents()
		{
			var contents = await _contentServices.GetContents();
			return Json(new { data = contents });
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("SectionId,Material")] Content content)
		{
			var newContent = await _contentServices.AddContent(content);
			if (newContent.ContentId > 0)
			{
				return RedirectToAction("Index");
			}
			return View(content);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var content = await _contentServices.GetContentById(id);
			return View(content);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("ContentId,SectionId,Material")] Content content)
		{
			var updatedContent = await _contentServices.UpdateContent(content);
			if (updatedContent.ContentId > 0)
			{
				return RedirectToAction("Index");
			}
			return View(content);
		}

		public async Task<IActionResult> Remove(int id)
		{
			var content = await _contentServices.GetContentById(id);
			return View(content);
		}

		public async Task<IActionResult> Delete([Bind("ContentId,SectionId,Material")] Content content)
		{
			var removedContent = await _contentServices.DeleteContent(content.ContentId);
			return RedirectToAction("Index");
		}
	}
}
