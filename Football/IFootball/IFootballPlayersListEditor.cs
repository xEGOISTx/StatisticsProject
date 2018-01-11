using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseObjects;
using Football.Player;

namespace Football
{
	/// <summary>
	/// Интерфейс редактора списка футболистов
	/// </summary>
	public interface IFootballPlayersListEditor : IBasicPlayersListEditor
	{
		/// <summary>
		/// Добавить нового футболиста
		/// </summary>
		/// <param name="name"></param>
		/// <param name="keyName"></param>
		/// <param name="basicPosition"></param>
		void AddNewPlayer(string name, string keyName, FootballPosition basicPosition);
	}
}
