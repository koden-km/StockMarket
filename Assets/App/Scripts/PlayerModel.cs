//using UnityEngine;
using System.Collections.Generic;

namespace App
{

	/// <summary>
	/// Player model.
	/// </summary>
	public class PlayerModel : IPlayerModel
	{

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="App.PlayerModel"/> class.
		/// </summary>
		/// <param name="name">Name.</param>
		public PlayerModel(string name)
			: this(
				name,
				UnityEngine.Color.white,
				0,
				0,
				JobType.Worker100,
				new Dictionary<CompanyType,int>(),
				null
			)
		{
			//m_Shares[CompanyType.AlphaA] = 0;
			//m_Shares[CompanyType.AlphaB] = 0;
			//m_Shares[CompanyType.AlphaC] = 0;
			//m_Shares[CompanyType.AlphaD] = 0;
			//m_Shares[CompanyType.OmegaA] = 0;
			//m_Shares[CompanyType.OmegaB] = 0;
			//m_Shares[CompanyType.OmegaC] = 0;
			//m_Shares[CompanyType.OmegaD] = 0;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="App.PlayerModel"/> class.
		/// This is the designated constructor.
		/// </summary>
		/// <param name="name">Name of player.</param>
		/// <param name="color">Color of player token.</param>
		/// <param name="cash">Cash.</param>
		/// <param name="boardTileIndex">Board tile index.</param>
		/// <param name="job">Job.</param>
		/// <param name="shares">Company shares.</param>
		/// <param name="shareholderMeeting">Company share holder meeting currently attending, or null if not currently attending.</param>
		public PlayerModel(
			string name,
			UnityEngine.Color color,
			int cash,
			int boardTileIndex,
			JobType job,
			Dictionary<CompanyType,int> shares,
			CompanyType? shareholderMeeting
		)
		{
			Name = name;
			Color = color;
			Cash = cash;
			BoardTileIndex = boardTileIndex;
			Job = job;
			Shares = shares;
			ShareHolderMeeting = ShareHolderMeeting;
		}

		#endregion // Constructors

		#region Helpers

		/// <summary>
		/// Resets to default values.
		/// Can be used when bankrupt and/or going back to work.
		/// </summary>
		public void ResetValues()
		{
			//OnModelChanging(new PlayerModelChangedEventArgs(""));

			Cash = 0;
			BoardTileIndex = 0;
			Job = JobType.Worker100;
			ShareHolderMeeting = null;

			// Set and send event manually to prevent resending the event every time.
			OnSharesChanging(new PlayerModelChangingEventArgs("Shares"));
			m_Shares[CompanyType.AlphaA] = 0;
			m_Shares[CompanyType.AlphaB] = 0;
			m_Shares[CompanyType.AlphaC] = 0;
			m_Shares[CompanyType.AlphaD] = 0;
			m_Shares[CompanyType.OmegaA] = 0;
			m_Shares[CompanyType.OmegaB] = 0;
			m_Shares[CompanyType.OmegaC] = 0;
			m_Shares[CompanyType.OmegaD] = 0;
			OnSharesChanged(new PlayerModelChangedEventArgs("Shares"));

			//OnModelChanged(new PlayerModelChangedEventArgs(""));
		}

		#endregion // Helpers

		#region Properties

		/// <summary>
		/// The name of the player.
		/// </summary>
		/// <value>The name of the player.</value>
		public string Name {
			get { return m_Name; }
			set {
				if (m_Name != value) {
					OnNameChanging(new PlayerModelChangingEventArgs("Name"));
					m_Name = value;
					OnNameChanged(new PlayerModelChangedEventArgs("Name"));
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
		/// The shares this player currently has.
		/// A map of company type to share count.
		/// </summary>
		public Dictionary<CompanyType,int> Shares {

			// TODO: Try refactor this out. Maybe just have a bunch of Int fields for the shares of each type?
			//get { return m_Shares; }
			get { return new Dictionary<CompanyType,int>(m_Shares); }

			protected set {
				if (m_Shares != value) {
					OnSharesChanging(new PlayerModelChangingEventArgs("Shares"));
					m_Shares = value;
					OnSharesChanged(new PlayerModelChangedEventArgs("Shares"));
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
		/// <param name="company">Company.</param>
		/// <param name="shares">Shares.</param>
		public void SetShares(CompanyType company, int shares)
		{
			int currentShares = m_Shares[company];
			if (shares != currentShares) {
				OnSharesChanging(new PlayerModelChangingEventArgs("Shares"));
				m_Shares[company] = shares;
				OnSharesChanged(new PlayerModelChangedEventArgs("Shares"));
			}
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

		#endregion // Properties

		#region Event Handlers

		//		/// <summary>
		//		/// Occurs when model is about to change.
		//		/// </summary>
		//		public event System.EventHandler<PlayerModelChangingEventArgs> ModelChanging = (sender, e) => {};
		//
		//		/// <summary>
		//		/// Occurs when model has changed.
		//		/// </summary>
		//		public event System.EventHandler<PlayerModelChangedEventArgs> ModelChanged = (sender, e) => {};

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
		/// Occurs when board index is about to change.
		/// </summary>
		public event System.EventHandler<PlayerModelChangingEventArgs> BoardTileIndexChanging = (sender, e) => {};

		/// <summary>
		/// Occurs when board index has changed.
		/// </summary>
		public event System.EventHandler<PlayerModelChangedEventArgs> BoardTileIndexChanged = (sender, e) => {};

		/// <summary>
		/// Occurs when job is about to change.
		/// </summary>
		public event System.EventHandler<PlayerModelChangingEventArgs> JobChanging = (sender, e) => {};

		/// <summary>
		/// Occurs when job has changed.
		/// </summary>
		public event System.EventHandler<PlayerModelChangedEventArgs> JobChanged = (sender, e) => {};

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

		//		/// <summary>
		//		/// Raises the model changing event.
		//		/// </summary>
		//		/// <param name="eventArgs">Event arguments.</param>
		//		protected virtual void OnModelChanging(PlayerModelChangingEventArgs eventArgs)
		//		{
		//			ModelChanging(this, eventArgs);
		//		}
		//
		//		/// <summary>
		//		/// Raises the model changed event.
		//		/// </summary>
		//		/// <param name="eventArgs">Event arguments.</param>
		//		protected virtual void OnModelChanged(PlayerModelChangedEventArgs eventArgs)
		//		{
		//			ModelChanged(this, eventArgs);
		//		}

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

		#region Data

		/// <summary>
		/// The name of the player.
		/// </summary>
		private string m_Name;

		/// <summary>
		/// The token color of the player.
		/// </summary>
		private UnityEngine.Color m_Color;

		/// <summary>
		/// The amount of cash this player currently has.
		/// </summary>
		private int m_Cash;

		/// <summary>
		/// The index of the board tile the player is currently at.
		/// </summary>
		private int m_BoardTileIndex;

		/// <summary>
		/// The job type this player is currently doing.
		/// </summary>
		private JobType m_Job;

		/// <summary>
		/// The shares this player currently has.
		/// A map of company type to share count.
		/// </summary>
		private Dictionary<CompanyType,int> m_Shares;

		/// <summary>
		/// The company share holder meeting this player is currently attending, or null if not currently attending.
		/// </summary>
		private CompanyType? m_ShareHolderMeeting;

		#endregion // Data
	}

}
