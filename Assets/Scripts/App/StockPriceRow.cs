using System.Collections.Generic;

namespace App
{
	
	public class StockPriceRow
	{
		//public Dictionary<CompanyType,int> Price;
		private int[] m_Prices;

		public StockPriceRow(int[] prices)
		{
			//Price = new Dictionary<CompanyType, int>();
			//int count = System.Enum.GetValues(typeof(CompanyType)).Length;
			//m_Price = new int[count];

			m_Prices = prices;
		}

		public int Price(CompanyType company)
		{
			return m_Prices[(int)company];
		}
	}

}
