using System;

namespace BaseObjects
{
	/// <summary>
	/// Подпараметр игрока
	/// </summary>
	[Serializable]
	public class SubParameterPlayer : ISubParameterPlayer
	{
		#region Constructors
		/// <summary>
		/// Инициализация подпараметра
		/// </summary>
		public SubParameterPlayer()
		{
            IsNotBlockedFailed = true;
            IsNotBlockedSuccessFully = true;
        }
		#endregion Constructors

		#region Properties
		/// <summary>
		/// Имя подпараметра
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Показатель "Успешно"
		/// </summary>
		public uint Failed { get; set; }

		/// <summary>
		/// Показатель "Неуспешно"
		/// </summary>
		public uint SuccessFully { get; set; }

		/// <summary>
		/// Блокировка свойства "Неуспешно" 
		/// </summary>
		public bool IsNotBlockedFailed { get; set; }

		/// <summary>
		/// Блокировка свойства "Успешно"
		/// </summary>
		public bool IsNotBlockedSuccessFully { get; set; }
		#endregion Properties

		#region Methods
		/// <summary>
		/// Возвращает копию подпараметра
		/// </summary>
		/// <returns></returns>
		public ISubParameterPlayer GetCopy()
		{
			SubParameterPlayer subParameter = new SubParameterPlayer();
			subParameter.Name = Name;
			subParameter.Failed = Failed;
			subParameter.SuccessFully = SuccessFully;
			subParameter.IsNotBlockedFailed = IsNotBlockedFailed;
			subParameter.IsNotBlockedSuccessFully = IsNotBlockedSuccessFully;
			return subParameter;
		}
		#endregion Methods
	}
}
