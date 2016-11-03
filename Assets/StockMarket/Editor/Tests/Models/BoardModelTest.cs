using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using NSubstitute;
using StockMarket.Models;

namespace StockMarket.Tests.Models
{

	[TestFixture]
	public class BoardModelTest
	{
		//BoardModel sut;

		[TestFixtureSetUp]
		public void SetUp()
		{
			//var game = Substitute.For<IGameModel>();

			//var game = GameModel.CreateNewGame();
			//sut = new BoardModel(game);
			//sut = game.Board;
		}

		[TestFixtureTearDown]
		public void TearDown()
		{
			//sut = null;
		}

		[Test]
		[Ignore("TODO: Write tests.")]
		public void Placeholder()
		{
		}
	}

}
