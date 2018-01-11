using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Player
{
	/// <summary>
	/// Футбольные позиции
	/// </summary>
	public enum FootballPosition
	{
		Default = 0,
		ВРТ = 1,
		ПФЗ, //- правый фланговый защитник / бровочник с акцентом на оборону
		ЛЦЗ, //- левый центральный защитник
		ЦЗ, //- центральный защитник
		ПЦЗ, //- правый центральный защитник
		ЛЗ, //- левый защитник
		ЛФЗ, //- левый фланговый защитник / бровочник с акцентом на оборону
		ПОП, //- правый опорный полузащитник
		ЦОП, //- центральный опорный полузащитник
		ЛОП, //- левый опорный полузащитник
		ПЦП, //- правый центральный полузащитник
		ЦП, //- центральный полузащитник
		ЛЦП, //- левый центральный полузащитник
		ПП, //- правый крайний полузащитник
		ЛП, //- левый крайний полузащитник
		ПАП, //- правый атакующий полузащитник
		ЦАП, //- центральный атакующий полузащитник
		ЛАП, //- левый атакующий полузащитник
		ФРВ, //- форвард / чистый форвард
		ПФД, //- правый  форвард
		ЛФД, //- левый форвард. 
		ЦФД, //- оттянутый форвард
		ПФА, //- правый фланговый атакующий / правый крайний форвард
		ЛФА, //- левый фланговый атакующий / левый крайний форвард
		ПЗ
	}

	/// <summary>
	/// Интерфейс футболиста
	/// </summary>
	public interface IFootballPlayer : BaseObjects.IBasicPlayer
	{
		#region Properties
		/// <summary>
		/// Базавая позиция футболиста
		/// </summary>
		FootballPosition BasicPlayPosition { get; }

		/// <summary>
		/// Текущая позиция футболиста
		/// </summary>
		FootballPosition CurrentPlayPosition { get; }
		#endregion Properties



		#region Methods
		/// <summary>
		/// Возвращает копию
		/// </summary>
		/// <returns></returns>
		IFootballPlayer GetCopy();
		#endregion Methods
	}
}
