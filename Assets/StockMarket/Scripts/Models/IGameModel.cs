using System.Collections.Generic;

namespace StockMarket.Models
{

	public interface IGameModel
	{
		#region Properties/Methods

		/// <summary>
		/// Gets the job details.
		/// </summary>
		/// <returns>The job details.</returns>
		/// <param name="job">The job to get details for.</param>
		JobModel GetJob(JobType job);

		/// <summary>
		/// Gets the company details.
		/// </summary>
		/// <returns>The company details.</returns>
		/// <param name="company">The company to get details for.</param>
		CompanyModel GetCompany(CompanyType company);

		/// <summary>
		/// Gets or sets the index of the current player who's turn it is.
		/// </summary>
		/// <value>The index of the current player who's turn it is.</value>
		int CurrentPlayerIndex { get; set; }

		/// <summary>
		/// Gets or sets the index of the current price tier.
		/// </summary>
		/// <value>The index of the current price tier.</value>
		int CurrentPriceIndex { get; set; }

		//		// Not sure if i should make this available on the GameModel... maybe GameService or BoardModel/Service?
		//		/// <summary>
		//		/// Gets the current price tier.
		//		/// </summary>
		//		/// <value>The current price tier.</value>
		//		StockPriceTier CurrentPriceTier { get; }

		/// <summary>
		/// Gets or sets the price index change amount.
		/// A negative value will go down, a positive value will go up.
		/// If the index hits the end it should invert +/- and continue in other direction.
		/// </summary>
		/// <value>The price index change amount.</value>
		int PriceIndexChange { get; set; }

		/// <summary>
		/// Gets or sets the winning net worth amount.
		/// A player will win the game when their net worth reaches this value on their turn to roll the dice.
		/// </summary>
		/// <value>The winning net worth amount.</value>
		int WinningNetWorthAmount { get; set; }

		/// <summary>
		/// Gets the game board details.
		/// </summary>
		/// <value>The board details.</value>
		BoardModel Board { get; }

		/// <summary>
		/// Gets the players currently in the game.
		/// </summary>
		/// <value>The players currently in the game.</value>
		List<IPlayerModel> Players { get; }

		/// <summary>
		/// Add a player to the game.
		/// </summary>
		/// <param name="player">The player to add.</param>
		void AddPlayer(IPlayerModel player);

		/// <summary>
		/// The current the player who's turn it is.
		/// </summary>
		/// <returns>The player who's turn it is.</returns>
		IPlayerModel CurrentPlayer();

		#endregion // Properties/Methods
	}

}
