using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

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

		}
	}
}
