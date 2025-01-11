namespace Admin.YFC.Models
{
	public class Ministry
	{
		public int MinistryId { get; set; }
		public string Name { get; set; } = default!;
		public bool Enabled { get; set; }
		public virtual ICollection<MinistryInfo>? MinistryInfos { get; set; }
	}
}
