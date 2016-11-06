using System.Collections.Generic;

namespace StockMarket.Models
{

	public class GameModel : IGameModel
	{
		#region Factory Method(s)

		/// <summary>
		/// Creates the new game model.
		/// </summary>
		/// <returns>The new game model.</returns>
		public static IGameModel CreateNewGame()
		{
			GameModel game = new GameModel();
			game.m_Board = new BoardModel(game);
			return game;
		}

		#endregion // Factory Method(s)

		#region Properties/Methods

		/// <summary>
		/// Gets the job details.
		/// </summary>
		/// <returns>The job details.</returns>
		/// <param name="job">The job to get details for.</param>
		public JobModel GetJob(JobType job)
		{
			return m_Jobs[job];
		}

		/// <summary>
		/// Gets the company details.
		/// </summary>
		/// <returns>The company details.</returns>
		/// <param name="company">The company to get details for.</param>
		public CompanyModel GetCompany(CompanyType company)
		{
			return m_Companies[company];
		}

		/// <summary>
		/// Gets or sets the index of the current player who's turn it is.
		/// </summary>
		/// <value>The index of the current player who's turn it is.</value>
		public int CurrentPlayerIndex {
			get { return m_CurrentPlayerIndex; }
			set {
				if (m_CurrentPlayerIndex != value) {
					// OnChanging...
					m_CurrentPlayerIndex = value;
					// OnChanged...
				}
			}
		}

		/// <summary>
		/// Gets or sets the index of the current price tier.
		/// </summary>
		/// <value>The index of the current price tier.</value>
		public int CurrentPriceIndex {
			get { return m_CurrentPriceIndex; }
			set {
				if (m_CurrentPriceIndex != value) {
					// OnChanging...
					m_CurrentPriceIndex = value;
					// OnChanged...
				}
			}
		}

		//		// Not sure if i should make this available on the GameModel... maybe GameService or BoardModel/Service?
		//		/// <summary>
		//		/// Gets the current price tier.
		//		/// </summary>
		//		/// <value>The current price tier.</value>
		//		public StockPriceTier CurrentPriceTier {
		//			get { return Board.PriceTable[CurrentPlayerIndex]; }
		//		}

		/// <summary>
		/// Gets or sets the price index change amount.
		/// A negative value will go down, a positive value will go up.
		/// If the index hits the end it should invert +/- and continue in other direction.
		/// </summary>
		/// <value>The price index change amount.</value>
		public int PriceIndexChange {
			get { return m_PriceIndexChange; }
			set {
				if (m_PriceIndexChange != value) {
					// OnChanging...
					m_PriceIndexChange = value;
					// OnChanged...
				}
			}
		}

		/// <summary>
		/// Gets or sets the winning net worth amount.
		/// A player will win the game when their net worth reaches this value on their turn to roll the dice.
		/// </summary>
		/// <value>The winning net worth amount.</value>
		public int WinningNetWorthAmount {
			get { return m_WinningNetWorthAmount; }
			set {
				if (m_WinningNetWorthAmount != value) {
					// OnChanging...
					m_WinningNetWorthAmount = value;
					// OnChanged...
				}
			}
		}

		/// <summary>
		/// Gets the game board details.
		/// </summary>
		/// <value>The board details.</value>
		public BoardModel Board {
			get { return m_Board; }
		}

		/// <summary>
		/// Gets the players currently in the game.
		/// </summary>
		/// <value>The players currently in the game.</value>
		public List<IPlayerModel> Players {
			get { return m_Players; }
		}

		//		/// <summary>
		//		/// Add a player to the game.
		//		/// </summary>
		//		/// <param name="player">The player to add.</param>
		//		public void AddPlayer(IPlayerModel player)
		//		{
		//			m_Players.Add(player);
		//		}

