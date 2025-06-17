namespace Admin.YFC.ViewModels
{
	public class MinistryScheduleViewModel
	{
		public int MinistryScheduleId { get; set; }
		public int MinistryId { get; set; }
		public string? Ministry { get; set; }
		public string Title { get; set; } = default!;
		public string Description { get; set; } = default!;
		public string Day { get; set; } = default!;
		public DateTime Time { get; set; } = default!;
	}
}
