using Web.YFC.Common;
using Web.YFC.Models;
using System.Text.Json;

namespace Web.YFC.Services
{
	public class SectionServices
	{
		public async Task<List<Section>> GetMinistries()
		{
			List<Section> contacts = new List<Section>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.SectionEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<Section>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<Section> GetSectionById(int id)
		{
			Section Section = new Section();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.SectionEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				Section = JsonSerializer.Deserialize<Section>(result, AppSettings.options)!;
			}
			return Section;
		}

		public async Task<Section> AddSection(Section Section)
		{
			Section SectionDb = new Section();

			var data = JsonSerializer.Serialize(Section).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.SectionEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				SectionDb = JsonSerializer.Deserialize<Section>(result, AppSettings.options)!;
				return SectionDb;
			}
			return Section;
		}

		public async Task<Section> UpdateSection(Section Section)
		{
			Section SectionDb = new Section();
			var data = JsonSerializer.Serialize(Section).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.SectionEndpoint + "/" + Section.SectionId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.SectionEndpoint + "/" + Section.SectionId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				SectionDb = JsonSerializer.Deserialize<Section>(result, AppSettings.options)!;
				return SectionDb;
			}
			return Section;
		}

		public async Task<string> DeleteSection(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.SectionEndpoint + "/" + id);
			return result;
		}
	}
}
