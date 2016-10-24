using UnityEngine;
using System.Collections.Generic;

namespace App
{

	// TODO: this should be a plain C# class (not MonoBehaviour) according to some Unity MVC tutorials.
	// The view classes should be MonoBehaviour's that send events here.

	public class GameController : MonoBehaviour
	{
		/// <summary>
		/// The game model.
		/// </summary>
		private GameModel m_Game;

		private GameService m_GameService;

		private PlayerService m_PlayerService;

		// TODO: Not sure if needed and/or where to put this?
		//public PlayerController m_PlayerController;

		// TODO: Not sure if needed and/or where to put this?
		//public BoardController m_GameBoard;

		// TODO: Not sure if needed and/or where to put this?
		//public BoardView m_BoardView;

		// TODO: Not sure if needed and/or where to put this?
		//public PlayerView m_PlayerView;

		void Start()
		{
			m_Game = new GameModel();

			m_GameService = new GameService(m_Game);

			m_PlayerService = new PlayerService();

			//m_PlayerController = new PlayerController();

			// TODO: hook up view handlers?
			//m_BoardView = Instantiate<BoardView>(m_BoardView);
			//m_BoardView.transform.SetParent(this.transform);
		}

		// TODO: do this as an enumerator?
		void Update()
		{
			// TickGame();
		}

		// TODO: should these be named as event handlers? OnCreatePlayer(..) ?
		public void CreatePlayer(string name)
		{
			m_GameService.AddPlayer(name);
		}

		// TODO: should these be named as event handlers? OnXxxx(..) ?
		public void RemovePlayer(string name)
		{
			m_GameService.RemovePlayer(name);

			// TODO: check this.
			// If the current player leaves then this needs to switch to the next player.
			// But make sure this doesn't continue/resume some player turn operation(s) on the newly switched player.
			UpdateCurrentPlayer();
		}

		// TODO: should these be named as event handlers? OnXxxx(..) ?
		public void NewGame()
		{
			Debug.Log("Setup New Game ...");
			
			CleanupCurrentGame();

			// TODO: Setup new game. just load the scene again?
			// * Init game model.
			// * Create board.
		}

		// TODO: should these be named as event handlers? OnXxxx(..) ?
		public void LoadGame()
		{
			Debug.Log("Load Existing Game ...");

			CleanupCurrentGame();

			// TODO: Load existing saved game data. then create the board.
		}

		// TODO: should these be named as event handlers? OnXxxx(..) ?
		public void PauseGame()
		{
			Debug.Log("Pause Current Game ...");

			// TODO: Show table of current player net worths? or just a pause menu.
		}

		// TODO: should these be named as event handlers? OnXxxx(..) ?
		public void SaveGame()
		{
			Debug.Log("Save Current Game ...");

			// TODO: Save current game data.
		}

		// TODO: should these be named as event handlers? OnXxxx(..) ?
		public void EndGame()
		{
			Debug.Log("End Existing Game ...");

			// TODO: Show player total net worths so winner(s) can be decided.
			// Calculate all player net worths (values at current price) and show in a table view thing.
		}

		// TODO: not sure if this is needed now...
		private void UpdateCurrentPlayer()
		{
			if (m_Game != null) {
			}

			if (m_Game.Players.Count > 0) {
				//m_PlayerService.SetPlayer(m_Game.Players[m_Game.CurrentPlayerIndex]);
			} else {
				//m_PlayerService.ClearPlayer();
			}
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

		// TODO: This is legacy gui style. Need to learn modern GUI.
		//public void OnGui()
		//{
		//	Debug.Log("OnGui...");
		//}

	}

}
