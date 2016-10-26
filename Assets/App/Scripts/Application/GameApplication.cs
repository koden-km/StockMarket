using UnityEngine;

namespace App
{
	// Note: Based on examples here https://www.toptal.com/unity-unity3d/unity-with-mvc-how-to-level-up-your-game-development


	/// <summary>
	/// Game application entry point.
	/// Reference to the root instances of the MVC.
	/// </summary>
	public class GameApplication : MonoBehaviour
	{
		// TODO: could this act as a dependency container?

		public ModelContainer Models;
		public ViewContainer Views;
		public ControllerContainer Controllers;

		// TODO: services were not in the example. they should contain the business logic to prevent fat controllers/models.
		//public ServiceContainer Services;

		void Start()
		{
		}

	}

}
