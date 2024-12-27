using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Admin.YFC.Controllers
{
	public class TeachingsController : Controller
	{
		private readonly TeachingServices _teachingServices;
		private readonly FileUploadServices _fileUploadServices;

		public TeachingsController(TeachingServices teachingServices,
			FileUploadServices fileUploadServices)
		{
			_teachingServices = teachingServices;
			_fileUploadServices = fileUploadServices;
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

		[HttpPost]
		public async Task<IActionResult> Create(IFormFile file, [Bind("Title,Speaker,TeachingDate,Picture,Video,Audio,PDF")] Teaching teaching)
		{
			if (ModelState.IsValid)
			{
				if(file != null)
				{
					await _fileUploadServices.Upload(file, "Teachings/" + teaching.TeachingId + "/", file.FileName);
					await _teachingServices.AddTeaching(teaching);
					return RedirectToAction("Index");
				}
			}
			return View(teaching);
		}

		public async Task<IActionResult> Edit(int id)
		{
			ViewBag.TeachingId = id;
			var teaching = await _teachingServices.GetTeachingById(id);
			return View(teaching);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(IFormFile file, int id, [Bind("TeachingId,Title,Speaker,TeachingDate,Picture,Video,Audio,PDF")] Teaching teaching)
		{
			if (ModelState.IsValid)
			{
				if (file != null)
				{
					await _fileUploadServices.Upload(file, "Teachings/" + teaching.TeachingId + "/", file.FileName);
				}
				await _teachingServices.UpdateTeaching(teaching);
				return RedirectToAction("Index");
			}
			return View(teaching);
		}

		public async Task<IActionResult> Remove(int id)
		{
			ViewBag.TeachingId = id;
			var teaching = await _teachingServices.GetTeachingById(id);
			return View(teaching);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var teaching = await _teachingServices.GetTeachingById(id);
			await _fileUploadServices.Remove("Teachings", teaching.TeachingId.ToString(), teaching.Picture);
			await _teachingServices.DeleteTeaching(id);
			return RedirectToAction("Index");
		}
	}
}
