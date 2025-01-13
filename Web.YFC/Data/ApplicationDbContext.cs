using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web.YFC.Models;

namespace Web.YFC.Data
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
		public DbSet<Teaching> Teachings { get; set; }
		public DbSet<Community> Communities { get; set; }
		public DbSet<Ministry> Ministries { get; set; }
		public DbSet<Church> Churches { get; set; }
		public DbSet<PastorMessage> PastorMessages { get; set; }
		public DbSet<Pastor> Pastors { get; set; }
		public DbSet<Section> Sections { get; set; }
		public DbSet<Content> Contents { get; set; }
		public DbSet<Testimonial> Testimonials { get; set; }
	}
}
