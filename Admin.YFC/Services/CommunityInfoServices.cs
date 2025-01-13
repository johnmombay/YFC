using Admin.YFC.Common;
using Admin.YFC.Models;
using System.Text.Json;

namespace Admin.YFC.Services
{
	public class CommunityInfoServices
	{
		public async Task<List<CommunityInfo>> GetCommunityInfos()
		{
			List<CommunityInfo> contacts = new List<CommunityInfo>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityInfoEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<CommunityInfo>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<CommunityInfo> GetCommunityInfoById(int id)
		{
			CommunityInfo CommunityInfo = new CommunityInfo();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityInfoEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				CommunityInfo = JsonSerializer.Deserialize<CommunityInfo>(result, AppSettings.options)!;
			}
			return CommunityInfo;
		}

		public async Task<CommunityInfo> AddCommunityInfo(CommunityInfo CommunityInfo)
		{
			CommunityInfo CommunityInfoDb = new CommunityInfo();

			var data = JsonSerializer.Serialize(CommunityInfo).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.CommunityInfoEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				CommunityInfoDb = JsonSerializer.Deserialize<CommunityInfo>(result, AppSettings.options)!;
				return CommunityInfoDb;
			}
			return CommunityInfo;
		}

		public async Task<CommunityInfo> UpdateCommunityInfo(CommunityInfo CommunityInfo)
		{
			CommunityInfo CommunityInfoDb = new CommunityInfo();
			var data = JsonSerializer.Serialize(CommunityInfo).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.CommunityInfoEndpoint + "/" + CommunityInfo.CommunityInfoId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityInfoEndpoint + "/" + CommunityInfo.CommunityInfoId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				CommunityInfoDb = JsonSerializer.Deserialize<CommunityInfo>(result, AppSettings.options)!;
				return CommunityInfoDb;
			}
			return CommunityInfo;
		}

		public async Task<string> DeleteCommunityInfo(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.CommunityInfoEndpoint + "/" + id);
			return result;
		}
	}
}
