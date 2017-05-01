using Booma.GameServerList.Lib;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Booma.GameServerList.Module
{
	public class ControllerRegistry : IApplicationFeatureProvider<ControllerFeature>
	{
		public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
		{
			feature.Controllers.Add(typeof(GameListRequestController).GetTypeInfo());
		}
	}
}
