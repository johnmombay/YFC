using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Admin.YFC.Controllers
{
	public class InspirationsController : Controller
	{
		private readonly InspirationServices _inspirationServices;

		public InspirationsController(InspirationServices inspirationServices)
		{
			_inspirationServices = inspirationServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetInspirations()
		{
			var inspirations = await _inspirationServices.g();
			return Json(new { data = inspirations });
		}

		public IActionResult Create()
		{
			return View();
		}

		public async Task<IActionResult> Create([Bind("Title,Message,Author")] Inspiration inspiration)
		{
			if (ModelState.IsValid)
			{
				await _inspirationServices.AddInspiration(inspiration);
				return RedirectToAction("Index");
			}
			return View(inspiration);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var inspiration = await _inspirationServices.GetInspirationById(id);
			return View(inspiration);
		}

		public async Task<IActionResult> Edit(int id, [Bind("InspirationId,Title,Message,Author")] Inspiration inspiration)
		{
			if (ModelState.IsValid)
			{
				await _inspirationServices.UpdateInspiration(inspiration);
				return RedirectToAction("Index");
			}
			return View(inspiration);
		}

		public async Task<IActionResult> Remove(int id)
		{
			var inspiration = await _inspirationServices.GetInspirationById(id);
			return View(inspiration);
		}

		public async Task<IActionResult> Delete(int id)
		{
			await _inspirationServices.DeleteInspiration(id);
			return RedirectToAction("Index");
		}
	}
}
