using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseObjects.BaseComponents;
using System.Collections;

namespace Football.Field
{
	/// <summary>
	/// Футбольные схемы
	/// </summary>
	public enum FootballScheme
	{
		[Name("3-1-4-2")]
		S3_1_4_2,
		[Name("3-4-1-2")]
		S3_4_1_2,
		[Name("3-4-2-1")]
		S3_4_2_1,
		[Name("3-4-3 Ромб")]
		S3_4_3Romb,
		[Name("3-4-3 В линию")]
		S3_4_3Line,
		[Name("3-5-1-1")]
		S3_5_1_1,
		[Name("3-5-2")]
		S3_5_2,
		[Name("4-1-2-1-2 Узкая")]
		S4_1_2_1_2Narrow,
		[Name("4-1-2-1-2 Широкая")]
		S4_1_2_1_2Wide,
		[Name("4-1-3-2")]
		S4_1_3_2,
		[Name("4-1-4-1")]
		S4_1_4_1,
		[Name("4-2-2-2")]
		S4_2_2_2,
		[Name("4-2-3-1 Узкая")]
		S4_2_3_1Narrow,
		[Name("4-2-3-1 Широкая")]
		S4_2_3_1Wide,
		[Name("4-2-4")]
		S4_2_4,
		[Name("4-3-1-2")]
		S4_3_1_2,
		[Name("4-3-2-1")]
		S4_3_2_1,
		[Name("4-3-3 Атакуящая")]
		S4_3_3Attack,
		[Name("4-3-3 В линию")]
		S4_3_3Line,
		[Name("4-3-3 Защита")]
		S4_3_3Defence,
		[Name("4-3-3 Ложная 9")]
		S4_3_3False9,
		[Name("4-3-3 Удержание")]
		S4_3_3Retention,
		[Name("4-4-1-1 Атакующая")]
		S4_4_1_1Attack,
		[Name("4-4-1-1 Полузащита")]
		S4_4_1_1Halfbacks,
		[Name("4-4-2 В линию")]
		S4_4_2Line,
		[Name("4-4-2 Удержание")]
		S4_4_2Retention,
		[Name("4-5-1 Атакуящая")]
		S4_5_1Attack,
		[Name("4-5-1 В линию")]
		S4_5_1Line,
		[Name("5-2-1-2")]
		S5_2_1_2,
		[Name("5-3-2")]
		S5_3_2,
		[Name("5-4-1 В линию")]
		S5_4_1Line,
		[Name("5-4-1 Ромб")]
		S5_4_1Romb
	}

	/// <summary>
	/// Список схем
	/// </summary>
	public interface ISchemeList : IEnumerable
	{
		/// <summary>
		/// Возвращает схему
		/// </summary>
		/// <param name="scheme"></param>
		/// <param name="numberObjectToField"></param>
		/// <returns></returns>
		IScheme GetScheme(FootballScheme scheme);
	}
}
