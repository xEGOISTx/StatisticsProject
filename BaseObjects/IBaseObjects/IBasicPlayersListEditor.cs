using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseObjects
{
	/// <summary>
	/// Интерфейс базового редактора списка игроков
	/// </summary>
	public interface IBasicPlayersListEditor
	{
		#region Methods
		/// <summary>
		/// Активировать/деактивировать игрока
		/// </summary>
		/// <param name="player"></param>
		void ActivateDeactivatePlayer(IBasicPlayer player, bool value);

		/// <summary>
		/// Полное удаление игрока
		/// </summary>
		/// <param name="player"></param>
		void DeletePlayer(IBasicPlayer player);
		#endregion Methods

	}
}
