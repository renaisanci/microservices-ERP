using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace CRM.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			BuildWebHost(args).Run();
		}

		public static IWebHost BuildWebHost(string[] args) =>
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
			.UseStartup<Startup>()
			.UseUrls("http://localhost:9003")
			.Build();
	}
}
