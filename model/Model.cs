using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour.model
{
	public class Model
	{
		private readonly int ROWS = 6;
		private readonly int COLS = 6;
		private readonly int LEFT_TOP_X = 5;
		private readonly int LEFT_TOP_Y = 5;
		private readonly int SPACE_BETWEEN_CIRCLES = 10;
		private readonly int R = 60; // radius
		public List<Circle> Circles { get; set; }

		public void makeOrResetCircles()
		{
			if (Circles == null)
			{
				Circles = new List<Circle>();
				for (int i = 0; i < COLS; i++)
				{
					for (int j = 0; j < ROWS; j++)
					{
						Circles.Add(
							new Circle(LEFT_TOP_X + i * (R + SPACE_BETWEEN_CIRCLES),
										LEFT_TOP_Y + j * (R + SPACE_BETWEEN_CIRCLES),
										R, PlayerEnum.NONE)
						);
					}
				}
			}
			else
			{
				int index;
				Circle circle;

				for (int i = 0; i < COLS; i++)
				{
					for (int j = 0; j < ROWS; j++)
					{
						index = i * ROWS + j;
						circle = Circles[index];
						if (circle.Player != PlayerEnum.NONE)
						{
							circle.Player = PlayerEnum.NONE;
						}
					}
				}
			}
		}
		public int getRows()
		{
			return ROWS;
		}
		public int getCols()
		{
			return COLS;
		}

		public int getR()
		{
			return R;
		}

	}

}
