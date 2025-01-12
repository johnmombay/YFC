using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Admin.YFC.Controllers
{
	public class PastorMessagesController : Controller
	{
		private readonly PastorMessageServices _pastorMessageServices;

		public PastorMessagesController(PastorMessageServices pastorMessageServices)
		{
			_pastorMessageServices = pastorMessageServices;
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

		public IActionResult Create()
		{
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
			return View(pastorMessage);
		}

		public async Task<IActionResult> Delete([Bind("PastorMessageId,Title,Message,PastorId")] PastorMessage pastorMessage)
		{
			var result = await _pastorMessageServices.DeletePastorMessage(pastorMessage.PastorMessageId);
			return RedirectToAction("Index");
		}
	}
}
