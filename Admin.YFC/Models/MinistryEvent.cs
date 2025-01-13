namespace Admin.YFC.Models
{
	public class MinistryEvent
	{
		public int MinistryEventId { get; set; }
		public int MinistryId { get; set; }
		public Ministry? Ministry { get; set; }
		public string? Picture { get; set; }
		public string Title { get; set; } = default!;
		public string Description { get; set; } = default!;
		public DateTime EventDate { get; set; }
	}
}
