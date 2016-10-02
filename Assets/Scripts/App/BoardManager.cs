using UnityEngine;
using System.Collections.Generic;

namespace App
{

	public class BoardManager
	{
		/// <summary>
		/// The board tiles.
		///  4 - Job tiles.
		/// 48 - Outer tiles around board edge.
		/// 36 - Share holder meeting tiles (4 groups of 9 meeting tiles).
		/// Equals 88 total game board tiles.
		/// </summary>
		private BoardTile[] m_BoardTiles;

		private BoardManager()
		{
			m_BoardTiles = new BoardTile[88];
		}

		public static BoardManager CreateBoard(GameOptions options)
		{
			BoardManager board = new BoardManager();
			
			// Setup job tiles ...
			board.m_BoardTiles[0] = BoardTile.Create(TileType.Job, JobType.Worker100, options);
			board.m_BoardTiles[1] = BoardTile.Create(TileType.Job, JobType.Worker200, options);
			board.m_BoardTiles[2] = BoardTile.Create(TileType.Job, JobType.Worker300, options);
			board.m_BoardTiles[3] = BoardTile.Create(TileType.Job, JobType.Worker400, options);

			// Setup game board edge tiles ...
			// TODO

			// Setup share holder meeting tiles ...
			// TODO

			return board;
		}
	}

}
