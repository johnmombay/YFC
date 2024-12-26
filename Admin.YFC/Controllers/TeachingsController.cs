using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Admin.YFC.Controllers
{
	public class TeachingsController : Controller
	{
		private readonly TeachingServices _teachingServices;

		public TeachingsController(TeachingServices teachingServices)
		{
			_teachingServices = teachingServices;
		}
		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetTeachings()
		{
			var teachings = await _teachingServices.GetTeachings();
			return Json(new { data = teachings });
		}

		public IActionResult Create()
		{
			return View();
		}

		public async Task<IActionResult> Create([Bind("Title,Speacker,TeachingDate,Picture,Video,Audio,PDF")] Teaching teaching)
		{
			if (ModelState.IsValid)
			{
				await _teachingServices.AddTeaching(teaching);
				return RedirectToAction("Index");
			}
			return View(teaching);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var teaching = await _teachingServices.GetTeachingById(id);
			return View(teaching);
		}

		public async Task<IActionResult> Edit(int id, [Bind("TeachingId,Title,Speacker,TeachingDate,Picture,Video,Audio,PDF")] Teaching teaching)
		{
			if (ModelState.IsValid)
			{
				await _teachingServices.UpdateTeaching(teaching);
				return RedirectToAction("Index");
			}
			return View(teaching);
		}

		public async Task<IActionResult> Remove(int id)
		{
			var teaching = await _teachingServices.GetTeachingById(id);
			return View(teaching);
		}

		public async Task<IActionResult> Delete(int id)
		{
			await _teachingServices.DeleteTeaching(id);
			return RedirectToAction("Index");
		}
	}
}
