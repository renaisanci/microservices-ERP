using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace DBCorp.ControleAcesso.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
			.ConfigureAppConfiguration((hostingContext, config) =>
			{
				var env = hostingContext.HostingEnvironment;

				// find the shared folder in the parent folder
				var sharedSettingsPath = Path.Combine(env.ContentRootPath, "..\\..\\..\\", "sharedsettings.json");

				config.AddJsonFile(sharedSettingsPath);
				config.AddJsonFile("appsettings.json");
				config.AddEnvironmentVariables();
			})
			 .UseUrls("http://localhost:9001")
				.UseStartup<Startup>();
	}
}
