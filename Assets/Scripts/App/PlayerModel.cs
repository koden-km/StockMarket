//using UnityEngine;
using System.Collections.Generic;

namespace App
{

	public class PlayerModel
	{
		/// <summary>
		/// The name of the player.
		/// </summary>
		public string Name;

		/// <summary>
		/// The amount of cash this player currently has.
		/// </summary>
		public int Cash;

		/// <summary>
		/// The current value of held stock.
		/// </summary>
		//public int StockValue;

		/// <summary>
		/// The index of the board tile the player is currently at.
		/// </summary>
		public int BoardTileIndex;

		/// <summary>
		/// The job type this player is currently doing.
		/// </summary>
		public JobType Job;

		/// <summary>
		/// The shares this player currently has.
		/// A map of company type to share count.
		/// </summary>
		public Dictionary<CompanyType, int> Shares;

		/// <summary>
		/// The share holder meeting currently attending, or null if not currently attending.
		/// </summary>
		public CompanyType? ShareHolderMeeting;

		/// <summary>
		/// Initializes a new instance of the <see cref="App.PlayerModel"/> class.
		/// </summary>
		/// <param name="name">Name.</param>
		public PlayerModel(string name)
		{
			Name = name;
			Cash = 0;
			//StockValue = 0;
			BoardTileIndex = 0;
			Job = JobType.Worker100;
			Shares = new Dictionary<CompanyType, int>();
			ShareHolderMeeting = null;
		}

	}

}
