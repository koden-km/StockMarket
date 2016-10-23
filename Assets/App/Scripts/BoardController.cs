using UnityEngine;
using System.Collections.Generic;

namespace App
{

	public class BoardController
	{
		private BoardModel m_BoardModel;

		//public BoardController(BoardModel boardModel, GameOptions options)
		public BoardController(BoardModel boardModel, GameModel gameModel)
		{
			m_BoardModel = boardModel;

			SetupStockPriceTable();

			m_BoardModel.BoardTiles = new BoardTileModel[88];

			// Setup job tiles ...
			m_BoardModel.BoardTiles[0] = BoardTileModel.CreateJob(TileType.Job, JobType.Worker100, gameModel);
			m_BoardModel.BoardTiles[1] = BoardTileModel.CreateJob(TileType.Job, JobType.Worker200, gameModel);
			m_BoardModel.BoardTiles[2] = BoardTileModel.CreateJob(TileType.Job, JobType.Worker300, gameModel);
			m_BoardModel.BoardTiles[3] = BoardTileModel.CreateJob(TileType.Job, JobType.Worker400, gameModel);

			// Setup game board trader tiles ...
			// TODO, set them up clockwise or counter-clockwise starting at the stock price UP.

			// Setup share holder meeting tiles ...
			// TODO, set them up in the same direction as board trader tiles.
		}

		public StockPriceTier StockPriceAtIndex(int index)
		{
			return m_BoardModel.PriceTable[index];
		}

		public StockPriceTier StockPriceAtLowest()
		{
			return m_BoardModel.LowestPrice;
		}

		private void SetupStockPriceTable()
		{
			int[,] priceTiers = PriceListTiers();
			int count = priceTiers.Length;

			int[] prices;
			int iAlpha;
			int iOmega;

			m_BoardModel.PriceTable = new StockPriceTier[count];  // 51 tiers on original board.

			for (int i = 0; i < count; i++) {
				// 8 companies (4 on each side of board).
				prices = new int[8];

				// Alpha (normal direction)
				iAlpha = i;
				prices[0] = priceTiers[iAlpha, 0];
				prices[1] = priceTiers[iAlpha, 1];
				prices[2] = priceTiers[iAlpha, 2];
				prices[3] = priceTiers[iAlpha, 3];
				// Omega (inverted direction)
				iOmega = count - 1 - i;
				prices[4] = priceTiers[iOmega, 0];
				prices[5] = priceTiers[iOmega, 1];
				prices[6] = priceTiers[iOmega, 2];
				prices[7] = priceTiers[iOmega, 3];

				m_BoardModel.PriceTable[i] = new StockPriceTier(prices);
			}

			// 8 companies (4 on each side of board).
			prices = new int[8];

			// Alpha (normal direction)
			iAlpha = 0;
			prices[0] = priceTiers[iAlpha, 0];
			prices[1] = priceTiers[iAlpha, 1];
			prices[2] = priceTiers[iAlpha, 2];
			prices[3] = priceTiers[iAlpha, 3];
			// Omega (inverted direction)
			iOmega = count - 1;
			prices[4] = priceTiers[iOmega, 0];
			prices[5] = priceTiers[iOmega, 1];
			prices[6] = priceTiers[iOmega, 2];
			prices[7] = priceTiers[iOmega, 3];
			m_BoardModel.LowestPrice = new StockPriceTier(prices);
		}

		/// <summary>
		/// Price list tiers.
		/// Only one side of the table is needed, the other side is inverted.
		/// </summary>
		/// <returns>The list tiers.</returns>
		private int[,] PriceListTiers()
		{
			// Company Type column order: A, B, C, D
			return new int[,] {
				{ 30, 10, 15, 18 },
				{ 34, 12, 16, 18 },
				{ 38, 14, 17, 19 },
				{ 42, 16, 18, 19 },
				{ 46, 18, 19, 20 },
				{ 50, 20, 20, 20 },
				{ 54, 22, 21, 21 },
				{ 58, 24, 22, 21 },
				{ 62, 26, 23, 22 },
				{ 66, 28, 24, 22 },
				{ 70, 30, 25, 23 },
				{ 74, 32, 26, 23 },
				{ 78, 34, 27, 24 },
				{ 82, 36, 28, 24 },
				{ 86, 38, 29, 25 },
				{ 90, 40, 30, 25 },
				{ 94, 42, 31, 26 },
				{ 98, 44, 32, 26 },
				{ 102, 46, 33, 27 },
				{ 106, 48, 34, 27 },
				{ 110, 50, 35, 28 },
				{ 114, 52, 36, 28 },
				{ 118, 54, 37, 29 },
				{ 122, 56, 38, 29 },
				{ 126, 58, 39, 30 },
				{ 130, 60, 40, 30 },
				{ 134, 62, 41, 31 },
				{ 138, 64, 42, 31 },
				{ 142, 66, 43, 32 },
				{ 146, 68, 44, 32 },
				{ 150, 70, 45, 33 },
				{ 154, 72, 46, 33 },
				{ 158, 74, 47, 34 },
				{ 162, 76, 48, 34 },
				{ 166, 78, 49, 35 },
				{ 170, 80, 50, 35 },
				{ 174, 82, 51, 36 },
				{ 178, 84, 52, 36 },
				{ 182, 86, 53, 37 },
				{ 186, 88, 54, 37 },
				{ 190, 90, 55, 38 },
				{ 194, 92, 56, 38 },
				{ 198, 94, 57, 39 },
				{ 202, 96, 58, 39 },
				{ 206, 98, 59, 40 },
				{ 210, 100, 60, 40 },
				{ 214, 102, 61, 41 },
				{ 218, 104, 62, 41 },
				{ 222, 106, 63, 42 },
				{ 226, 108, 64, 42 },
				{ 230, 110, 65, 43 },
			};
		}

	}

}
