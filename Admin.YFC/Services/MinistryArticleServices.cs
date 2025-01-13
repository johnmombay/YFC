using Admin.YFC.Common;
using Admin.YFC.Models;
using System.Text.Json;

namespace Admin.YFC.Services
{
	public class MinistryArticleServices
	{
		public async Task<List<MinistryArticle>> GetMinistryArticles()
		{
			List<MinistryArticle> contacts = new List<MinistryArticle>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryArticleEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<MinistryArticle>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<MinistryArticle> GetMinistryArticleById(int id)
		{
			MinistryArticle MinistryArticle = new MinistryArticle();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryArticleEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistryArticle = JsonSerializer.Deserialize<MinistryArticle>(result, AppSettings.options)!;
			}
			return MinistryArticle;
		}

		public async Task<MinistryArticle> AddMinistryArticle(MinistryArticle MinistryArticle)
		{
			MinistryArticle MinistryArticleDb = new MinistryArticle();

			var data = JsonSerializer.Serialize(MinistryArticle).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.MinistryArticleEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistryArticleDb = JsonSerializer.Deserialize<MinistryArticle>(result, AppSettings.options)!;
				return MinistryArticleDb;
			}
			return MinistryArticle;
		}

		public async Task<MinistryArticle> UpdateMinistryArticle(MinistryArticle MinistryArticle)
		{
			MinistryArticle MinistryArticleDb = new MinistryArticle();
			var data = JsonSerializer.Serialize(MinistryArticle).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.MinistryArticleEndpoint + "/" + MinistryArticle.MinistryArticleId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryArticleEndpoint + "/" + MinistryArticle.MinistryArticleId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistryArticleDb = JsonSerializer.Deserialize<MinistryArticle>(result, AppSettings.options)!;
				return MinistryArticleDb;
			}
			return MinistryArticle;
		}

		public async Task<string> DeleteMinistryArticle(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.MinistryArticleEndpoint + "/" + id);
			return result;
		}
	}
}
