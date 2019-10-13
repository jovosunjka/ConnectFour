using ConnectFour.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour.viewModel
{
	public class NewGameExitViewModel
	{
		private NewGameExitDialog newGameExitDialog;
		private Controller controller;

		public NewGameExitViewModel(NewGameExitDialog _newGameExitDialog, Controller _controller)
		{
			newGameExitDialog = _newGameExitDialog;
			controller = _controller;
		}

		public void exit()
		{
			newGameExitDialog.Close();
			System.Windows.Application.Current.Shutdown();
		}

		public void newGame()
		{
			controller.newGame();
			newGameExitDialog.Close();
		}
	}
}
