using Admin.YFC.Common;
using Admin.YFC.Models;
using System.Text.Json;

namespace Admin.YFC.Services
{
	public class TestimonialServices
	{
		public async Task<List<Testimonial>> GetTestimonials()
		{
			List<Testimonial> contacts = new List<Testimonial>();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.TestimonialEndpoint);
			if (!string.IsNullOrWhiteSpace(result))
			{
				contacts = JsonSerializer.Deserialize<List<Testimonial>>(result, AppSettings.options)!;
			}
			return contacts;
		}

		public async Task<Testimonial> GetTestimonialById(int id)
		{
			Testimonial Testimonial = new Testimonial();

			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.TestimonialEndpoint + "/" + id);
			if (!string.IsNullOrWhiteSpace(result))
			{
				Testimonial = JsonSerializer.Deserialize<Testimonial>(result, AppSettings.options)!;
			}
			return Testimonial;
		}

		public async Task<Testimonial> AddTestimonial(Testimonial Testimonial)
		{
			Testimonial TestimonialDb = new Testimonial();

			var data = JsonSerializer.Serialize(Testimonial).ToString();
			var result = await RestCall.Post(AppSettings.ApiUri + EndPoints.TestimonialEndpoint, data);
			if (!string.IsNullOrWhiteSpace(result))
			{
				TestimonialDb = JsonSerializer.Deserialize<Testimonial>(result, AppSettings.options)!;
				return TestimonialDb;
			}
			return Testimonial;
		}

		public async Task<Testimonial> UpdateTestimonial(Testimonial Testimonial)
		{
			Testimonial TestimonialDb = new Testimonial();
			var data = JsonSerializer.Serialize(Testimonial).ToString();
			await RestCall.Put(AppSettings.ApiUri + EndPoints.TestimonialEndpoint + "/" + Testimonial.TestimonialId, data);
			var result = await RestCall.Get(AppSettings.ApiUri + EndPoints.TestimonialEndpoint + "/" + Testimonial.TestimonialId);
			if (!string.IsNullOrWhiteSpace(result))
			{
				TestimonialDb = JsonSerializer.Deserialize<Testimonial>(result, AppSettings.options)!;
				return TestimonialDb;
			}
			return Testimonial;
		}

		public async Task<string> DeleteTestimonial(int id)
		{
			var result = await RestCall.Remove(AppSettings.ApiUri + EndPoints.TestimonialEndpoint + "/" + id);
			return result;
		}
	}
}
