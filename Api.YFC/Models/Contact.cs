namespace Api.YFC.Models
{
	public class Contact
	{
		public int ContactId { get; set; }
		public DateTime ContactDate { get; set; } 
		public string Name { get; set; } = default!;
		public string Email { get; set; } = default!;
		public string Message { get; set; } = default!;
	}
}
