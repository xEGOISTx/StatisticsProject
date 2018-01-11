using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseObjects;

namespace Football.Player
{
	public interface IEditorLocationPlayer
	{
		/// <summary>
		/// Установить текущую позицию
		/// </summary>
		/// <param name="position"></param>
		void EditCurrentPosition(IFootballPlayer player, FootballPosition position);

		/// <summary>
		/// Установить текущий номер расположения на поле
		/// </summary>
		/// <param name="player"></param>
		/// <param name="numberLocPos"></param>
		void EditCurrentNumberLocPos(IFootballPlayer player, byte numberLocPos);
	}
}
