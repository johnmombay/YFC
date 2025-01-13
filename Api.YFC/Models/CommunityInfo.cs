namespace Api.YFC.Models
{
	public class CommunityInfo
	{
		public int CommunityInfoId { get; set; }
		public int CommunityId { get; set; }
		public Community? Community { get; set; }
		public string Content { get; set; } = default!;
	}
}
