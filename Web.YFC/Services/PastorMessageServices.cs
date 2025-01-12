using Web.YFC.Common;
using Web.YFC.Models;
using System.Text.Json;

namespace Web.YFC.Services
{
	public class PastorMessageServices
	{
		public async Task<List<PastorMessage>> GetMinistries()
		{
			List<PastorMessage> contacts = new List<PastorMessage>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.PastorMessageEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<PastorMessage>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<PastorMessage> GetPastorMessageById(int id)
		{
			PastorMessage PastorMessage = new PastorMessage();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.PastorMessageEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				PastorMessage = JsonSerializer.Deserialize<PastorMessage>(result, AppSettings.options)!;
			}
			return PastorMessage;
		}

		public async Task<PastorMessage> AddPastorMessage(PastorMessage PastorMessage)
		{
			PastorMessage PastorMessageDb = new PastorMessage();

			var data = JsonSerializer.Serialize(PastorMessage).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.PastorMessageEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				PastorMessageDb = JsonSerializer.Deserialize<PastorMessage>(result, AppSettings.options)!;
				return PastorMessageDb;
			}
			return PastorMessage;
		}

		public async Task<PastorMessage> UpdatePastorMessage(PastorMessage PastorMessage)
		{
			PastorMessage PastorMessageDb = new PastorMessage();
			var data = JsonSerializer.Serialize(PastorMessage).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.PastorMessageEndpoint + "/" + PastorMessage.PastorMessageId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.PastorMessageEndpoint + "/" + PastorMessage.PastorMessageId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				PastorMessageDb = JsonSerializer.Deserialize<PastorMessage>(result, AppSettings.options)!;
				return PastorMessageDb;
			}
			return PastorMessage;
		}

		public async Task<string> DeletePastorMessage(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.PastorMessageEndpoint + "/" + id);
			return result;
		}
	}
}
