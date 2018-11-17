using System.IO;

namespace CellLink.BouncyCastle.Asn1
{
	internal interface Asn1OctetStringParser
		: IAsn1Convertible
	{
		Stream GetOctetStream();
	}
}
