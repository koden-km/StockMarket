using System.Collections.Generic;

//using Unity
//using Color = UnityEngine.Color;

namespace App
{

	public class GameOptions
	{
		public Dictionary<JobType, JobDetail> Jobs;
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
			Jobs[JobType.Worker200] = new JobDetail(JobType.Worker200, "Doctor", 100, 4, 10);
			Jobs[JobType.Worker300] = new JobDetail(JobType.Worker300, "Deep Sea Diver", 100, 3, 11);
			Jobs[JobType.Worker400] = new JobDetail(JobType.Worker400, "Prospector", 100, 2, 12);

			Companies[CompanyType.AlphaA] = new CompanyDetail(CompanyType.AlphaA, "Alcoa");
			Companies[CompanyType.AlphaB] = new CompanyDetail(CompanyType.AlphaB, "Bank of NSW");
			Companies[CompanyType.AlphaC] = new CompanyDetail(CompanyType.AlphaC, "Ampol");
			Companies[CompanyType.AlphaD] = new CompanyDetail(CompanyType.AlphaD, "BHP");
			Companies[CompanyType.OmegaA] = new CompanyDetail(CompanyType.OmegaA, "Woolworths");
			Companies[CompanyType.OmegaB] = new CompanyDetail(CompanyType.OmegaB, "Consol'D. Press");
			Companies[CompanyType.OmegaC] = new CompanyDetail(CompanyType.OmegaC, "Coles");
			Companies[CompanyType.OmegaD] = new CompanyDetail(CompanyType.OmegaD, "Western Mining");
		}
	}

}
