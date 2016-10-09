using UnityEngine;
using System.Collections.Generic;

namespace App
{

	public class GameController : MonoBehaviour
	{
		// the Unity game object board. this might be the BoardManager?
		//public GameObject Board;
		//private BoardManager Board;
	
		public GameOptions Options;
		public GameState State;

		void Start()
		{
		}

		// TODO: do this as an enumerator?
		void Update()
		{
			// TickGame();
		}

		public void CreatePlayer(string name)
		{
			//PlayerController player = new PlayerController(new PlayerModel(name));
			//State.Players.Add(player);
		}

		public void RemovePlayer(string name)
		{
			// TODO...
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
