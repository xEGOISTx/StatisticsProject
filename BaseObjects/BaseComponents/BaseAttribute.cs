using System;

namespace BaseObjects.BaseComponents
{
	/// <summary>
	/// Базовый класс атрибута
	/// </summary>
	public class BaseAttribute : Attribute
	{
		private readonly object _value;

		public BaseAttribute(object value)
		{
			this._value = value;
		}

		/// <summary>
		/// Возвращает значение
		/// </summary>
		/// <returns></returns>
		public object GetValue()
		{
			return this._value;
		}
	}
}
