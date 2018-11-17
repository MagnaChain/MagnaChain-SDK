using System.Threading.Tasks;

namespace CellLink
{
	public interface IBlockRepository
	{
		Task<Block> GetBlockAsync(uint256 blockId);
	}
}
