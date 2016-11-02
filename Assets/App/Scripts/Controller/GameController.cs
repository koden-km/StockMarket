using UnityEngine;
using System.Collections.Generic;
using App.Model;
using App.Service;

namespace App.Controller
{

	// TODO: this should be a plain C# class (not MonoBehaviour) according to some Unity MVC tutorials.
	// The view classes should be MonoBehaviour's that send events here.

	public class GameController : MonoBehaviour
	{
		/// <summary>
		/// The game model.
		/// </summary>
		private IGameModel m_Game;

		/// <summary>
		/// The game service.
		/// </summary>
		private GameService m_GameService;

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
			m_Game = GameModel.CreateNewGame();

			m_GameService = new GameService(new PlayerService());

			//m_PlayerController = new PlayerController();

			// TODO: hook up view handlers?
			//m_BoardView = Instantiate<BoardView>(m_BoardView);
			//m_BoardView.transform.SetParent(this.transform);
		}

		// TODO: do this as an enumerator?
		void Update()
		{
			// TickGame();
			m_GameService.TickGame(m_Game);
		}

		// TODO: should these be named as event handlers? OnCreatePlayer(..) ?
		public void CreatePlayer(string name)
		{
			m_GameService.AddPlayer(m_Game, name);
		}

		// TODO: should these be named as event handlers? OnXxxx(..) ?
		public void RemovePlayer(string name)
		{
			m_GameService.RemovePlayer(m_Game, name);
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
		//		private void TickGame()
		//		{
		//			if (m_Game.Players.Count == 0) {
		//				return;
		//			}
		//
		//			int roll = 0; // TODO: m_Game.CurrentPlayer().DoTurn();
		//			if (roll > 0) {
		//				// TODO: Need to give money to Worker players if the roll was for them.
		//				// A roll of zero could mean they didn't roll anything, and/or are still having their turn? (enumerator?)
		//
		//				//JobType
		//				System.Enum.GetValues(typeof(JobType));
		//				foreach (JobType jobType in System.Enum.GetValues(typeof(JobType))) {
		//					JobModel job = m_Game.GetJob(jobType);
		//					if (roll == job.FirstPaysRoll) {
		//						// TODO: pay players currently in this job.
		//					} else if (roll == job.SecondPaysRoll) {
		//						// TODO: pay players currently in this job.
		//					}
		//				}
		//
		//				m_Game.CurrentPlayerIndex++;
		//				if (m_Game.CurrentPlayerIndex > m_Game.Players.Count) {
		//					m_Game.CurrentPlayerIndex = 0;
		//				}
		//			}
		//		}

		// TODO: This is legacy gui style. Need to learn modern GUI.
		//public void OnGui()
		//{
		//	Debug.Log("OnGui...");
		//}

	}

}
