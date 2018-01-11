using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Football.Player;

namespace Football.Field
{
	/// <summary>
	/// Расположение игровой позиции на поле
	/// </summary>
	public class LocationPosition : ILocationPosition
	{
		#region Fields
		ILocCellToField _locCell;
		ILocInCell _locInCell;
		FootballPosition _position;
		byte _numberLocation;
		#endregion Fields



		#region Constructors
		/// <summary>
		/// Инициализация расположения игровой позиции на поле
		/// </summary>
		/// <param name="column"></param>
		/// <param name="row"></param>
		/// <param name="vPos"></param>
		/// <param name="hPos"></param>
		/// <param name="playPos"></param>
		public LocationPosition(byte numberLocation, ILocCellToField locCell, ILocInCell locInCell, FootballPosition playPos)
		{
			_position = playPos;
			_numberLocation = numberLocation;
			_locCell = locCell;
			_locInCell = locInCell;

			//IdentifyLocCell(locCell);
			//IdentifyLocInCell(locInCell);
		}
		#endregion Constructors



		#region Properties
		/// <summary>
		/// Позиция
		/// </summary>
		public FootballPosition Position
		{
			get { return _position; }
		}


		/// <summary>
		/// Номер расположения
		/// </summary>
		public byte NumberLocation
		{
			get { return _numberLocation; }
		}

		/// <summary>
		/// Возврвращает расположение ячейки
		/// </summary>
		public ILocCellToField GetLocCell
		{
			get { return _locCell; }
		}

		/// <summary>
		/// Возвращает расположение в ячейке
		/// </summary>
		public ILocInCell GetLocInCell
		{
			get { return _locInCell; }
		}
		#endregion Properties



		#region Methods
		///// <summary>
		///// Идентификация расположения ячейки
		///// </summary>
		///// <param name="locCell"></param>
		//private void IdentifyLocCell(LocCell locCell)
		//{
		//	LocCellToFieldList locs = new LocCellToFieldList();
		//	_locCell = locs[locCell];
		//}

		///// <summary>
		///// Идентификация расположения в ячейке
		///// </summary>
		///// <param name="locInCell"></param>
		//private void IdentifyLocInCell(LocsInCell locInCell)
		//{
		//	LocInCellList locs = new LocInCellList();
		//	_locInCell = locs[locInCell];
		//}
		#endregion Methods
	}
}
