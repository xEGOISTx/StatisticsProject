using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Football.Player;

namespace Football.Field
{
	/// <summary>
	/// Интерфейс расположения игровой позиции в поле
	/// </summary>
	public interface ILocationPosition
	{
		#region Properties
		/// <summary>
		/// Возвращает расположение ячейки
		/// </summary>
		ILocCellToField GetLocCell { get; }

		/// <summary>
		/// Возвращает расположение в ячейке
		/// </summary>
		ILocInCell GetLocInCell { get; }

		/// <summary>
		/// Возвращает игровую позицию
		/// </summary>
		FootballPosition Position { get; }

		/// <summary>
		/// Номер расположения
		/// </summary>
		byte NumberLocation { get; }
		#endregion Properties
	}
}
