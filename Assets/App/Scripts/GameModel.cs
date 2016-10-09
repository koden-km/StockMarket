//using UnityEngine;
using System.Collections.Generic;

namespace App
{

	/// <summary>
	/// Game state. Storage for keep track of current game state.
	/// </summary>
	public class GameModel
	{
		public GameOptions Options;
		public BoardManager Board;

		/// <summary>
		/// The players currently in the game.
		/// </summary>
		public List<PlayerController> Players = new List<PlayerController>();

		/// <summary>
		/// The current player index who's turn it is.
		/// </summary>
		public int CurrentPlayer = 0;

		/// <summary>
		/// The current index of the stock price table.
		/// </summary>
		public int CurrentPriceIndex = 26;

		/// <summary>
		/// The price index change amount.
		/// A negative value will go down, a positive value will go up.
		/// If the index hits the end it should invert +/- and continue in other direction.
		/// </summary>
		public int PriceIndexChange = 0;

		private GameModel(GameOptions options, BoardManager board)
		{
			Options = options;
			Board = board;
		}

		public static GameModel Create(GameOptions options)
		{
			BoardManager board = BoardManager.CreateBoard(options);
			GameModel gameModel = new GameModel(options, board);
			return gameModel;
		}

	}

}
