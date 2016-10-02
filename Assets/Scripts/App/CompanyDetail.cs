
namespace App
{

	/// <summary>
	/// Company details.
	/// </summary>
	public class CompanyDetail
	{
		public CompanyType Company;

		public string Name;

		//public UnityEngine.Color Color;

		// The current stock price?
		//public int StockPrice;

		//public CompanyDetail(CompanyType company, string name, UnityEngine.Color color)
		public CompanyDetail(CompanyType company, string name)
		{
			Company = company;
			Name = name;
			//Color = color;
		}
	}

}
