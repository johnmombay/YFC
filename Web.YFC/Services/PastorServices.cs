using Web.YFC.Common;
using Web.YFC.Models;
using System.Text.Json;

namespace Web.YFC.Services
{
	public class PastorServices
	{
		public async Task<List<Pastor>> GetMinistries()
		{
			List<Pastor> contacts = new List<Pastor>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.PastorEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<Pastor>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<Pastor> GetPastorById(int id)
		{
			Pastor Pastor = new Pastor();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.PastorEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				Pastor = JsonSerializer.Deserialize<Pastor>(result, AppSettings.options)!;
			}
			return Pastor;
		}

		public async Task<Pastor> AddPastor(Pastor Pastor)
		{
			Pastor PastorDb = new Pastor();

			var data = JsonSerializer.Serialize(Pastor).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.PastorEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				PastorDb = JsonSerializer.Deserialize<Pastor>(result, AppSettings.options)!;
				return PastorDb;
			}
			return Pastor;
		}

		public async Task<Pastor> UpdatePastor(Pastor Pastor)
		{
			Pastor PastorDb = new Pastor();
			var data = JsonSerializer.Serialize(Pastor).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.PastorEndpoint + "/" + Pastor.PastorId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.PastorEndpoint + "/" + Pastor.PastorId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				PastorDb = JsonSerializer.Deserialize<Pastor>(result, AppSettings.options)!;
				return PastorDb;
			}
			return Pastor;
		}

		public async Task<string> DeletePastor(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.PastorEndpoint + "/" + id);
			return result;
		}
	}
}
