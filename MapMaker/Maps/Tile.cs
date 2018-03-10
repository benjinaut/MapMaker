using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapMaker.Maps
{
	class Tile : GameObject
	{
		int id;
		public Tile(Texture2D _texture, Vector2 _position, int _id) : base(_texture, _position)
		{
			id = _id;
		}

		public bool Walkable()
		{
			return (id == 0);
		}

		public override void Draw(SpriteBatch _spriteBatch)
		{
			_spriteBatch.Draw(texture, position);
		}

		public override void Update(GameTime _gameTime)
		{
			throw new NotImplementedException();
		}
	}
}
