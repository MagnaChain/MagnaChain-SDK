using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLink.Payment
{
	public interface ISignatureChecker
	{
		bool VerifySignature(byte[] certificate, byte[] hash, string hashOID, byte[] signature);
	}
}
