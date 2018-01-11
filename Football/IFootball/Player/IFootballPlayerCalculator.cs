using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Player
{
	/// <summary>
	/// Профиль игрока
	/// </summary>
	public enum PlayerProfile
	{
		Gollkiper,
		WingBack,
		CentralBack,
		Midfielder, //опроник
		HalfBack,
		AttackingMidfielder,
		Forward,
		Winger
	}

	public interface IFootballPlayerCalculator : BaseObjects.IBasicCalculator
	{
		/// <summary>
		/// Расчитать эффектавность игрока на позиции
		/// </summary>
		/// <param name="player"></param>
		/// <param name="position"></param>
		/// <returns></returns>
		byte CalculationEfiiciencyPosition(IFootballPlayer player, FootballPosition position);
	}
}
