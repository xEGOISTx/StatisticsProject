using System;
using System.Collections.Generic;


namespace BaseObjects
{
	/// <summary>
	/// Базовый класс игрока
	/// </summary>
	[Serializable]
	public class BasicPlayer : IBasicPlayer
	{
		
		#region Properties
		/// <summary>
		/// Эффективность на базовой позиции
		/// </summary>
		public byte BasicPlayPositionEff { get; set; }

		/// <summary>
		/// Эффективность на текущей позиции
		/// </summary>
		public byte CurrentPlayPositionEff { get; set; }

		/// <summary>
		/// Кол-во игр
		/// </summary>
		public ushort CountGames { get; set; }

		/// <summary>
		/// ID игрока
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// Ключевое имя игрока
		/// </summary>
		public string KeyName { get; set; }

		/// <summary>
		/// Имя игрока
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Номер игрового бокса на поле
		/// </summary>
		public byte PlayBox { get; set; }

		/// <summary>
		/// Активный или не активный игрок
		/// </summary>
		public bool IsActive { get; set; }

		/// <summary>
		/// Рейтинг
		/// </summary>
		public float Rating { get; set; }

		/// <summary>
		/// Список параметров игрока
		/// </summary>
		public IList<IParameterPlayer> ParameterPlayerList { get; protected set; } = new List<IParameterPlayer>();
		#endregion Properties

		/// <summary>
		/// Возврашиет копию списка параметров
		/// </summary>
		/// <returns></returns>
		protected IList<IParameterPlayer> GetCopyParameters()
		{
			List<IParameterPlayer> parameters = new List<IParameterPlayer>();

			foreach (IParameterPlayer parameter in ParameterPlayerList)
			{
				parameters.Add(parameter.GetCopy());
			}

			return parameters;
		}

	}
}
