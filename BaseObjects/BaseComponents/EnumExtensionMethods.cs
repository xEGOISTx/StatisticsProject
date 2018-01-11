using System;

namespace BaseObjects.BaseComponents
{
	/// <summary>
	/// Атрибут "Название"
	/// </summary>
	public class Name : BaseAttribute { public Name(string value) : base(value) { } }

	/// <summary>
	/// Методы расширения Enum
	/// </summary>
	public static class EnumExtensionMethods
	{
		public static string GetName(this Enum enumItem)
		{
			return enumItem.GetAttributeValue(typeof(Name), enumItem.ToString());
		}
	}
}
