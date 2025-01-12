namespace Admin.YFC.Models
{
	public class Church
	{
		public int ChurchId { get; set; }
		public string Picture { get; set; } = default!;
		public string Title { get; set; } = default!;
		public string Description { get; set; } = default!;
		public string URL { get; set; } = default!;
	}
}
