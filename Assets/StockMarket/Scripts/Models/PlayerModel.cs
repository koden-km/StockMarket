using System.Collections.Generic;

namespace StockMarket.Models
{

	/// <summary>
	/// Player model.
	/// </summary>
	public class PlayerModel : IPlayerModel
	{
		#region Constructor(s)

		/// <summary>
		/// Initializes a new instance of the <see cref="App.Model.PlayerModel"/> class.
		/// This is a convenience constructor.
		/// </summary>
		/// <param name="name">Name.</param>
		public PlayerModel(string name)
			: this(
				name,
				UnityEngine.Color.white,
				JobType.Worker100,
				0,
				0,
				new Dictionary<CompanyType,int>(),
				null
			)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="App.Model.PlayerModel"/> class.
		/// This is the designated constructor.
		/// </summary>
		/// <param name="name">Name of player.</param>
		/// <param name="color">Color of player token.</param>
		/// <param name="job">Job.</param>
		/// <param name="boardTileIndex">Board tile index.</param>
		/// <param name="cash">Cash.</param>
		/// <param name="shares">Company shares.</param>
		/// <param name="shareHolderMeeting">Company share holder meeting currently attending, or null if not currently attending.</param>
		public PlayerModel(
			string name,
			UnityEngine.Color color,
			JobType job,
			int boardTileIndex,
			int cash,
			Dictionary<CompanyType,int> shares,
			CompanyType? shareHolderMeeting
		)
		{
			Name = name;
			Color = color;
			Job = job;
			BoardTileIndex = boardTileIndex;
			Cash = cash;
			SetShares(shares);
			ShareHolderMeeting = shareHolderMeeting;
		}

		#endregion // Constructor(s)

		#region Properties/Methods

		/// <summary>
		/// The name of the player.
		/// </summary>
		/// <value>The name of the player.</value>
		public string Name {
			get { return m_Name; }
			set {
				if (m_Name != value) {
					OnNameChanging(new PlayerNameEventArgs(m_Name));
					m_Name = value;
					OnNameChanged(new PlayerNameEventArgs(m_Name));
				}
			}
		}

		/// <summary>
		/// The token color of the player.
		/// </summary>
		public UnityEngine.Color Color {
			get { return m_Color; }
			set {
				if (m_Color != value) {
					OnColorChanging(new PlayerModelChangingEventArgs("Color"));
					m_Color = value;
					OnColorChanged(new PlayerModelChangedEventArgs("Color"));
				}
			}
		}

		/// <summary>
		/// The job type this player is currently doing.
		/// </summary>
		public JobType Job {
			get { return m_Job; }
			set {
				if (m_Job != value) {
					OnJobChanging(new PlayerModelChangingEventArgs("Job"));
					m_Job = value;
					OnJobChanged(new PlayerModelChangedEventArgs("Job"));
				}
			}
		}

		/// <summary>
		/// The index of the board tile the player is currently at.
		/// </summary>
		public int BoardTileIndex {
			get { return m_BoardTileIndex; }
			set {
				if (m_BoardTileIndex != value) {
					OnBoardTileIndexChanging(new PlayerModelChangingEventArgs("BoardTileIndex"));
					m_BoardTileIndex = value;
					OnBoardTileIndexChanged(new PlayerModelChangedEventArgs("BoardTileIndex"));
				}
			}
		}

		/// <summary>
		/// The amount of cash this player currently has.
		/// </summary>
		public int Cash {
			get { return m_Cash; }
			set {
				if (m_Cash != value) {
					OnCashChanging(new PlayerModelChangingEventArgs("Cash"));
					m_Cash = value;
					OnCashChanged(new PlayerModelChangedEventArgs("Cash"));
				}
			}
		}

		/// <summary>
		/// Gets the shares this player has for the given company.
		/// </summary>
		/// <returns>The shares owned for the given company.</returns>
		/// <param name="company">The company to get shares for.</param>
		public int GetShares(CompanyType company)
		{
			int shares = 0;
			m_Shares.TryGetValue(company, out shares);
			return shares;
		}

		/// <summary>
		/// Sets the shares this player has for the given company.
		/// </summary>
		/// <param name="company">The company to set shares for.</param>
		/// <param name="shares">The number of shares to set.</param>
		public void SetShares(CompanyType company, int shares)
		{
			int currentShares = GetShares(company);
			if (shares != currentShares) {
				OnSharesChanging(new PlayerModelChangingEventArgs("Shares"));
				m_Shares[company] = shares;
				OnSharesChanged(new PlayerModelChangedEventArgs("Shares"));
			}
		}

