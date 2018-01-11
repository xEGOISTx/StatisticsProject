using System;
using System.Collections.Generic;

namespace BaseObjects
{
	/// <summary>
	/// Базовый интерфейс игрока
	/// </summary>
	public interface IBasicPlayer : IBasicPropertiesPlayer
	{
		#region Properties
		/// <summary>
		/// ID игрока
		/// </summary>
		int ID { get; }

		/// <summary>
		/// Ключевое имя игрока
		/// </summary>
		string KeyName { get; }
		#endregion Properties
	}
}
