namespace Api.YFC.Models
{
	public class CommunityEvent
	{
		public int CommunityEventId { get; set; }
		public int CommunityId { get; set; }
		public Community? Community { get; set; }
		public string? Picture { get; set; }
		public string Title { get; set; } = default!;
		public string Description { get; set; } = default!;
		public DateTime EventDate { get; set; }
	}
}
