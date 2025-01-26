using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Admin.YFC.Controllers
{
	public class PastorsController : Controller
	{
		private readonly PastorServices _pastorServices;
		private readonly FileUploadServices _fileUploadServices;

		public PastorsController(PastorServices pastorServices,
			FileUploadServices fileUploadServices)
		{
			_pastorServices = pastorServices;
			_fileUploadServices = fileUploadServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetPastors()
		{
			var pastors = await _pastorServices.GetPastors();
			return Json(new { data = pastors });
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(IFormFile file, [Bind("Name,Signature")] Pastor pastor)
		{
			pastor.Signature = file.FileName;
			if (file != null)
			{
				var newPastor = await _pastorServices.AddPastor(pastor);
				if (newPastor.PastorId > 0)
				{
					await _fileUploadServices.Upload(file, "Pastors/" + newPastor.PastorId + "/", file.FileName);
					return RedirectToAction("Index");
				}
			}
			return View(pastor);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var pastor = await _pastorServices.GetPastorById(id);
			return View(pastor);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(IFormFile file, int id, [Bind("PastorId,Name,Signature")] Pastor pastor)
		{
			if (file != null)
			{
				await _fileUploadServices.Upload(file, "Pastors/" + pastor.PastorId + "/", file.FileName);
				await _fileUploadServices.Remove("Pastors", pastor.PastorId.ToString(), pastor.Signature);
				pastor.Signature = file.FileName;
			}
			await _pastorServices.UpdatePastor(pastor);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Remove(int id)
		{
			var pastor = await _pastorServices.GetPastorById(id);
			return View(pastor);
		}

		public async Task<IActionResult> Delete([Bind("PastorId,Name,Signature")] Pastor pastor)
		{
			var result = await _pastorServices.DeletePastor(pastor.PastorId);
			return RedirectToAction("Index");
		}
	}
}
