using System.Text.Json;

namespace Web.YFC.Common
{
	public static class Config
	{
		private static IConfiguration configuration;
		static Config()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
			configuration = builder.Build();
		}

		public static string Get(string name)
		{
			string appSettings = configuration[name]!;
			return appSettings!;
		}
	}

	public static class AppSettings
	{
		public static string ApiUri = Config.Get("ApiUrl");
		public static string ApiKey = Config.Get("ApiKey");
		public static string ApiSecret = Config.Get("ApiSecret");
		public static string ImageUrl = Config.Get("ImageUrl");

		public static JsonSerializerOptions options = new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		};
	}

	public static class EndPoints
	{
		public static string UserEndpoint = "/Users";
		public static string EventEndpoint = "/Events";
		public static string HeadlineEndpoint = "/Headlines";
		public static string TeachingEndpoint = "/Teachings";
		public static string FileUploadEndpoint = "/FileUpload";
		public static string CommunityEndpoint = "/Communities";
		public static string MinistryEndpoint = "/Ministries";
		public static string ChurchEndpoint = "/Churches";
		public static string PastorEndpoint = "/Pastors";
		public static string PastorMessageEndpoint = "/PastorMessages";
		public static string SectionEndpoint = "/Sections";
		public static string ContentEndpoint = "/Contents";
		public static string TestimonialEndpoint = "/Testimonials";
		public static string CommunityInfoEndpoint = "/CommunityInfos";
		public static string CommunityArticleEndpoint = "/CommunityArticles";
		public static string CommunityEventEndpoint = "/CommunityEvents";
		public static string CommunityLeaderEndpoint = "/CommunityLeaders";
		public static string CommunityScheduleEndpoint = "/CommunitySchedules";
		public static string MinistryArticleEndpoint = "/MinistryArticles";
		public static string MinistryEventEndpoint = "/MinistryEvents";
		public static string MinistryInfoEndpoint = "/MinistryInfos";
		public static string MinistryLeaderEndpoint = "/MinistryLeaders";
		public static string MinistryScheduleEndpoint = "/MinistrySchedules";
		public static string CommunityAlbumEndpoint = "/CommunityAlbums";
		public static string MinistryAlbumEndpoint = "/MinistryAlbums";
	}
}
