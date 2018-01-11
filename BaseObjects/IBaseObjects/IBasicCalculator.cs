using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseObjects
{
	/// <summary>
	/// Интерфейс базового калькулятора
	/// </summary>
	public interface IBasicCalculator
	{
		/// <summary>
		/// Расчитать эффективность параметров игрока
		/// </summary>
		/// <param name="player"></param>
		void CalculationEfiiciencyParameters(IBasicPlayer player);

		/// <summary>
		/// Расчитать рейтинг игрока
		/// </summary>
		/// <param name="player"></param>
		/// <param name="newRating"></param>
		/// <returns></returns>
		float CalculationRating(IBasicPlayer player, float newRating);
	}
}
