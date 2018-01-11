using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Football.Field
{
	/// <summary>
	/// Расположение в ячейке
	/// </summary>
	public interface ILocInCell
	{
		/// <summary>
		/// Вертикальное положение
		/// </summary>
		VerticalAlignment Vertical { get; }

		/// <summary>
		/// Горизонтальное положение
		/// </summary>
		HorizontalAlignment Horizontal { get; }
	}
}
