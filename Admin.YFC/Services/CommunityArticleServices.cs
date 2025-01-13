using Admin.YFC.Common;
using Admin.YFC.Models;
using System.Text.Json;

namespace Admin.YFC.Services
{
	public class CommunityArticleServices
	{
		public async Task<List<CommunityArticle>> GetCommunityArticles()
		{
			List<CommunityArticle> contacts = new List<CommunityArticle>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityArticleEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<CommunityArticle>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<CommunityArticle> GetCommunityArticleById(int id)
		{
			CommunityArticle CommunityArticle = new CommunityArticle();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityArticleEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				CommunityArticle = JsonSerializer.Deserialize<CommunityArticle>(result, AppSettings.options)!;
			}
			return CommunityArticle;
		}

		public async Task<CommunityArticle> AddCommunityArticle(CommunityArticle CommunityArticle)
		{
			CommunityArticle CommunityArticleDb = new CommunityArticle();

			var data = JsonSerializer.Serialize(CommunityArticle).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.CommunityArticleEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				CommunityArticleDb = JsonSerializer.Deserialize<CommunityArticle>(result, AppSettings.options)!;
				return CommunityArticleDb;
			}
			return CommunityArticle;
		}

		public async Task<CommunityArticle> UpdateCommunityArticle(CommunityArticle CommunityArticle)
		{
			CommunityArticle CommunityArticleDb = new CommunityArticle();
			var data = JsonSerializer.Serialize(CommunityArticle).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.CommunityArticleEndpoint + "/" + CommunityArticle.CommunityArticleId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityArticleEndpoint + "/" + CommunityArticle.CommunityArticleId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				CommunityArticleDb = JsonSerializer.Deserialize<CommunityArticle>(result, AppSettings.options)!;
				return CommunityArticleDb;
			}
			return CommunityArticle;
		}

		public async Task<string> DeleteCommunityArticle(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.CommunityArticleEndpoint + "/" + id);
			return result;
		}
	}
}
