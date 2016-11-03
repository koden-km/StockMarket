namespace StockMarket.Models
{

	/// <summary>
	/// Stock price tier data.
	/// </summary>
	public class StockPriceTier
	{
		#region Constructor(s)

		/// <summary>
		/// Initializes a new instance of the <see cref="App.Model.StockPriceTier"/> class.
		/// </summary>
		/// <param name="prices">The prices for stock on this tier.</param>
		public StockPriceTier(int[] prices)
		{
			m_Prices = prices;
		}

		#endregion // Constructor(s)

		#region Properties/Methods

		/// <summary>
		/// Get the stock price the specified company.
		/// </summary>
		/// <param name="company">The company to get stock price for.</param>
		public int Price(CompanyType company)
		{
			return m_Prices[(int)company];
		}

		#endregion // Properties/Methods

		#region Model Data

		/// <summary>
		/// The stock prices for this tier.
		/// </summary>
		private int[] m_Prices;

		#endregion // Model Data
	}

}
