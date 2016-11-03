using UnityEngine;
using System.Collections.Generic;
using StockMarket.Models;
using StockMarket.Services;

namespace StockMarket.Controllers
{

	public class BoardController
	{
		//private BoardModel m_BoardModel;

		public BoardController(BoardModel boardModel, GameModel gameModel)
		{
			// TODO: should this all go in the Model constructor?

//			m_BoardModel = boardModel;
//
//			SetupStockPriceTable();
//
//			//m_BoardModel.BoardTiles = new BoardTileModel[88];
//
//			// Setup job tiles ...
//			m_BoardModel.BoardTiles[0] = BoardTileModel.CreateJob(TileType.Job, JobType.Worker100, gameModel);
//			m_BoardModel.BoardTiles[1] = BoardTileModel.CreateJob(TileType.Job, JobType.Worker200, gameModel);
//			m_BoardModel.BoardTiles[2] = BoardTileModel.CreateJob(TileType.Job, JobType.Worker300, gameModel);
//			m_BoardModel.BoardTiles[3] = BoardTileModel.CreateJob(TileType.Job, JobType.Worker400, gameModel);
//
//			// Setup game board trader tiles ...
//			// TODO, set them up clockwise or counter-clockwise starting at the stock price UP.
//
//			// Setup share holder meeting tiles ...
//			// TODO, set them up in the same direction as board trader tiles.
		}

		// TODO: this would be in service class?
		//		public StockPriceTier StockPriceAtIndex(int index)
		//		{
		//			return m_BoardModel.PriceTable[index];
		//		}

		// TODO: this would be in service class?
		//		public StockPriceTier StockPriceAtLowest()
		//		{
		//			return m_BoardModel.LowestPrice;
		//		}

	}

}
