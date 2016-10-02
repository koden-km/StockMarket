using UnityEngine;
using System.Collections.Generic;

namespace App
{

	public class BoardTile
	{
		public TileType Tile;

		public BoardTileMoveOption MoveOption;

		public string MainTitle;

		public string SubTitle;

		public JobType? Job;

		public CompanyType? Company;

		public int Dividend;

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

		public static BoardTile Create(
			TileType tile,
			JobType job,
			GameOptions options
		)
		{
			BoardTile bt = new BoardTile(tile, BoardTileMoveOption.Job);
			bt.SetupTitleJob(options);
			bt.Job = job;
			bt.Company = null;
			bt.Dividend = 0;
			return bt;
		}

		public static BoardTile Create(
			TileType tile,
			BoardTileMoveOption moveOption,
			CompanyType company,
			int dividend,
			GameOptions options

		)
		{
			BoardTile bt = new BoardTile(tile, moveOption);
			bt.SetupTitleTrade(options);
			bt.Job = null;
			bt.Company = company;
			bt.Dividend = dividend;
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

		private void SetupTitleJob(GameOptions options)
		{
//			MainTitle = jobNames[Job];
//			switch (Job) {
//			case JobType.Worker100:
//				SubTitle = "5 or 9 pays $100 salary";
//				break;
//			case JobType.Worker200:
//				SubTitle = "5 or 9 pays $100 salary";
//				break;
//			case JobType.Worker300:
//				SubTitle = "5 or 9 pays $100 salary";
//				break;
//			case JobType.Worker400:
//				SubTitle = "5 or 9 pays $100 salary";
//				break;
//			}

			JobDetail jobDetail = options.Jobs[Job];
			MainTitle = jobDetail.Title;
			SubTitle = jobDetail.PayoutDescription();
		}

		private string SetupTitleTrade(GameOptions options)
		{
			return "TODO";

			//CompanyType
		}
	}

}
