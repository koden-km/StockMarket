using UnityEngine;
using System.Collections.Generic;

namespace App
{

	public class BoardTileModel
	{
		public TileType Tile;

		public BoardTileMoveFlags MoveFlags;

		public UnityEngine.Color Color;

		public string MainTitle;

		public string SubTitle;

		public JobType? Job;

		public CompanyType? Company;

		public int Dividend;

		// $100 fee for landing on Start.
		//public int Fee;

		/// <summary>
		/// The previous board tile.
		/// Use for general movement around the board, not move option logic.
		/// </summary>
		public BoardTileModel Previous;

		/// <summary>
		/// The next board tile.
		/// Use for general movement around the board, not move option logic.
		/// </summary>
		public BoardTileModel Next;

		/// <summary>
		/// The shareholder meeting board tile.
		/// Use for general movement around the board, not move option logic.
		/// </summary>
		public BoardTileModel ShareMeeting;

		private BoardTileModel(TileType tile, BoardTileMoveFlags moveFlags)
		{
			Tile = tile;
			MoveFlags = moveFlags;
			MainTitle = string.Empty;
			SubTitle = string.Empty;

			Previous = null;
			Next = null;
			ShareMeeting = null;
		}

		public static BoardTileModel CreateJob(
			TileType tile,
			JobType job,
			GameModel game
		)
		{
			BoardTileModel bt = new BoardTileModel(tile, BoardTileMoveFlags.Job);
			bt.Color = Color.white;
			bt.SetupTitleJob(game, job);
			bt.Job = job;
			bt.Company = null;
			bt.Dividend = 0;
			return bt;
		}

		public static BoardTileModel CreateCompany(
			TileType tile,
			BoardTileMoveFlags moveFlags,
			CompanyType company,
			int dividend,
			GameModel game
		)
		{
			BoardTileModel bt = new BoardTileModel(tile, moveFlags);
			bt.Color = game.Companies[company].Color;
			bt.SetupTitleTrade(game, company, tile);
			bt.Job = null;
			bt.Company = company;
			bt.Dividend = dividend;
			return bt;
		}

		public static BoardTileModel CreateCompanyMeeting(
			TileType tile,
			GameModel game
		)
		{
			BoardTileModel bt = new BoardTileModel(tile, BoardTileMoveFlags.Left | BoardTileMoveFlags.Right);
			// TODO
			return bt;
		}

		public static BoardTileModel CreateStart(
			TileType tile,
			GameModel game
		)
		{
			BoardTileModel bt = new BoardTileModel(tile, BoardTileMoveFlags.Left | BoardTileMoveFlags.Right);
			// TODO
			return bt;
		}

		public static BoardTileModel CreateBrokerFee(
			TileType tile,
			GameModel game
		)
		{
			BoardTileModel bt = new BoardTileModel(tile, BoardTileMoveFlags.Right);
			// TODO
			return bt;
		}

		/// <summary>
		/// Determines whether a player on this tile can sell at the current stock price.
		/// If not, the player would only be able to sell at lowest possible price.
		/// </summary>
		/// <returns><c>true</c> if a player on this tile can sell at current price; otherwise, <c>false</c>.</returns>
		public bool CanSellAtCurrentPrice()
		{
			switch (Tile) {
			case TileType.Start:
			case TileType.BuyMany:
			case TileType.BuyOne:
			case TileType.Meeting1for1:
			case TileType.Meeting2for1:
			case TileType.Meeting3for1:
				return true;
			}

			return false;
		}

		private void SetupTitleJob(GameModel game, JobType job)
		{
			JobModel jobDetail = game.Jobs[job];
			MainTitle = jobDetail.Title;
			SubTitle = jobDetail.PayoutDescription();
		}

		private void SetupTitleTrade(GameModel game, CompanyType company, TileType tile)
		{
			// TODO: deal with the Sell All and single buy tiles?

			CompanyModel companyDetail = game.Companies[company];

			if (tile == TileType.SellAllCompany) {
				MainTitle = "Sell All\n" + companyDetail.Name;
				SubTitle = "At minimum per share";
			} else if (tile == TileType.BuyOne) {
				MainTitle = companyDetail.Name;
				SubTitle = "Purchase limit 1 share";
			} else {
				MainTitle = companyDetail.Name;
				SubTitle = "";
			}
		}

	}

}
