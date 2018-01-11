using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Field
{
	/// <summary>
	/// Интерфейс футбольной схемы
	/// </summary>
	public interface IScheme : IEnumerable
	{
		/// <summary>
		/// Название схемы
		/// </summary>
		string NameScheme { get; }

		/// <summary>
		/// Возвращает расположение позиции в поле
		/// </summary>
		ILocationPosition GetLocation(byte numberObject);
	}
}
