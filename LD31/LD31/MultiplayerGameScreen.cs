﻿using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD31
{
	public class MultiplayerGameScreen : GameScreen
	{
		public PlayerRect Player2Rectangle;

		public MultiplayerGameScreen()
		{
			saveFile = "multi.dat";
		}

		public override void Update()
		{
			Player2Rectangle.Update();
			base.Update();

			if (Player2Rectangle.Rectangle.IntersectsWith(PlayerRectangle.Rectangle))
			{
				EndGame("You crashed! (Press enter)");
			}
			else if (CheckPlayerCollisions(PlayerRectangle))
			{
				EndGame("Player1 died! (Press enter)");
			}
			else if (CheckPlayerCollisions(Player2Rectangle))
			{
				EndGame("Player2 died! (Press enter)");
			}
		}

		public override void Render()
		{
			Player2Rectangle.Render();
			base.Render();
		}

		public override void Reset()
		{
			base.Reset();
			Player2Rectangle = new PlayerRect(PlayerRect.PlayerInputMode.Arrows)
			{
				Color = Color.Blue
			};
			PlayerRectangle = new PlayerRect(PlayerRect.PlayerInputMode.WASD);

			Vector2 centerScreen = Game.Instance.ClientCenter;

			Player2Rectangle.Center = centerScreen + new Vector2(centerScreen.X / 2, 0);
			PlayerRectangle.Center = centerScreen - new Vector2(centerScreen.X / 2, 0);
		}

		protected override void RenderRects()
		{
			base.RenderRects();
			Player2Rectangle.Render();
		}
	}
}
