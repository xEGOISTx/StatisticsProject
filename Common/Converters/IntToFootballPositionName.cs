using System;
using System.Globalization;
using System.Windows.Data;

namespace Converters
{
	public class IntToFootballPositionName : IValueConverter
	{
		public static IntToFootballPositionName Instance = new IntToFootballPositionName();

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((int)value == 0)
			{
				return string.Empty;
			}

			return ((Football.Player.FootballPosition)((int)value)).ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
