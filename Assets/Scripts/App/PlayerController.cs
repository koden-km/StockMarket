//using UnityEngine;
using System.Collections.Generic;

namespace App
{

	public class PlayerController
	{
		private PlayerModel playerModel;

		public PlayerController(PlayerModel player)
		{
			playerModel = player;
		}

		public bool HasShares(CompanyType company)
		{
			return playerModel.Shares.ContainsKey(company);
		}

		public int GetShares(CompanyType company)
		{
			int count = 0;
			playerModel.Shares.TryGetValue(company, out count);
			return count;
		}

		public void SetShares(CompanyType company, int count)
		{
			playerModel.Shares[company] = count;
		}

		public void AddShares(CompanyType company, int count)
		{
			if (playerModel.Shares.ContainsKey(company)) {
				playerModel.Shares[company] += count;
			} else {
				playerModel.Shares[company] = count;
			}
		}

		public void SubtractShares(CompanyType company, int count)
		{
			if (playerModel.Shares.ContainsKey(company)) {
				playerModel.Shares[company] -= count;
			} else {
				playerModel.Shares[company] = count;
			}
		}

		public int CalculateStockValue(StockPriceRow stockPrice, CompanyType company)
		{
			return GetShares(company) * stockPrice.Price(company);
		}

		public int CalculateStockTotalValue(StockPriceRow stockPrice)
		{
			int total = 0;
			foreach (KeyValuePair<CompanyType,int> pair in playerModel.Shares) {
				total += CalculateStockValue(stockPrice, pair.Key);
			}
			return total;
		}

		public int CalculateNetWorth()
		{
			return playerModel.Cash + CalculateStockTotalValue();
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
			//      Do nothing
			//
			// When finished turn return true.
			// return true
			return true;
		}

	}

}
