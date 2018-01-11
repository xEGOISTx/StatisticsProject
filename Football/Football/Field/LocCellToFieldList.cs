using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Field
{
	/// <summary>
	/// Список расположения ячеек на футбольном поле
	/// </summary>
	public class LocCellToFieldList : ILocCellToFieldList
	{
		LocCellToField[] _cells = new LocCellToField[30];


		/// <summary>
		/// Инициализация списка расположения ячеек на футбольном поле
		/// </summary>
		public LocCellToFieldList()
		{
			InitLocCells();
		}

		/// <summary>
		/// Инициализация расположения ячеек
		/// </summary>
		private void InitLocCells()
		{
			byte index = 0;
			for (byte row = 0; row < 6; row++)
			{
				for (byte col = 0; col < 5; col++)
				{
					_cells[index++] = new LocCellToField(row, col);
				}
			}
		}

		/// <summary>
		/// Возвращает расположение ячейки
		/// </summary>
		/// <param name="cell"></param>
		/// <returns></returns>
		public ILocCellToField this[LocCell locCell]
		{
			get { return _cells[(byte)locCell]; }
		}
	}
}
