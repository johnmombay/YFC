using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Admin.YFC.Controllers
{
	public class PastorsController : Controller
	{
		private readonly PastorServices _pastorServices;

		public PastorsController(PastorServices pastorServices)
		{
			_pastorServices = pastorServices;
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
		public async Task<IActionResult> Create([Bind("Name,Signature")] Pastor pastor)
		{
			var newPastor = await _pastorServices.AddPastor(pastor);
			if (newPastor.PastorId > 0)
			{
				return RedirectToAction("Index");
			}
			return View(pastor);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var pastor = await _pastorServices.GetPastorById(id);
			return View(pastor);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("PastorId,Name,Signature")] Pastor pastor)
		{
			var updatedPastor = await _pastorServices.UpdatePastor(pastor);
			if (updatedPastor.PastorId > 0)
			{
				return RedirectToAction("Index");
			}
			return View(pastor);
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
