namespace StockMarket.Models
{

	/// <summary>
	/// Board tile move flags.
	/// </summary>
	[System.Flags]
	public enum BoardTileMoveFlags
	{
		/// <summary>
		/// Can move to any other job when player is working.
		/// </summary>
		Job,

		/// <summary>
		/// Can move left.
		/// </summary>
		Left,

		/// <summary>
		/// Can move right.
		/// </summary>
		Right,

		/// <summary>
		/// Can move up into shareholder meeting, if has company shares.
		/// </summary>
		Up,
	}

}
