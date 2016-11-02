using System.Collections.Generic;
using App.Model;

namespace App.Service
{
	
	/// <summary>
	/// Player game logic operations.
	/// </summary>
	public class PlayerService : IPlayerService
	{
		#region Constructor(s)

		/// <summary>
		/// Initializes a new instance of the <see cref="App.Service.PlayerService"/> class.
		/// This is the designated constructor.
		/// </summary>
		public PlayerService()
		{
		}

		#endregion // Constructor(s)

		#region Player Game Logic

		/// <summary>
		/// Calculates the share value of the specified number of shares.
		/// Note: This is not related to how many shares the player actually owns, just the value
		/// of the specified number of company shares at the given stock price.
		/// </summary>
		/// <returns>The share value.</returns>
		/// <param name="stockPrice">The stock price tier to use for calculation.</param>
		/// <param name="company">The company to calculate share value for.</param>
		/// <param name="shares">The number of shares to calcuate value for.</param>
		public int CalculateShareValue(StockPriceTier stockPrice, CompanyType company, int shares)
		{
			return shares * stockPrice.Price(company);
		}

		/// <summary>
		/// Calculates the player current share value for the given company.
		/// </summary>
		/// <returns>The current share value.</returns>
		/// <param name="player">The player.</param>
		/// <param name="stockPrice">The stock price tier.</param>
		/// <param name="company">The company to calculate share value for.</param>
		public int CalculateCurrentShareValue(IPlayerModel player, StockPriceTier stockPrice, CompanyType company)
		{
			return player.GetShares(company) * stockPrice.Price(company);
		}

		/// <summary>
		/// Calculates the player current total value of all shares.
		/// </summary>
		/// <returns>The current total value.</returns>
		/// <param name="player">The player.</param>
		/// <param name="stockPrice">The stock price tier.</param>
		public int CalculateCurrentTotalValue(IPlayerModel player, StockPriceTier stockPrice)
		{
			int totalValue = 0;
			foreach (CompanyType company in System.Enum.GetValues(typeof(CompanyType))) {
				totalValue += CalculateCurrentShareValue(player, stockPrice, company);
			}
			return totalValue;
		}

		/// <summary>
		/// Calculates the player current net worth.
		/// </summary>
		/// <returns>The player net worth.</returns>
		/// <param name="player">The player.</param>
		/// <param name="stockPrice">The stock price tier to use for calculation.</param>
		public int CalculateNetWorth(IPlayerModel player, StockPriceTier stockPrice)
		{
			return player.Cash + CalculateCurrentTotalValue(player, stockPrice);
		}

		/// <summary>
		/// Buys the specified number of company shares and returns the amount of cash spent.
		/// </summary>
		/// <returns>The amount of cash spent.</returns>
		/// <param name="player">The player.</param>
		/// <param name="stockPrice">The stock price tier.</param>
		/// <param name="company">The company to sell shares from.</param>
		/// <param name="shares">The number of shares to buy.</param>
		public int BuyShares(IPlayerModel player, StockPriceTier stockPrice, CompanyType company, int shares)
		{
			int shareValue = CalculateShareValue(stockPrice, company, shares);
			if (player.Cash < shareValue) {
				throw new System.Exception("Not enough cash to buy shares.");
			}
			player.Cash -= shareValue;
			player.AddShares(company, shares);
			return shareValue;
		}

		/// <summary>
		/// Sells the specified number of company shares and returns the amount of cash gained.
		/// </summary>
		/// <returns>The amount of cash gained.</returns>
		/// <param name="player">The player.</param>
		/// <param name="stockPrice">The stock price tier.</param>
		/// <param name="company">The company to sell shares from.</param>
		/// <param name="shares">The number of shares to sell.</param>
		public int SellShares(IPlayerModel player, StockPriceTier stockPrice, CompanyType company, int shares)
		{
			if (player.GetShares(company) < shares) {
				throw new System.Exception("Not enough owned shares to sell.");
			}
			int shareValue = CalculateShareValue(stockPrice, company, shares);
			player.SubtractShares(company, shares);
			player.Cash += shareValue;
			return shareValue;
		}

		/// <summary>
		/// Calculates the broker fee at a fixed value (eg. $10) per share.
		/// </summary>
		/// <returns>The broker fee.</returns>
		/// <param name="player">The player.</param>
		public int CalculateBrokerFee(IPlayerModel player)
		{
			int totalShares = 0;
			foreach (CompanyType company in System.Enum.GetValues(typeof(CompanyType))) {
				totalShares += player.GetShares(company);
			}
			const int brokerFeePerShare = 10;
			return brokerFeePerShare * totalShares;
		}

		/// <summary>
		/// Determines whether the player can afford broker fee.
		/// </summary>
		/// <returns><c>true</c> if the player can afford broker fee; otherwise, <c>false</c>.</returns>
		/// <param name="player">The player.</param>
		public bool CanAffordBrokerFee(IPlayerModel player)
		{
			return player.Cash >= CalculateBrokerFee(player);
		}

		/// <summary>
		/// Pays the broker fee.
		/// </summary>
		/// <returns>The amount of cash spent.</returns>
		/// <param name="player">The player.</param>
		public int PayBrokerFee(IPlayerModel player)
		{
			int fee = CalculateBrokerFee(player);
			if (player.Cash < fee) {
				throw new System.Exception("Not enough cash to pay broker fee.");
			}
			player.Cash -= fee;
			return fee;
		}

		/// <summary>
		/// Determines whether the player can afford $100 fee.
		/// </summary>
		/// <returns><c>true</c> if the player can afford $100 fee; otherwise, <c>false</c>.</returns>
		/// <param name="player">The player.</param>
		public bool CanAfford100Fee(IPlayerModel player)
		{
			const int fee = 100;
			return player.Cash >= fee;
		}

		/// <summary>
		/// Pays the $100 fee.
		/// </summary>
		/// <returns>The amount of cash spent.</returns>
		/// <param name="player">The player.</param>
		public int Pay100Fee(IPlayerModel player)
		{
			const int fee = 100;
			if (player.Cash < fee) {
				throw new System.Exception("Not enough cash to pay 100 fee.");
			}
			player.Cash -= fee;
			return fee;
		}

		/// <summary>
		/// Clear all player cash and shares then set them back at work.
		/// </summary>
		/// <param name="player">The player.</param>
		public void GoBackToWork(IPlayerModel player)
		{
			player.BoardTileIndex = 0;
			player.Job = JobType.Worker100;
			player.Cash = 0;
			player.ClearAllShares();
			player.ShareHolderMeeting = null;
		}

		#endregion
	}

}
