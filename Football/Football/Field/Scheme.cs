using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Football.Field
{
	/// <summary>
	/// Схема
	/// </summary>
	public class Scheme : IScheme
	{
		SortedList<int, LocationPosition> _locations = new SortedList<int, LocationPosition>(11);



		#region Constructors
		/// <summary>
		/// Инициализация схемы
		/// </summary>
		public Scheme(string nameScheme)
		{
			NameScheme = nameScheme;
		}
		#endregion Constructors



		#region Properties
		/// <summary>
		/// Названиие схемы
		/// </summary>
		public string NameScheme { get; internal set; }
		#endregion Properties



		#region Methods
		/// <summary>
		/// Получить расположение позиции
		/// </summary>
		/// <param name="numberObject"></param>
		/// <returns></returns>
		public ILocationPosition GetLocation(byte numberObject)
		{
			return _locations[numberObject];
		}

		/// <summary>
		/// Добавить расположение позиции
		/// </summary>
		/// <param name="numberObject"></param>
		/// <param name="location"></param>
		public void AddLocation(LocationPosition location)
		{
			_locations.Add(location.NumberLocation, location);
		}

		/// <summary>
		/// Возвращает перечислитель
		/// </summary>
		/// <returns></returns>
		public IEnumerator GetEnumerator()
		{
			return _locations.Values.GetEnumerator();
		}
		#endregion Methods
	}
}
