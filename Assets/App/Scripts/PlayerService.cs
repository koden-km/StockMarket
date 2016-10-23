using System.Collections.Generic;

namespace App
{

	/// <summary>
	/// Player logic operations.
	/// </summary>
	public class PlayerService
	{
		public const int BrokerFeePerShare = 10;

		/// <summary>
		/// The player to operate on.
		/// </summary>
		private PlayerModel m_Player;

		/// <summary>
		/// Initializes a new instance of the <see cref="App.PlayerService"/> class.
		/// </summary>
		public PlayerService()
		{
			m_Player = null;
		}

		#region Player Operation Focus

		/// <summary>
		/// Set the player to operate on.
		/// </summary>
		/// <param name="player">The player.</param>
		public void SetPlayer(PlayerModel player)
		{
			m_Player = player;
		}

		/// <summary>
		/// Clears the player being operated on.
		/// </summary>
		public void ClearPlayer()
		{
			m_Player = null;
		}

		#endregion

		#region Player Cash Operations

		/// <summary>
		/// The player current cash.
		/// </summary>
		/// <returns>The cash amount.</returns>
		public int CurrentCash()
		{
			return m_Player.Cash;
		}

		/// <summary>
		/// Determines whether the player has any cash (greater than zero).
		/// </summary>
		/// <returns><c>true</c> if the player has any cash; otherwise, <c>false</c>.</returns>
		public bool HasAnyCash()
		{
			return m_Player.Cash > 0;
		}

		/// <summary>
		/// Determines whether the player has cash at or above the specified amount.
		/// </summary>
		/// <returns><c>true</c> if the player has cash at or above the specified amount; otherwise, <c>false</c>.</returns>
		/// <param name="amount">Amount.</param>
		public bool HasCash(int amount)
		{
			return m_Player.Cash >= amount;
		}

		public void SetCash(int amount)
		{
			m_Player.Cash = amount;
		}

		public void AddCash(int amount)
		{
			m_Player.Cash += amount;
		}

		public void SubtractCash(int amount)
		{
			m_Player.Cash -= amount;
		}

		#endregion

		#region Player Share Operations

		public int CurrentShares(CompanyType company)
		{
			int count = 0;
			m_Player.Shares.TryGetValue(company, out count);
			return count;
		}

		public Dictionary<CompanyType, int> AllCompanyShares()
		{
			return m_Player.Shares;
		}

		/// <summary>
		/// Determines whether the player has any company shares.
		/// </summary>
		/// <returns><c>true</c> if the player has any company shares; otherwise, <c>false</c>.</returns>
		/// <param name="company">Company.</param>
		public bool HasAnyShares(CompanyType company)
		{
			return CurrentShares(company) > 0;
		}

		/// <summary>
		/// Determines whether the player has company shares at or above the specified count.
		/// </summary>
		/// <returns><c>true</c> if the player has company shares at or above the specified count; otherwise, <c>false</c>.</returns>
		/// <param name="company">Company.</param>
		/// <param name="count">Count.</param>
		public bool HasShares(CompanyType company, int count)
		{
			return CurrentShares(company) > count;
		}

		public void SetShares(CompanyType company, int count)
		{
			m_Player.Shares[company] = count;
		}

		public void AddShares(CompanyType company, int count)
		{
			if (m_Player.Shares.ContainsKey(company)) {
				m_Player.Shares[company] += count;
			} else {
				m_Player.Shares[company] = count;
			}
		}

