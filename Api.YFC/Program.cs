using Api.YFC.Data;
using Api.YFC.Middleware;
using Api.YFC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
	options.Password.RequireDigit = false;
	options.Password.RequireLowercase = false;
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequiredLength = 1;
	options.Password.RequireUppercase = false;
})
	.AddDefaultTokenProviders()
	.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "YFC API", Version = "v1" });
	c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
	{
		Description = "ApiKey must appear in header",
		Type = SecuritySchemeType.ApiKey,
		Name = "YFC",
		In = ParameterLocation.Header,
		Scheme = "ApiKeyScheme"
	});
	var key = new OpenApiSecurityScheme()
	{
		Reference = new OpenApiReference
		{
			Type = ReferenceType.SecurityScheme,
			Id = "ApiKey"
		},
		In = ParameterLocation.Header
	};
	var requirement = new OpenApiSecurityRequirement
		{
			{ key, new List<string>() }
		};
	c.AddSecurityRequirement(requirement);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllers();

app.Run();
