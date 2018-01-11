using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseObjects;
using BaseObjects.BaseComponents;
using Football.Player;

namespace Football
{
    /// <summary>
    /// Интерфейс списка футболистов
    /// </summary>
    public interface IFootballPlayerList : IEnumerable
	{
		#region Properties
		/// <summary>
		/// Редактор списка
		/// </summary>
		IFootballPlayersListEditor Editor { get; }

		/// <summary>
		/// Кол-во футболистов в списке
		/// </summary>
		int Count { get; }

		/// <summary>
		/// Кол-во активных футболистов в списке
		/// </summary>
		int CountActivePlayers { get; }
		#endregion Properties



		#region Methods
		/// <summary>
		/// Проверить наличие футболиста в списке по ключевому имени
		/// </summary>
		/// <param name="keyName"></param>
		/// <returns></returns>
		bool Present(string keyName);

		/// <summary>
		/// Загрузить футболистов в список
		/// </summary>
		void LoadPlayers();

		/// <summary>
		/// Возвращает футболиста по ключевому имени
		/// </summary>
		/// <param name="keyName"></param>
		/// <returns></returns>
		IFootballPlayer this[string keyName] { get; }

		/// <summary>
		/// Возвращает копию списка
		/// </summary>
		/// <returns></returns>
		IFootballPlayerList GetCopy();

		/// <summary>
		/// Возврещает редактор игрока
		/// </summary>
		/// <returns></returns>
		IPlayerEditor GetPlayerEditor();

		#endregion Methods



		#region Events
		/// <summary>
		/// Возникает при успешном добавлении нового футболиста в список
		/// </summary>
		event AddedPlayerEventHandler AddedPlayer;
		#endregion Events

	}
}
