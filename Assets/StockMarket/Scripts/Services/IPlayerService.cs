using System.Collections.Generic;
using StockMarket.Models;

namespace StockMarket.Services
{

	/// <summary>
	/// Interface for player logic operations.
	/// </summary>
	public interface IPlayerService
	{
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
		int CalculateShareValue(StockPriceTier stockPrice, CompanyType company, int shares);

		/// <summary>
		/// Calculates the player current share value for the given company.
		/// </summary>
		/// <returns>The current share value.</returns>
		/// <param name="player">The player.</param>
		/// <param name="stockPrice">The stock price tier.</param>
		/// <param name="company">The company to calculate share value for.</param>
		int CalculateCurrentShareValue(IPlayerModel player, StockPriceTier stockPrice, CompanyType company);

		/// <summary>
		/// Calculates the player current total value of all shares.
		/// </summary>
		/// <returns>The current total value.</returns>
		/// <param name="player">The player.</param>
		/// <param name="stockPrice">The stock price tier.</param>
		int CalculateCurrentTotalShareValue(IPlayerModel player, StockPriceTier stockPrice);

		/// <summary>
		/// Calculates the player current net worth.
		/// </summary>
		/// <returns>The player net worth.</returns>
		/// <param name="player">The player.</param>
		/// <param name="stockPrice">The stock price tier to use for calculation.</param>
		int CalculateNetWorth(IPlayerModel player, StockPriceTier stockPrice);

		/// <summary>
		/// Buys the specified number of company shares and returns the amount of cash spent.
		/// </summary>
		/// <returns>The amount of cash spent.</returns>
		/// <param name="player">The player.</param>
		/// <param name="stockPrice">The stock price tier.</param>
		/// <param name="company">The company to sell shares from.</param>
		/// <param name="shares">The number of shares to buy.</param>
		int BuyShares(IPlayerModel player, StockPriceTier stockPrice, CompanyType company, int shares);

		/// <summary>
		/// Sells the specified number of company shares and returns the amount of cash gained.
		/// </summary>
		/// <returns>The amount of cash gained.</returns>
		/// <param name="player">The player.</param>
		/// <param name="stockPrice">The stock price tier.</param>
		/// <param name="company">The company to sell shares from.</param>
		/// <param name="shares">The number of shares to sell.</param>
		int SellShares(IPlayerModel player, StockPriceTier stockPrice, CompanyType company, int shares);

		/// <summary>
		/// Calculates the broker fee at a fixed value (eg. $10) per share.
		/// </summary>
		/// <returns>The broker fee.</returns>
		/// <param name="player">The player.</param>
		int CalculateBrokerFee(IPlayerModel player);

		/// <summary>
		/// Determines whether the player can afford broker fee.
		/// </summary>
		/// <returns><c>true</c> if the player can afford broker fee; otherwise, <c>false</c>.</returns>
		/// <param name="player">The player.</param>
		bool CanAffordBrokerFee(IPlayerModel player);

		/// <summary>
		/// Pays the broker fee.
		/// </summary>
		/// <returns>The amount of cash spent.</returns>
		/// <param name="player">The player.</param>
		int PayBrokerFee(IPlayerModel player);

		/// <summary>
		/// Determines whether the player can afford $100 fee.
		/// </summary>
		/// <returns><c>true</c> if the player can afford $100 fee; otherwise, <c>false</c>.</returns>
		/// <param name="player">The player.</param>
		bool CanAfford100Fee(IPlayerModel player);

		/// <summary>
		/// Pays the $100 fee.
		/// </summary>
		/// <returns>The amount of cash spent.</returns>
		/// <param name="player">The player.</param>
		int Pay100Fee(IPlayerModel player);

		/// <summary>
		/// Receives the dividend cash per share for the specified company.
		/// </summary>
		/// <returns>The dividend received.</returns>
		/// <param name="player">The player.</param>
		/// <param name="company">The company.</param>
		/// <param name="dividendPerShare">The cash dividend per share.</param>
		int ReceiveDividend(IPlayerModel player, CompanyType company, int dividendPerShare);

		/// <summary>
		/// Clear all player cash and shares then set them back at work.
		/// </summary>
		/// <param name="player">The player.</param>
		void GoBackToWork(IPlayerModel player);

		#endregion
	}

}
