namespace Web.YFC.Models
{
	public class MinistryAlbum
	{
		public int MinistryAlbumId { get; set; }
		public string AlbumId { get; set; } = default!;
		public int MinistryId { get; set; }
		public Ministry? Ministry
		{
			get; set;
		}
	}
}
