using ConnectFour.viewModel;
using ConnectFour.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConnectFour
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public Controller Controller { get; set; }
		
		public String CanvasViewport { get; set; }
		public int CanvasWidth { get; set; }
		public int CanvasHeight { get; set; }
		public List<Circle> Circles { get; set; }


		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = this;

			WindowState = WindowState.Maximized;

			Controller = new Controller(this);
			Controller.newGame();
			Controller.prepareCanvas();
		}

		private void cnv_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Canvas canvas = sender as Canvas;
			Point mousePosition = e.GetPosition(canvas); // dobicemo relativne koordinate u odnosu
														// na gornji levi cosak Canvas-a
			// MessageBox.Show("Point: " + mousePosition.X + ", " + mousePosition.Y);
			int col = (int) (mousePosition.X / 70);
			// MessageBox.Show("Col: " + col);
			Controller.changeCircle(col);
		}

		public void prepareCanvas(int rows, int cols, int cellSize, List<Circle> circles)
		{
			CanvasViewport = "0,0," + cellSize + "," + cellSize;
			CanvasWidth = cols * cellSize;
			CanvasHeight = rows * cellSize;
			Circles = circles;
		}
	}
}
