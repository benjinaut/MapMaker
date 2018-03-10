using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace MapMaker.Maps
{
	class MapGenerator
	{
		public Color[,] bitMap;


		public MapGenerator(Point size)
		{
			bitMap = new Color[size.X, size.Y];
			GenerateBitmap();
		}

		public void GenerateBitmap()
		{
			Random rndm = new Random();
			// erstellen/randomgenerieren der bitMap
			for ( int i =0; i< bitMap.GetLength(0); i++)
			{
				for (int j=0; j< bitMap.GetLength(1); j++)

				if (rndm.Next(3) == 1)
				{
						
					bitMap[i,j] = Color.Black;
				}
				else
				{
					bitMap[i, j] = Color.White;
				}
			}

			MapCorrection();
		}
		


		private void MapCorrection()
		{
			for(int i=0; i<bitMap.GetLength(0); i++)
			{
				for (int j =0; j< bitMap.GetLength(1); j++)
				{
					if (bitMap[i, j] == Color.White)
					{
					}
					else if (!CheckCityBlock(new Point(i, j)))
					{
						bitMap[i, j] = Color.Gray;
					}
				}
			}
		}

		private bool CheckSchachBrett(Point _position)
		{//8.er Nachtbarschaft//rand behandlungskrams 
			if (bitMap[_position.X, _position.Y] == Color.White)
			{
				return false;
			}
			else
			{
				if (_position.Y == 0)
				{//rand oben
					if (_position.X == 0)
					{// ecke rechts oben/ checken von links, unten und linksunten
						return (CheckLeft(_position) 
							|| CheckDown(_position) 
							|| CheckLeftDown(_position));
					}
					else if (_position.X == bitMap.GetLength(0) - 1)
					{// ecke links oben/ checken von rechts, unten und rechtsunten
						return (CheckRight(_position) 
							|| CheckDown(_position) 
							|| CheckRightDown(_position));
					}
					else
					{// Rand oben/ checken von rechts, links, rechtsunten, linksunten und unten
						return (CheckLeft(_position) 
							|| CheckDown(_position) 
							|| CheckRight(_position)
							|| CheckRightDown(_position)
							|| CheckLeftDown(_position));
					}
				}
				else if (_position.Y == bitMap.GetLength(1) - 1)
				{//rand unten
					if (_position.X == 0)
					{// ecke rechts unten/ checken von links, oben und linksoben
						return (CheckLeft(_position) 
							|| CheckUp(_position) 
							|| CheckLeftUp(_position));
					}
					else if (_position.X == bitMap.GetLength(0) - 1)
					{// ecke links unten/ checken von rechts, oben und rechtsoben
						return (CheckRight(_position) 
							|| CheckUp(_position) 
							|| CheckRightUp(_position));
					}
					else
					{// Rand unten, checken von rechts, rechtsoben, links, linksoben und oben
						return (CheckLeft(_position) 
							|| CheckUp(_position) 
							|| CheckRight(_position) 
							|| CheckLeftUp(_position) 
							|| CheckRightUp(_position));
					}
				}
				else if (_position.X == 0)
				{// rand links/ checken von rechts, rechtsoben, rechtsunten, oben und unten
					return (CheckLeft(_position) 
						|| CheckUp(_position) 
						|| CheckDown(_position)
						|| CheckLeftDown(_position)
						|| CheckLeftUp(_position));
				}
				else if (_position.X == bitMap.GetLength(0) - 1)
				{// rand rechts/ checken von oben, links und unten
					return (CheckRight(_position) 
						|| CheckUp(_position) 
						|| CheckDown(_position)
						|| CheckRightDown(_position)
						|| CheckRightUp(_position));
				}
				else
				{ //middle Suff/ checken von rechts, links, oben und unten
					return (CheckRight(_position) 
						|| CheckLeft(_position) 
						|| CheckUp(_position) 
						|| CheckDown(_position)
						|| CheckLeftDown(_position)
						|| CheckLeftUp(_position)
						|| CheckRightDown(_position)
						|| CheckRightUp(_position));
				}
			}

		}

		private bool CheckCityBlock(Point _position)
		{//4.er Nachtbarschaft//rand behandlungskrams damit keine outabounds exepts kommen #straightOuttaBounds
			if (bitMap[_position.X, _position.Y] == Color.White)
			{
				return false;
			}
			else
			{
				if (_position.Y == 0)
				{//rand oben
					if (_position.X == 0)
					{// ecke rechts oben/ checken von links unten
						return (CheckLeft(_position) 
							|| CheckDown(_position));
					}
					else if (_position.X == bitMap.GetLength(0)-1)
					{// ecke links oben/ checken von rechts unten
						return (CheckRight(_position) 
							|| CheckDown(_position));
					}
					else
					{// Rand oben/ checken von rechts, links und unten
						return (CheckLeft(_position) 
							|| CheckDown(_position) 
							|| CheckRight(_position));
					}
				}
				else if (_position.Y == bitMap.GetLength(1)-1)
				{//rand unten
					if (_position.X == 0)
					{// ecke rechts unten/ checken von links oben
						return (CheckLeft(_position) 
							|| CheckUp(_position));
					}
					else if (_position.X == bitMap.GetLength(0)-1)
					{// ecke links unten/ checken von rechts oben
						return (CheckRight(_position) 
							|| CheckUp(_position));
					}
					else
					{// Rand unten, checken von rechts, links und oben
						return (CheckLeft(_position) 
							|| CheckUp(_position) 
							|| CheckRight(_position));
					}
				}
				else if (_position.X == 0)
				{// rand links/ checken von rechts, oben und unten
					return (CheckLeft(_position) 
						|| CheckUp(_position) 
						|| CheckDown(_position));
				}
				else if (_position.X == bitMap.GetLength(0)-1)
				{// rand rechts/ checken von oben, links und unten
					return (CheckRight(_position) 
						|| CheckUp(_position) 
						|| CheckDown(_position));
				}
				else
				{ //middle Suff/ checken von rechts, links, oben und unten
					return (CheckRight(_position) 
						|| CheckLeft(_position) 
						|| CheckUp(_position) 
						|| CheckDown(_position));
				}
			}
		}
		
		private bool CheckLeft(Point _position)
		{
			return (bitMap[_position.X+1, _position.Y] == Color.Black);
		}

		private bool CheckRight(Point _position)
		{
			return (bitMap[_position.X-1, _position.Y] == Color.Black);	
		}

		private bool CheckUp(Point _position)
		{
			return (bitMap[_position.X, _position.Y-1] == Color.Black);
		}

		private bool CheckDown(Point _position)
		{
			return  (bitMap[_position.X, _position.Y+1] == Color.Black);
		}

		private bool CheckLeftUp(Point _position)
		{
			return (bitMap[_position.X + 1, _position.Y-1] == Color.Black);
		}

		private bool CheckLeftDown(Point _position)
		{
			return (bitMap[_position.X + 1, _position.Y + 1] == Color.Black);
		}

		private bool CheckRightDown(Point _position)
		{
			return (bitMap[_position.X - 1, _position.Y + 1] == Color.Black);
		}

		private bool CheckRightUp(Point _position)
		{
			return (bitMap[_position.X - 1, _position.Y - 1] == Color.Black);
		}	
	}
}
