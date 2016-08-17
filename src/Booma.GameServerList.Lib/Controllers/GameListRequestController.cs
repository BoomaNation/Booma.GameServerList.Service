using Booma.Payloads.ServerSelection;
using GladNet.ASP.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GladNet.Payload;

namespace Booma.GameServerList.Lib
{
	/// <summary>
	/// Controller that handles GladNet <see cref="GameServerListRequestPayload"/>s.
	/// </summary>
	public class GameListRequestController : RequestController<GameServerListRequestPayload>
	{
		/// <summary>
		/// Gameserver details repo.
		/// </summary>
		private IGameServerDetailsRepositoryAsync gameserverDetailsRepoService { get;}

		public GameListRequestController(IGameServerDetailsRepositoryAsync repo)
		{
			gameserverDetailsRepoService = repo;
		}

		/// <summary>
		/// Called by GladNet when a <see cref="GameServerListRequestPayload"/> is recieved by the
		/// ASP controller.
		/// </summary>
		/// <param name="payloadInstance"></param>
		/// <returns>A <see cref="GameServerListResponsePayload"/>.</returns>
		public override async Task<PacketPayload> HandlePost(GameServerListRequestPayload payloadInstance)
		{
			GameServerListResponseCode responseCode = GameServerListResponseCode.Unknown;

			IEnumerable<GameServerDetailsModel> details = await gameserverDetailsRepoService.GetAllPublic();

			//Check if we have any servers
			if (details.Count() == 0)
				responseCode = GameServerListResponseCode.ServiceUnavailable;
			else
				responseCode = GameServerListResponseCode.Success;

			//Build a response payload and map the DB model to the wire-type model.
			return new GameServerListResponsePayload(responseCode, details.Select(d => new SimpleGameServerDetailsModel(d.Name, d.Address, d.ServerPort, d.Region)));
		}
	}
}
