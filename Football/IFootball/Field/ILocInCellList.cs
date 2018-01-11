using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Field
{
	/// <summary>
	/// Расположение а ячейке
	/// </summary>
	public enum LocsInCell : byte
	{
		TopLeft,
		Top,
		TopRight,
		CenterLeft,
		Center,
		CenterRight,
		BottomLeft,
		Bottom,
		BottomRight
	}

	/// <summary>
	/// Интерфейс списка расположений в ячейке
	/// </summary>
	public interface ILocInCellList
	{
		/// <summary>
		/// Возвращает расположение в ячейке
		/// </summary>
		/// <param name="locInCell"></param>
		/// <returns></returns>
		ILocInCell this[LocsInCell locInCell] { get; }
	}
}
