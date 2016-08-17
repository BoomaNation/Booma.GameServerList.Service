using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booma.GameServerList.Lib
{
	public class GameServerDetailsRepository : IGameServerDetailsRepositoryAsync
	{
		/// <summary>
		/// Database context.
		/// </summary>
		private GameServerListDbContext gameserverListContext { get; }

		/// <summary>
		/// Creates a new gameserver repo.
		/// </summary>
		/// <param name="context">Database context.</param>
		public GameServerDetailsRepository(GameServerListDbContext context)
		{
			gameserverListContext = context;
		}

		public async Task<IEnumerable<GameServerDetailsModel>> GetAllPublic()
		{
			return await gameserverListContext.GameServers
				.ToAsyncEnumerable()
				.Where(gs => gs.Status.HasFlag(ServerStatus.Public | ServerStatus.Online)) //select online public servers
				.ToList();
		}
	}
}
