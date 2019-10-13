using ConnectFour.model;
using ConnectFour.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConnectFour.viewModel
{
	public class Controller : INotifyPropertyChanged
	{
		
		private Model model;
		private MainWindow mainWindow;

		private readonly int NUM_OF_CIRCLES_FOR_WIN = 4;

		private int rows;
		private int cols;

		private PlayerEnum _CurrentPlayer;
		public PlayerEnum CurrentPlayer {
			get { return _CurrentPlayer; }
			set
			{
				if (_CurrentPlayer != value)
				{
					_CurrentPlayer = value;
					OnPropertyChanged("CurrentPlayer");
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string name)
		{

			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(name));
			}
		}

		public Controller(MainWindow _mainWindow)
		{
			mainWindow = _mainWindow;
			model = new Model();
			rows = model.getRows();
			cols = model.getCols();
		}

		public void newGame()
		{
			model.makeOrResetCircles();
			CurrentPlayer = PlayerEnum.FIRST_PLAYER;
		}

		public void changeCircle(int col)
		{
			int index;
			Circle circle;

			
			for (int i = rows - 1; i >= 0; i--)
			{
				index = col * rows + i;
				circle = model.Circles[index];
				if (circle.Player == PlayerEnum.NONE) // ako je prazan krug
				{
					circle.Player = CurrentPlayer;
					if(checkGameOver())
					{
						NewGameExitDialog nged = new NewGameExitDialog(this, CurrentPlayer);
						nged.ShowDialog();
						return;
					}
					changeCurrentPlayer();
					break;
				}
			}
		}

		private void changeCurrentPlayer()
		{
			if (CurrentPlayer == PlayerEnum.FIRST_PLAYER)
			{
				CurrentPlayer = PlayerEnum.SECOND_PLAYER;
			} else if (CurrentPlayer == PlayerEnum.SECOND_PLAYER)
			{
				CurrentPlayer = PlayerEnum.FIRST_PLAYER;
			} else
			{
				MessageBox.Show("CurrentPlayer must be PlayerEnum.FIRST_PLAYER or PlayerEnum.SECOND_PLAYER" 
								+ " (method changeCurrentPlayer)");
			}
		}

		public void prepareCanvas()
		{
			int r = model.getR();
			int cellSize = r + 10;

			mainWindow.prepareCanvas(rows, cols, cellSize, model.Circles);
		}

		public bool checkGameOver()
		{
			for (int i = 0; i < cols; i++)
			{
				for (int j = 0; j < rows; j++)
				{
					if (!checkCircle(j, i))
					{
						continue;
					}

					if (checkHorizontal(j, i))
					{
						return true;
					}

					if (checkVertical(j, i))
					{
						return true;
					}

					if (checkLeftDiagonal(j, i))
					{
						return true;
					}

					if (checkRightDiagonal(j, i))
					{
						return true;
					}
				}
			}

			return false;
		}

		private bool checkHorizontal(int row, int col)
		{
			bool check;
			bool win;

			for (int i = NUM_OF_CIRCLES_FOR_WIN - 1; i >= 0; i--)
			{
				check = true;
				for (int j = i; j > 0; j--)
				{
					if (!checkCircle(row, col + j))
					{
						check = false;
						break;
					}
				}

				if (check)
				{
					win = true;
					for (int k = NUM_OF_CIRCLES_FOR_WIN - 1 - i; k > 0; k--)
					{
						if (!checkCircle(row, col - k))
						{
							win = false;
							break;
						}
					}

					if (win) {
						return true;
					}
				}
			}

			return false;

		}

		private bool checkLeftDiagonal(int row, int col)
		{
			bool check;
			bool win;

			for (int i = NUM_OF_CIRCLES_FOR_WIN - 1; i >= 0; i--)
			{
				check = true;
				for (int j = i; j > 0; j--)
				{
					if (!checkCircle(row + j, col + j))
					{
						check = false;
						break;
					}
				}

				if (check)
				{
					win = true;
					for (int k = NUM_OF_CIRCLES_FOR_WIN - 1 - i; k > 0; k--)
					{
						if (!checkCircle(row - k, col - k))
						{
							win = false;
							break;
						}
					}

					if (win)
					{
						return true;
					}
				}
			}

			return false;

		}

		private bool checkRightDiagonal(int row, int col)
		{
			bool check;
			bool win;

			for (int i = NUM_OF_CIRCLES_FOR_WIN - 1; i >= 0; i--)
			{
				check = true;
				for (int j = i; j > 0; j--)
				{
					if (!checkCircle(row - j, col + j))
					{
						check = false;
						break;
					}
				}

				if (check)
				{
					win = true;
					for (int k = NUM_OF_CIRCLES_FOR_WIN - 1 - i; k > 0; k--)
					{
						if (!checkCircle(row + k, col - k))
						{
							win = false;
							break;
						}
					}

					if (win)
					{
						return true;
					}
				}
			}

			return false;

		}


		private bool checkVertical(int row, int col)
		{
			bool check;
			bool win;

			for (int i = NUM_OF_CIRCLES_FOR_WIN - 1; i >= 0; i--)
			{
				check = true;
				for (int j = i; j > 0; j--)
				{
					if (!checkCircle(row + j, col))
					{
						check = false;
						break;
					}
				}

				if (check)
				{
					win = true;
					for (int k = NUM_OF_CIRCLES_FOR_WIN - 1 - i; k > 0; k--)
					{
						if (!checkCircle(row - k, col))
						{
							win = false;
							break;
						}
					}

					if (win)
					{
						return true;
					}
				}
			}

			return false;

		}

		private bool checkCircle(int row, int col)
		{
			if (row < 0 || row >= rows || col < 0 || col >= cols)
			{
				return false;
			}

			int index = col * rows + row;
			Circle circle = model.Circles[index];
			if (circle.Player == CurrentPlayer)
			{
				return true;
			} 
			else
			{
				return false;
			}
		}

	}

}
