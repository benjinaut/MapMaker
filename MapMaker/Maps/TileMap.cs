using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapMaker.Maps
{
	class TileMap : Maps
	{
		private Tile[,] map;
		private Point size;
		private List<Vector2> checkPoints;


		
		public TileMap(Texture2D[] _textures, Texture2D _bitMap)
		{//constructor für texturen
			map = new Tile[_bitMap.Width, _bitMap.Height];
			size = new Point(_textures[0].Width, _textures[0].Height);
			checkPoints = new List<Vector2>();
			BuildMap(_textures, _bitMap);
		}

		public TileMap(Texture2D[] _textures, Color[,] _colors)
		{//constructor für mapgenerator
			map = new Tile[_colors.GetLength(0), _colors.GetLength(1)];
			size = new Point(_textures[0].Width, _textures[0].Height);
			checkPoints = new List<Vector2>();
			BuildMap(_textures, _colors);

		}

		public Point GetSize()
		{
			return size;
		}

		public Vector2 GetStartPoint()
		{
			if (checkPoints.Count > 0)
				return checkPoints.ElementAt(0);

			throw new Exception("es gibt keinen StartPunkt du depp");

		}

		public Vector2 GetRandomCheckPoint()
		{
			if (checkPoints.Count > 0)
			{
				Random random = new Random();
				int rn = random.Next(checkPoints.Count);
				return checkPoints.ElementAt(rn);

			}

			return Vector2.Zero;
		}

		public Vector2 GetCheckPoints(int n)
		{
			if (checkPoints.Count < n && checkPoints.Count > 0)
			{
				Random random = new Random();
				int rn = random.Next(n);
				return checkPoints.ElementAt(n);
			}
			return Vector2.Zero;
		}

		public bool Walkable(Vector2 _currentPosition)
		{
			return map[(int)(_currentPosition.X / size.X), (int)(_currentPosition.Y / size.Y)].Walkable();

		}

		public override void Draw(SpriteBatch _spriteBatch)
		{
			for (int y = 0; y < map.GetLength(1); y++)
			{
				for (int x = 0; x < map.GetLength(0); x++)
				{
					map[x, y].Draw(_spriteBatch);
				}
			}
		}

		public override void Update(GameTime _gameTime)
		{

		}

		protected override void BuildMap(Texture2D[] _textures, Texture2D _bitMap)
		{
			Color[] colores = new Color[_bitMap.Width * _bitMap.Height];
			_bitMap.GetData(colores);

			for (int y = 0; y < map.GetLength(1); y++)
			{
				for (int x = 0; x < map.GetLength(0); x++)
				{
					if (colores[y * map.GetLength(0) + x] == Color.White)
					{   //White 255.255.255
						map[x, y] = new Tile(_textures[0], new Vector2(x * size.X, y * size.Y), 0);
					}
					else if (colores[y * map.GetLength(0) + x] == Color.Black)
					{   //Black 0.0.0
						map[x, y] = new Tile(_textures[1], new Vector2(x * size.X, y * size.Y), 1);
					}
					else if (colores[y * map.GetLength(0) + x] == Color.Blue)
					{   //Blue Startpoint 0.0.255
						map[x, y] = new Tile(_textures[2], new Vector2(x * size.X, y * size.Y), 2);
						checkPoints.Add(new Vector2(x * size.X, y * size.Y));
					}
					else if (colores[y * map.GetLength(0) + x] == Color.Brown)
					{   //Brown
						map[x, y] = new Tile(_textures[3], new Vector2(x * size.X, y * size.Y), 3);
					}
					else if (colores[y * map.GetLength(0) + x] == Color.Gray)
					{   //Gray
						map[x, y] = new Tile(_textures[4], new Vector2(x * size.X, y * size.Y), 4);
					}
					else if (colores[y * map.GetLength(0) + x] == Color.Green)
					{   //Green
						map[x, y] = new Tile(_textures[5], new Vector2(x * size.X, y * size.Y), 5);
					}
					else if (colores[y * map.GetLength(0) + x] == Color.Orange)
					{   //Orange
						map[x, y] = new Tile(_textures[6], new Vector2(x * size.X, y * size.Y), 6);
					}
					else if (colores[y * map.GetLength(0) + x] == Color.Pink)
					{   //Pink
						map[x, y] = new Tile(_textures[7], new Vector2(x * size.X, y * size.Y), 7);
					}
					else if (colores[y * map.GetLength(0) + x] == Color.Yellow)
					{   //Yellow
						map[x, y] = new Tile(_textures[8], new Vector2(x * size.X, y * size.Y), 8);
					}
					else
					{   //Red, Default 
						map[x, y] = new Tile(_textures[_textures.Length - 1], new Vector2(x * size.X, y * size.Y), _textures.Length - 1);
					}
				}
			}
		}
		protected void BuildMap(Texture2D[] _textures, Color[,] _colors)
		{
			for (int i=0; i<_colors.GetLength(0); i++)
			{
				for (int j= 0; j<_colors.GetLength(1); j++)
				{
					if(_colors[i,j]== Color.White)
					{
						map[i,j] = new Tile(_textures[0], new Vector2(i * size.X, j* size.Y), 0);
					}
					else if (_colors[i,j]== Color.Black)
					{
						map[i, j] = new Tile(_textures[1], new Vector2(i * size.X, j * size.Y), 1);
					}
					else if (_colors[i,j]== Color.Blue)
					{
						map[i, j] = new Tile(_textures[2], new Vector2(i * size.X, j * size.Y), 2);
					}
					else if (_colors[i, j] == Color.Brown)
					{
						map[i, j] = new Tile(_textures[3], new Vector2(i * size.X, j * size.Y), 3);
					}
					else if (_colors[i, j] == Color.Gray)
					{
						map[i, j] = new Tile(_textures[4], new Vector2(i * size.X, j * size.Y), 4);
					}
					else if (_colors[i, j] == Color.Green)
					{
						map[i, j] = new Tile(_textures[5], new Vector2(i * size.X, j * size.Y), 5);
					}
					else if (_colors[i, j] == Color.Orange)
					{
						map[i, j] = new Tile(_textures[6], new Vector2(i * size.X, j * size.Y), 6);
					}
					else if (_colors[i, j] == Color.Pink)
					{
						map[i, j] = new Tile(_textures[7], new Vector2(i * size.X, j * size.Y), 7);
					}
					else if (_colors[i, j] == Color.Yellow)
					{
						map[i, j] = new Tile(_textures[8], new Vector2(i * size.X, j * size.Y), 8);
					}
					else
					{
						map[i, j] = new Tile(_textures[_textures.Length - 1], new Vector2(i * size.X, j * size.Y), _textures.Length - 1);
					}
				}
			}
		}
	}
}
