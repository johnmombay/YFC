using Admin.YFC.Common;
using Admin.YFC.Models;
using System.Text.Json;

namespace Admin.YFC.Services
{
	public class MinistryLeaderServices
	{
		public async Task<List<MinistryLeader>> GetMinistryLeaders()
		{
			List<MinistryLeader> contacts = new List<MinistryLeader>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryLeaderEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<MinistryLeader>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<MinistryLeader> GetMinistryLeaderById(int id)
		{
			MinistryLeader MinistryLeader = new MinistryLeader();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryLeaderEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistryLeader = JsonSerializer.Deserialize<MinistryLeader>(result, AppSettings.options)!;
			}
			return MinistryLeader;
		}

		public async Task<MinistryLeader> AddMinistryLeader(MinistryLeader MinistryLeader)
		{
			MinistryLeader MinistryLeaderDb = new MinistryLeader();

			var data = JsonSerializer.Serialize(MinistryLeader).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.MinistryLeaderEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistryLeaderDb = JsonSerializer.Deserialize<MinistryLeader>(result, AppSettings.options)!;
				return MinistryLeaderDb;
			}
			return MinistryLeader;
		}

		public async Task<MinistryLeader> UpdateMinistryLeader(MinistryLeader MinistryLeader)
		{
			MinistryLeader MinistryLeaderDb = new MinistryLeader();
			var data = JsonSerializer.Serialize(MinistryLeader).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.MinistryLeaderEndpoint + "/" + MinistryLeader.MinistryLeaderId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryLeaderEndpoint + "/" + MinistryLeader.MinistryLeaderId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistryLeaderDb = JsonSerializer.Deserialize<MinistryLeader>(result, AppSettings.options)!;
				return MinistryLeaderDb;
			}
			return MinistryLeader;
		}

		public async Task<string> DeleteMinistryLeader(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.MinistryLeaderEndpoint + "/" + id);
			return result;
		}
	}
}
