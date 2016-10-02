﻿
namespace App
{

	/// <summary>
	/// Job details.
	/// </summary>
	public class JobDetail
	{
		public JobType Job;

		public string Title;

		public int Salary;

		public int PayRollA;

		public int PayRollB;

		public JobDetail(JobType job, string title, int salary, int rollA, int rollB)
		{
			Job = job;
			Title = title;
			Salary = salary;
			PayRollA = rollA;
			PayRollB = rollB;
		}

		public string PayoutDescription()
		{
			System.Text.StringBuilder builder = new System.Text.StringBuilder();
			builder.AppendFormat("{0} OR {1} PAYS", PayRollA, PayRollB);
			return builder.ToString();
		}
	}

}
