using Admin.YFC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Admin.YFC.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<Headline> Headlines { get; set; }
		public DbSet<Inspiration> Inspirations { get; set; }
		public DbSet<Statement> Statements { get; set; }
		public DbSet<Teaching> Teachings { get; set; }
	}
}
