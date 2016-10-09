using System.Collections.Generic;

namespace App
{

	/// <summary>
	/// Stock price tier data.
	/// </summary>
	public class StockPriceTier
	{
		private int[] m_Prices;

		/// <summary>
		/// Initializes a new instance of the <see cref="App.StockPriceTier"/> class.
		/// </summary>
		/// <param name="prices">The prices for stock on this tier.</param>
		public StockPriceTier(int[] prices)
		{
			m_Prices = prices;
		}

		/// <summary>
		/// Get the stock price the specified company.
		/// </summary>
		/// <param name="company">The company to get stock price for.</param>
		public int Price(CompanyType company)
		{
			return m_Prices[(int)company];
		}

	}

}
