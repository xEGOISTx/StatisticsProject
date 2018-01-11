using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Football.Field
{
	/// <summary>
	/// Список расположений в ячейке
	/// </summary>
	public class LocInCellList : ILocInCellList
	{
		LocInCell[] _locs = new LocInCell[9];

		/// <summary>
		/// Инициализация списка расположений в ячейке
		/// </summary>
		public LocInCellList()
		{
			InitLocsInCell();
		}

		/// <summary>
		/// Инициализация расположений в ячейке
		/// </summary>
		private void InitLocsInCell()
		{
			byte index = 0;
			for (byte vert = 0; vert < 3; vert++)
			{
				for (byte hor = 0; hor < 3; hor++)
				{
					_locs[index++] = new LocInCell((HorizontalAlignment)hor, (VerticalAlignment)vert);
				}
			}
		}

		/// <summary>
		/// Возвращает расположение в ячейке
		/// </summary>
		/// <param name="locInCell"></param>
		/// <returns></returns>
		public ILocInCell this[LocsInCell locInCell]
		{
			get { return _locs[(byte)locInCell]; }
		}
	}
}
