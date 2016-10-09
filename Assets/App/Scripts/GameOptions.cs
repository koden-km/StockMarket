using System.Collections.Generic;

namespace App
{

	/// <summary>
	/// Game options.
	/// </summary>
	public class GameOptions
	{
		/// <summary>
		/// The jobs details map.
		/// </summary>
		public Dictionary<JobType, JobDetail> Jobs;

		/// <summary>
		/// The company details map.
		/// </summary>
		public Dictionary<CompanyType, CompanyDetail> Companies;

		/// <summary>
		/// Initializes a new instance of the <see cref="App.GameOptions"/> class.
		/// Use default values from original board game.
		/// </summary>
		public GameOptions()
		{
			Jobs = new Dictionary<JobType, JobDetail>();
			Companies = new Dictionary<CompanyType, CompanyDetail>();

			Jobs[JobType.Worker100] = new JobDetail(JobType.Worker100, "Policeman", 100, 5, 9);
			Jobs[JobType.Worker200] = new JobDetail(JobType.Worker200, "Doctor", 200, 4, 10);
			Jobs[JobType.Worker300] = new JobDetail(JobType.Worker300, "Deep Sea Diver", 300, 3, 11);
			Jobs[JobType.Worker400] = new JobDetail(JobType.Worker400, "Prospector", 400, 2, 12);

			Companies[CompanyType.AlphaA] = new CompanyDetail(CompanyType.AlphaA, "Alcoa", UnityEngine.Color.red);
			Companies[CompanyType.AlphaB] = new CompanyDetail(CompanyType.AlphaB, "Bank of NSW", UnityEngine.Color.yellow);
			Companies[CompanyType.AlphaC] = new CompanyDetail(CompanyType.AlphaC, "Ampol", new UnityEngine.Color(0.4f, 0.39f, 0.35f));
			Companies[CompanyType.AlphaD] = new CompanyDetail(CompanyType.AlphaD, "BHP", UnityEngine.Color.blue);

			Companies[CompanyType.OmegaA] = new CompanyDetail(CompanyType.OmegaA, "Woolworths", new UnityEngine.Color(0.71f, 0.29f, 0.14f));
			Companies[CompanyType.OmegaB] = new CompanyDetail(CompanyType.OmegaB, "Consol'D. Press", UnityEngine.Color.green);
			Companies[CompanyType.OmegaC] = new CompanyDetail(CompanyType.OmegaC, "Coles", new UnityEngine.Color(0.12f, 0.4f, 0.41f));
			Companies[CompanyType.OmegaD] = new CompanyDetail(CompanyType.OmegaD, "Western Mining", UnityEngine.Color.magenta);
		}

	}

}
