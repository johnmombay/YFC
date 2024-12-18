using Microsoft.AspNetCore.Identity;

namespace Api.YFC.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string Firstname { get; set; } = default!;
		public string Lastname { get; set; } = default!;
	}
}
