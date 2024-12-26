using Admin.YFC.Common;
using Admin.YFC.Models;
using System.Text.Json;

namespace Admin.YFC.Services
{
	public class EventServices
	{
		public async Task<List<Event>> GetEvents()
		{
			List<Event> contacts = new List<Event>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.EventEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<Event>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<Event> GetEventById(int id)
		{
			Event Event = new Event();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.EventEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				Event = JsonSerializer.Deserialize<Event>(result, AppSettings.options)!;
			}
			return Event;
		}

		public async Task<Event> AddEvent(Event Event)
		{
			Event EventDb = new Event();

			var data = JsonSerializer.Serialize(Event).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.EventEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				EventDb = JsonSerializer.Deserialize<Event>(result, AppSettings.options)!;
				return EventDb;
			}
			return Event;
		}

		public async Task<Event> UpdateEvent(Event Event)
		{
			Event EventDb = new Event();
			var data = JsonSerializer.Serialize(Event).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.EventEndpoint + "/" + Event.EventId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.EventEndpoint + "/" + Event.EventId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				EventDb = JsonSerializer.Deserialize<Event>(result, AppSettings.options)!;
				return EventDb;
			}
			return Event;
		}

		public async Task<string> DeleteEvent(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.EventEndpoint + "/" + id);
			return result;
		}
	}
}
