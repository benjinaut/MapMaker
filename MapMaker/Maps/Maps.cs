using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker.Maps
{
	abstract class Maps
	{
		protected abstract void BuildMap(Texture2D[] _textures, Texture2D _bitMap);
		public abstract void Draw(SpriteBatch _sBatch);
		public abstract void Update(GameTime _gTimeh);
	}
}
