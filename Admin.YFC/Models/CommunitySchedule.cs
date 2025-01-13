namespace Admin.YFC.Models
{
	public class CommunitySchedule
	{
		public int CommunityScheduleId { get; set; }
		public int CommunityId { get; set; }
		public Community? Community { get; set; }
		public string Title { get; set; } = default!;
		public string Description { get; set; } = default!;
		public string Day { get; set; } = default!;		
		public DateTime Time { get; set; } = default!;
	}
}
