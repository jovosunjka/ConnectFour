using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour.model
{
	public class Circle : INotifyPropertyChanged
	{
		public int X { get; set; }
		public int Y { get; set; }
		public int R { get; set; } // precnik

		private PlayerEnum _Player;
		public PlayerEnum Player
		{
			get { return _Player; }
			set
			{
				if (_Player != value)
				{
					_Player = value;
					OnPropertyChanged("Player");
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

		public Circle(int _x, int _y, int _r, PlayerEnum _player) {
			X = _x;
			Y = _y;
			R = _r;
			Player = _player;
		}
	}
}
