using System.Text.Json;

namespace Admin.YFC.Common
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
		public static string InspirationEndpoint = "/Inspirations";
		public static string StatementEndpoint = "/Statements";
		public static string TeachingEndpoint = "/Teachings";
	}
}
