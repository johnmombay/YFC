namespace Admin.YFC.Models
{
	public class MinistrySchedule
	{
		public int MinistryScheduleId { get; set; }
		public int MinistryId { get; set; }
		public Ministry? Ministry { get; set; }
		public string Title { get; set; } = default!;
		public string Description { get; set; } = default!;
		public string Day { get; set; } = default!;
		public DateTime Time { get; set; } = default!;
	}
}
