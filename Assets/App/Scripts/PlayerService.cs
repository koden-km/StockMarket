using System.Collections.Generic;

namespace App
{
	
	/// <summary>
	/// Interface for player logic operations.
	/// </summary>
	public interface IPlayerService
	{
		// TODO: put methods from main class into here and move to own file.
	}


	/// <summary>
	/// Player logic operations.
	/// </summary>
	public class PlayerService : IPlayerService
	{
		/// <summary>
		/// The broker fee per share (in dollars).
		/// </summary>
		public const int BrokerFeePerShare = 10;

		/// <summary>
		/// Initializes a new instance of the <see cref="App.PlayerService"/> class.
		/// </summary>
		public PlayerService()
		{
		}

		#region Player Cash Operations

		/// <summary>
		/// The player current cash.
		/// </summary>
		/// <returns>The cash amount.</returns>
		/// <param name="player">The player.</param>
		public int CurrentCash(PlayerModel player)
		{
			return player.Cash;
		}

		/// <summary>
		/// Determines whether the player has any cash (greater than zero).
		/// </summary>
		/// <returns><c>true</c> if the player has any cash; otherwise, <c>false</c>.</returns>
		/// <param name="player">The player.</param>
		public bool HasAnyCash(PlayerModel player)
		{
			return player.Cash > 0;
		}

		/// <summary>
		/// Determines whether the player has cash at or above the specified amount.
		/// </summary>
		/// <returns><c>true</c> if the player has cash at or above the specified amount; otherwise, <c>false</c>.</returns>
		/// <param name="player">The player.</param>
		/// <param name="amount">The amount of cash to check for.</param>
		public bool HasCash(PlayerModel player, int amount)
		{
			return player.Cash >= amount;
		}

		/// <summary>
		/// Sets the player cash to the specified amount.
		/// </summary>
		/// <param name="player">The player.</param>
		/// <param name="amount">The amount of cash to set.</param>
		public void SetCash(PlayerModel player, int amount)
		{
			player.Cash = amount;
		}

		/// <summary>
		/// Adds the specified amount of cash to the player.
		/// </summary>
		/// <param name="player">The player.</param>
		/// <param name="amount">The amount of cash to add.</param>
		public void AddCash(PlayerModel player, int amount)
		{
			player.Cash += amount;
		}

		/// <summary>
		/// Subtracts the specified amount of cash to the player.
		/// Note: Does not verify that the player has the amount of cash.
		/// </summary>
		/// <param name="player">The player.</param>
		/// <param name="amount">The amount of cash to subtract.</param>
		public void SubtractCash(PlayerModel player, int amount)
		{
			player.Cash -= amount;
		}

		#endregion

		#region Player Share Operations

		/// <summary>
		/// Get the player current number of shares for the specified company.
		/// </summary>
		/// <returns>The number of shares.</returns>
		/// <param name="player">The player.</param>
		/// <param name="company">The company to get shares for.</param>
		public int CurrentShares(PlayerModel player, CompanyType company)
		{
			return player.GetShares(company);
		}

		/// <summary>
		/// Get all the player shares for all companies.
		/// </summary>
		/// <returns>The shares for all companies.</returns>
		/// <param name="player">The player.</param>
		public Dictionary<CompanyType,int> AllCompanyShares(PlayerModel player)
		{
			// TODO: Refactor to use getter/setter/methods. Mutators should not use Shares directly?

			return player.Shares;
		}

		/// <summary>
		/// Determines whether the player has any company shares (greater than zero).
		/// </summary>
		/// <returns><c>true</c> if the player has any company shares; otherwise, <c>false</c>.</returns>
		/// <param name="player">The player.</param>
		/// <param name="company">The company to check shares for.</param>
		public bool HasAnyShares(PlayerModel player, CompanyType company)
		{
			return CurrentShares(player, company) > 0;
		}

		/// <summary>
		/// Determines whether the player has company shares at or above the specified number.
		/// </summary>
		/// <returns><c>true</c> if the player has company shares at or above the specified number; otherwise, <c>false</c>.</returns>
		/// <param name="player">The player.</param>
		/// <param name="company">The company to check shares for.</param>
		/// <param name="shares">The number of shares to check for.</param>
		public bool HasShares(PlayerModel player, CompanyType company, int shares)
		{
			return CurrentShares(player, company) > shares;
		}

		/// <summary>
		/// Sets the player shares to the given number for the specified company.
		/// </summary>
		/// <param name="player">The player.</param>
		/// <param name="company">The company who owns the shares.</param>
		/// <param name="shares">The number of shares to set.</param>
		public void SetShares(PlayerModel player, CompanyType company, int shares)
		{
			player.SetShares(company, shares);
		}

		/// <summary>
		/// Adds a number shares to the player for the specified company.
		/// </summary>
		/// <param name="player">The player.</param>
		/// <param name="company">The company who owns the shares.</param>
		/// <param name="shares">The number of shares to add.</param>
		public void AddShares(PlayerModel player, CompanyType company, int shares)
		{
			// TODO: Refactor to use getter/setter/methods. Mutators should not use Shares directly?

			if (player.Shares.ContainsKey(company)) {
				player.Shares[company] += shares;
			} else {
				player.Shares[company] = shares;
			}
		}

