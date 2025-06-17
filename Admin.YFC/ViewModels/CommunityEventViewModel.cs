namespace Admin.YFC.ViewModels
{
	public class CommunityEventViewModel
	{
		public int CommunityEventId { get; set; }
		public int CommunityId { get; set; }
		public string? Community { get; set; }
		public string? Picture { get; set; }
		public string Title { get; set; } = default!;
		public string Description { get; set; } = default!;
		public DateTime EventDate { get; set; }
	}
}
