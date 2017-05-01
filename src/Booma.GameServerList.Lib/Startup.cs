using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using GladNet.Serializer;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Booma.GameServerList.Lib;
using Microsoft.EntityFrameworkCore;

namespace GladLive.ModuleService.ASP
{
	//Uncomment for migrations
	/*public class Startup
	{

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddEntityFramework()
				.AddDbContext<GameServerListDbContext>(options =>
				{
					options.UseSqlServer(@"Server=Glader-PC;Database=ASPTEST;Trusted_Connection=True;");
				});
		}

		//This changed in RTM. Fluently build and setup the web hosting
		public static void Main(string[] args)
		{
			new WebHostBuilder()
			.UseStartup<Startup>()
			.Build()
			.Run();
		}
	}*/
}
