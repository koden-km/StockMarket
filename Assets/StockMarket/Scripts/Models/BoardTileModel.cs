namespace StockMarket.Models
{

	/// <summary>
	/// Board tile model.
	/// </summary>
	public class BoardTileModel
	{
		#region Factory Method(s)

		/// <summary>
		/// Creates a job tile.
		/// </summary>
		/// <returns>The job tile.</returns>
		/// <param name="job">Job type. Must not be a trader job type.</param>
		/// <param name="game">The game.</param>
		public static BoardTileModel CreateJob(
			JobType job,
			IGameModel game
		)
		{
			// TODO: validate job type options to not be trader job type.

			BoardTileModel bt = new BoardTileModel(TileType.Job, BoardTileMoveFlags.Job);
			bt.Color = UnityEngine.Color.white;
			bt.SetupTitleJob(game, job);
			bt.Job = job;
			bt.Company = null;
			bt.Dividend = 0;
			return bt;
		}

		/// <summary>
		/// Creates a company type tile.
		/// </summary>
		/// <returns>The company tile.</returns>
		/// <param name="tile">The tile type. Must be a company meeting tile type.</param>
		/// <param name="moveFlags">Available move flags.</param>
		/// <param name="company">The company.</param>
		/// <param name="dividend">The dividend for players with shares in this company.</param>
		/// <param name="game">Game.</param>
		public static BoardTileModel CreateCompany(
			TileType tile,
			BoardTileMoveFlags moveFlags,
			CompanyType company,
			int dividend,
			IGameModel game
		)
		{
			// TODO: validate tile type options to be company tile types.

			BoardTileModel bt = new BoardTileModel(tile, moveFlags);
			bt.Color = game.GetCompany(company).Color;
			bt.SetupTitleTrade(game, company, tile);
			bt.Job = null;
			bt.Company = company;
			bt.Dividend = dividend;
			return bt;
		}

		/// <summary>
		/// Creates a company stockholder meeting tile.
		/// </summary>
		/// <returns>The company stockholder meeting.</returns>
		/// <param name="tile">The tile type. Must be a stockholder meeting tile type.</param>
		/// <param name="game">The game.</param>
		public static BoardTileModel CreateCompanyMeeting(
			TileType tile,
			IGameModel game
		)
		{
			// TODO: validate tile type options to be stockholder meeting tile types.

			BoardTileModel bt = new BoardTileModel(tile, BoardTileMoveFlags.Left | BoardTileMoveFlags.Right);
			// TODO
			return bt;
		}

		/// <summary>
		/// Creates a start tile.
		/// </summary>
		/// <returns>The start tile.</returns>
		/// <param name="game">The game.</param>
		public static BoardTileModel CreateStart(
			IGameModel game
		)
		{
			BoardTileModel bt = new BoardTileModel(TileType.Start, BoardTileMoveFlags.Left | BoardTileMoveFlags.Right);
			// TODO: not they can only move left/right depending if the roll was odd or even.
			return bt;
		}

		/// <summary>
		/// Creates a broker fee tile.
		/// </summary>
		/// <returns>The broker fee tile.</returns>
		/// <param name="game">The game.</param>
		public static BoardTileModel CreateBrokerFee(
			IGameModel game
		)
		{
			BoardTileModel bt = new BoardTileModel(TileType.BrokerFee, BoardTileMoveFlags.Right);
			// TODO
			return bt;
		}

		#endregion // Factory Method(s)

		#region Properties/Methods

		public TileType Tile;

		public BoardTileMoveFlags MoveFlags;

		public UnityEngine.Color Color;

		public string MainTitle;

		public string SubTitle;

		public JobType? Job;

		public CompanyType? Company;

		public int Dividend;

		// $100 fee for landing on Start.
		//public int Fee;

		/// <summary>
		/// The previous board tile.
		/// Use for general movement around the board, not move option logic.
		/// </summary>
		public BoardTileModel Previous;

		/// <summary>
		/// The next board tile.
		/// Use for general movement around the board, not move option logic.
		/// </summary>
		public BoardTileModel Next;

		/// <summary>
		/// The shareholder meeting board tile.
		/// Use for general movement around the board, not move option logic.
		/// </summary>
		public BoardTileModel ShareMeeting;

		#endregion // Properties/Methods

		/// <summary>
		/// Setup the title for a job tile.
		/// </summary>
		/// <param name="game">The game.</param>
		/// <param name="job">The job type.</param>
		private void SetupTitleJob(IGameModel game, JobType job)
		{
			JobModel jobModel = game.GetJob(job);
			MainTitle = jobModel.Title;
			SubTitle = string.Format("{0} OR {1} PAYS", jobModel.FirstPaysRoll, jobModel.SecondPaysRoll);
		}

		/// <summary>
		/// Setup the title for a trade tile.
		/// </summary>
		/// <param name="game">The game.</param>
		/// <param name="company">The company type.</param>
		/// <param name="tile">The tile type.</param>
		private void SetupTitleTrade(IGameModel game, CompanyType company, TileType tile)
		{
			// TODO: deal with the Sell All and single buy tiles?

			CompanyModel companyModel = game.GetCompany(company);

			if (tile == TileType.SellAllCompany) {
				MainTitle = "Sell All\n" + companyModel.Name;
				SubTitle = "At minimum per share";
			} else if (tile == TileType.BuyOne) {
				MainTitle = companyModel.Name;
				SubTitle = "Purchase limit 1 share";
			} else {
				MainTitle = companyModel.Name;
				SubTitle = "";
			}
		}

		#region Private Constructor(s)

		/// <summary>
		/// Initializes a new instance of the <see cref="App.Model.BoardTileModel"/> class.
		/// </summary>
		/// <param name="tile">Tile type.</param>
		/// <param name="moveFlags">Move flags for starting turn on this tile.</param>
		private BoardTileModel(TileType tile, BoardTileMoveFlags moveFlags)
		{
			Tile = tile;
			MoveFlags = moveFlags;
			MainTitle = string.Empty;
			SubTitle = string.Empty;

			Previous = null;
			Next = null;
			ShareMeeting = null;
		}

		#endregion // Private Constructor(s)
	}

}
