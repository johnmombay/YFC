using Admin.YFC.Common;
using Admin.YFC.Models;
using System.Text.Json;

namespace Admin.YFC.Services
{
	public class HeadlineServices
	{
		public async Task<List<Headline>> GetHeadlines()
		{
			List<Headline> contacts = new List<Headline>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.HeadlineEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<Headline>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<Headline> GetHeadlineById(int id)
		{
			Headline Headline = new Headline();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.HeadlineEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				Headline = JsonSerializer.Deserialize<Headline>(result, AppSettings.options)!;
			}
			return Headline;
		}

		public async Task<Headline> AddHeadline(Headline Headline)
		{
			Headline HeadlineDb = new Headline();

			var data = JsonSerializer.Serialize(Headline).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.HeadlineEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				HeadlineDb = JsonSerializer.Deserialize<Headline>(result, AppSettings.options)!;
				return HeadlineDb;
			}
			return Headline;
		}

		public async Task<Headline> UpdateHeadline(Headline Headline)
		{
			Headline HeadlineDb = new Headline();
			var data = JsonSerializer.Serialize(Headline).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.HeadlineEndpoint + "/" + Headline.HeadlineId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.HeadlineEndpoint + "/" + Headline.HeadlineId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				HeadlineDb = JsonSerializer.Deserialize<Headline>(result, AppSettings.options)!;
				return HeadlineDb;
			}
			return Headline;
		}

		public async Task<string> DeleteHeadline(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.HeadlineEndpoint + "/" + id);
			return result;
		}
	}
}
