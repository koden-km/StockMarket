using UnityEngine;

namespace App
{

	/// <summary>
	/// Base class for all elements in this application.
	/// </summary>
	public abstract class GameElement : MonoBehaviour
	{

		// Gives access to the application and all instances.
		public GameApplication GameApp {
			get { return GameObject.FindObjectOfType<GameApplication>(); }
		}

	}

}
