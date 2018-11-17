﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellLink.BitcoinCore
{
	public interface IBlockProvider
	{
		Block GetBlock(uint256 id, List<byte[]> searchedData);
	}
}
