using Admin.YFC.Data;
using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<EventServices, EventServices>();
builder.Services.AddScoped<HeadlineServices, HeadlineServices>();
builder.Services.AddScoped<TeachingServices, TeachingServices>();
builder.Services.AddScoped<UserServices, UserServices>();
builder.Services.AddScoped<FileUploadServices, FileUploadServices>();
builder.Services.AddScoped<CommunityServices, CommunityServices>();
builder.Services.AddScoped<MinistryServices, MinistryServices>();
builder.Services.AddScoped<ContentServices, ContentServices>();
builder.Services.AddScoped<ChurchServices, ChurchServices>();
builder.Services.AddScoped<PastorServices, PastorServices>();
builder.Services.AddScoped<SectionServices, SectionServices>();
builder.Services.AddScoped<PastorMessageServices, PastorMessageServices>();
builder.Services.AddScoped<TestimonialServices, TestimonialServices>();
builder.Services.AddScoped<CommunityArticleServices, CommunityArticleServices>();
builder.Services.AddScoped<CommunityEventServices, CommunityEventServices>();
builder.Services.AddScoped<CommunityInfoServices, CommunityInfoServices>();
builder.Services.AddScoped<CommunityLeaderServices, CommunityLeaderServices>();
builder.Services.AddScoped<CommunityScheduleServices, CommunityScheduleServices>();
builder.Services.AddScoped<MinistryArticleServices, MinistryArticleServices>();
builder.Services.AddScoped<MinistryEventServices, MinistryEventServices>();
builder.Services.AddScoped<MinistryInfoServices, MinistryInfoServices>();
builder.Services.AddScoped<MinistryLeaderServices, MinistryLeaderServices>();
builder.Services.AddScoped<MinistryScheduleServices, MinistryScheduleServices>();
builder.Services.AddScoped<TestimonialServices, TestimonialServices>();
builder.Services.AddScoped<MinistryAlbumServices, MinistryAlbumServices>();
builder.Services.AddScoped<CommunityAlbumServices, CommunityAlbumServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}")
	.WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
