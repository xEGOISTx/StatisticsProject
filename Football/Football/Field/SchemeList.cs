using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Football.Player;

namespace Football.Field
{
	/// <summary>
	/// Список схем
	/// </summary>
	public class SchemeList : ISchemeList
	{
		#region Fields
		Dictionary<FootballScheme, Scheme> _schemes = new Dictionary<FootballScheme, Scheme>();
		#endregion Fields



		#region Constructors
		/// <summary>
		/// Инициализация списка схем
		/// </summary>
		public SchemeList(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			InitSchemes(locCells, locsInCell);
		}
		#endregion Constructors


		#region Methods
		/// <summary>
		/// Возвращает схему
		/// </summary>
		/// <param name="scheme"></param>
		/// <returns></returns>
		public IScheme GetScheme(FootballScheme scheme)
		{
			return _schemes[scheme];
		}

		/// <summary>
		/// Инициализация схем
		/// </summary>
		void InitSchemes(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			_schemes.Clear();

			Scheme3_1_4_2(locCells, locsInCell);
			Scheme3_4_1_2(locCells, locsInCell);
			Scheme3_4_2_1(locCells, locsInCell);
			Scheme3_4_3Romb(locCells, locsInCell);
			Scheme3_4_3Line(locCells, locsInCell);
			Scheme3_5_1_1(locCells, locsInCell);
			Scheme3_5_2(locCells, locsInCell);
			Scheme4_1_2_1_2Narrow(locCells, locsInCell);
			Scheme4_1_2_1_2Wide(locCells, locsInCell);
			Scheme4_1_3_2(locCells, locsInCell);
			Scheme4_1_4_1(locCells, locsInCell);
			Scheme4_2_2_2(locCells, locsInCell);
			Scheme4_2_3_1Narrow(locCells, locsInCell);
			Scheme4_2_3_1Wide(locCells, locsInCell);
			Scheme4_2_4(locCells, locsInCell);
			Scheme4_3_1_2(locCells, locsInCell);
			Scheme4_3_2_1(locCells, locsInCell);
			Scheme4_3_3Attack(locCells, locsInCell);
			Scheme4_3_3Line(locCells, locsInCell);
			Scheme4_3_3Defence(locCells, locsInCell);
			Scheme4_3_3False9(locCells, locsInCell);
			Scheme4_3_3Retention(locCells, locsInCell);
			Scheme4_4_1_1Attack(locCells, locsInCell);
			Scheme4_4_1_1Halfbacks(locCells, locsInCell);
			Scheme4_4_2Line(locCells, locsInCell);
			Scheme4_4_2Retention(locCells, locsInCell);
			Scheme4_5_1Attack(locCells, locsInCell);
			Scheme4_5_1Line(locCells, locsInCell);
			Scheme5_2_1_2(locCells, locsInCell);
			Scheme5_3_2(locCells, locsInCell);
			Scheme5_4_1Line(locCells, locsInCell);
			Scheme5_4_1Romb(locCells, locsInCell);
		}

		/// <summary>
		/// Возвращает перечеслитель
		/// </summary>
		/// <returns></returns>
		public IEnumerator GetEnumerator()
		{
			return _schemes.Values.GetEnumerator();
		}

		#region Schemes
		void Scheme3_1_4_2(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("3-1-4-2");

			scheme.AddLocation( new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation( new LocationPosition(2, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.BottomLeft], FootballPosition.ЛЦЗ));
			scheme.AddLocation( new LocationPosition(3, locCells[LocCell.LC_4_2], locsInCell[LocsInCell.Center], FootballPosition.ЦЗ));
			scheme.AddLocation( new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.BottomRight], FootballPosition.ПЦЗ));
			scheme.AddLocation( new LocationPosition(5, locCells[LocCell.LC_3_2], locsInCell[LocsInCell.Center], FootballPosition.ЦОП));
			scheme.AddLocation( new LocationPosition(6, locCells[LocCell.LC_2_0], locsInCell[LocsInCell.Top], FootballPosition.ЛП));
			scheme.AddLocation( new LocationPosition(7, locCells[LocCell.LC_2_1], locsInCell[LocsInCell.Center], FootballPosition.ЛЦП));
			scheme.AddLocation( new LocationPosition(8, locCells[LocCell.LC_2_3], locsInCell[LocsInCell.Center], FootballPosition.ПЦП));
			scheme.AddLocation( new LocationPosition(9, locCells[LocCell.LC_2_4], locsInCell[LocsInCell.Top], FootballPosition.ПП));
			scheme.AddLocation( new LocationPosition(10, locCells[LocCell.LC_0_1], locsInCell[LocsInCell.BottomRight], FootballPosition.ЛФД));
			scheme.AddLocation( new LocationPosition(11, locCells[LocCell.LC_0_3], locsInCell[LocsInCell.BottomLeft], FootballPosition.ПФД));

