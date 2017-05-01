using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using System.Net;

namespace Booma.GameServerList.Lib
{
	/// <summary>
	/// Context for the gameserver list.
	/// </summary>
	public class GameServerListDbContext : DbContext
	{
		/// <summary>
		/// The available gameservers.
		/// </summary>
		public DbSet<GameServerDetailsModel> GameServers { get; private set; }

		public GameServerListDbContext(DbContextOptions options) 
			: base(options)
		{
			//Uncomment for test
			if (GameServers.Count() < 1)
			{
				GameServers.Add(new GameServerDetailsModel() { Address = IPAddress.Any.ToString(), Name = "Test", Region = Common.ServerSelection.ServerRegion.CN, ServerPort = 55, Status = ServerStatus.Online | ServerStatus.Public });
				SaveChanges();
			}				
		}
	}
}
