using ConnectFour.model;
using ConnectFour.viewModel;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ConnectFour.view
{
	/// <summary>
	/// Interaction logic for NewGameExitDialog.xaml
	/// </summary>
	public partial class NewGameExitDialog : Window
	{
		private NewGameExitViewModel newGameExitViewModel;
		public PlayerEnum Winner { get; set; }

		public NewGameExitDialog(Controller controller, PlayerEnum _winner)
		{
			InitializeComponent();
			this.DataContext = this;
			newGameExitViewModel = new NewGameExitViewModel(this, controller);
			Winner = _winner;
		}

		private void Button_Click_Exit(object sender, RoutedEventArgs e)
		{
			newGameExitViewModel.exit();
		}

		private void Button_Click_New_Game(object sender, RoutedEventArgs e)
		{
			newGameExitViewModel.newGame();
		}
	}
}
