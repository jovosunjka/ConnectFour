using ConnectFour.model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ConnectFour.view.converters
{
	public class PlayerToColorConverter : IValueConverter
	{
		private readonly String GRAY = "#CFCFCF";
		private readonly String YELLOW = "#FAE007";
		private readonly String RED = "#FE2020";

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			PlayerEnum player = (PlayerEnum) value;
			if (player == PlayerEnum.FIRST_PLAYER)
			{
				return YELLOW;
			} 
			else if (player == PlayerEnum.SECOND_PLAYER)
			{
				return RED;
			}

			return GRAY;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

}
