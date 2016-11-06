using System.Collections.Generic;
using StockMarket.Models;

namespace StockMarket.Services
{

	/// <summary>
	/// Game logic operations.
	/// </summary>
	public class GameService : IGameService
	{
		#region Constructor(s)

		/// <summary>
		/// Initializes a new instance of the <see cref="App.Service.GameService"/> class.
		/// This is the designated constructor.
		/// </summary>
		/// <param name="playerService">Player service.</param>
		public GameService(IPlayerService playerService)
		{
			m_PlayerService = playerService;
		}

		#endregion // Constructor(s)

		#region Services

		/// <summary>
		/// Gets the player service.
		/// </summary>
		/// <value>The player service.</value>
		public IPlayerService PlayerService {
			get { return m_PlayerService; }
		}

		#endregion // Services

		#region Game Logic Operations

		// TODO?
		// player turns?
		// dice rolling?

		public void StartNewGame(IGameModel game)
		{
			// TODO
		}

		public void SaveGame(IGameModel game)
		{
			// TODO
		}

		public void LoadGame(IGameModel game)
		{
			// TODO
		}

		// TODO: do this as an enumerator?
		public void TickGame(IGameModel game)
		{
			// TODO: check game state?

			if (game.Players.Count == 0) {
				return;
			}

			// TODO: do the player turn? CurrentPlayer(game).DoTurn(game);
			// - ask to chose an option for turn:
			//   + sell stock
			//   + go back to work
			//   + retire and exit (name and networth kept in game scores until end of game. they might win at end of time limit)
			//   + roll dice and move
			//
			// - if chose to roll dice
			//   + ask to chose a destination roll option if there are multiple paths

			int roll = RollDice();
			if (roll > 0) {
				// TODO: Need to give money to Worker players if the roll was for them.
				// A roll of zero could mean they didn't roll anything, and/or are still having their turn? (enumerator?)

				//JobType
				System.Enum.GetValues(typeof(JobType));
				foreach (JobType jobType in System.Enum.GetValues(typeof(JobType))) {
					JobModel job = game.GetJob(jobType);
					if (roll == job.FirstPaysRoll) {
						// TODO: pay players currently in this job.
					} else if (roll == job.SecondPaysRoll) {
						// TODO: pay players currently in this job.
					}
				}

				// TODO: does ++ operator work with properties?
				game.CurrentPlayerIndex++;
				if (game.CurrentPlayerIndex > game.Players.Count) {
					game.CurrentPlayerIndex = 0;
				}
			}
		}

		#endregion // Game Logic Operations

		#region Game Board Operations

		// TODO? use a BoardService for this?
		// stock price things?
		// player board movement?

		/// <summary>
		/// Get the current stock price.
		/// </summary>
		/// <returns>The current stock price.</returns>
		/// <param name="game">The game.</param>
		public StockPriceTier CurrentStockPrice(IGameModel game)
		{
			return game.Board.PriceTable[game.CurrentPriceIndex];
		}

		/// <summary>
		/// Get the lowest stock price.
		/// </summary>
		/// <returns>The lowest stock price.</returns>
		/// <param name="game">The game.</param>
		public StockPriceTier LowestStockPrice(IGameModel game)
		{
			return game.Board.LowestPrice;
		}

		/// <summary>
		/// Rolls the (2d6) dice.
		/// </summary>
		/// <returns>The dice roll result.</returns>
		public int RollDice()
		{
			// 2d6 (2 to 12). Range() is Inclusive to Exclusive.
			return UnityEngine.Random.Range(2, 13);
		}

		#endregion // Game Board Operations

		#region Game Player Operations

		/// <summary>
		/// Adds a new player to the game.
		/// </summary>
		/// <param name="game">The game.</param>
		/// <param name="name">The name of the player to add.</param>
		public void AddPlayer(IGameModel game, string name)
		{
			game.Players.Add(new PlayerModel(name));
		}

		/// <summary>
		/// Removes an existing player from the game.
		/// </summary>
		/// <param name="game">The game.</param>
		/// <param name="name">The name of the player to remove.</param>
		public void RemovePlayer(IGameModel game, string name)
		{
			int count = game.Players.Count;
			for (int i = 0; i < count; ++i) {
				IPlayerModel player = game.Players[i];
				if (player.Name == name) {
					if (i >= game.CurrentPlayerIndex) {
						// Update the current player index to stay in range.
						game.CurrentPlayerIndex = game.CurrentPlayerIndex - 1;
					}
					game.Players.Remove(player);
					break;
				}
			}
		}

		/// <summary>
		/// The current the player who's turn it is.
		/// </summary>
		/// <returns>The player who's turn it is.</returns>
		public IPlayerModel CurrentPlayer(IGameModel game)
		{
			return game.Players[game.CurrentPlayerIndex];
		}

		/// <summary>
		/// Determines whether the current player has won the game.
		/// To win, a player must have $100,000 (WinningNetWorthAmount) at his turn to roll the dice.
		/// This includes his cash and all of his stock at the current board price.
		/// </summary>
		/// <returns><c>true</c> if the current player won the specified; otherwise, <c>false</c>.</returns>
		/// <param name="game">Game.</param>
		public bool HasPlayerWon(IGameModel game)
		{
			int netWorth = PlayerService.CalculateNetWorth(CurrentPlayer(game), CurrentStockPrice(game));
			return netWorth >= game.WinningNetWorthAmount;
		}

		/// <summary>
		/// The board tile of the current player.
		/// </summary>
		/// <returns>The board tile.</returns>
		/// <param name="game">Game.</param>
		public BoardTileModel CurrentBoardTile(IGameModel game)
		{
			int boardTileIndex = CurrentPlayer(game).BoardTileIndex;
			return game.Board.BoardTiles[boardTileIndex];
		}

		/// <summary>
		/// Determines whether the current player can sell at the current stock price on current tile.
		/// If not, the player would only be able to sell at lowest possible price.
		/// </summary>
		/// <returns><c>true</c> if a player on this tile can sell at current price; otherwise, <c>false</c>.</returns>
		/// <param name="game">The game.</param>
		public bool CanSellAtCurrentPrice(IGameModel game)
		{
			switch (CurrentBoardTile(game).Tile) {
			case TileType.Start:
			case TileType.BuyMany:
			case TileType.BuyOne:
			case TileType.Meeting1for1:
			case TileType.Meeting2for1:
			case TileType.Meeting3for1:
				return true;
			}

			return false;
		}

		/// <summary>
		/// Pays the dividend to the current player if on a company dividend paying tile.
		/// </summary>
		/// <param name="game">The game.</param>
		public void PayDividend(IGameModel game)
		{
			BoardTileModel boardTile = CurrentBoardTile(game);
			if (boardTile.Company.HasValue && boardTile.Dividend > 0) {
				PlayerService.ReceiveDividend(CurrentPlayer(game), boardTile.Company.Value, boardTile.Dividend);
			}
		}

		#endregion // Game Player Operations

		#region Member(s)

		/// <summary>
		/// The player service.
		/// </summary>
		private IPlayerService m_PlayerService;

		#endregion // Member(s)
	}

}
