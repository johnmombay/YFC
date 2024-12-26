using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Admin.YFC.Controllers
{
	public class EventsController : Controller
	{
		private readonly EventServices _eventServices;

		public EventsController(EventServices eventServices) 
		{
			_eventServices = eventServices;
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

		public async Task<IActionResult> Create([Bind("Title,Description,EventDate,Picture,Url")] Event @event)
		{
			if (ModelState.IsValid)
			{
				await _eventServices.AddEvent(@event);
				return RedirectToAction("Index");
			}
			return View(@event);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var @event = await _eventServices.GetEventById(id);
			return View(@event);
		}

		public async Task<IActionResult> Edit(int id, [Bind("EventId,Title,Description,EventDate,Picture,Url")] Event @event)
		{
			if (ModelState.IsValid)
			{
				await _eventServices.UpdateEvent(@event);
				return RedirectToAction("Index");
			}
			return View(@event);
		}

		public async Task<IActionResult> Remove(int id)
		{
			var @event = await _eventServices.GetEventById(id);
			return View(@event);
		}

		public async Task<IActionResult> Delete(int id)
		{
			await _eventServices.DeleteEvent(id);
			return RedirectToAction("Index");
		}
	}
}
