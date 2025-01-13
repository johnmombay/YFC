using Admin.YFC.Common;
using Admin.YFC.Models;
using System.Text.Json;

namespace Admin.YFC.Services
{
	public class MinistryScheduleServices
	{
		public async Task<List<MinistrySchedule>> GetMinistrySchedules()
		{
			List<MinistrySchedule> contacts = new List<MinistrySchedule>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryScheduleEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<MinistrySchedule>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<MinistrySchedule> GetMinistryScheduleById(int id)
		{
			MinistrySchedule MinistrySchedule = new MinistrySchedule();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryScheduleEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistrySchedule = JsonSerializer.Deserialize<MinistrySchedule>(result, AppSettings.options)!;
			}
			return MinistrySchedule;
		}

		public async Task<MinistrySchedule> AddMinistrySchedule(MinistrySchedule MinistrySchedule)
		{
			MinistrySchedule MinistryScheduleDb = new MinistrySchedule();

			var data = JsonSerializer.Serialize(MinistrySchedule).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.MinistryScheduleEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistryScheduleDb = JsonSerializer.Deserialize<MinistrySchedule>(result, AppSettings.options)!;
				return MinistryScheduleDb;
			}
			return MinistrySchedule;
		}

		public async Task<MinistrySchedule> UpdateMinistrySchedule(MinistrySchedule MinistrySchedule)
		{
			MinistrySchedule MinistryScheduleDb = new MinistrySchedule();
			var data = JsonSerializer.Serialize(MinistrySchedule).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.MinistryScheduleEndpoint + "/" + MinistrySchedule.MinistryScheduleId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.MinistryScheduleEndpoint + "/" + MinistrySchedule.MinistryScheduleId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				MinistryScheduleDb = JsonSerializer.Deserialize<MinistrySchedule>(result, AppSettings.options)!;
				return MinistryScheduleDb;
			}
			return MinistrySchedule;
		}

		public async Task<string> DeleteMinistrySchedule(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.MinistryScheduleEndpoint + "/" + id);
			return result;
		}
	}
}
