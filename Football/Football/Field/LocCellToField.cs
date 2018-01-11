using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Field
{
	/// <summary>
	/// Расположения ячейки на поле
	/// </summary>
	public class LocCellToField : ILocCellToField
	{
		byte _column;
		byte _row;


		/// <summary>
		/// Инициализация расположения ячейки на поле
		/// </summary>
		/// <param name="row"></param>
		/// <param name="column"></param>
		public LocCellToField(byte row,byte column)
		{
			_column = column;
			_row = row;
		}


		/// <summary>
		/// Колонка
		/// </summary>
		public byte Column
		{
			get { return _column; }
		}

		/// <summary>
		/// Ряд
		/// </summary>
		public byte Row
		{
			get { return _row; }
		}

	}
}
