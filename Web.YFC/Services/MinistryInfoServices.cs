using Web.YFC.Common;
using Web.YFC.Models;
using System.Text.Json;

namespace Web.YFC.Services
{
	public class MinistryInfoServices
	{
		public async Task<List<MinistryInfo>> GetMinistryInfos()
		{
			List<MinistryInfo> contacts = new List<MinistryInfo>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryInfoEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<MinistryInfo>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<MinistryInfo> GetMinistryInfoById(int id)
		{
			MinistryInfo MinistryInfo = new MinistryInfo();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryInfoEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistryInfo = JsonSerializer.Deserialize<MinistryInfo>(result, AppSettings.options)!;
			}
			return MinistryInfo;
		}

		public async Task<MinistryInfo> GetMinistryInfoByMinistryId(int id)
		{
			MinistryInfo MinistryInfo = new MinistryInfo();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryInfoEndpoint + "/GetMinistryInfoByMinistryId/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistryInfo = JsonSerializer.Deserialize<MinistryInfo>(result, AppSettings.options)!;
			}
			return MinistryInfo;
		}

		public async Task<MinistryInfo> AddMinistryInfo(MinistryInfo MinistryInfo)
		{
			MinistryInfo MinistryInfoDb = new MinistryInfo();

			var data = JsonSerializer.Serialize(MinistryInfo).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.MinistryInfoEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistryInfoDb = JsonSerializer.Deserialize<MinistryInfo>(result, AppSettings.options)!;
				return MinistryInfoDb;
			}
			return MinistryInfo;
		}

		public async Task<MinistryInfo> UpdateMinistryInfo(MinistryInfo MinistryInfo)
		{
			MinistryInfo MinistryInfoDb = new MinistryInfo();
			var data = JsonSerializer.Serialize(MinistryInfo).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.MinistryInfoEndpoint + "/" + MinistryInfo.MinistryInfoId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryInfoEndpoint + "/" + MinistryInfo.MinistryInfoId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistryInfoDb = JsonSerializer.Deserialize<MinistryInfo>(result, AppSettings.options)!;
				return MinistryInfoDb;
			}
			return MinistryInfo;
		}

		public async Task<string> DeleteMinistryInfo(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.MinistryInfoEndpoint + "/" + id);
			return result;
		}
	}
}
