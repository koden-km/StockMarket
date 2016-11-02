//using UnityEngine;
using System.Collections.Generic;
using App.Model;

namespace App.Controller
{

	// TODO: I'm not sure if i need this class, controllers are for talking to views?
	// So this will only be needed if there is a player view?
	// Which there might be if there is some HUD for their turn?


	public class PlayerController
	{
		//private PlayerService m_PlayerService;

		//public bool DoTurn(PlayerService playerService)
		public bool DoTurn()
		{
			// TODO
			// Check job type
			//   If Worker
			//     If check money > 1000
			//       Need to start trading, ask to pick start location
			//     else
			//       Ask if want to switch job, and if so move token
			//   If Trader
			//     Ask if want to sell some shares before moving?
			//
			// Roll dice
			//   If Trader
			//     Give choices for move locations, can go into stockholder meeting if has shares
			//     Move token
			//     If not in stockholder meeting
			//       Update share slider
			//
			// If Trader
			//   Check tile type that was moved to
			//   If a share tile or stockholder meeting doorway tile
			//      If has shares give dividend
			//      Ask if want to buy more, with limit if doorway tile
			//   Else If stockholder meeting tile
			//      Give bonus shares
			//   Else If sell all shares
			//      Sell all shares
			//   Else If borker fee
			//      Pay broker fee, may need to sell shares at base price
			//   Else must be a start square
			//      Pay 100 fee if already a trader, not on changing from work to start
			//
			// When finished turn return true.
			// return true
			return true;
		}

	}

}
