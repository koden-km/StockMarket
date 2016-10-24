using UnityEngine;

namespace App
{

	[RequireComponent(typeof(Canvas))]
	public class GameView : MonoBehaviour
	{
		void Start()
		{
		}

		void Update()
		{
			// If the primary mouse button was pressed this frame
			if (Input.GetMouseButtonDown(0)) {

				Debug.Log("GameView.Update() - Mouse down!");
				// TODO: something like this... but find which tile was hit and tell it to fire the event?
				// I wouldn't want every board tile to do a ray cast every click like the exmaple did for its enemies, right?


				// // If the mouse hit a board tile
				// var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				// RaycastHit hit;
				// if (Physics.RayCast(ray, out hit) && hit.transform == transform) {
				// 	// Dispatch the 'on clicked' event
				// 	var eventArgs = new TileClickedEventArgs();
				// 	OnClicked(this, eventArgs);
				// }
			}
		}

	}

}
