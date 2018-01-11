using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseObjects;
using BaseObjects.BaseComponents;

namespace Football.Player
{
	public delegate void AcceptChangesEventHandler(object sender, EventArgs e);

	public interface IPlayerEditor : IEditorLocationPlayer
	{

		#region Properties
		/// <summary>
		/// Признак налиция игрока в редакторе
		/// </summary>
		bool IsPresentPlayer { get; }
		float CurrentRating { get; }
		float EditableRating { get; }
		ushort CurrentCountGames { get; }
		ushort EditableCountGames { get; }
		bool PresentChangedPlayers { get; }
        FootballPosition CurrentBasicPosition { get; }
        FootballPosition EditableBasicPosition { get; }
        string CurrentName { get; }
        string EditableName { get; }
        #endregion Properties



        #region Methods
        /// <summary>
        /// Установить игрока для редактирования
        /// </summary>
        /// <param name="player"></param>
        void SetPlayer(IFootballPlayer player);

		/// <summary>
		/// Редактировать под параметер
		/// </summary>
		/// <param name="subParam"></param>
		/// <param name="successFully"></param>
		/// <param name="failed"></param>
		void EditSubParameter(ref ISubParameterPlayer subParam, uint successFully, uint failed);

		/// <summary>
		/// Редактировать рейтинг
		/// </summary>
		/// <param name="raring"></param>
		/// <param name="countGames"></param>
		void EditRating(float raring, ushort countGames);

        /// <summary>
        /// Редактировать имя и базовую позицию игрока
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="position"></param>
        void EditBasicProperties(string playerName, FootballPosition position);

		/// <summary>
		/// Очистить редактор. Удаляет игрока, а также очищает все изменения всех изменённых игроков
		/// </summary>
		void Clear();

		/// <summary>
		/// Удалить игрока из редактора
		/// </summary>
		void RemovePlayer();

		/// <summary>
		/// Закончить редактирование
		/// </summary>
		/// <param name="acceptChange"></param>
		void EndEditing(bool acceptChanged);

		/// <summary>
		/// Возврашает список параметров для редактирования
		/// </summary>
		/// <returns></returns>
		IList<ISubParameterPlayer> GetListForEditParameters();

		/// <summary>
		/// Возвращает саисок параметров с текущими значениями
		/// </summary>
		/// <returns></returns>
		IList<ISubParameterPlayer> GetCurrentParametersValuesList();

		/// <summary>
		/// Возвращает игрока находящегося в редакторе. Если игрока нет возвращает null
		/// </summary>
		/// <returns></returns>
		IFootballPlayer GetPlayer();
		#endregion



		#region Events
		/// <summary>
		/// Возникаеи при применении изменений
		/// </summary>
		event AcceptChangesEventHandler AcceptChanges;
		#endregion Events
	}
}
