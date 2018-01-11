﻿using System;
using System.Linq;

namespace BaseObjects.BaseComponents
{
	/// <summary>
	/// Базовая логика атрибута перечисления
	/// </summary>
	public static class EnumAttributesBaseLogic
	{
		/// <param name="enumItem">Элемент перечисления</param>
		/// <param name="attributeType">Тип атрибута, значение которого хотим получить</param>
		/// <param name="defaultValue">
		/// Значение по-умолчанию, которое будет возвращено, если переданный
		/// элемент перечисления не помечен переданным атрибутом
		/// </param>
		/// <returns>Возвращает значение переданного атрибута у переданного элемента перечисления</returns>
		public static VAL GetAttributeValue<ENUM, VAL>(this ENUM enumItem, Type attributeType, VAL defaultValue)
		{
			var attribute = enumItem.GetType().GetField(enumItem.ToString()).GetCustomAttributes(attributeType, true)
			  .Where(a => a is BaseAttribute)
			  .Select(a => (BaseAttribute)a)
			  .FirstOrDefault();

			return attribute == null ? defaultValue : (VAL)attribute.GetValue();
		}
	}
}