			_schemes.Add(FootballScheme.S3_1_4_2, scheme);
		}

		void Scheme3_4_1_2(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("3-4-1-2");

			scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.BottomLeft], FootballPosition.ЛЦЗ));
			scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_2], locsInCell[LocsInCell.Center], FootballPosition.ЦЗ));
			scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.BottomRight], FootballPosition.ПЦЗ));
			scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_2_0], locsInCell[LocsInCell.Top], FootballPosition.ЛП));
			scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_2_1], locsInCell[LocsInCell.Bottom], FootballPosition.ЛЦП));
			scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_2_3], locsInCell[LocsInCell.Bottom], FootballPosition.ПЦП));
			scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_2_4], locsInCell[LocsInCell.Top], FootballPosition.ПП));
			scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_1_2], locsInCell[LocsInCell.Bottom], FootballPosition.ЦАП));
			scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_0_1], locsInCell[LocsInCell.Bottom], FootballPosition.ЛФД));
			scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_3], locsInCell[LocsInCell.Bottom], FootballPosition.ПФД));

			_schemes.Add(FootballScheme.S3_4_1_2, scheme);
		}

		void Scheme3_4_2_1(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("3-4-2-1");

			scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.BottomLeft], FootballPosition.ЛЦЗ));
			scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_2], locsInCell[LocsInCell.Center], FootballPosition.ЦЗ));
			scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.BottomRight], FootballPosition.ПЦЗ));
			scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_2_0], locsInCell[LocsInCell.Top], FootballPosition.ЛП));
			scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_2_1], locsInCell[LocsInCell.Bottom], FootballPosition.ЛЦП));
			scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_2_3], locsInCell[LocsInCell.Bottom], FootballPosition.ПЦП));
			scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_2_4], locsInCell[LocsInCell.Top], FootballPosition.ПП));
			scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_1_1], locsInCell[LocsInCell.CenterLeft], FootballPosition.ЛФД));
			scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_1_3], locsInCell[LocsInCell.CenterRight], FootballPosition.ПФД));
			scheme.AddLocation( new LocationPosition(11, locCells[LocCell.LC_0_2], locsInCell[LocsInCell.Bottom], FootballPosition.ФРВ));

			_schemes.Add(FootballScheme.S3_4_2_1, scheme);
		}

		void Scheme3_4_3Romb(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("3-4-3 Romb");



			scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.BottomLeft], FootballPosition.ЛЦЗ));
			scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_2], locsInCell[LocsInCell.Center], FootballPosition.ЦЗ));
			scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.BottomRight], FootballPosition.ПЦЗ));
			scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_2_0], locsInCell[LocsInCell.Bottom], FootballPosition.ЛП));
			scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_3_2], locsInCell[LocsInCell.Bottom], FootballPosition.ЦОП));
			scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_1_2], locsInCell[LocsInCell.Center], FootballPosition.ЦАП));
			scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_2_4], locsInCell[LocsInCell.Bottom], FootballPosition.ПП));
			scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_0_0], locsInCell[LocsInCell.BottomLeft], FootballPosition.ЛФА));
			scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_0_2], locsInCell[LocsInCell.Center], FootballPosition.ФРВ));
			scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_4], locsInCell[LocsInCell.BottomRight], FootballPosition.ПФА));

			_schemes.Add(FootballScheme.S3_4_3Romb, scheme);
		}

		void Scheme3_4_3Line(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("3-4-3 Line");



			scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.BottomLeft], FootballPosition.ЛЦЗ));
			scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_2], locsInCell[LocsInCell.Center], FootballPosition.ЦЗ));
			scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.BottomRight], FootballPosition.ПЦЗ));
			scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_2_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛП));
			scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_2_1], locsInCell[LocsInCell.Bottom], FootballPosition.ЛЦП));
			scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_2_3], locsInCell[LocsInCell.Bottom], FootballPosition.ПЦП));
			scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_2_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПП));
			scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_0_0], locsInCell[LocsInCell.BottomRight], FootballPosition.ЛФА));
			scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_0_2], locsInCell[LocsInCell.Center], FootballPosition.ФРВ));
			scheme.AddLocation( new LocationPosition(11, locCells[LocCell.LC_0_4], locsInCell[LocsInCell.BottomLeft], FootballPosition.ПФА));

			_schemes.Add(FootballScheme.S3_4_3Line, scheme);
		}

		void Scheme3_5_1_1(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("3-5-1-1");

			scheme.AddLocation( new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation( new LocationPosition(2, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.BottomLeft], FootballPosition.ЛЦЗ));
			scheme.AddLocation( new LocationPosition(3, locCells[LocCell.LC_4_2], locsInCell[LocsInCell.Center], FootballPosition.ЦЗ));
			scheme.AddLocation( new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.BottomRight], FootballPosition.ПЦЗ));
			scheme.AddLocation( new LocationPosition(5, locCells[LocCell.LC_2_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛП));
			scheme.AddLocation( new LocationPosition(6, locCells[LocCell.LC_3_1], locsInCell[LocsInCell.Center], FootballPosition.ЛОП));
			scheme.AddLocation( new LocationPosition(7, locCells[LocCell.LC_2_2], locsInCell[LocsInCell.Bottom], FootballPosition.ЦП));
			scheme.AddLocation( new LocationPosition(8, locCells[LocCell.LC_3_3], locsInCell[LocsInCell.Center], FootballPosition.ПОП));
			scheme.AddLocation( new LocationPosition(9, locCells[LocCell.LC_2_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПП));
			scheme.AddLocation( new LocationPosition(10, locCells[LocCell.LC_1_2], locsInCell[LocsInCell.Top], FootballPosition.ЦФД));
			scheme.AddLocation( new LocationPosition(11, locCells[LocCell.LC_0_2], locsInCell[LocsInCell.Center], FootballPosition.ФРВ));

			_schemes.Add(FootballScheme.S3_5_1_1, scheme);
		}

		void Scheme3_5_2(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("3-5-2");

			scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.BottomLeft], FootballPosition.ЛЦЗ));
			scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_2], locsInCell[LocsInCell.Center], FootballPosition.ЦЗ));
			scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.BottomRight], FootballPosition.ПЦЗ));
			scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_2_0], locsInCell[LocsInCell.Center], FootballPosition.ЛП));
			scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_3_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛОП));
			scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_1_2], locsInCell[LocsInCell.Bottom], FootballPosition.ЦАП));
			scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_3_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПОП));
			scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_2_4], locsInCell[LocsInCell.Center], FootballPosition.ПП));
			scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_0_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛФД));
			scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПФД));

			_schemes.Add(FootballScheme.S3_5_2, scheme);
		}

		void Scheme4_1_2_1_2Narrow(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("4-1-2-1 Narrow");

			scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЗ));
			scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛЦЗ));
			scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПЦЗ));
			scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПЗ));
			scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_3_2], locsInCell[LocsInCell.Center], FootballPosition.ЦОП));
			scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_2_1], locsInCell[LocsInCell.Bottom], FootballPosition.ЛЦП));
			scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_2_3], locsInCell[LocsInCell.Bottom], FootballPosition.ПЦП));
			scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_1_2], locsInCell[LocsInCell.Center], FootballPosition.ЦАП));
			scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_0_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛФД));
			scheme.AddLocation( new LocationPosition(11, locCells[LocCell.LC_0_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПФД));

			_schemes.Add(FootballScheme.S4_1_2_1_2Narrow, scheme);
		}

		void Scheme4_1_2_1_2Wide(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("4-1-2-1 Wide");

			scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЗ));
			scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛЦЗ));
			scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПЦЗ));
			scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПЗ));
			scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_3_2], locsInCell[LocsInCell.Center], FootballPosition.ЦОП));
			scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_2_0], locsInCell[LocsInCell.Center], FootballPosition.ЛП));
			scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_2_4], locsInCell[LocsInCell.Center], FootballPosition.ПП));
			scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_1_2], locsInCell[LocsInCell.Center], FootballPosition.ЦАП));
			scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_0_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛФД));
			scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПФД));

			_schemes.Add(FootballScheme.S4_1_2_1_2Wide, scheme);
		}

		void Scheme4_1_3_2(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("4-1-3-2");

			scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЗ));
			scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛЦЗ));
			scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПЦЗ));
			scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПЗ));
			scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_3_2], locsInCell[LocsInCell.Bottom], FootballPosition.ЦОП));
			scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_2_0], locsInCell[LocsInCell.CenterLeft], FootballPosition.ЛП));
			scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_2_2], locsInCell[LocsInCell.Center], FootballPosition.ЦП));
			scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_2_4], locsInCell[LocsInCell.CenterRight], FootballPosition.ПП));
			scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_0_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛФД));
			scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПФД));

			_schemes.Add(FootballScheme.S4_1_3_2, scheme);
		}

		void Scheme4_1_4_1(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("4-1-4-1");

			scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЗ));
			scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛЦЗ));
			scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПЦЗ));
			scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПЗ));
			scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_3_2], locsInCell[LocsInCell.Center], FootballPosition.ЦОП));
			scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_2_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛП));
			scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_2_1], locsInCell[LocsInCell.Center], FootballPosition.ЛЦП));
			scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_2_3], locsInCell[LocsInCell.Center], FootballPosition.ПЦП));
			scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_2_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПП));
			scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_2], locsInCell[LocsInCell.Bottom], FootballPosition.ФРВ));

			_schemes.Add(FootballScheme.S4_1_4_1, scheme);
		}

		void Scheme4_2_2_2(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("4-2-2-2");

			scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЗ));
			scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛЦЗ));
			scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПЦЗ));
			scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПЗ));
			scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_3_1], locsInCell[LocsInCell.Center], FootballPosition.ЛОП));
			scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_3_3], locsInCell[LocsInCell.Center], FootballPosition.ПОП));
			scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_1_0], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛАП));
			scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_1_4], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПАП));
			scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_0_1], locsInCell[LocsInCell.Center], FootballPosition.ЛФД));
			scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_3], locsInCell[LocsInCell.Center], FootballPosition.ПФД));

			_schemes.Add(FootballScheme.S4_2_2_2, scheme);
		}

		void Scheme4_2_3_1Narrow(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("4-2-3 Narrow");

			scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЗ));
			scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛЦЗ));
			scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПЦЗ));
			scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПЗ));
			scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_3_1], locsInCell[LocsInCell.Center], FootballPosition.ЛОП));
			scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_3_3], locsInCell[LocsInCell.Center], FootballPosition.ПОП));
			scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_1_0], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛАП));
			scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_1_2], locsInCell[LocsInCell.Center], FootballPosition.ЦАП));
			scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_1_4], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПАП));
			scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_2], locsInCell[LocsInCell.Bottom], FootballPosition.ФРВ));

			_schemes.Add(FootballScheme.S4_2_3_1Narrow, scheme);
		}

		void Scheme4_2_3_1Wide(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("4-2-3 Wide");

			scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.Center], FootballPosition.ЛЗ));
			scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.Bottom], FootballPosition.ЛЦЗ));
			scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.Bottom], FootballPosition.ПЦЗ));
			scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.Center], FootballPosition.ПЗ));
			scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_3_1], locsInCell[LocsInCell.Center], FootballPosition.ЛОП));
			scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_3_3], locsInCell[LocsInCell.Center], FootballPosition.ПОП));
			scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_2_0], locsInCell[LocsInCell.Center], FootballPosition.ЛП));
			scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_2_4], locsInCell[LocsInCell.Center], FootballPosition.ПП));
			scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_1_2], locsInCell[LocsInCell.Bottom], FootballPosition.ЦАП));
			scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_2], locsInCell[LocsInCell.Center], FootballPosition.ФРВ));

			_schemes.Add(FootballScheme.S4_2_3_1Wide, scheme);
		}

		void Scheme4_2_4(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("4-2-4");

			scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЗ));
			scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛЦЗ));
			scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПЦЗ));
			scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПЗ));
			scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_2_1], locsInCell[LocsInCell.Center], FootballPosition.ЛЦП));
			scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_2_3], locsInCell[LocsInCell.Center], FootballPosition.ПЦП));
			scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_0_0], locsInCell[LocsInCell.Bottom], FootballPosition.ЛФА));
			scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_0_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛФД));
			scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_0_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПФД));
			scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_4], locsInCell[LocsInCell.Bottom], FootballPosition.ПФА));

			_schemes.Add(FootballScheme.S4_2_4, scheme);
		}

		void Scheme4_3_1_2(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("4-3-1-2");

			scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЗ));
			scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛЦЗ));
			scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПЦЗ));
			scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПЗ));
			scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_2_1], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЦП));
			scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_2_2], locsInCell[LocsInCell.Center], FootballPosition.ЦП));
			scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_2_3], locsInCell[LocsInCell.TopRight], FootballPosition.ПЦП));
			scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_1_2], locsInCell[LocsInCell.Center], FootballPosition.ЦАП));
			scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_0_1], locsInCell[LocsInCell.Bottom], FootballPosition.ЛФД));
			scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_3], locsInCell[LocsInCell.Bottom], FootballPosition.ПФД));

			_schemes.Add(FootballScheme.S4_3_1_2, scheme);
		}

		void Scheme4_3_2_1(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("4-3-2-1");

			scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЗ));
			scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛЦЗ));
			scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПЦЗ));
			scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПЗ));
			scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_2_1], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЦП));
			scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_2_2], locsInCell[LocsInCell.Center], FootballPosition.ЦП));
			scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_2_3], locsInCell[LocsInCell.TopRight], FootballPosition.ПЦП));
			scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_1_1], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛФД));
			scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_1_3], locsInCell[LocsInCell.TopRight], FootballPosition.ПФД));
			scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_2], locsInCell[LocsInCell.Bottom], FootballPosition.ФРВ));

			_schemes.Add(FootballScheme.S4_3_2_1, scheme);
		}

		void Scheme4_3_3Attack(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("4-3-3 Attack");

			scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЗ));
			scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛЦЗ));
			scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПЦЗ));
			scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПЗ));
			scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_2_1], locsInCell[LocsInCell.Center], FootballPosition.ЛЦП));
			scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_1_2], locsInCell[LocsInCell.Center], FootballPosition.ЦАП));
			scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_2_3], locsInCell[LocsInCell.Center], FootballPosition.ПЦП));
			scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_0_0], locsInCell[LocsInCell.BottomRight], FootballPosition.ЛФА));
			scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_0_2], locsInCell[LocsInCell.Center], FootballPosition.ФРВ));
			scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_4], locsInCell[LocsInCell.BottomLeft], FootballPosition.ПФА));

			_schemes.Add(FootballScheme.S4_3_3Attack, scheme);
		}

		void Scheme4_3_3Line(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("4-3-3 Line");

			scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЗ));
			scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛЦЗ));
			scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПЦЗ));
			scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПЗ));
			scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_2_1], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЦП));
			scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_2_2], locsInCell[LocsInCell.Center], FootballPosition.ЦП));
			scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_2_3], locsInCell[LocsInCell.TopRight], FootballPosition.ПЦП));
			scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_0_0], locsInCell[LocsInCell.BottomRight], FootballPosition.ЛФА));
			scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_0_2], locsInCell[LocsInCell.Center], FootballPosition.ФРВ));
			scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_4], locsInCell[LocsInCell.BottomLeft], FootballPosition.ПФА));

			_schemes.Add(FootballScheme.S4_3_3Line, scheme);
		}

		void Scheme4_3_3Defence(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("4-3-3 Defence");

			scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЗ));
			scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛЦЗ));
			scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПЦЗ));
			scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПЗ));
			scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_3_1], locsInCell[LocsInCell.Center], FootballPosition.ЛОП));
			scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_2_2], locsInCell[LocsInCell.Top], FootballPosition.ЦП));
			scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_3_3], locsInCell[LocsInCell.Center], FootballPosition.ПОП));
			scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_0_0], locsInCell[LocsInCell.BottomRight], FootballPosition.ЛФА));
			scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_0_2], locsInCell[LocsInCell.Center], FootballPosition.ФРВ));
			scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_4], locsInCell[LocsInCell.BottomLeft], FootballPosition.ПФА));

			_schemes.Add(FootballScheme.S4_3_3Defence, scheme);
		}

		void Scheme4_3_3False9(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("4-3-3 False 9");

			scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЗ));
			scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛЦЗ));
			scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПЦЗ));
			scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПЗ));
			scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_2_1], locsInCell[LocsInCell.Top], FootballPosition.ЛЦП));
			scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_3_2], locsInCell[LocsInCell.Center], FootballPosition.ЦОП));
			scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_2_3], locsInCell[LocsInCell.Top], FootballPosition.ПЦП));
			scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_0_0], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛФА));
			scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_1_2], locsInCell[LocsInCell.Top], FootballPosition.ЦФД));
			scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_4], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПФА));

			_schemes.Add(FootballScheme.S4_3_3False9, scheme);
		}

		void Scheme4_3_3Retention(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("4-3-3 Retention");

			scheme.AddLocation( new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation( new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЗ));
			scheme.AddLocation( new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛЦЗ));
			scheme.AddLocation( new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПЦЗ));
			scheme.AddLocation( new LocationPosition(5, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПЗ));
			scheme.AddLocation( new LocationPosition(6, locCells[LocCell.LC_2_1], locsInCell[LocsInCell.CenterLeft], FootballPosition.ЛЦП));
			scheme.AddLocation( new LocationPosition(7, locCells[LocCell.LC_3_2], locsInCell[LocsInCell.Top], FootballPosition.ЦОП));
			scheme.AddLocation( new LocationPosition(8, locCells[LocCell.LC_2_3], locsInCell[LocsInCell.CenterRight], FootballPosition.ПЦП));
			scheme.AddLocation( new LocationPosition(9, locCells[LocCell.LC_0_0], locsInCell[LocsInCell.Bottom], FootballPosition.ЛФА));
			scheme.AddLocation( new LocationPosition(10, locCells[LocCell.LC_0_2], locsInCell[LocsInCell.Center], FootballPosition.ФРВ));
			scheme.AddLocation( new LocationPosition(11, locCells[LocCell.LC_0_4], locsInCell[LocsInCell.Bottom], FootballPosition.ПФА));

			_schemes.Add(FootballScheme.S4_3_3Retention, scheme);
		}

		void Scheme4_4_1_1Attack(LocCellToFieldList locCells, LocInCellList locsInCell)
		{
			Scheme scheme = new Scheme("4-4-1-1 Attack");

			scheme.AddLocation( new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
			scheme.AddLocation( new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЗ));
			scheme.AddLocation( new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛЦЗ));
			scheme.AddLocation( new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПЦЗ));
			scheme.AddLocation( new LocationPosition(5, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПЗ));
			scheme.AddLocation( new LocationPosition(6, locCells[LocCell.LC_2_0], locsInCell[LocsInCell.Top], FootballPosition.ЛП));
			scheme.AddLocation( new LocationPosition(7, locCells[LocCell.LC_2_1], locsInCell[LocsInCell.Center], FootballPosition.ЛЦП));
			scheme.AddLocation( new LocationPosition(8, locCells[LocCell.LC_2_3], locsInCell[LocsInCell.Center], FootballPosition.ПЦП));
			scheme.AddLocation( new LocationPosition(9, locCells[LocCell.LC_2_4], locsInCell[LocsInCell.Top], FootballPosition.ПП));
			scheme.AddLocation( new LocationPosition(10, locCells[LocCell.LC_1_2], locsInCell[LocsInCell.Top], FootballPosition.ЦФД));
			scheme.AddLocation( new LocationPosition(11, locCells[LocCell.LC_0_2], locsInCell[LocsInCell.Center], FootballPosition.ФРВ));

			_schemes.Add(FootballScheme.S4_4_1_1Attack, scheme);
		}

        void Scheme4_4_1_1Halfbacks(LocCellToFieldList locCells, LocInCellList locsInCell)
        {
            Scheme scheme = new Scheme("4-4-1-1 Halfbacks");

            scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
            scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЗ));
            scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛЦЗ));
            scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПЦЗ));
            scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПЗ));
            scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_2_0], locsInCell[LocsInCell.Top], FootballPosition.ЛП));
            scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_2_1], locsInCell[LocsInCell.Center], FootballPosition.ЛЦП));
            scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_2_3], locsInCell[LocsInCell.Center], FootballPosition.ПЦП));
            scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_2_4], locsInCell[LocsInCell.Top], FootballPosition.ПП));
            scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_1_2], locsInCell[LocsInCell.Center], FootballPosition.ЦАП));
            scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_2], locsInCell[LocsInCell.Center], FootballPosition.ФРВ));

            _schemes.Add(FootballScheme.S4_4_1_1Halfbacks, scheme);
        }

        void Scheme4_4_2Line(LocCellToFieldList locCells, LocInCellList locsInCell)
        {
            Scheme scheme = new Scheme("4-4-2 Line");

            scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
            scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЗ));
            scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛЦЗ));
            scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПЦЗ));
            scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПЗ));
            scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_2_0], locsInCell[LocsInCell.Top], FootballPosition.ЛП));
            scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_2_1], locsInCell[LocsInCell.Center], FootballPosition.ЛЦП));
            scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_2_3], locsInCell[LocsInCell.Center], FootballPosition.ПЦП));
            scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_2_4], locsInCell[LocsInCell.Top], FootballPosition.ПП));
            scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_0_1], locsInCell[LocsInCell.Bottom], FootballPosition.ЛФД));
            scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_3], locsInCell[LocsInCell.Bottom], FootballPosition.ПФД));

            _schemes.Add(FootballScheme.S4_4_2Line, scheme);
        }

        void Scheme4_4_2Retention(LocCellToFieldList locCells, LocInCellList locsInCell)
        {
            Scheme scheme = new Scheme("4-4-2 Retention");

            scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
            scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЗ));
            scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛЦЗ));
            scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПЦЗ));
            scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПЗ));
            scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_2_0], locsInCell[LocsInCell.Center], FootballPosition.ЛП));
            scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_3_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛОП));
            scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_3_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПОП));
            scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_2_4], locsInCell[LocsInCell.Center], FootballPosition.ПП));
            scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_0_1], locsInCell[LocsInCell.Bottom], FootballPosition.ЛФД));
            scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_3], locsInCell[LocsInCell.Bottom], FootballPosition.ПФД));

            _schemes.Add(FootballScheme.S4_4_2Retention, scheme);
        }

        void Scheme4_5_1Attack(LocCellToFieldList locCells, LocInCellList locsInCell)
        {
            Scheme scheme = new Scheme("4-5-1 Attack");

            scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
            scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЗ));
            scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛЦЗ));
            scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПЦЗ));
            scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПЗ));
            scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_2_0], locsInCell[LocsInCell.Bottom], FootballPosition.ЛП));
            scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_1_1], locsInCell[LocsInCell.CenterLeft], FootballPosition.ЛАП));
            scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_3_2], locsInCell[LocsInCell.Top], FootballPosition.ЦП));
            scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_1_3], locsInCell[LocsInCell.CenterRight], FootballPosition.ПАП));
            scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_2_4], locsInCell[LocsInCell.Bottom], FootballPosition.ПП));
            scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_2], locsInCell[LocsInCell.Bottom], FootballPosition.ФРВ));

            _schemes.Add(FootballScheme.S4_5_1Attack, scheme);
        }

        void Scheme4_5_1Line(LocCellToFieldList locCells, LocInCellList locsInCell)
        {
            Scheme scheme = new Scheme("4-5-1 Line");

            scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
            scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЗ));
            scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.CenterRight], FootballPosition.ЛЦЗ));
            scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.CenterLeft], FootballPosition.ПЦЗ));
            scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.TopRight], FootballPosition.ПЗ));
            scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_1_0], locsInCell[LocsInCell.Bottom], FootballPosition.ЛП));
            scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_2_1], locsInCell[LocsInCell.CenterLeft], FootballPosition.ЛЦП));
            scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_3_2], locsInCell[LocsInCell.Top], FootballPosition.ЦП));
            scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_2_3], locsInCell[LocsInCell.CenterRight], FootballPosition.ПЦП));
            scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_1_4], locsInCell[LocsInCell.Bottom], FootballPosition.ПП));
            scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_2], locsInCell[LocsInCell.Center], FootballPosition.ФРВ));

            _schemes.Add(FootballScheme.S4_5_1Line, scheme);
        }

        void Scheme5_2_1_2(LocCellToFieldList locCells, LocInCellList locsInCell)
        {
            Scheme scheme = new Scheme("5-2-1-2");

            scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
            scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.Top], FootballPosition.ЛФЗ));
            scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.BottomLeft], FootballPosition.ЛЦЗ));
            scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_2], locsInCell[LocsInCell.Center], FootballPosition.ЦЗ));
            scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.BottomRight], FootballPosition.ПЦЗ));
            scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.Top], FootballPosition.ПФЗ));
            scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_2_1], locsInCell[LocsInCell.Center], FootballPosition.ЛЦП));
            scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_2_3], locsInCell[LocsInCell.Center], FootballPosition.ПЦП));
            scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_1_2], locsInCell[LocsInCell.Center], FootballPosition.ЦАП));
            scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_0_1], locsInCell[LocsInCell.Bottom], FootballPosition.ЛФД));
            scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_3], locsInCell[LocsInCell.Bottom], FootballPosition.ПФД));

            _schemes.Add(FootballScheme.S5_2_1_2, scheme);
        }

        void Scheme5_3_2(LocCellToFieldList locCells, LocInCellList locsInCell)
        {
            Scheme scheme = new Scheme("5-3-2");

            scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
            scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.Top], FootballPosition.ЛФЗ));
            scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.BottomLeft], FootballPosition.ЛЦЗ));
            scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_2], locsInCell[LocsInCell.Center], FootballPosition.ЦЗ));
            scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.BottomRight], FootballPosition.ПЦЗ));
            scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.Top], FootballPosition.ПФЗ));
            scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_2_1], locsInCell[LocsInCell.TopLeft], FootballPosition.ЛЦП));
            scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_2_2], locsInCell[LocsInCell.Center], FootballPosition.ЦП));
            scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_2_3], locsInCell[LocsInCell.TopRight], FootballPosition.ПЦП));
            scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_0_1], locsInCell[LocsInCell.Bottom], FootballPosition.ЛФД));
            scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_3], locsInCell[LocsInCell.Bottom], FootballPosition.ПФД));

            _schemes.Add(FootballScheme.S5_3_2, scheme);
        }

        void Scheme5_4_1Line(LocCellToFieldList locCells, LocInCellList locsInCell)
        {
            Scheme scheme = new Scheme("5-4-1 Line");

            scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
            scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.Top], FootballPosition.ЛФЗ));
            scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.BottomLeft], FootballPosition.ЛЦЗ));
            scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_2], locsInCell[LocsInCell.Center], FootballPosition.ЦЗ));
            scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.BottomRight], FootballPosition.ПЦЗ));
            scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.Top], FootballPosition.ПФЗ));
            scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_1_0], locsInCell[LocsInCell.Bottom], FootballPosition.ЛП));
            scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_2_1], locsInCell[LocsInCell.Center], FootballPosition.ЛЦП));
            scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_2_3], locsInCell[LocsInCell.Center], FootballPosition.ПЦП));
            scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_1_4], locsInCell[LocsInCell.Bottom], FootballPosition.ПП));
            scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_2], locsInCell[LocsInCell.Center], FootballPosition.ФРВ));

            _schemes.Add(FootballScheme.S5_4_1Line, scheme);
        }

        void Scheme5_4_1Romb(LocCellToFieldList locCells, LocInCellList locsInCell)
        {
            Scheme scheme = new Scheme("5-4-1 Romb");

            scheme.AddLocation(new LocationPosition(1, locCells[LocCell.LC_5_2], locsInCell[LocsInCell.Center], FootballPosition.ВРТ));
            scheme.AddLocation(new LocationPosition(2, locCells[LocCell.LC_4_0], locsInCell[LocsInCell.Top], FootballPosition.ЛФЗ));
            scheme.AddLocation(new LocationPosition(3, locCells[LocCell.LC_4_1], locsInCell[LocsInCell.BottomLeft], FootballPosition.ЛЦЗ));
            scheme.AddLocation(new LocationPosition(4, locCells[LocCell.LC_4_2], locsInCell[LocsInCell.Center], FootballPosition.ЦЗ));
            scheme.AddLocation(new LocationPosition(5, locCells[LocCell.LC_4_3], locsInCell[LocsInCell.BottomRight], FootballPosition.ПЦЗ));
            scheme.AddLocation(new LocationPosition(6, locCells[LocCell.LC_4_4], locsInCell[LocsInCell.Top], FootballPosition.ПФЗ));
            scheme.AddLocation(new LocationPosition(7, locCells[LocCell.LC_2_0], locsInCell[LocsInCell.Top], FootballPosition.ЛП));
            scheme.AddLocation(new LocationPosition(8, locCells[LocCell.LC_3_2], locsInCell[LocsInCell.Center], FootballPosition.ЦОП));
            scheme.AddLocation(new LocationPosition(9, locCells[LocCell.LC_1_2], locsInCell[LocsInCell.Center], FootballPosition.ЦАП));
            scheme.AddLocation(new LocationPosition(10, locCells[LocCell.LC_2_4], locsInCell[LocsInCell.Top], FootballPosition.ПП));
            scheme.AddLocation(new LocationPosition(11, locCells[LocCell.LC_0_2], locsInCell[LocsInCell.Center], FootballPosition.ФРВ));

            _schemes.Add(FootballScheme.S5_4_1Romb, scheme);
        }
        #endregion Schemes
        #endregion Methods
    }
}
