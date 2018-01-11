using System;

namespace BaseObjects
{
	/// <summary>
	/// Интерфейс подпараметра игрока
	/// </summary>
	public interface ISubParameterPlayer
	{
		#region Properties
		/// <summary>
		/// Название подпараметра
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Показатель "Успешно"
		/// </summary>
		uint SuccessFully { get; }

		/// <summary>
		/// Показатель "Неуспешно"
		/// </summary>
		uint Failed { get; }

		/// <summary>
		/// Блокировка свойства "Неуспешно"
		/// </summary>
		bool IsNotBlockedFailed { get; }

		/// <summary>
		/// Блокировка свойства "Успешно"
		/// </summary>
		bool IsNotBlockedSuccessFully { get; }
		#endregion Properties

		#region Methods
		/// <summary>
		/// Возвращает копию подпараметра
		/// </summary>
		/// <returns></returns>
		ISubParameterPlayer GetCopy();
		#endregion Methods
	}
}
