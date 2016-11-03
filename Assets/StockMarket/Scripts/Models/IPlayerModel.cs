namespace StockMarket.Models
{

	/// <summary>
	/// Interface for player models.
	/// </summary>
	public interface IPlayerModel
	{
		#region Properties

		/// <summary>
		/// The name of the player.
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// The token color of the player.
		/// </summary>
		UnityEngine.Color Color { get; set; }

		/// <summary>
		/// The index of the board tile the player is currently at.
		/// </summary>
		int BoardTileIndex { get; set; }

		/// <summary>
		/// The job type this player is currently doing.
		/// </summary>
		JobType Job { get; set; }

		/// <summary>
		/// The amount of cash this player currently has.
		/// </summary>
		int Cash { get; set; }

		/// <summary>
		/// Gets the shares this player has for the given company.
		/// </summary>
		/// <returns>The shares owned for the given company.</returns>
		/// <param name="company">The company to get shares for.</param>
		int GetShares(CompanyType company);

		/// <summary>
		/// Sets the shares this player has for the given company.
		/// </summary>
		/// <param name="company">Company.</param>
		/// <param name="shares">Shares.</param>
		void SetShares(CompanyType company, int shares);

		/// <summary>
		/// Adds shares to this player for the given company.
		/// </summary>
		/// <param name="company">The company to add shares for.</param>
		/// <param name="shares">The number of shares to add.</param>
		void AddShares(CompanyType company, int shares);

		/// <summary>
		/// Subtract shares from this player for the given company.
		/// </summary>
		/// <param name="company">The company to subtract shares for.</param>
		/// <param name="shares">The number of shares to subtract.</param>
		void SubtractShares(CompanyType company, int shares);

		/// <summary>
		/// Clears all shares for this player.
		/// </summary>
		void ClearAllShares();

		/// <summary>
		/// The company share holder meeting this player is currently attending, or null if not currently attending.
		/// </summary>
		CompanyType? ShareHolderMeeting { get; set; }

		#endregion // Properties

		#region Event Handlers

		//		/// <summary>
		//		/// Occurs when model is about to change.
		//		/// </summary>
		//		event System.EventHandler<PlayerModelChangedEventArgs> ModelChanging = (sender, e) => {};
		//
		//		/// <summary>
		//		/// Occurs when model has changed.
		//		/// </summary>
		//		event System.EventHandler<PlayerModelChangedEventArgs> ModelChanged = (sender, e) => {};

		/// <summary>
		/// Occurs when name is about to change.
		/// </summary>
		event System.EventHandler<PlayerModelChangingEventArgs> NameChanging;

		/// <summary>
		/// Occurs when name has changed.
		/// </summary>
		event System.EventHandler<PlayerModelChangedEventArgs> NameChanged;

		/// <summary>
		/// Occurs when color is about to change.
		/// </summary>
		event System.EventHandler<PlayerModelChangingEventArgs> ColorChanging;

		/// <summary>
		/// Occurs when color has changed.
		/// </summary>
		event System.EventHandler<PlayerModelChangedEventArgs> ColorChanged;

		/// <summary>
		/// Occurs when board index is about to change.
		/// </summary>
		event System.EventHandler<PlayerModelChangingEventArgs> BoardTileIndexChanging;

		/// <summary>
		/// Occurs when board index has changed.
		/// </summary>
		event System.EventHandler<PlayerModelChangedEventArgs> BoardTileIndexChanged;

		/// <summary>
		/// Occurs when job is about to change.
		/// </summary>
		event System.EventHandler<PlayerModelChangingEventArgs> JobChanging;

		/// <summary>
		/// Occurs when job has changed.
		/// </summary>
		event System.EventHandler<PlayerModelChangedEventArgs> JobChanged;

		/// <summary>
		/// Occurs when cash is about to change.
		/// </summary>
		event System.EventHandler<PlayerModelChangingEventArgs> CashChanging;

		/// <summary>
		/// Occurs when cash has changed.
		/// </summary>
		event System.EventHandler<PlayerModelChangedEventArgs> CashChanged;

		/// <summary>
		/// Occurs when shares is about to change.
		/// </summary>
		event System.EventHandler<PlayerModelChangingEventArgs> SharesChanging;

		/// <summary>
		/// Occurs when shares has changed.
		/// </summary>
		event System.EventHandler<PlayerModelChangedEventArgs> SharesChanged;

		/// <summary>
		/// Occurs when share holder meeting is about to change.
		/// </summary>
		event System.EventHandler<PlayerModelChangingEventArgs> ShareHolderMeetingChanging;

		/// <summary>
		/// Occurs when share holder meeting has changed.
		/// </summary>
		event System.EventHandler<PlayerModelChangedEventArgs> ShareHolderMeetingChanged;

		#endregion // Event Handlers
	}

}
