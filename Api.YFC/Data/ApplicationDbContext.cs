using Api.YFC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.YFC.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<Gallery> Galleries { get; set; }
		public DbSet<Headline> Headlines { get; set; }
		public DbSet<Statement> Statements { get; set; }
		public DbSet<Contact> Contacts { get; set; }
	}
}
