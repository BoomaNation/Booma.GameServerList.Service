using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booma.GameServerList.Lib
{
	/// <summary>
	/// Flags indicating the server type.
	/// </summary>
	public enum ServerStatus : int
	{
		Offline = 1 << 0,
		Online = 1 << 1,
		Public = 1 << 2,
		Test = 1 << 3,
		Private = 1 << 4
	}
}