		/// <summary>
		/// Subtracts a number of shares from the player for the specified company.
		/// Note: Does not verify that the player has the number of shares.
		/// </summary>
		/// <param name="player">The player.</param>
		/// <param name="company">The company who owns the shares.</param>
		/// <param name="shares">The number of shares to subtract.</param>
		public void SubtractShares(PlayerModel player, CompanyType company, int shares)
		{
			// TODO: Refactor to use getter/setter/methods. Mutators should not use Shares directly?

			if (player.Shares.ContainsKey(company)) {
				player.Shares[company] -= shares;
			}
		}

		#endregion

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
		public int CalculateCurrentShareValue(PlayerModel player, StockPriceTier stockPrice, CompanyType company)
		{
			return CurrentShares(player, company) * stockPrice.Price(company);
		}

		/// <summary>
		/// Calculates the player current total value of all shares.
		/// </summary>
		/// <returns>The current total value.</returns>
		/// <param name="player">The player.</param>
		/// <param name="stockPrice">The stock price tier.</param>
		public int CalculateCurrentTotalValue(PlayerModel player, StockPriceTier stockPrice)
		{
			int total = 0;
			foreach (KeyValuePair<CompanyType,int> pair in AllCompanyShares(player)) {
				total += CalculateCurrentShareValue(player, stockPrice, pair.Key);
			}
			return total;
		}

		/// <summary>
		/// Calculates the player current net worth.
		/// </summary>
		/// <returns>The player net worth.</returns>
		/// <param name="player">The player.</param>
		/// <param name="stockPrice">The stock price tier to use for calculation.</param>
		public int CalculateNetWorth(PlayerModel player, StockPriceTier stockPrice)
		{
			return CurrentCash(player) + CalculateCurrentTotalValue(player, stockPrice);
		}

		/// <summary>
		/// Buys the specified number of company shares and returns the amount of cash spent.
		/// </summary>
		/// <returns>The amount of cash spent.</returns>
		/// <param name="player">The player.</param>
		/// <param name="stockPrice">The stock price tier.</param>
		/// <param name="company">The company to sell shares from.</param>
		/// <param name="shares">The number of shares to buy.</param>
		public int BuyShares(PlayerModel player, StockPriceTier stockPrice, CompanyType company, int shares)
		{
			int value = CalculateShareValue(stockPrice, company, shares);
			if (!HasCash(player, value)) {
				throw new System.Exception("Not enough cash to buy shares.");
			}
			SubtractCash(player, value);
			AddShares(player, company, shares);
			return value;
		}

		/// <summary>
		/// Sells the specified number of company shares and returns the amount of cash gained.
		/// </summary>
		/// <returns>The amount of cash gained.</returns>
		/// <param name="player">The player.</param>
		/// <param name="stockPrice">The stock price tier.</param>
		/// <param name="company">The company to sell shares from.</param>
		/// <param name="shares">The number of shares to sell.</param>
		public int SellShares(PlayerModel player, StockPriceTier stockPrice, CompanyType company, int shares)
		{
			if (!HasShares(player, company, shares)) {
				throw new System.Exception("Not enough owned shares to sell.");
			}
			int value = CalculateShareValue(stockPrice, company, shares);
			SubtractShares(player, company, shares);
			AddCash(player, value);
			return value;
		}

		/// <summary>
		/// Calculates the broker fee at a fixed value (eg. $10) per share.
		/// </summary>
		/// <returns>The broker fee.</returns>
		/// <param name="player">The player.</param>
		public int CalculateBrokerFee(PlayerModel player)
		{
			int shares = 0;
			foreach (KeyValuePair<CompanyType,int> pair in AllCompanyShares(player)) {
				shares += pair.Value;
			}
			return BrokerFeePerShare * shares;
		}

		/// <summary>
		/// Determines whether the player can afford broker fee.
		/// </summary>
		/// <returns><c>true</c> if the player can afford broker fee; otherwise, <c>false</c>.</returns>
		/// <param name="player">The player.</param>
		public bool CanAffordBrokerFee(PlayerModel player)
		{
			return HasCash(player, CalculateBrokerFee(player));
		}

		/// <summary>
		/// Pays the broker fee.
		/// </summary>
		/// <returns>The amount of cash spent.</returns>
		/// <param name="player">The player.</param>
		public int PayBrokerFee(PlayerModel player)
		{
			int fee = CalculateBrokerFee(player);
			if (!HasCash(player, fee)) {
				throw new System.Exception("Not enough cash to pay broker fee.");
			}
			SubtractCash(player, fee);
			return fee;
		}

		/// <summary>
		/// Determines whether the player can afford $100 fee.
		/// </summary>
		/// <returns><c>true</c> if the player can afford $100 fee; otherwise, <c>false</c>.</returns>
		/// <param name="player">The player.</param>
		public bool CanAfford100Fee(PlayerModel player)
		{
			return HasCash(player, 100);
		}

		/// <summary>
		/// Pays the $100 fee.
		/// </summary>
		/// <returns>The amount of cash spent.</returns>
		/// <param name="player">The player.</param>
		public int Pay100Fee(PlayerModel player)
		{
			const int fee = 100;
			if (!HasCash(player, fee)) {
				throw new System.Exception("Not enough cash to pay 100 fee.");
			}
			SubtractCash(player, fee);
			return fee;
		}

		/// <summary>
		/// Clear all player money and shares then sends the player back to work.
		/// </summary>
		/// <param name="player">The player.</param>
		public void GoBackToWork(PlayerModel player)
		{
			player.ResetValues();
		}

		#endregion

	}

}
