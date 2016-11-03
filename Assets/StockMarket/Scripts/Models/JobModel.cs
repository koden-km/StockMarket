namespace StockMarket.Models
{

	/// <summary>
	/// Job model.
	/// </summary>
	public class JobModel
	{
		#region Constructor(s)

		/// <summary>
		/// Initializes a new instance of the <see cref="App.Model.JobModel"/> class.
		/// </summary>
		/// <param name="job">Job type.</param>
		/// <param name="title">Job title.</param>
		/// <param name="salary">Job salary.</param>
		/// <param name="firstPaysRoll">The first pays on roll value.</param>
		/// <param name="secondPaysRoll">The second pays on roll value.</param>
		public JobModel(JobType job, string title, int salary, int firstPaysRoll, int secondPaysRoll)
		{
			m_Job = job;
			m_Title = title;
			m_Salary = salary;
			m_FirstPaysRoll = firstPaysRoll;
			m_SecondPaysRoll = secondPaysRoll;
		}

		#endregion // Constructor(s)

		#region Properties/Methods

		/// <summary>
		/// Gets the job type.
		/// </summary>
		/// <value>The job type.</value>
		public JobType Job {
			get { return m_Job; }
		}

		/// <summary>
		/// Gets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title {
			get { return m_Title; }
		}

		/// <summary>
		/// Gets the salary.
		/// </summary>
		/// <value>The salary.</value>
		public int Salary {
			get { return m_Salary; }
		}

		/// <summary>
		/// Gets the first pays on dice roll value.
		/// Example:
		/// Doctor pays on dice rolls of 2 and 10.
		/// This value would be the roll of 2.
		/// </summary>
		/// <value>The first pays on dice roll value.</value>
		public int FirstPaysRoll {
			get { return m_FirstPaysRoll; }
		}

		/// <summary>
		/// Gets the second pays on dice roll value.
		/// Example:
		/// Doctor pays on dice rolls of 2 and 10.
		/// This value would be the roll of 10.
		/// </summary>
		/// <value>The second pays on roll value.</value>
		public int SecondPaysRoll {
			get { return m_SecondPaysRoll; }
		}

		#endregion // Properties/Methods

		#region Model Data

		/// <summary>
		/// The job type.
		/// </summary>
		private JobType m_Job;

		/// <summary>
		/// The job title.
		/// </summary>
		private string m_Title;

		/// <summary>
		/// The job salary.
		/// </summary>
		private int m_Salary;

		/// <summary>
		/// The first pays on roll value.
		/// </summary>
		private int m_FirstPaysRoll;

		/// <summary>
		/// The second pays on roll value.
		/// </summary>
		private int m_SecondPaysRoll;

		#endregion // Model Data
	}

}
