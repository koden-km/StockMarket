namespace App.Model
{

	/// <summary>
	/// Board tile model.
	/// </summary>
	public class BoardTileModel
	{
		#region Factory Method(s)

		public static BoardTileModel CreateJob(
			TileType tile,
			JobType job,
			IGameModel game
		)
		{
			BoardTileModel bt = new BoardTileModel(tile, BoardTileMoveFlags.Job);
			bt.Color = UnityEngine.Color.white;
			bt.SetupTitleJob(game, job);
			bt.Job = job;
			bt.Company = null;
			bt.Dividend = 0;
			return bt;
		}

		public static BoardTileModel CreateCompany(
			TileType tile,
			BoardTileMoveFlags moveFlags,
			CompanyType company,
			int dividend,
			IGameModel game
		)
		{
			BoardTileModel bt = new BoardTileModel(tile, moveFlags);
			bt.Color = game.GetCompany(company).Color;
			bt.SetupTitleTrade(game, company, tile);
			bt.Job = null;
			bt.Company = company;
			bt.Dividend = dividend;
			return bt;
		}

		public static BoardTileModel CreateCompanyMeeting(
			TileType tile,
			IGameModel game
		)
		{
			BoardTileModel bt = new BoardTileModel(tile, BoardTileMoveFlags.Left | BoardTileMoveFlags.Right);
			// TODO
			return bt;
		}

		public static BoardTileModel CreateStart(
			TileType tile,
			IGameModel game
		)
		{
			BoardTileModel bt = new BoardTileModel(tile, BoardTileMoveFlags.Left | BoardTileMoveFlags.Right);
			// TODO
			return bt;
		}

		public static BoardTileModel CreateBrokerFee(
			TileType tile,
			IGameModel game
		)
		{
			BoardTileModel bt = new BoardTileModel(tile, BoardTileMoveFlags.Right);
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
