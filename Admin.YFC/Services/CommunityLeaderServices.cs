using Admin.YFC.Common;
using Admin.YFC.Models;
using System.Text.Json;

namespace Admin.YFC.Services
{
	public class CommunityLeaderServices
	{
		public async Task<List<CommunityLeader>> GetCommunityLeaders()
		{
			List<CommunityLeader> contacts = new List<CommunityLeader>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityLeaderEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<CommunityLeader>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<CommunityLeader> GetCommunityLeaderById(int id)
		{
			CommunityLeader CommunityLeader = new CommunityLeader();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityLeaderEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				CommunityLeader = JsonSerializer.Deserialize<CommunityLeader>(result, AppSettings.options)!;
			}
			return CommunityLeader;
		}

		public async Task<CommunityLeader> AddCommunityLeader(CommunityLeader CommunityLeader)
		{
			CommunityLeader CommunityLeaderDb = new CommunityLeader();

			var data = JsonSerializer.Serialize(CommunityLeader).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.CommunityLeaderEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				CommunityLeaderDb = JsonSerializer.Deserialize<CommunityLeader>(result, AppSettings.options)!;
				return CommunityLeaderDb;
			}
			return CommunityLeader;
		}

		public async Task<CommunityLeader> UpdateCommunityLeader(CommunityLeader CommunityLeader)
		{
			CommunityLeader CommunityLeaderDb = new CommunityLeader();
			var data = JsonSerializer.Serialize(CommunityLeader).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.CommunityLeaderEndpoint + "/" + CommunityLeader.CommunityLeaderId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityLeaderEndpoint + "/" + CommunityLeader.CommunityLeaderId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				CommunityLeaderDb = JsonSerializer.Deserialize<CommunityLeader>(result, AppSettings.options)!;
				return CommunityLeaderDb;
			}
			return CommunityLeader;
		}

		public async Task<string> DeleteCommunityLeader(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.CommunityLeaderEndpoint + "/" + id);
			return result;
		}
	}
}
