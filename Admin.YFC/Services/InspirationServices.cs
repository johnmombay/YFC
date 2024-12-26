using Admin.YFC.Common;
using Admin.YFC.Models;
using System.Text.Json;

namespace Admin.YFC.Services
{
	public class InspirationServices
	{
		public async Task<List<Inspiration>> GetInspirations()
		{
			List<Inspiration> contacts = new List<Inspiration>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.InspirationEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<Inspiration>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<Inspiration> GetInspirationById(int id)
		{
			Inspiration Inspiration = new Inspiration();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.InspirationEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				Inspiration = JsonSerializer.Deserialize<Inspiration>(result, AppSettings.options)!;
			}
			return Inspiration;
		}

		public async Task<Inspiration> AddInspiration(Inspiration Inspiration)
		{
			Inspiration InspirationDb = new Inspiration();

			var data = JsonSerializer.Serialize(Inspiration).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.InspirationEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				InspirationDb = JsonSerializer.Deserialize<Inspiration>(result, AppSettings.options)!;
				return InspirationDb;
			}
			return Inspiration;
		}

		public async Task<Inspiration> UpdateInspiration(Inspiration Inspiration)
		{
			Inspiration InspirationDb = new Inspiration();
			var data = JsonSerializer.Serialize(Inspiration).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.InspirationEndpoint + "/" + Inspiration.InspirationId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.InspirationEndpoint + "/" + Inspiration.InspirationId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				InspirationDb = JsonSerializer.Deserialize<Inspiration>(result, AppSettings.options)!;
				return InspirationDb;
			}
			return Inspiration;
		}

		public async Task<string> DeleteInspiration(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.InspirationEndpoint + "/" + id);
			return result;
		}
	}
}
