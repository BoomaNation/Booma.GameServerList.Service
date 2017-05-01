using Booma.Payloads.ServerSelection;
using GladNet.ASP.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GladNet.Payload;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.Extensions.Logging;

namespace Booma.GameServerList.Lib
{
	/// <summary>
	/// Controller that handles GladNet <see cref="GameServerListRequestPayload"/>s.
	/// </summary>
	[PayloadRoute(typeof(GameServerListRequestPayload))]
	public class GameListRequestController : RequestController<GameServerListRequestPayload>
	{
		/// <summary>
		/// Gameserver details repo.
		/// </summary>
		private IGameServerDetailsRepositoryAsync gameserverDetailsRepoService { get;}

		private ILogger loggingService { get; }

		public GameListRequestController(IGameServerDetailsRepositoryAsync repo, ILogger<GameListRequestController> logger)
		{
			gameserverDetailsRepoService = repo;
			loggingService = logger;
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

			loggingService.LogCritical($"Found: {details.Count()}.");

			//Check if we have any servers
			if (details.Count() == 0)
				responseCode = GameServerListResponseCode.ServiceUnavailable;
			else
				responseCode = GameServerListResponseCode.Success;

			SimpleGameServerDetailsModel[] detailsList = details.Select(d => new SimpleGameServerDetailsModel(d.Name, IPAddress.Parse(d.Address), d.ServerPort, d.Region)).ToArray();

			loggingService.LogCritical($"Found: {detailsList.Count()}.");

			//Build a response payload and map the DB model to the wire-type model.
			return new GameServerListResponsePayload(responseCode, detailsList);
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			IEnumerable<GameServerDetailsModel> details = await gameserverDetailsRepoService.GetAllPublic();

			return new JsonResult(details);
		}
	}
}
