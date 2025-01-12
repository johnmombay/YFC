using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Admin.YFC.Controllers
{
	public class PastorMessagesController : Controller
	{
		private readonly PastorMessageServices _pastorMessageServices;
		private readonly PastorServices _pastorServices;

		public PastorMessagesController(PastorMessageServices pastorMessageServices,
			PastorServices pastorServices)
		{
			_pastorMessageServices = pastorMessageServices;
			_pastorServices = pastorServices;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetPastorMessages()
		{
			var pastorMessages = await _pastorMessageServices.GetPastorMessages();
			return Json(new { data = pastorMessages });
		}

		public async Task<IActionResult> Create()
		{
			var pastors = await _pastorServices.GetPastors();
			ViewBag.Pastors = new SelectList(pastors, "PastorId", "Name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("Title,Message,PastorId")] PastorMessage pastorMessage)
		{
			var newPastorMessage = await _pastorMessageServices.AddPastorMessage(pastorMessage);
			if (newPastorMessage.PastorMessageId > 0)
			{
				return RedirectToAction("Index");
			}
			return View(pastorMessage);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var pastorMessage = await _pastorMessageServices.GetPastorMessageById(id);
			var pastors = await _pastorServices.GetPastors();
			ViewBag.Pastors = new SelectList(pastors, "PastorId", "Name", pastorMessage.PastorId);
			return View(pastorMessage);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("PastorMessageId,Title,Message,PastorId")] PastorMessage pastorMessage)
		{
			var updatedPastorMessage = await _pastorMessageServices.UpdatePastorMessage(pastorMessage);
			if (updatedPastorMessage.PastorMessageId > 0)
			{
				return RedirectToAction("Index");
			}
			return View(pastorMessage);
		}

		public async Task<IActionResult> Remove(int id)
		{
			var pastorMessage = await _pastorMessageServices.GetPastorMessageById(id);
			var pastors = await _pastorServices.GetPastors();
			ViewBag.Pastors = new SelectList(pastors, "PastorId", "Name", pastorMessage.PastorId);
			return View(pastorMessage);
		}

		public async Task<IActionResult> Delete([Bind("PastorMessageId,Title,Message,PastorId")] PastorMessage pastorMessage)
		{
			var result = await _pastorMessageServices.DeletePastorMessage(pastorMessage.PastorMessageId);
			return RedirectToAction("Index");
		}
	}
}
