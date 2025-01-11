using Admin.YFC.Common;
using Admin.YFC.Models;
using System.Text.Json;

namespace Admin.YFC.Services
{
	public class MinistryServices
	{
		public async Task<List<Ministry>> GetMinistries()
		{
			List<Ministry> contacts = new List<Ministry>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<Ministry>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<Ministry> GetMinistryById(int id)
		{
			Ministry Ministry = new Ministry();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				Ministry = JsonSerializer.Deserialize<Ministry>(result, AppSettings.options)!;
			}
			return Ministry;
		}

		public async Task<Ministry> AddMinistry(Ministry Ministry)
		{
			Ministry MinistryDb = new Ministry();

			var data = JsonSerializer.Serialize(Ministry).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.MinistryEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistryDb = JsonSerializer.Deserialize<Ministry>(result, AppSettings.options)!;
				return MinistryDb;
			}
			return Ministry;
		}

		public async Task<Ministry> UpdateMinistry(Ministry Ministry)
		{
			Ministry MinistryDb = new Ministry();
			var data = JsonSerializer.Serialize(Ministry).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.MinistryEndpoint + "/" + Ministry.MinistryId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryEndpoint + "/" + Ministry.MinistryId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistryDb = JsonSerializer.Deserialize<Ministry>(result, AppSettings.options)!;
				return MinistryDb;
			}
			return Ministry;
		}

		public async Task<string> DeleteMinistry(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.MinistryEndpoint + "/" + id);
			return result;
		}
	}
}
