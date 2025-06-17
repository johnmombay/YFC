using Admin.YFC.Common;
using Admin.YFC.Models;
using System.Text.Json;

namespace Admin.YFC.Services
{
	public class CommunityAlbumServices
	{
		public async Task<List<CommunityAlbum>> GetCommunityAlbums()
		{
			List<CommunityAlbum> contacts = new List<CommunityAlbum>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityAlbumEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<CommunityAlbum>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<CommunityAlbum> GetCommunityAlbumById(int id)
		{
			CommunityAlbum CommunityAlbum = new CommunityAlbum();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityAlbumEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				CommunityAlbum = JsonSerializer.Deserialize<CommunityAlbum>(result, AppSettings.options)!;
			}
			return CommunityAlbum;
		}

		public async Task<CommunityAlbum> AddCommunityAlbum(CommunityAlbum CommunityAlbum)
		{
			CommunityAlbum CommunityAlbumDb = new CommunityAlbum();

			var data = JsonSerializer.Serialize(CommunityAlbum).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.CommunityAlbumEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				CommunityAlbumDb = JsonSerializer.Deserialize<CommunityAlbum>(result, AppSettings.options)!;
				return CommunityAlbumDb;
			}
			return CommunityAlbum;
		}

		public async Task<CommunityAlbum> UpdateCommunityAlbum(CommunityAlbum CommunityAlbum)
		{
			CommunityAlbum CommunityAlbumDb = new CommunityAlbum();
			var data = JsonSerializer.Serialize(CommunityAlbum).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.CommunityAlbumEndpoint + "/" + CommunityAlbum.CommunityAlbumId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityAlbumEndpoint + "/" + CommunityAlbum.CommunityAlbumId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				CommunityAlbumDb = JsonSerializer.Deserialize<CommunityAlbum>(result, AppSettings.options)!;
				return CommunityAlbumDb;
			}
			return CommunityAlbum;
		}

		public async Task<string> DeleteCommunityAlbum(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.CommunityAlbumEndpoint + "/" + id);
			return result;
		}
	}
}
