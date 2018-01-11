using System;
using System.Collections.Generic;

namespace BaseObjects
{
	/// <summary>
	/// Параметр игрока
	/// </summary>
	[Serializable]
	public class ParameterPlayer : IParameterPlayer
	{
		#region Properties
		/// <summary>
		/// Имя параметра
		/// </summary>
		public string NameParameter { get; set; }

		/// <summary>
		/// Значение параметра
		/// </summary>
		public float ValueParameter { get; set; }

		/// <summary>
		/// Список подпараметров
		/// </summary>
		public IList<ISubParameterPlayer> SubParameterList { get; set; } = new List<ISubParameterPlayer>();
		#endregion Properties

		#region Methods
		/// <summary>
		/// Возвращает копию параметра
		/// </summary>
		/// <returns></returns>
		public IParameterPlayer GetCopy()
		{
			ParameterPlayer parameter = new ParameterPlayer();
			parameter.NameParameter = NameParameter;
			parameter.ValueParameter = ValueParameter;

			parameter.SubParameterList = new List<ISubParameterPlayer>();
			
			foreach(ISubParameterPlayer subParameter in SubParameterList)
			{
				parameter.SubParameterList.Add(subParameter.GetCopy());
			}

			return parameter;
		}
		#endregion Methods
	}
}
