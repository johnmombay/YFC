using Web.YFC.Common;
using Web.YFC.Models;
using System.Text.Json;

namespace Web.YFC.Services
{
	public class CommunityEventServices
	{
		public async Task<List<CommunityEvent>> GetCommunityEvents()
		{
			List<CommunityEvent> contacts = new List<CommunityEvent>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityEventEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<CommunityEvent>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<List<CommunityEvent>> GetCommunityEventsByCommunityId(int id)
		{
			List<CommunityEvent> contacts = new List<CommunityEvent>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityEventEndpoint + "/GetCommunityEventsByCommunityId/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<CommunityEvent>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<CommunityEvent> GetCommunityEventById(int id)
		{
			CommunityEvent CommunityEvent = new CommunityEvent();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityEventEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				CommunityEvent = JsonSerializer.Deserialize<CommunityEvent>(result, AppSettings.options)!;
			}
			return CommunityEvent;
		}

		public async Task<CommunityEvent> AddCommunityEvent(CommunityEvent CommunityEvent)
		{
			CommunityEvent CommunityEventDb = new CommunityEvent();

			var data = JsonSerializer.Serialize(CommunityEvent).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.CommunityEventEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				CommunityEventDb = JsonSerializer.Deserialize<CommunityEvent>(result, AppSettings.options)!;
				return CommunityEventDb;
			}
			return CommunityEvent;
		}

		public async Task<CommunityEvent> UpdateCommunityEvent(CommunityEvent CommunityEvent)
		{
			CommunityEvent CommunityEventDb = new CommunityEvent();
			var data = JsonSerializer.Serialize(CommunityEvent).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.CommunityEventEndpoint + "/" + CommunityEvent.CommunityEventId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityEventEndpoint + "/" + CommunityEvent.CommunityEventId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				CommunityEventDb = JsonSerializer.Deserialize<CommunityEvent>(result, AppSettings.options)!;
				return CommunityEventDb;
			}
			return CommunityEvent;
		}

		public async Task<string> DeleteCommunityEvent(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.CommunityEventEndpoint + "/" + id);
			return result;
		}
	}
}
