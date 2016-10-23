using UnityEngine;
using System.Collections.Generic;

namespace App
{

	public class BoardModel
	{
		/// <summary>
		/// The stock price table.
		/// </summary>
		public StockPriceTier[] PriceTable;

		/// <summary>
		/// The lowest stock price for each company type.
		/// This is used for certain game events where players need to sell at lowest price;
		/// </summary>
		public StockPriceTier LowestPrice;

		/// <summary>
		/// The board tiles.
		///  4 - Job tiles.
		/// 48 - Outer tiles around board edge.
		/// 36 - Share holder meeting tiles (4 groups of 9 meeting tiles).
		/// Equals 88 total game board tiles.
		/// </summary>
		public BoardTileModel[] BoardTiles;

		public BoardModel()
		{
		}

	}

}
