using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using StockMarket.Models;

namespace StockMarket.Tests.Models
{

	[TestFixture]
	public class JobModelTest
	{
		JobModel sut;

		[TestFixtureSetUp]
		public void SetUp()
		{
		}

		[TestFixtureTearDown]
		public void TearDown()
		{
			sut = null;
		}

		[Test]
		public void ConstructorSetsValues()
		{
			sut = new JobModel(JobType.Worker100, "Developer", 100, 5, 9);

			Assert.AreEqual(JobType.Worker100, sut.Job);
			Assert.AreEqual(100, sut.Salary);
			Assert.AreEqual(5, sut.FirstPaysRoll);
			Assert.AreEqual(9, sut.SecondPaysRoll);
		}
	}

}
