using UnityEngine;
using System.Collections.Generic;

namespace App
{

	public class GameManager : MonoBehaviour
	{
		public GameOptions Options;
		public GameState State;
		
		//public int ActivePlayer = 0;
		//public List<PlayerController> Players = new List<PlayerController>();
		//public Dictionary<JobType,string> JobNames = new Dictionary<JobType, string>();
		//public Dictionary<CompanyType,string> CompanyNames = new Dictionary<CompanyType, string>();

		private BoardManager Board;

		void Start()
		{
		}

		// TODO: do this as an enumerator?
		void Update()
		{
		}

		public void CreatePlayer(string name)
		{
			//PlayerController player = new PlayerController(new PlayerModel(name));
			//Players.Add(player);
		}

		public void CreateBoard()
		{
			// TODO: remove game entities?
			
			// Remove old board if exists.
			//boardManager = null;

			// Create new board.
			//boardManager = new BoardManager();
			//boardManager.CreateBoard(JobNames, CompanyNames);
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

	}

}
