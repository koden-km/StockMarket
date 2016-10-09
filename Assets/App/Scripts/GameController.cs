using UnityEngine;
using System.Collections.Generic;

namespace App
{

	public class GameController : MonoBehaviour
	{
		/// <summary>
		/// The game model.
		/// </summary>
		public GameModel m_Game;

		// TODO: Not sure where to put this?
		public PlayerController m_PlayerController;

		// TODO: Not sure where to put this?
		public BoardController m_GameBoard;

		// TODO: Not sure where to put this?
		public BoardView m_BoardView;

		void Start()
		{
			m_BoardView = Instantiate<BoardView>(m_BoardView);
			m_BoardView.transform.SetParent(this.transform);
		}

		// TODO: do this as an enumerator?
		void Update()
		{
			// TickGame();
		}

		public void CreatePlayer(string name)
		{
			// TODO...
			//m_Game.Players.Add(new PlayerModel(name));
		}

		public void RemovePlayer(string name)
		{
			// TODO...
		}

		public void UpdatePlayerController()
		{
			if (m_Game.Players.Count > 0) {
				m_PlayerController.SetPlayer(m_Game.Players[m_Game.CurrentPlayer]);
			} else {
				m_PlayerController = null;
			}
		}

		public void NewGame()
		{
			Debug.Log("Setup New Game ...");
			
			CleanupCurrentGame();

			// Setup new game.
			//State = GameState.Create(Options);
		}

		public void LoadGame()
		{
			Debug.Log("Load Existing Game ...");

			CleanupCurrentGame();

			// TODO: Load existing saved game data
			//State = GameState.Create(Options);
		}

		public void EndGame()
		{
			Debug.Log("End Existing Game ...");

			// TODO: Show player scores so winner(s) can be decided.
			// Calculate all player net worths (values at current price) and show in a table view thing.
		}

		private void CleanupCurrentGame()
		{
			Debug.Log("Cleanup Current Game ...");

			// Remove old board if exists. eg. starting new game while existing was in progress.
			//if (State == null) {
			//	return;
			//}

			// TODO...

			// Destroy game objects that were created.
			// Destroy(Board);

			//State = null;
		}

		// TODO: do this as an enumerator?
		/*
		private void TickGame()
		{
			if (Players.Count == 0) {
				return;
			}

			int roll = Players[ActivePlayer].DoTurn();
			if (roll > 0) {
				// TODO: Need to give money to Worker players if the roll was for them.
				// A roll of zero could mean they didn't roll anything, and/or are still having their turn? (enumerator?)
				
				ActivePlayer++;
				if (ActivePlayer > Players.Count) {
					ActivePlayer = 0;
				}
			}
		}
		*/

		//public void OnGui()
		//{
		//	Debug.Log("OnGui...");
		//}

	}

}