		/// <summary>
		/// Sets all the shares this player has.
		/// </summary>
		/// <param name="shares">The new shares object.</param>
		protected void SetShares(Dictionary<CompanyType,int> shares)
		{
			if (m_Shares != shares) {
				OnSharesChanging(new PlayerModelChangingEventArgs("Shares"));
				m_Shares = shares;
				OnSharesChanged(new PlayerModelChangedEventArgs("Shares"));
			}
		}

		/// <summary>
		/// Adds shares to this player for the given company.
		/// </summary>
		/// <param name="company">The company to add shares for.</param>
		/// <param name="shares">The number of shares to add.</param>
		public void AddShares(CompanyType company, int shares)
		{
			SetShares(company, GetShares(company) + shares);
		}

		/// <summary>
		/// Subtract shares from this player for the given company.
		/// </summary>
		/// <param name="company">The company to subtract shares for.</param>
		/// <param name="shares">The number of shares to subtract.</param>
		public void SubtractShares(CompanyType company, int shares)
		{
			SetShares(company, GetShares(company) - shares);
		}

		/// <summary>
		/// Clears all shares for this player.
		/// </summary>
		public void ClearAllShares()
		{
			OnSharesChanging(new PlayerModelChangingEventArgs("Shares"));
			m_Shares.Clear();
			OnSharesChanged(new PlayerModelChangedEventArgs("Shares"));
		}

		/// <summary>
		/// The company share holder meeting this player is currently attending, or null if not currently attending.
		/// </summary>
		public CompanyType? ShareHolderMeeting {
			get { return m_ShareHolderMeeting; }
			set {
				if (m_ShareHolderMeeting != value) {
					OnShareHolderMeetingChanging(new PlayerModelChangingEventArgs("ShareHolderMeeting"));
					m_ShareHolderMeeting = value;
					OnShareHolderMeetingChanged(new PlayerModelChangedEventArgs("ShareHolderMeeting"));
				}
			}
		}

		#endregion // Properties/Methods

		#region Event Handlers

		/// <summary>
		/// Occurs when name is about to change.
		/// </summary>
		public event System.EventHandler<PlayerModelChangingEventArgs> NameChanging = (sender, e) => {};

		/// <summary>
		/// Occurs when name has changed.
		/// </summary>
		public event System.EventHandler<PlayerModelChangedEventArgs> NameChanged = (sender, e) => {};

		/// <summary>
		/// Occurs when color is about to change.
		/// </summary>
		public event System.EventHandler<PlayerModelChangingEventArgs> ColorChanging = (sender, e) => {};

		/// <summary>
		/// Occurs when color has changed.
		/// </summary>
		public event System.EventHandler<PlayerModelChangedEventArgs> ColorChanged = (sender, e) => {};

		/// <summary>
		/// Occurs when job is about to change.
		/// </summary>
		public event System.EventHandler<PlayerModelChangingEventArgs> JobChanging = (sender, e) => {};

		/// <summary>
		/// Occurs when job has changed.
		/// </summary>
		public event System.EventHandler<PlayerModelChangedEventArgs> JobChanged = (sender, e) => {};

		/// <summary>
		/// Occurs when board index is about to change.
		/// </summary>
		public event System.EventHandler<PlayerModelChangingEventArgs> BoardTileIndexChanging = (sender, e) => {};

		/// <summary>
		/// Occurs when board index has changed.
		/// </summary>
		public event System.EventHandler<PlayerModelChangedEventArgs> BoardTileIndexChanged = (sender, e) => {};

		/// <summary>
		/// Occurs when cash is about to change.
		/// </summary>
		public event System.EventHandler<PlayerModelChangingEventArgs> CashChanging = (sender, e) => {};

		/// <summary>
		/// Occurs when cash has changed.
		/// </summary>
		public event System.EventHandler<PlayerModelChangedEventArgs> CashChanged = (sender, e) => {};

		/// <summary>
		/// Occurs when shares is about to change.
		/// </summary>
		public event System.EventHandler<PlayerModelChangingEventArgs> SharesChanging = (sender, e) => {};

		/// <summary>
		/// Occurs when shares has changed.
		/// </summary>
		public event System.EventHandler<PlayerModelChangedEventArgs> SharesChanged = (sender, e) => {};

		/// <summary>
		/// Occurs when share holder meeting is about to change.
		/// </summary>
		public event System.EventHandler<PlayerModelChangingEventArgs> ShareHolderMeetingChanging = (sender, e) => {};

		/// <summary>
		/// Occurs when share holder meeting has changed.
		/// </summary>
		public event System.EventHandler<PlayerModelChangedEventArgs> ShareHolderMeetingChanged = (sender, e) => {};

		#endregion // Event Handlers

		#region Event Triggers

