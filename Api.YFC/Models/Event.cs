namespace Api.YFC.Models
{
	public class Event
	{
		public int EventId {  get; set; }
		public DateTime From { get; set; }
		public DateTime To { get; set; }
		public string Title { get; set; } = default!;
		public string? Description { get; set; }
		public string Image { get; set; } = default!;
		public string Url { get; set; } = default!;

	}
}
