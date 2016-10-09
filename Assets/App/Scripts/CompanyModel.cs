
namespace App
{

	/// <summary>
	/// Company details.
	/// </summary>
	public class CompanyModel
	{
		/// <summary>
		/// The company type.
		/// </summary>
		public CompanyType Company;

		/// <summary>
		/// The name of the company.
		/// </summary>
		public string Name;

		/// <summary>
		/// The color of the company.
		/// </summary>
		public UnityEngine.Color Color;

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		/// <param name="company">Company type.</param>
		/// <param name="name">Name of company.</param>
		/// <param name="color">Color of company.</param>
		public CompanyModel(CompanyType company, string name, UnityEngine.Color color)
		{
			Company = company;
			Name = name;
			Color = color;
		}
	}

}
