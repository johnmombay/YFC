namespace Admin.YFC.ViewModels
{
	public class MinistryEventViewModel
	{
		public int MinistryEventId { get; set; }
		public int MinistryId { get; set; }
		public string? Ministry { get; set; }
		public string? Picture { get; set; }
		public string Title { get; set; } = default!;
		public string Description { get; set; } = default!;
		public DateTime EventDate { get; set; }
	}
}
