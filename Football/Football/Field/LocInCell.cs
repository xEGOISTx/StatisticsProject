using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Football.Field
{
	/// <summary>
	/// Расположение внутри ячейки 
	/// </summary>
	public class LocInCell : ILocInCell
	{
		VerticalAlignment _vertical;
		HorizontalAlignment _horizontal;

		/// <summary>
		/// Инициализация расположения внутри ячейки
		/// </summary>
		/// <param name="horizontal"></param>
		/// <param name="vertical"></param>
		public LocInCell(HorizontalAlignment horizontal, VerticalAlignment vertical)
		{
			_vertical = vertical;
			_horizontal = horizontal;
		}



		/// <summary>
		/// Горизонтальное положение
		/// </summary>
		public HorizontalAlignment Horizontal
		{
			get { return _horizontal; }
		}

		/// <summary>
		/// Вертикальное положение
		/// </summary>
		public VerticalAlignment Vertical
		{
			get { return _vertical; }
		}
	}
}
