using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Field
{
	/// <summary>
	/// Расположение ячеек
	/// </summary>
	public enum LocCell : byte
	{
		LC_0_0,
		LC_0_1,
		LC_0_2,
		LC_0_3,
		LC_0_4,
		LC_1_0,
		LC_1_1,
		LC_1_2,
		LC_1_3,
		LC_1_4,
		LC_2_0,
		LC_2_1,
		LC_2_2,
		LC_2_3,
		LC_2_4,
		LC_3_0,
		LC_3_1,
		LC_3_2,
		LC_3_3,
		LC_3_4,
		LC_4_0,
		LC_4_1,
		LC_4_2,
		LC_4_3,
		LC_4_4,
		LC_5_0,
		LC_5_1,
		LC_5_2,
		LC_5_3,
		LC_5_4,

	}

	/// <summary>
	/// Список расположения ячеек на футбольном поле
	/// </summary>
	public interface ILocCellToFieldList
	{
		/// <summary>
		/// Возвращает расположение ячейки
		/// </summary>
		/// <param name="cell"></param>
		/// <returns></returns>
		ILocCellToField this[LocCell locCell] { get; }
	}
}
