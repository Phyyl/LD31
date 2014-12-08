﻿using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTKUtil.Minimal;
using OpenTK.Graphics.OpenGL;

namespace LD31
{
	public abstract class GameRect
	{
		public Vector2 Center;
		public Vector2 Size;
		public Color Color;
		public float Speed;

		public RectangleF Rectangle
		{
			get
			{
				return new RectangleF(
					Center.X - Size.X / 2,
					Center.Y - Size.Y / 2,
					Size.X,
					Size.Y);
			}
		}

		public GameRect(float x, float y, float width, float height, float speed, Color color)
		{
			Size = new Vector2(width, height);
			Center = new Vector2(x, y);
			Color = color;
			Speed = speed;
		}

		public virtual void Update()
		{
			var halfSize = Size / 2;
			if (Center.X < halfSize.X)
			{
				Center.X = halfSize.X;
				HitLeft();
			}
			else if (Center.X > Game.Instance.ClientSize.X - halfSize.X)
			{
				Center.X = Game.Instance.ClientSize.X - halfSize.X;
				HitRight();
			}

			if (Center.Y < halfSize.Y)
			{
				Center.Y = halfSize.Y;
				HitTop();
			}
			else if (Center.Y > Game.Instance.ClientSize.Y - halfSize.Y)
			{
				Center.Y = Game.Instance.ClientSize.Y - halfSize.Y;
				HitBottom();
			}
		}

		public virtual void Render()
		{
			GL.Color4(Color);
			Rectangle.Render();
		}

		public virtual void HitLeft() { }
		public virtual void HitRight() { }
		public virtual void HitTop() { }
		public virtual void HitBottom() { }
	}
}
