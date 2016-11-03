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
		/// Determines whether a player on this tile can sell at the current stock price.
		/// If not, the player would only be able to sell at lowest possible price.
		/// </summary>
		/// <returns><c>true</c> if a player on this tile can sell at current price; otherwise, <c>false</c>.</returns>
		/// <param name="game">The game.</param>
		public bool CanSellAtCurrentPrice(IGameModel game)
		{
			int boardTileIndex = game.CurrentPlayer().BoardTileIndex;
			BoardTileModel boardTile = game.Board.BoardTiles[boardTileIndex];

			switch (boardTile.Tile) {
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

		// TODO: do this as an enumerator?
		public void TickGame(IGameModel game)
		{
			if (game.Players.Count == 0) {
				return;
			}

			int roll = 0; // TODO: m_Game.CurrentPlayer().DoTurn();
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

				game.CurrentPlayerIndex++;
				if (game.CurrentPlayerIndex > game.Players.Count) {
					game.CurrentPlayerIndex = 0;
				}
			}
		}

		#endregion // Game Player Operations

		#region Game Board Operations

		// TODO? use a BoardService for this?
		// stock price things?
		// player board movement?

		#endregion // Game Board Operations

		#region Game Logic

		// TODO?
		// checking win condition?
		// player turns?
		// dice rolling?

		#endregion // Game Logic

		#region Service Helpers

		/// <summary>
		/// The player service.
		/// </summary>
		private IPlayerService m_PlayerService;

		#endregion // Service Helpers
	}

}
