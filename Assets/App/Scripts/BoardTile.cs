using UnityEngine;
using System.Collections.Generic;

namespace App
{

	public class BoardTile
	{
		public TileType Tile;

		public BoardTileMoveOption MoveOption;

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
		public BoardTile Previous;

		/// <summary>
		/// The next board tile.
		/// Use for general movement around the board, not move option logic.
		/// </summary>
		public BoardTile Next;

		/// <summary>
		/// The shareholder meeting board tile.
		/// Use for general movement around the board, not move option logic.
		/// </summary>
		public BoardTile ShareMeeting;

		private BoardTile(TileType tile, BoardTileMoveOption moveOption)
		{
			Tile = tile;
			MoveOption = moveOption;
			MainTitle = string.Empty;
			SubTitle = string.Empty;

			Previous = null;
			Next = null;
			ShareMeeting = null;
		}

		public static BoardTile CreateJob(
			TileType tile,
			JobType job,
			GameOptions options
		)
		{
			BoardTile bt = new BoardTile(tile, BoardTileMoveOption.Job);
			bt.Color = Color.white;
			bt.SetupTitleJob(options, job);
			bt.Job = job;
			bt.Company = null;
			bt.Dividend = 0;
			return bt;
		}

		public static BoardTile CreateCompany(
			TileType tile,
			BoardTileMoveOption moveOption,
			CompanyType company,
			int dividend,
			GameOptions options
		)
		{
			BoardTile bt = new BoardTile(tile, moveOption);
			bt.Color = options.Companies[company].Color;
			bt.SetupTitleTrade(options, company, tile);
			bt.Job = null;
			bt.Company = company;
			bt.Dividend = dividend;
			return bt;
		}

		public static BoardTile CreateCompanyMeeting(
			TileType tile,
			GameOptions options
		)
		{
			BoardTile bt = new BoardTile(tile, BoardTileMoveOption.Left | BoardTileMoveOption.Right);
			// TODO
			return bt;
		}

		public static BoardTile CreateStart(
			TileType tile,
			GameOptions options
		)
		{
			BoardTile bt = new BoardTile(tile, BoardTileMoveOption.Left | BoardTileMoveOption.Right);
			// TODO
			return bt;
		}

		public static BoardTile CreateBrokerFee(
			TileType tile,
			GameOptions options
		)
		{
			BoardTile bt = new BoardTile(tile, BoardTileMoveOption.Right);
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

		private void SetupTitleJob(GameOptions options, JobType job)
		{
			JobDetail jobDetail = options.Jobs[job];
			MainTitle = jobDetail.Title;
			SubTitle = jobDetail.PayoutDescription();
		}

		private void SetupTitleTrade(GameOptions options, CompanyType company, TileType tile)
		{
			// TODO: deal with the Sell All and single buy tiles?

			CompanyDetail companyDetail = options.Companies[company];

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
