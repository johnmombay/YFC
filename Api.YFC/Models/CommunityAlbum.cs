namespace Api.YFC.Models
{
	public class CommunityAlbum
	{
		public int CommunityAlbumId { get; set; }
		public string AlbumId { get; set; } = default!;
		public int CommunityId { get; set; }
		public Community? Community { get; set; }
	}
}
