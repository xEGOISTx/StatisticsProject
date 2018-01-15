using System;

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
