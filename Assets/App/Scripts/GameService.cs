using System.Collections.Generic;

namespace App
{

	/// <summary>
	/// Game logic operations.
	/// </summary>
	public class GameService
	{
		/// <summary>
		/// The game to operate on.
		/// </summary>
		private GameModel m_Game;

		/// <summary>
		/// Initializes a new instance of the <see cref="App.PlayerService"/> class.
		/// </summary>
		public GameService(GameModel game)
		{
			m_Game = game;
		}

		#region Game Operation Focus

		/// <summary>
		/// Set the game to operate on.
		/// </summary>
		/// <param name="game">The game.</param>
		public void SetGame(GameModel game)
		{
			m_Game = game;
		}

		/// <summary>
		/// Clears the game being operated on.
		/// </summary>
		public void ClearGame()
		{
			m_Game = null;
		}

		#endregion

		#region Game Player Operations

		/// <summary>
		/// Adds a new player to the game.
		/// </summary>
		/// <param name="name">The name of the player to add.</param>
		public void AddPlayer(string name)
		{
			m_Game.Players.Add(new PlayerModel(name));
		}

		/// <summary>
		/// Removes an existing player from the game.
		/// </summary>
		/// <param name="name">The name of the player to remove.</param>
		public void RemovePlayer(string name)
		{
			int count = m_Game.Players.Count;
			for (int i = 0; i < count; ++i) {
				PlayerModel player = m_Game.Players[i];
				if (player.Name == name) {
					if (i >= m_Game.CurrentPlayerIndex) {
						// Update the current player index to stay in range.
						m_Game.CurrentPlayerIndex = m_Game.CurrentPlayerIndex - 1;
					}
					m_Game.Players.Remove(player);
					break;
				}
			}
		}

		#endregion

		#region Game Board Operations

		// TODO?
		// stock price things?
		// player board movement?

		#endregion

		#region Game Logic

		// TODO?
		// checking win condition?
		// player turns?
		// dice rolling?

		#endregion

	}

}
