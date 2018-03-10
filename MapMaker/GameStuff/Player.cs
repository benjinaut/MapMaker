using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MapMaker
{
	class Player : GameObject
	{
		private Vector2 move;


		public Player(Texture2D _texture) : base(_texture, GS.i.tileMap.GetRandomCheckPoint())
		{
			move = Vector2.Zero;
		}

		void KeyboardInput()
		{
			KeyboardState key = Keyboard.GetState();
			move = Vector2.Zero;

			//key block
			if (key.IsKeyDown(Keys.A)|| key.IsKeyDown(Keys.Right))
			{
				move.X -= 1;
				
			}
			if (key.IsKeyDown(Keys.D) || key.IsKeyDown(Keys.Left))
			{
				move.X += 1;

			}
			if (key.IsKeyDown(Keys.S) || key.IsKeyDown(Keys.Down))
			{
				move.Y += 1;

			}
			if (key.IsKeyDown(Keys.W) || key.IsKeyDown(Keys.Up))
			{
				move.Y -= 1;

			}

			if (move != Vector2.Zero)
				move.Normalize();
			move *= 9;

			position += move;
		}


		public override void Draw(SpriteBatch _spriteBatch)
		{
			_spriteBatch.Draw(texture, position);
		}

		public override void Update(GameTime _gameTime)
		{
			KeyboardInput();
		}
	}
}
