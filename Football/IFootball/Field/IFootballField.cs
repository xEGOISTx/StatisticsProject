using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Field
{
	/// <summary>
	/// Футбольное поле
	/// </summary>
	public interface IFootballField
	{
		/// <summary>
		/// Схемы
		/// </summary>
		ISchemeList Schemes { get; }
	}
}
