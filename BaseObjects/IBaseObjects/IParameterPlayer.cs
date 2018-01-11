using System;
using System.Collections.Generic;

namespace BaseObjects
{
	/// <summary>
	/// Параметр игрока
	/// </summary>
	public interface IParameterPlayer
	{
		/// <summary>
		/// Имя параметра
		/// </summary>
		string NameParameter { get; }

		/// <summary>
		/// Значение параметра
		/// </summary>
		float ValueParameter { get; }

		/// <summary>
		/// Список подпараметров
		/// </summary>
		IList<ISubParameterPlayer> SubParameterList { get; }

		/// <summary>
		/// Возвращает копию
		/// </summary>
		/// <returns></returns>
		IParameterPlayer GetCopy();
	}
}
