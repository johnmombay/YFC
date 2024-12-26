using Web.YFC.Common;
using Web.YFC.Models;
using System.Text.Json;

namespace Admin.YFC.Services
{
	public class TeachingServices
	{
		public async Task<List<Teaching>> GetTeachings()
		{
			List<Teaching> contacts = new List<Teaching>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.TeachingEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<Teaching>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<Teaching> GetTeachingById(int id)
		{
			Teaching Teaching = new Teaching();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.TeachingEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				Teaching = JsonSerializer.Deserialize<Teaching>(result, AppSettings.options)!;
			}
			return Teaching;
		}

		public async Task<Teaching> AddTeaching(Teaching Teaching)
		{
			Teaching TeachingDb = new Teaching();

			var data = JsonSerializer.Serialize(Teaching).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.TeachingEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				TeachingDb = JsonSerializer.Deserialize<Teaching>(result, AppSettings.options)!;
				return TeachingDb;
			}
			return Teaching;
		}

		public async Task<Teaching> UpdateTeaching(Teaching Teaching)
		{
			Teaching TeachingDb = new Teaching();
			var data = JsonSerializer.Serialize(Teaching).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.TeachingEndpoint + "/" + Teaching.TeachingId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.TeachingEndpoint + "/" + Teaching.TeachingId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				TeachingDb = JsonSerializer.Deserialize<Teaching>(result, AppSettings.options)!;
				return TeachingDb;
			}
			return Teaching;
		}

		public async Task<string> DeleteTeaching(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.TeachingEndpoint + "/" + id);
			return result;
		}
	}
}
