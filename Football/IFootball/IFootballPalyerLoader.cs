using BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football.Player;

namespace Football
{
	/// <summary>
	/// Интерфейс загрузчика футболистов
	/// </summary>
	public interface IFootballPalyerLoader
	{
		/// <summary>
		/// Загрузить игроков
		/// </summary>
		/// <returns></returns>
		IFootballPlayer[] LoadPlayers();

		/// <summary>
		/// Сохранить данные игрока
		/// </summary>
		/// <param name="player"></param>
		void SavePlayer(IFootballPlayer player);

		/// <summary>
		/// Удалить игрока
		/// </summary>
		/// <param name="player"></param>
		void DeletePlayer(IFootballPlayer player);
	}
}
