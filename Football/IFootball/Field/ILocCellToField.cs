using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Field
{
	/// <summary>
	/// Интерфейс расположения ячейки на поле
	/// </summary>
	public interface ILocCellToField
	{
		/// <summary>
		/// Ряд
		/// </summary>
		byte Row { get; }

		/// <summary>
		/// Колонка
		/// </summary>
		byte Column { get; }
	}
}
