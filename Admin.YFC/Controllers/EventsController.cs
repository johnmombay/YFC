using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Admin.YFC.Controllers
{
	public class EventsController : Controller
	{
		private readonly EventServices _eventServices;
		private readonly FileUploadServices _fileUploadServices;

		public EventsController(EventServices eventServices,
			FileUploadServices fileUploadServices) 
		{
			_eventServices = eventServices;
			_fileUploadServices = fileUploadServices;
		}
		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetEvents()
		{
			var events = await _eventServices.GetEvents();
			return Json(new { data = events });
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(IFormFile file, [Bind("Title,Description,EventDate,Url")] Event @event)
		{
			@event.Picture = file.FileName;
			if (file != null)
			{
				await _fileUploadServices.Upload(file, "Events/" + @event.EventId + "/", file.FileName);
				await _eventServices.AddEvent(@event);
				return RedirectToAction("Index");
			}
			return View(@event);
		}

		public async Task<IActionResult> Edit(int id)
		{
			ViewBag.EventId = id;
			var @event = await _eventServices.GetEventById(id);
			return View(@event);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(IFormFile file, int id, [Bind("EventId,Title,Description,EventDate,Url")] Event @event)
		{
			if (file != null)
			{
				await _fileUploadServices.Upload(file, "Events/" + @event.EventId + "/", file.FileName);
			}
			await _eventServices.UpdateEvent(@event);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Remove(int id)
		{
			ViewBag.EventId = id;
			var @event = await _eventServices.GetEventById(id);
			return View(@event);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var @event = await _eventServices.GetEventById(id);
			await _fileUploadServices.Remove("Events", @event.EventId.ToString(), @event.Picture);
			await _eventServices.DeleteEvent(id);
			return RedirectToAction("Index");
		}
	}
}
