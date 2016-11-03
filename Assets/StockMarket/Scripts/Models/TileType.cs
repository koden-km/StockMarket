namespace StockMarket.Models
{

	/// <summary>
	/// Tile type.
	/// </summary>
	public enum TileType
	{
		/// <summary>
		/// A job tile.
		/// </summary>
		Job,

		/// <summary>
		/// A start tile.
		/// </summary>
		Start,

		/// <summary>
		/// A broker fee tile.
		/// </summary>
		BrokerFee,

		/// <summary>
		/// A buy many shares tile.
		/// </summary>
		BuyMany,

		/// <summary>
		/// A buy one share tile.
		/// </summary>
		BuyOne,

		/// <summary>
		/// A share holder meeting 1 for 1 tile.
		/// </summary>
		Meeting1for1,

		/// <summary>
		/// A share holder meeting 2 for 1 tile.
		/// </summary>
		Meeting2for1,

		/// <summary>
		/// A share holder meeting 3 for 1 tile.
		/// </summary>
		Meeting3for1,

		/// <summary>
		/// A sell all company shares tile.
		/// </summary>
		SellAllCompany,
	}

}
