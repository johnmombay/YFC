using System.Text.Json;
using Web.YFC.Common;
using Web.YFC.Models;

namespace Web.YFC.Services
{
	public class MinistryAlbumServices
	{
		public async Task<List<MinistryAlbum>> GetMinistryAlbums()
		{
			List<MinistryAlbum> contacts = new List<MinistryAlbum>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryAlbumEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<MinistryAlbum>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<MinistryAlbum> GetMinistryAlbumById(int id)
		{
			MinistryAlbum MinistryAlbum = new MinistryAlbum();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryAlbumEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistryAlbum = JsonSerializer.Deserialize<MinistryAlbum>(result, AppSettings.options)!;
			}
			return MinistryAlbum;
		}

		public async Task<List<MinistryAlbum>> GetMinistryAlbumByMinistryId(int id)
		{
			List<MinistryAlbum> MinistryAlbum = new List<MinistryAlbum>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryAlbumEndpoint + "/ByMinistryId/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistryAlbum = JsonSerializer.Deserialize<List<MinistryAlbum>>(result, AppSettings.options)!;
			}
			return MinistryAlbum;
		}

		public async Task<MinistryAlbum> AddMinistryAlbum(MinistryAlbum MinistryAlbum)
		{
			MinistryAlbum MinistryAlbumDb = new MinistryAlbum();

			var data = JsonSerializer.Serialize(MinistryAlbum).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.MinistryAlbumEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistryAlbumDb = JsonSerializer.Deserialize<MinistryAlbum>(result, AppSettings.options)!;
				return MinistryAlbumDb;
			}
			return MinistryAlbum;
		}

		public async Task<MinistryAlbum> UpdateMinistryAlbum(MinistryAlbum MinistryAlbum)
		{
			MinistryAlbum MinistryAlbumDb = new MinistryAlbum();
			var data = JsonSerializer.Serialize(MinistryAlbum).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.MinistryAlbumEndpoint + "/" + MinistryAlbum.MinistryAlbumId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryAlbumEndpoint + "/" + MinistryAlbum.MinistryAlbumId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistryAlbumDb = JsonSerializer.Deserialize<MinistryAlbum>(result, AppSettings.options)!;
				return MinistryAlbumDb;
			}
			return MinistryAlbum;
		}

		public async Task<string> DeleteMinistryAlbum(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.MinistryAlbumEndpoint + "/" + id);
			return result;
		}
	}
}