		// TODO: this should go on a GameService class. It is game logic.
		//		/// <summary>
		//		/// Resets to default values.
		//		/// Can be used when starting a new game.
		//		/// </summary>
		//		public void ResetToDefault()
		//		{
		//		}

		#endregion // Properties/Methods

		#region Constructor(s)

		/// <summary>
		/// Initializes a new instance of the <see cref="App.Model.GameModel"/> class.
		/// </summary>
		private GameModel()
		{
			m_Jobs = new Dictionary<JobType, JobModel>(4);
			m_Companies = new Dictionary<CompanyType, CompanyModel>(8);

			m_Jobs[JobType.Worker100] = new JobModel(JobType.Worker100, "Policeman", 100, 5, 9);
			m_Jobs[JobType.Worker200] = new JobModel(JobType.Worker200, "Doctor", 200, 4, 10);
			m_Jobs[JobType.Worker300] = new JobModel(JobType.Worker300, "Deep Sea Diver", 300, 3, 11);
			m_Jobs[JobType.Worker400] = new JobModel(JobType.Worker400, "Prospector", 400, 2, 12);

			m_Companies[CompanyType.AlphaA] = new CompanyModel(CompanyType.AlphaA, "Alcoa", UnityEngine.Color.red);
			m_Companies[CompanyType.AlphaB] = new CompanyModel(CompanyType.AlphaB, "Bank of NSW", UnityEngine.Color.yellow);
			m_Companies[CompanyType.AlphaC] = new CompanyModel(CompanyType.AlphaC, "Ampol", new UnityEngine.Color(0.4f, 0.39f, 0.35f));
			m_Companies[CompanyType.AlphaD] = new CompanyModel(CompanyType.AlphaD, "BHP", UnityEngine.Color.blue);

			m_Companies[CompanyType.OmegaA] = new CompanyModel(CompanyType.OmegaA, "Woolworths", new UnityEngine.Color(0.71f, 0.29f, 0.14f));
			m_Companies[CompanyType.OmegaB] = new CompanyModel(CompanyType.OmegaB, "Consol'D. Press", UnityEngine.Color.green);
			m_Companies[CompanyType.OmegaC] = new CompanyModel(CompanyType.OmegaC, "Coles", new UnityEngine.Color(0.12f, 0.4f, 0.41f));
			m_Companies[CompanyType.OmegaD] = new CompanyModel(CompanyType.OmegaD, "Western Mining", UnityEngine.Color.magenta);

			m_CurrentPlayerIndex = 0;
			m_CurrentPriceIndex = 26;
			m_PriceIndexChange = 0;
			m_WinningNetWorthAmount = 100000;

			m_Board = null; //new BoardModel(this);

			m_Players = new List<IPlayerModel>();
		}

		#endregion // Constructor(s)

		#region Model Data

		/// <summary>
		/// The jobs details map.
		/// </summary>
		private Dictionary<JobType, JobModel> m_Jobs;

		/// <summary>
		/// The company details map.
		/// </summary>
		private Dictionary<CompanyType, CompanyModel> m_Companies;

		/// <summary>
		/// The current player index who's turn it is.
		/// </summary>
		private int m_CurrentPlayerIndex;

		/// <summary>
		/// The current index of the stock price table.
		/// </summary>
		private int m_CurrentPriceIndex;

		/// <summary>
		/// The price index change amount.
		/// A negative value will go down, a positive value will go up.
		/// If the index hits the end it should invert +/- and continue in other direction.
		/// </summary>
		private int m_PriceIndexChange;

		/// <summary>
		/// The winning net worth amount.
		/// To win the game, a player must have a net worth of this value at their turn to roll the dice.
		/// </summary>
		private int m_WinningNetWorthAmount;

		/// <summary>
		/// The game board.
		/// </summary>
		private BoardModel m_Board;

		/// <summary>
		/// The players currently in the game.
		/// </summary>
		private List<IPlayerModel> m_Players;

		#endregion // Model Data
	}

}
