namespace Admin.YFC.Models
{
	public class Event
	{
		public int EventId {  get; set; }
		public string Title { get; set; } = default!;
		public string? Description { get; set; }
		public DateTime EventDate { get; set; }
		public string Picture { get; set; } = default!;
		public string Url { get; set; } = default!;
	}
}
