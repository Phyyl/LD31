﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LD31
{
	public class MasterEnemyRect : BaseEnemyRect
	{
		public MasterEnemyRect(float x, float y, float width, float height)
			: base(x, y, width, height)
		{
			Color = Color.Red;
			Speed = 5f;
		}

		public override void HitLeft()
		{
			base.HitLeft();
			Game.Instance.Game_Screen.AddRandomEnemyAt(Center.X, Center.Y);
			Game.Instance.Game_Screen.Points += 2;
		}

		public override void HitRight()
		{
			base.HitRight();
			Game.Instance.Game_Screen.AddRandomEnemyAt(Center.X, Center.Y);
			Game.Instance.Game_Screen.Points += 2;
		}

		public override void HitTop()
		{
			base.HitTop();
			Game.Instance.Game_Screen.AddRandomEnemyAt(Center.X, Center.Y);
			Game.Instance.Game_Screen.Points += 2;
		}

		public override void HitBottom()
		{
			base.HitBottom();
			Game.Instance.Game_Screen.AddRandomEnemyAt(Center.X, Center.Y);
			Game.Instance.Game_Screen.Points += 2;
		}
	}
}