		/// <summary>
		/// Raises the name changing event.
		/// </summary>
		/// <param name="eventArgs">Event arguments.</param>
		protected virtual void OnNameChanging(PlayerModelChangingEventArgs eventArgs)
		{
			NameChanging(this, eventArgs);
		}

		/// <summary>
		/// Raises the name changed event.
		/// </summary>
		/// <param name="eventArgs">Event arguments.</param>
		protected virtual void OnNameChanged(PlayerModelChangedEventArgs eventArgs)
		{
			NameChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the color changing event.
		/// </summary>
		/// <param name="eventArgs">Event arguments.</param>
		protected virtual void OnColorChanging(PlayerModelChangingEventArgs eventArgs)
		{
			ColorChanging(this, eventArgs);
		}

		/// <summary>
		/// Raises the color changed event.
		/// </summary>
		/// <param name="eventArgs">Event arguments.</param>
		protected virtual void OnColorChanged(PlayerModelChangedEventArgs eventArgs)
		{
			ColorChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the job changing event.
		/// </summary>
		/// <param name="eventArgs">Event arguments.</param>
		protected virtual void OnJobChanging(PlayerModelChangingEventArgs eventArgs)
		{
			JobChanging(this, eventArgs);
		}

		/// <summary>
		/// Raises the job changed event.
		/// </summary>
		/// <param name="eventArgs">Event arguments.</param>
		protected virtual void OnJobChanged(PlayerModelChangedEventArgs eventArgs)
		{
			JobChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the board tile index changing event.
		/// </summary>
		/// <param name="eventArgs">Event arguments.</param>
		protected virtual void OnBoardTileIndexChanging(PlayerModelChangingEventArgs eventArgs)
		{
			BoardTileIndexChanging(this, eventArgs);
		}

		/// <summary>
		/// Raises the board tile index changed event.
		/// </summary>
		/// <param name="eventArgs">Event arguments.</param>
		protected virtual void OnBoardTileIndexChanged(PlayerModelChangedEventArgs eventArgs)
		{
			BoardTileIndexChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the cash changing event.
		/// </summary>
		/// <param name="eventArgs">Event arguments.</param>
		protected virtual void OnCashChanging(PlayerModelChangingEventArgs eventArgs)
		{
			CashChanging(this, eventArgs);
		}

		/// <summary>
		/// Raises the cash changed event.
		/// </summary>
		/// <param name="eventArgs">Event arguments.</param>
		protected virtual void OnCashChanged(PlayerModelChangedEventArgs eventArgs)
		{
			CashChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the shares changing event.
		/// </summary>
		/// <param name="eventArgs">Event arguments.</param>
		protected virtual void OnSharesChanging(PlayerModelChangingEventArgs eventArgs)
		{
			SharesChanging(this, eventArgs);
		}

		/// <summary>
		/// Raises the shares changed event.
		/// </summary>
		/// <param name="eventArgs">Event arguments.</param>
		protected virtual void OnSharesChanged(PlayerModelChangedEventArgs eventArgs)
		{
			SharesChanged(this, eventArgs);
		}

		/// <summary>
		/// Raises the share holder meeting changing event.
		/// </summary>
		/// <param name="eventArgs">Event arguments.</param>
		protected virtual void OnShareHolderMeetingChanging(PlayerModelChangingEventArgs eventArgs)
		{
			ShareHolderMeetingChanging(this, eventArgs);
		}

		/// <summary>
		/// Raises the share holder meeting changed event.
		/// </summary>
		/// <param name="eventArgs">Event arguments.</param>
		protected virtual void OnShareHolderMeetingChanged(PlayerModelChangedEventArgs eventArgs)
		{
			ShareHolderMeetingChanged(this, eventArgs);
		}

		#endregion // Event Triggers

		#region Model Data

		/// <summary>
		/// The name of the player.
		/// </summary>
		private string m_Name;

		/// <summary>
		/// The token color of the player.
		/// </summary>
		private UnityEngine.Color m_Color;

		/// <summary>
		/// The job type this player is currently doing.
		/// </summary>
		private JobType m_Job;

		/// <summary>
		/// The index of the board tile the player is currently at.
		/// </summary>
		private int m_BoardTileIndex;

		/// <summary>
		/// The amount of cash this player currently has.
		/// </summary>
		private int m_Cash;

		/// <summary>
		/// The shares this player currently has.
		/// A map of company type to share count.
		/// </summary>
		private Dictionary<CompanyType,int> m_Shares;

		/// <summary>
		/// The company share holder meeting this player is currently attending, or null if not currently attending.
		/// </summary>
		private CompanyType? m_ShareHolderMeeting;

		#endregion // Model Data
	}

}