		public void SubtractShares(CompanyType company, int count)
		{
			if (m_Player.Shares.ContainsKey(company)) {
				m_Player.Shares[company] -= count;
			} else {
				m_Player.Shares[company] = count;
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
			// Note: This is not related to how many shares the player owns,
			// just the value of 'count' company shares of the given stock price.
			return shares * stockPrice.Price(company);
		}

		/// <summary>
		/// Calculates the player current share value for the given company.
		/// </summary>
		/// <returns>The current share value.</returns>
		/// <param name="stockPrice">The stock price tier.</param>
		/// <param name="company">The company to calculate share value for.</param>
		public int CalculateCurrentShareValue(StockPriceTier stockPrice, CompanyType company)
		{
			return CurrentShares(company) * stockPrice.Price(company);
		}

		/// <summary>
		/// Calculates the player current total value of all shares.
		/// </summary>
		/// <returns>The current total value.</returns>
		/// <param name="stockPrice">The stock price tier.</param>
		public int CalculateCurrentTotalValue(StockPriceTier stockPrice)
		{
			int total = 0;
			foreach (KeyValuePair<CompanyType,int> pair in AllCompanyShares()) {
				total += CalculateCurrentShareValue(stockPrice, pair.Key);
			}
			return total;
		}

		/// <summary>
		/// Calculates the player current net worth.
		/// </summary>
		/// <returns>The player net worth.</returns>
		/// <param name="stockPrice">The stock price tier to use for calculation.</param>
		public int CalculateNetWorth(StockPriceTier stockPrice)
		{
			return CurrentCash() + CalculateCurrentTotalValue(stockPrice);
		}

		/// <summary>
		/// Buy's count shares of company and return the amount of cash spent.
		/// </summary>
		/// <returns>The amount of cash spent.</returns>
		/// <param name="stockPrice">The stock price tier.</param>
		/// <param name="company">The company to sell shares from.</param>
		/// <param name="shares">The number of shares to buy.</param>
		public int BuyShares(StockPriceTier stockPrice, CompanyType company, int count)
		{
			int value = CalculateShareValue(stockPrice, company, count);
			if (!HasCash(value)) {
				throw new System.Exception("Not enough cash to buy shares.");
			}
			SubtractCash(value);
			AddShares(company, count);
			return value;
		}

		/// <summary>
		/// Sells count shares of company and return the amount of cash gained.
		/// </summary>
		/// <returns>The amount of cash gained.</returns>
		/// <param name="stockPrice">The stock price tier.</param>
		/// <param name="company">The company to sell shares from.</param>
		/// <param name="shares">The number of shares to sell.</param>
		public int SellShares(StockPriceTier stockPrice, CompanyType company, int shares)
		{
			if (!HasShares(company, shares)) {
				throw new System.Exception("Not enough owned shares to sell.");
			}
			int value = CalculateShareValue(stockPrice, company, shares);
			SubtractShares(company, shares);
			AddCash(value);
			return value;
		}

		/// <summary>
		/// Calculates the broker fee at a fixed value (eg. $10) per share.
		/// </summary>
		/// <returns>The broker fee.</returns>
		public int CalculateBrokerFee()
		{
			int shares = 0;
			foreach (KeyValuePair<CompanyType,int> pair in AllCompanyShares()) {
				shares += pair.Value;
			}
			return BrokerFeePerShare * shares;
		}

		/// <summary>
		/// Determines whether the player can afford broker fee.
		/// </summary>
		/// <returns><c>true</c> if the player can afford broker fee; otherwise, <c>false</c>.</returns>
		public bool CanAffordBrokerFee()
		{
			return HasCash(CalculateBrokerFee());
		}

		/// <summary>
		/// Pays the broker fee.
		/// </summary>
		/// <returns>The amount of cash spent.</returns>
		public int PayBrokerFee()
		{
			int fee = CalculateBrokerFee();
			if (!HasCash(fee)) {
				throw new System.Exception("Not enough cash to pay broker fee.");
			}
			SubtractCash(fee);
			return fee;
		}

		/// <summary>
		/// Determines whether the player can afford $100 fee.
		/// </summary>
		/// <returns><c>true</c> if the player can afford $100 fee; otherwise, <c>false</c>.</returns>
		public bool CanAfford100Fee()
		{
			return HasCash(100);
		}

		/// <summary>
		/// Pays the $100 fee.
		/// </summary>
		/// <returns>The amount of cash spent.</returns>
		public int Pay100Fee()
		{
			const int fee = 100;
			if (!HasCash(fee)) {
				throw new System.Exception("Not enough cash to pay 100 fee.");
			}
			SubtractCash(fee);
			return fee;
		}

		/// <summary>
		/// Clear all player money and shares then sends the player back to work.
		/// </summary>
		public void GoBackToWork()
		{
			m_Player.ResetToDefault();
		}

		#endregion

	}

}
