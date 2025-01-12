using Admin.YFC.Common;
using Admin.YFC.Models;
using System.Text.Json;

namespace Admin.YFC.Services
{
	public class ContentServices
	{
		public async Task<List<Content>> GetContents()
		{
			List<Content> contacts = new List<Content>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.ContentEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<Content>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<Content> GetContentById(int id)
		{
			Content Content = new Content();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.ContentEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				Content = JsonSerializer.Deserialize<Content>(result, AppSettings.options)!;
			}
			return Content;
		}

		public async Task<Content> AddContent(Content Content)
		{
			Content ContentDb = new Content();

			var data = JsonSerializer.Serialize(Content).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.ContentEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				ContentDb = JsonSerializer.Deserialize<Content>(result, AppSettings.options)!;
				return ContentDb;
			}
			return Content;
		}

		public async Task<Content> UpdateContent(Content Content)
		{
			Content ContentDb = new Content();
			var data = JsonSerializer.Serialize(Content).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.ContentEndpoint + "/" + Content.ContentId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.ContentEndpoint + "/" + Content.ContentId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				ContentDb = JsonSerializer.Deserialize<Content>(result, AppSettings.options)!;
				return ContentDb;
			}
			return Content;
		}

		public async Task<string> DeleteContent(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.ContentEndpoint + "/" + id);
			return result;
		}
	}
}
