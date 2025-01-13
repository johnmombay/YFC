namespace Api.YFC.Models
{
	public class Testimonial
	{
		public int TestimonialId { get; set; }
		public string Author { get; set; } = default!;
		public string Content { get; set; } = default!;
	}
}
