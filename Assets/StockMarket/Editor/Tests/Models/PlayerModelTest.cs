using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace StockMarket.Tests.Models
{

	public class PlayerModelTest
	{
		[Test]
		public void PlaceholderTest()
		{
			// Arrange
			var gameObject = new GameObject();

			// Act
			// Try to rename the GameObject
			var newGameObjectName = "My game object";
			gameObject.name = newGameObjectName;

			// Assert
			// The object has a new name
			Assert.AreEqual(newGameObjectName, gameObject.name);
		}

		[Test]
		public void NameIsSet()
		{
			var model = new StockMarket.Models.PlayerModel("bob");
			Assert.AreEqual("bob", model.Name);
		}
	}

}
