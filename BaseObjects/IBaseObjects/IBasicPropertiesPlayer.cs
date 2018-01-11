using System;
using System.Collections.Generic;

namespace BaseObjects
{
	/// <summary>
	/// Базовые свойства игрока
	/// </summary>
	public interface IBasicPropertiesPlayer
	{
		/// <summary>
		/// Имя игрока
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Номер игрового бокса на поле
		/// </summary>
		byte PlayBox { get; }

		/// <summary>
		/// Активный или не активный игрок
		/// </summary>
		bool IsActive { get; }

		/// <summary>
		/// Эффективность на базовой позиции
		/// </summary>
		byte BasicPlayPositionEff { get; }

		/// <summary>
		/// Эффективность на текущей позиции
		/// </summary>
		byte CurrentPlayPositionEff { get; }

		/// <summary>
		/// Рейтинг
		/// </summary>
		float Rating { get; }

		/// <summary>
		/// Кол-во игр
		/// </summary>
		ushort CountGames { get; }

		/// <summary>
		/// Список параметров игрока
		/// </summary>
		IList<IParameterPlayer> ParameterPlayerList { get; }
	}
}
