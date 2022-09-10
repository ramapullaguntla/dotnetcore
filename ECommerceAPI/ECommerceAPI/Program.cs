using ECommerce.EFCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI
{
	public class Program
	{
		static private IConfiguration Configuration { get; set; }

		public static void Main(string[] args)
		{
			//CreateHostBuilder(args).Build().Run();

			IHostBuilder host = null;
			try
			{
				host = CreateHostBuilder(args);

				Configuration = new ConfigurationBuilder()
					.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
					.AddEnvironmentVariables()
					.Build();

				migrateDatabase();

				host.Build().Run();
			}
			catch (Exception ex)
			{
				//Log.Logger?.Fatal(ex, "Host terminated unexpectedly");
			}
			finally
			{
				
				
			}
		}

		private static void migrateDatabase()
		{
			ECommerceContext dbContext = new ECommerceContext(Configuration.GetConnectionString("default"));
			dbContext.Database.Migrate();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
