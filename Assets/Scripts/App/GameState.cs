//using UnityEngine;
using System.Collections.Generic;

namespace App
{

	public class GameState
	{
		public BoardManager Board;
		public GameOptions Options;

		public int ActivePlayer = 0;
		public List<PlayerController> Players = new List<PlayerController>();

		//public Dictionary<JobType,string> JobNames = new Dictionary<JobType, string>();
		//public Dictionary<CompanyType,string> CompanyNames = new Dictionary<CompanyType, string>();

		/// <summary>
		/// The current index of the stock price.
		/// </summary>
		public int PriceIndex = 26;

		/// <summary>
		/// The price index change amount.
		/// A negative value will go down, a positive value will go up.
		/// If the index hits the end it should invert +/- and continue in other direction.
		/// </summary>
		public int PriceIndexChange = 0;

		/// <summary>
		/// The stock price table.
		/// </summary>
		private StockPriceRow[] PriceTable;

		private GameState(BoardManager board, GameOptions options)
		{
			Board = board;
			Options = options;
		}

		public static GameState Create(BoardManager board, GameOptions options)
		{
			GameState state = new GameState(board, options);
			state.SetupStockPrices();
			return state;
		}

		public StockPriceRow StockPriceCurrent(CompanyType company)
		{
			return PriceTable[PriceIndex].Price(company);
		}

		public StockPriceRow StockPriceLowest(CompanyType company)
		{
			int index;
			switch (company) {
			default:
			case CompanyType.AlphaA:
			case CompanyType.AlphaB:
			case CompanyType.AlphaC:
			case CompanyType.AlphaD:
				index = 0;
				break;
			case CompanyType.OmegaA:
			case CompanyType.OmegaB:
			case CompanyType.OmegaC:
			case CompanyType.OmegaD:
				index = PriceTable.Length - 1;
				break;
			}
			return PriceTable[index].Price(company);
		}

		private void SetupStockPrices()
		{
			PriceTable = new StockPriceRow[51];

			int[,] tiers = PriceListTiers();

			int count = tiers.Length;
			for (int i = 0; i < count; i++) {
				// Alpha companies
				PriceTable[i] = new StockPriceRow(tiers[i]);
				// Omega companies
				PriceTable[count - 1 - i] = new StockPriceRow(tiers[i]);
			}
		}

		/// <summary>
		/// Prices list tiers.
		/// Only one side of the table is needed, the other side is inverted.
		/// </summary>
		/// <returns>The list tiers.</returns>
		private int[,] PriceListTiers()
		{
			// Company Type: A, B, C, D
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