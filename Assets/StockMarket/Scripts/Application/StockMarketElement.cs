using UnityEngine;

namespace StockMarket
{
	// Note: Based on examples here https://www.toptal.com/unity-unity3d/unity-with-mvc-how-to-level-up-your-game-development


	/// <summary>
	/// Base class for all elements in this application.
	/// </summary>
	public abstract class StockMarketElement : MonoBehaviour
	{

		// Gives access to the application and all instances.
		public StockMarketApplication App {
			get { return GameObject.FindObjectOfType<StockMarketApplication>(); }
		}

	}

}
