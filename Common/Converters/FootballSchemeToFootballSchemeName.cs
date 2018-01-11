using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Football.Field;
using BaseObjects.BaseComponents;

namespace Converters
{
	public class FootballSchemeToFootballSchemeName : IValueConverter
	{
		public static FootballSchemeToFootballSchemeName Inst { get; } = new FootballSchemeToFootballSchemeName();

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ((FootballScheme)value).GetName();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
