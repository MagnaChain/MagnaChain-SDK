using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLink.Protocol
{
	/// <summary>
	/// Ask for known peer addresses in the network
	/// </summary>
	[Payload("getaddr")]
	public class GetAddrPayload : Payload
	{
	}
}
