//using UnityEngine;
using System.Collections.Generic;
using StockMarket.Models;

namespace StockMarket.Controllers
{

	// TODO: I'm not sure if i need this class, controllers are for talking to views?
	// So this will only be needed if there is a player view?
	// Which there might be if there is some HUD for their turn?
	//
	// UPDATE:
	// Ok from reading more about MVC, it does seem like i need this and it will be
	// used to talk to the view about player moving on the board and HUD elements for
	// money and shares.
	// It will hold references to both the Model and the View.
	// I may want to make a factory to create a "Player" as a concept that constructs
	// the model, view and controller and hooks them up.
	// I'm wondering if i should change from namespaces like Models/Views/Controllers
	// to more of a StockMarket.Player and StockMarket.Board setup to keep everything
	// near its other parts? In another project i was splitting them similar to this
	// to keep the scene monobehaviour classes separate for testing, but that shouldn't
	// be a problem with the better separation of concerns that MVC offers.


	public class PlayerController
	{


		//		private IPlayerModel m_Model;
		//		private IPlayerView m_View;
		//
		//		// TODO: put game logic in classes like this...
		//		// DI this into the constructor and/or have getter/setter for it.
		//		//private PlayerService m_PlayerService;
		//
		//		// TODO: write constructors like this...
		//		//public PlayerController(IPlayerModel model, IPlayerView view, PlayerService service)
		//		public PlayerController(IPlayerModel model, IPlayerView view)
		//		{
		//			m_Model = model;
		//			m_View = view;
		//
		//			// hook up event handlers
		//			m_Model.OnNameChanged += HandleNameChanged;
		//		}
		//
		//		// TODO: write handlers like this...
		//		private void HandleNameChanged(object sender, PlayerNameEventArgs e)
		//		{
		//			// TODO: tell the view about the event...
		//			// should this be done with getter/setter or some other kind of event?
		//			//m_View.Name = e.Name;
		//		}




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
