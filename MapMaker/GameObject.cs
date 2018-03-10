using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MapMaker
{
	abstract class GameObject
	{
		protected Texture2D texture;
		protected Vector2 position;

		protected GameObject(Texture2D _texture, Vector2 _position)
		{
			position = _position;
			texture = _texture;
		}

		public Vector2 GetPosition()
		{
			return position;
		}

		public Texture2D GetTexture()
		{
			return texture;
		}

		public abstract void Update(GameTime _gameTime);
		public abstract void Draw(SpriteBatch _spriteBatch);
	}


}
