using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLink.Payment
{
	public interface ISigner
	{
		byte[] Sign(object certificate, byte[] hash, string hashOID);
		byte[] StripPrivateKey(object certificate);
	}
}
