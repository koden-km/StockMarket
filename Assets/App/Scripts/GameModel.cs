//using UnityEngine;
using System.Collections.Generic;

namespace App
{

	/// <summary>
	/// Game state. Storage for keep track of current game state.
	/// </summary>
	public class GameModel
	{
		/// <summary>
		/// The jobs details map.
		/// </summary>
		public Dictionary<JobType, JobModel> Jobs;

		/// <summary>
		/// The company details map.
		/// </summary>
		public Dictionary<CompanyType, CompanyModel> Companies;

		/// <summary>
		/// The game board.
		/// </summary>
		public BoardModel Board;

		/// <summary>
		/// The players currently in the game.
		/// </summary>
		//public List<PlayerController> Players = new List<PlayerController>();
		public List<PlayerModel> Players = new List<PlayerModel>();

		/// <summary>
		/// The current player index who's turn it is.
		/// </summary>
		public int CurrentPlayerIndex = 0;

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

		/// <summary>
		/// The winning net worth amount.
		/// To win the game, a player must have a net worth of this value at their turn to roll the dice.
		/// </summary>
		public int WinningNetWorthAmount = 100000;

		public GameModel()
		{
			Jobs = new Dictionary<JobType, JobModel>(4);
			Companies = new Dictionary<CompanyType, CompanyModel>(8);

			Jobs[JobType.Worker100] = new JobModel(JobType.Worker100, "Policeman", 100, 5, 9);
			Jobs[JobType.Worker200] = new JobModel(JobType.Worker200, "Doctor", 200, 4, 10);
			Jobs[JobType.Worker300] = new JobModel(JobType.Worker300, "Deep Sea Diver", 300, 3, 11);
			Jobs[JobType.Worker400] = new JobModel(JobType.Worker400, "Prospector", 400, 2, 12);

			Companies[CompanyType.AlphaA] = new CompanyModel(CompanyType.AlphaA, "Alcoa", UnityEngine.Color.red);
			Companies[CompanyType.AlphaB] = new CompanyModel(CompanyType.AlphaB, "Bank of NSW", UnityEngine.Color.yellow);
			Companies[CompanyType.AlphaC] = new CompanyModel(CompanyType.AlphaC, "Ampol", new UnityEngine.Color(0.4f, 0.39f, 0.35f));
			Companies[CompanyType.AlphaD] = new CompanyModel(CompanyType.AlphaD, "BHP", UnityEngine.Color.blue);

			Companies[CompanyType.OmegaA] = new CompanyModel(CompanyType.OmegaA, "Woolworths", new UnityEngine.Color(0.71f, 0.29f, 0.14f));
			Companies[CompanyType.OmegaB] = new CompanyModel(CompanyType.OmegaB, "Consol'D. Press", UnityEngine.Color.green);
			Companies[CompanyType.OmegaC] = new CompanyModel(CompanyType.OmegaC, "Coles", new UnityEngine.Color(0.12f, 0.4f, 0.41f));
			Companies[CompanyType.OmegaD] = new CompanyModel(CompanyType.OmegaD, "Western Mining", UnityEngine.Color.magenta);

			Board = new BoardModel();

			Players = new List<PlayerModel>();

			CurrentPlayerIndex = 0;
			CurrentPriceIndex = 0;
			PriceIndexChange = 0;
		}

		//		/// <summary>
		//		/// Resets to default values.
		//		/// Can be used when starting a new game.
		//		/// </summary>
		//		public void ResetToDefault()
		//		{
		//		}

	}

}
