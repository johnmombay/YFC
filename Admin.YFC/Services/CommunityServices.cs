using Admin.YFC.Common;
using Admin.YFC.Models;
using System.Text.Json;

namespace Admin.YFC.Services
{
	public class CommunityServices
	{
		public async Task<List<Community>> GetCommunities()
		{
			List<Community> contacts = new List<Community>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<Community>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<Community> GetCommunityById(int id)
		{
			Community Community = new Community();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				Community = JsonSerializer.Deserialize<Community>(result, AppSettings.options)!;
			}
			return Community;
		}

		public async Task<Community> AddCommunity(Community Community)
		{
			Community CommunityDb = new Community();

			var data = JsonSerializer.Serialize(Community).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.CommunityEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				CommunityDb = JsonSerializer.Deserialize<Community>(result, AppSettings.options)!;
				return CommunityDb;
			}
			return Community;
		}

		public async Task<Community> UpdateCommunity(Community Community)
		{
			Community CommunityDb = new Community();
			var data = JsonSerializer.Serialize(Community).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.CommunityEndpoint + "/" + Community.CommunityId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityEndpoint + "/" + Community.CommunityId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				CommunityDb = JsonSerializer.Deserialize<Community>(result, AppSettings.options)!;
				return CommunityDb;
			}
			return Community;
		}

		public async Task<string> DeleteCommunity(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.CommunityEndpoint + "/" + id);
			return result;
		}
	}
}
