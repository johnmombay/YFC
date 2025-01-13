using Admin.YFC.Common;
using Admin.YFC.Models;
using System.Text.Json;

namespace Admin.YFC.Services
{
	public class CommunityScheduleServices
	{
		public async Task<List<CommunitySchedule>> GetCommunitySchedules()
		{
			List<CommunitySchedule> contacts = new List<CommunitySchedule>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityScheduleEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<CommunitySchedule>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<CommunitySchedule> GetCommunityScheduleById(int id)
		{
			CommunitySchedule CommunitySchedule = new CommunitySchedule();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityScheduleEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				CommunitySchedule = JsonSerializer.Deserialize<CommunitySchedule>(result, AppSettings.options)!;
			}
			return CommunitySchedule;
		}

		public async Task<CommunitySchedule> AddCommunitySchedule(CommunitySchedule CommunitySchedule)
		{
			CommunitySchedule CommunityScheduleDb = new CommunitySchedule();

			var data = JsonSerializer.Serialize(CommunitySchedule).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.CommunityScheduleEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				CommunityScheduleDb = JsonSerializer.Deserialize<CommunitySchedule>(result, AppSettings.options)!;
				return CommunityScheduleDb;
			}
			return CommunitySchedule;
		}

		public async Task<CommunitySchedule> UpdateCommunitySchedule(CommunitySchedule CommunitySchedule)
		{
			CommunitySchedule CommunityScheduleDb = new CommunitySchedule();
			var data = JsonSerializer.Serialize(CommunitySchedule).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.CommunityScheduleEndpoint + "/" + CommunitySchedule.CommunityScheduleId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.CommunityScheduleEndpoint + "/" + CommunitySchedule.CommunityScheduleId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				CommunityScheduleDb = JsonSerializer.Deserialize<CommunitySchedule>(result, AppSettings.options)!;
				return CommunityScheduleDb;
			}
			return CommunitySchedule;
		}

		public async Task<string> DeleteCommunitySchedule(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.CommunityScheduleEndpoint + "/" + id);
			return result;
		}
	}
}
