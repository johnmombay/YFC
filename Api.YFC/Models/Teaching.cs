namespace Api.YFC.Models
{
	public class Teaching
	{
		public int TeachingId { get; set; }
		public string Title { get; set; } = default!;
		public string Speaker {  get; set; } = default!;
		public DateTime TeachingDate { get; set; }
		public string Picture {  get; set; } = default!;
		public string Video { get; set; } = default!;
		public string? Audio { get; set; }
		public string? PDF { get; set; }
	}
}
