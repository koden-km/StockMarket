//using UnityEngine;
using System.Collections.Generic;

namespace App
{

	public class PlayerController
	{
		private PlayerModel m_PlayerModel;

		public PlayerController(PlayerModel player)
		{
			m_PlayerModel = player;
		}

		public int CurrentCash()
		{
			return m_PlayerModel.Cash;
		}

		public bool HasCash()
		{
			return m_PlayerModel.Cash > 0;
		}

		public bool HasCash(int amount)
		{
			return m_PlayerModel.Cash >= amount;
		}

		public void SetCash(int amount)
		{
			m_PlayerModel.Cash = amount;
		}

		public void AddCash(int amount)
		{
			m_PlayerModel.Cash += amount;
		}

		public void SubtractCash(int amount)
		{
			m_PlayerModel.Cash -= amount;
		}

		public int CurrentShares(CompanyType company)
		{
			int count = 0;
			m_PlayerModel.Shares.TryGetValue(company, out count);
			return count;
		}

		public bool HasShares(CompanyType company)
		{
			return CurrentShares(company) > 0;
		}

		public bool HasShares(CompanyType company, int count)
		{
			return CurrentShares(company) > count;
		}

		public void SetShares(CompanyType company, int count)
		{
			m_PlayerModel.Shares[company] = count;
		}

		public void AddShares(CompanyType company, int count)
		{
			if (m_PlayerModel.Shares.ContainsKey(company)) {
				m_PlayerModel.Shares[company] += count;
			} else {
				m_PlayerModel.Shares[company] = count;
			}
		}

		public void SubtractShares(CompanyType company, int count)
		{
			if (m_PlayerModel.Shares.ContainsKey(company)) {
				m_PlayerModel.Shares[company] -= count;
			} else {
				m_PlayerModel.Shares[company] = count;
			}
		}

		public int CalculateValueCountShares(StockPriceTier stockPrice, CompanyType company, int count)
		{
			// Note: This is not related to how many shares the player owns,
			// just the value of 'count' company shares of the given stock price.
			return count * stockPrice.Price(company);
		}

		public int CalculateValueCurrentShares(StockPriceTier stockPrice, CompanyType company)
		{
			return CurrentShares(company) * stockPrice.Price(company);
		}

		public int CalculateValueTotalStock(StockPriceTier stockPrice)
		{
			int total = 0;
			foreach (KeyValuePair<CompanyType,int> pair in m_PlayerModel.Shares) {
				total += CalculateValueCurrentShares(stockPrice, pair.Key);
			}
			return total;
		}

		/// <summary>
		/// Calculates the player current net worth.
		/// </summary>
		/// <returns>The net worth.</returns>
		/// <param name="stockPrice">The stock price tier to use for calculation.</param>
		public int CalculateNetWorth(StockPriceTier stockPrice)
		{
			return CurrentCash() + CalculateValueTotalStock(stockPrice);
		}

		/// <summary>
		/// Buy's count shares of company and return the amount of cash spent.
		/// </summary>
		/// <returns>The amount of cash spent.</returns>
		/// <param name="stockPrice">Stock price.</param>
		/// <param name="company">Company.</param>
		/// <param name="count">Count.</param>
		public int BuyShares(StockPriceTier stockPrice, CompanyType company, int count)
		{
			int value = CalculateValueCountShares(stockPrice, company, count);
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
		/// <param name="stockPrice">Stock price.</param>
		/// <param name="company">Company.</param>
		/// <param name="count">Count.</param>
		public int SellShares(StockPriceTier stockPrice, CompanyType company, int count)
		{
			if (!HasShares(company, count)) {
				throw new System.Exception("Not enough owned shares to sell.");
			}
			int value = CalculateValueCountShares(stockPrice, company, count);
			SubtractShares(company, count);
			AddCash(value);
			return value;
		}

		public int CalculateBrokerFee()
		{
			const int fee = 10;
			int shares = 0;
			foreach (KeyValuePair<CompanyType,int> pair in m_PlayerModel.Shares) {
				shares += pair.Value;
			}
			return shares * fee;
		}

		public bool CanAffordBrokerFee()
		{
			return HasCash(CalculateBrokerFee());
		}

		public void GoBackToWork()
		{
			m_PlayerModel.ResetToDefault();
		}

		public bool DoTurn()
		{
			// TODO
			// Check job type
			//   If Worker
			//     If check money > 1000
			//       Need to start trading, ask to pick start location
			//     else
			//       Ask if want to switch job, and if so move token
			//   If Trader
			//     Ask if want to sell some shares before moving?
			//
			// Roll dice
			//   If Trader
			//     Give choices for move locations, can go into stockholder meeting if has shares
			//     Move token
			//     If not in stockholder meeting
			//       Update share slider
			//
			// If Trader
			//   Check tile type that was moved to
			//   If a share tile or stockholder meeting doorway tile
			//      If has shares give dividend
			//      Ask if want to buy more, with limit if doorway tile
			//   Else If stockholder meeting tile
			//      Give bonus shares
			//   Else If sell all shares
			//      Sell all shares
			//   Else If borker fee
			//      Pay broker fee, may need to sell shares at base price
			//   Else must be a start square
			//      Pay 100 fee if already a trader, not on changing from work to start
			//
			// When finished turn return true.
			// return true
			return true;
		}

	}

}
