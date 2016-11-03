namespace StockMarket.Models
{

	/// <summary>
	/// Board model.
	/// </summary>
	public class BoardModel
	{
		#region Constructor(s)

		/// <summary>
		/// Initializes a new instance of the <see cref="App.Model.BoardModel"/> class.
		/// </summary>
		/// <param name="game">Game.</param>
		public BoardModel(IGameModel game)
		{
			SetupStockPriceTable();
			SetupBoardTiles(game);
		}

		#endregion // Constructor(s)

		#region Properties/Methods

		/// <summary>
		/// The stock price table.
		/// </summary>
		public StockPriceTier[] PriceTable {
			get { return m_PriceTable; }
		}

		/// <summary>
		/// The lowest stock price for each company type.
		/// This is used for certain game events where players need to sell at lowest price;
		/// </summary>
		public StockPriceTier LowestPrice {
			get { return m_LowestPrice; }
		}

		/// <summary>
		/// The board tiles.
		///  4 - Job tiles.
		/// 48 - Outer tiles around board edge.
		/// 36 - Share holder meeting tiles (4 groups of 9 meeting tiles).
		/// Equals 88 total game board tiles.
		/// </summary>
		public BoardTileModel[] BoardTiles {
			get { return m_BoardTiles; }
		}

		#endregion // Properties/Methods

		#region Private Properties/Methods

		/// <summary>
		/// Setup the stock price table.
		/// </summary>
		private void SetupStockPriceTable()
		{
			int iAlpha;
			int iOmega;
			int[] prices;
			int[,] priceTiers = PriceListTiers();
			int count = priceTiers.Length;
			m_PriceTable = new StockPriceTier[count];

			// Setup price table.
			for (int i = 0; i < count; i++) {
				// 8 companies (4 on each side of board).
				prices = new int[8];
				// Alpha (inverted direction)
				iAlpha = count - 1 - i;
				prices[0] = priceTiers[iAlpha, 0];
				prices[1] = priceTiers[iAlpha, 1];
				prices[2] = priceTiers[iAlpha, 2];
				prices[3] = priceTiers[iAlpha, 3];
				// Omega (normal direction)
				iOmega = i;
				prices[4] = priceTiers[iOmega, 0];
				prices[5] = priceTiers[iOmega, 1];
				prices[6] = priceTiers[iOmega, 2];
				prices[7] = priceTiers[iOmega, 3];
				m_PriceTable[i] = new StockPriceTier(prices);
			}

			// Setup lowest (on each side) price tier.
			// 8 companies (4 on each side of board).
			prices = new int[8];
			// Alpha (normal direction)
			iAlpha = count - 1;
			prices[0] = priceTiers[iAlpha, 0];
			prices[1] = priceTiers[iAlpha, 1];
			prices[2] = priceTiers[iAlpha, 2];
			prices[3] = priceTiers[iAlpha, 3];
			// Omega (inverted direction)
			iOmega = 0;
			prices[4] = priceTiers[iOmega, 0];
			prices[5] = priceTiers[iOmega, 1];
			prices[6] = priceTiers[iOmega, 2];
			prices[7] = priceTiers[iOmega, 3];
			m_LowestPrice = new StockPriceTier(prices);
		}

		/// <summary>
		/// Price list tiers.
		/// Only one side of the table is needed, the other side is inverted.
		/// </summary>
		/// <returns>The list tiers.</returns>
		private int[,] PriceListTiers()
		{
			// 51 tiers on original board.
			// Company Type column order: A, B, C, D.
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

		/// <summary>
		/// Setup the board tiles.
		/// The total number of board tiles is 88:
		///  4 - Job tiles.
		/// 48 - Outer tiles around board edge.
		/// 36 - Share holder meeting tiles (4 groups of 9 meeting tiles).
		/// </summary>
		/// <param name="gameModel">Game model.</param>
		private void SetupBoardTiles(IGameModel game)
		{
			const int TotalBoardTiles = 88;
			m_BoardTiles = new BoardTileModel[TotalBoardTiles];

			// Setup job tiles ...
			m_BoardTiles[0] = BoardTileModel.CreateJob(TileType.Job, JobType.Worker100, game);
			m_BoardTiles[1] = BoardTileModel.CreateJob(TileType.Job, JobType.Worker200, game);
			m_BoardTiles[2] = BoardTileModel.CreateJob(TileType.Job, JobType.Worker300, game);
			m_BoardTiles[3] = BoardTileModel.CreateJob(TileType.Job, JobType.Worker400, game);

			// Setup game board trader tiles ...
			// TODO, set them up clockwise or counter-clockwise starting at the stock price UP.

			// Setup share holder meeting tiles ...
			// TODO, set them up in the same direction as board trader tiles.
		}

		#endregion // Private Properties/Methods

		#region Model Data

		/// <summary>
		/// The stock price table.
		/// </summary>
		private StockPriceTier[] m_PriceTable;

		/// <summary>
		/// The lowest stock price for each company type.
		/// This is used for certain game events where players need to sell at lowest price;
		/// </summary>
		private StockPriceTier m_LowestPrice;

		/// <summary>
		/// The board tiles.
		/// </summary>
		private BoardTileModel[] m_BoardTiles;

		#endregion // Model Data
	}

}
