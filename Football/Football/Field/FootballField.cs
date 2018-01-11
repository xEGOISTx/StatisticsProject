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
	public class FootballField : IFootballField
	{
		/// <summary>
		/// Возвращает схемы
		/// </summary>
		public ISchemeList Schemes
		{
			get{ return new SchemeList(new LocCellToFieldList(),new LocInCellList()); }
		}
	}
}
