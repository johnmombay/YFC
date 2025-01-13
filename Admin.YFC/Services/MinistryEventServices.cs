using Admin.YFC.Common;
using Admin.YFC.Models;
using System.Text.Json;

namespace Admin.YFC.Services
{
	public class MinistryEventServices
	{
		public async Task<List<MinistryEvent>> GetMinistryEvents()
		{
			List<MinistryEvent> contacts = new List<MinistryEvent>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryEventEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<MinistryEvent>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<MinistryEvent> GetMinistryEventById(int id)
		{
			MinistryEvent MinistryEvent = new MinistryEvent();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryEventEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistryEvent = JsonSerializer.Deserialize<MinistryEvent>(result, AppSettings.options)!;
			}
			return MinistryEvent;
		}

		public async Task<MinistryEvent> AddMinistryEvent(MinistryEvent MinistryEvent)
		{
			MinistryEvent MinistryEventDb = new MinistryEvent();

			var data = JsonSerializer.Serialize(MinistryEvent).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.MinistryEventEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistryEventDb = JsonSerializer.Deserialize<MinistryEvent>(result, AppSettings.options)!;
				return MinistryEventDb;
			}
			return MinistryEvent;
		}

		public async Task<MinistryEvent> UpdateMinistryEvent(MinistryEvent MinistryEvent)
		{
			MinistryEvent MinistryEventDb = new MinistryEvent();
			var data = JsonSerializer.Serialize(MinistryEvent).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.MinistryEventEndpoint + "/" + MinistryEvent.MinistryEventId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryEventEndpoint + "/" + MinistryEvent.MinistryEventId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistryEventDb = JsonSerializer.Deserialize<MinistryEvent>(result, AppSettings.options)!;
				return MinistryEventDb;
			}
			return MinistryEvent;
		}

		public async Task<string> DeleteMinistryEvent(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.MinistryEventEndpoint + "/" + id);
			return result;
		}
	}
}
