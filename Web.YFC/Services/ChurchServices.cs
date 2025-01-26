using Web.YFC.Common;
using Web.YFC.Models;
using System.Text.Json;

namespace Web.YFC.Services
{
	public class ChurchServices
	{
		public async Task<List<Church>> GetChurches()
		{
			List<Church> contacts = new List<Church>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.ChurchEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<Church>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<Church> GetChurchById(int id)
		{
			Church Church = new Church();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.ChurchEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				Church = JsonSerializer.Deserialize<Church>(result, AppSettings.options)!;
			}
			return Church;
		}

		public async Task<Church> AddChurch(Church Church)
		{
			Church ChurchDb = new Church();

			var data = JsonSerializer.Serialize(Church).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.ChurchEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				ChurchDb = JsonSerializer.Deserialize<Church>(result, AppSettings.options)!;
				return ChurchDb;
			}
			return Church;
		}

		public async Task<Church> UpdateChurch(Church Church)
		{
			Church ChurchDb = new Church();
			var data = JsonSerializer.Serialize(Church).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.ChurchEndpoint + "/" + Church.ChurchId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.ChurchEndpoint + "/" + Church.ChurchId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				ChurchDb = JsonSerializer.Deserialize<Church>(result, AppSettings.options)!;
				return ChurchDb;
			}
			return Church;
		}

		public async Task<string> DeleteChurch(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.ChurchEndpoint + "/" + id);
			return result;
		}
	}
}
