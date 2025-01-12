using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Admin.YFC.Controllers
{
	public class SectionsController : Controller
	{
		private readonly SectionServices _sectionServices;

		public SectionsController(SectionServices sectionServices)
		{
			_sectionServices = sectionServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetSections()
		{
			var sections = await _sectionServices.GetSections();
			return Json(new { data = sections });
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("Name")] Section section)
		{
			var newSection = await _sectionServices.AddSection(section);
			if (newSection.SectionId > 0)
			{
				return RedirectToAction("Index");
			}
			return View(section);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var section = await _sectionServices.GetSectionById(id);
			return View(section);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("SectionId,Name")] Section section)
		{
			var updatedSection = await _sectionServices.UpdateSection(section);
			if (updatedSection.SectionId > 0)
			{
				return RedirectToAction("Index");
			}
			return View(section);
		}

		public async Task<IActionResult> Remove(int id)
		{
			var section = await _sectionServices.GetSectionById(id);
			return View(section);
		}

		[HttpPost]
		public async Task<IActionResult> Delete([Bind("SectionId,Name")] Section section)
		{
			var removedSection = await _sectionServices.DeleteSection(section.SectionId);
			return RedirectToAction("Index");
		}

	}
}
