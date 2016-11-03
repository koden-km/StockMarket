using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using StockMarket.Models;

namespace StockMarket.Tests.Models
{

	[TestFixture]
	public class PlayerModelTest
	{
		IPlayerModel sut;

		[TestFixtureSetUp]
		public void SetUp()
		{
			sut = new PlayerModel("Player 1");
		}

		[TestFixtureTearDown]
		public void TearDown()
		{
			sut = null;
		}

		[Test]
		public void DesignatedConstructor_SetsValues()
		{
			Dictionary<CompanyType,int> shares = new Dictionary<CompanyType, int>();
			shares[CompanyType.AlphaB] = 15;

			sut = new PlayerModel("Human", UnityEngine.Color.blue, JobType.Trader, 20, 2000, shares, CompanyType.AlphaB);

			Assert.AreEqual("Human", sut.Name);
			Assert.AreEqual(UnityEngine.Color.blue, sut.Color);
			Assert.AreEqual(JobType.Trader, sut.Job);
			Assert.AreEqual(20, sut.BoardTileIndex);
			Assert.AreEqual(2000, sut.Cash);
			foreach (CompanyType company in System.Enum.GetValues(typeof(CompanyType))) {
				if (CompanyType.AlphaB == company) {
					Assert.AreEqual(15, sut.GetShares(company));
				} else {
					Assert.AreEqual(0, sut.GetShares(company));
				}
			}
			Assert.IsTrue(sut.ShareHolderMeeting.HasValue);
			Assert.AreEqual(CompanyType.AlphaB, sut.ShareHolderMeeting.Value);
		}

		[Test]
		public void ConvienceConstructor_SetsDefaults()
		{
			Assert.AreEqual("Player 1", sut.Name);
			Assert.AreEqual(UnityEngine.Color.white, sut.Color);
			Assert.AreEqual(JobType.Worker100, sut.Job);
			Assert.AreEqual(0, sut.BoardTileIndex);
			Assert.AreEqual(0, sut.Cash);
			foreach (CompanyType company in System.Enum.GetValues(typeof(CompanyType))) {
				Assert.AreEqual(0, sut.GetShares(company));
			}
			Assert.IsFalse(sut.ShareHolderMeeting.HasValue);
		}

		[Test]
		public void SetName_DoesRaiseEvents_WhenChanged()
		{
			bool changing = false;
			bool changed = false;
			sut.NameChanging += (sender, e) => changing = ("Name" == e.FieldName);
			sut.NameChanged += (sender, e) => changed = ("Name" == e.FieldName);

			sut.Name = "New Name";

			Assert.AreEqual("New Name", sut.Name);
			Assert.IsTrue(changing);
			Assert.IsTrue(changed);
		}

		[Test]
		public void SetColor_DoesRaiseEvents_WhenChanged()
		{
			bool changing = false;
			bool changed = false;
			sut.ColorChanging += (sender, e) => changing = ("Color" == e.FieldName);
			sut.ColorChanged += (sender, e) => changed = ("Color" == e.FieldName);

			sut.Color = UnityEngine.Color.green;

			Assert.AreEqual(UnityEngine.Color.green, sut.Color);
			Assert.IsTrue(changing);
			Assert.IsTrue(changed);
		}

		[Test]
		public void SetJob_DoesRaiseEvents_WhenChanged()
		{
			bool changing = false;
			bool changed = false;
			sut.JobChanging += (sender, e) => changing = ("Job" == e.FieldName);
			sut.JobChanged += (sender, e) => changed = ("Job" == e.FieldName);

			sut.Job = JobType.Worker400;

			Assert.AreEqual(JobType.Worker400, sut.Job);
			Assert.IsTrue(changing);
			Assert.IsTrue(changed);
		}

		[Test]
		public void SetBoardTileIndex_DoesRaiseEvents_WhenChanged()
		{
			bool changing = false;
			bool changed = false;
			sut.BoardTileIndexChanging += (sender, e) => changing = ("BoardTileIndex" == e.FieldName);
			sut.BoardTileIndexChanged += (sender, e) => changed = ("BoardTileIndex" == e.FieldName);

			sut.BoardTileIndex = 30;

			Assert.AreEqual(30, sut.BoardTileIndex);
			Assert.IsTrue(changing);
			Assert.IsTrue(changed);
		}

		[Test]
		public void SetCash_DoesRaiseEvents_WhenChanged()
		{
			bool changing = false;
			bool changed = false;
			sut.CashChanging += (sender, e) => changing = ("Cash" == e.FieldName);
			sut.CashChanged += (sender, e) => changed = ("Cash" == e.FieldName);

			sut.Cash = 300;

			Assert.AreEqual(300, sut.Cash);
			Assert.IsTrue(changing);
			Assert.IsTrue(changed);
		}

		[Test]
		public void SetShares_DoesRaiseEvents_WhenChanged()
		{
			bool changing = false;
			bool changed = false;
			sut.SharesChanging += (sender, e) => changing = ("Shares" == e.FieldName);
			sut.SharesChanged += (sender, e) => changed = ("Shares" == e.FieldName);

			sut.SetShares(CompanyType.AlphaC, 45);

			Assert.AreEqual(45, sut.GetShares(CompanyType.AlphaC));
			Assert.IsTrue(changing);
			Assert.IsTrue(changed);
		}

		[Test]
		public void SetShareHolderMeeting_DoesRaiseEvents_WhenChanged()
		{
			bool changing = false;
			bool changed = false;
			sut.ShareHolderMeetingChanging += (sender, e) => changing = ("ShareHolderMeeting" == e.FieldName);
			sut.ShareHolderMeetingChanged += (sender, e) => changed = ("ShareHolderMeeting" == e.FieldName);

			sut.ShareHolderMeeting = CompanyType.OmegaA;

			Assert.IsTrue(sut.ShareHolderMeeting.HasValue);
			Assert.AreEqual(CompanyType.OmegaA, sut.ShareHolderMeeting.Value);
			Assert.IsTrue(changing);
			Assert.IsTrue(changed);
		}
	}

}
