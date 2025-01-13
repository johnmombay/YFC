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
		public DbSet<CommunityInfo> CommunityInfos { get; set; }
		public DbSet<MinistryInfo> MinistryInfos { get; set; }
		public DbSet<MinistryArticle> MinistryArticles { get; set; }
		public DbSet<CommunityArticle> CommunityArticles { get; set; }
		public DbSet<CommunityLeader> CommunityLeaders { get; set; }
		public DbSet<MinistryLeader> MinistryLeaders { get; set; }
		public DbSet<CommunitySchedule> CommunitySchedules { get; set; }
		public DbSet<MinistrySchedule> MinistrySchedules { get; set; }
		public DbSet<CommunityEvent> CommunityEvents { get; set; }
		public DbSet<MinistryEvent> MinistryEvents { get; set; }
	}
}
