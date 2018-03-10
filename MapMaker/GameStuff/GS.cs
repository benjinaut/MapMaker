using System;
using MapMaker.Maps;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMaker
{
	class GS
	{
		public static GS i;
		public Player player;
		public TileMap tileMap;
		public Camera camera;
		public MapGenerator mapGenerator;

		private GS()
		{

		}

		public static GS I
		{
			get
			{
				if (i == null)
					i = new GS();
				return i;
			}
		}
	}
}
