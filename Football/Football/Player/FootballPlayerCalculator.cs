using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseObjects;

namespace Football.Player
{
	/// <summary>
	/// Калькулятор футболиста
	/// </summary>
	public class FootballPlayerCalculator : IFootballPlayerCalculator
	{
		SortedList<FootballPosition, PlayerProfile> _profiles;


		/// <summary>
		/// Инициализация калькулятора футболиста
		/// </summary>
		public FootballPlayerCalculator()
		{
			InitProfiles();
		}


		#region Properties
		//------------------------------удержание мяча
		/// <summary>
		/// Эффективность владения мячом в процентах
		/// </summary>
		IParameterPlayer BallControlEff { get; set; }
		/// <summary>
		/// Эффективность игры на втором этаже в процентах
		/// </summary>
		IParameterPlayer TopGameEff { get; set; }

		//----------------------------пермешение
		/// <summary>
		/// Эффективность перемещения с мячом в процентах
		/// </summary>
		IParameterPlayer DribblingEff { get; set; }

		//--------------------------гк
		/// <summary>
		/// Эффективность на позиции вратаря в процентах
		/// </summary>
		IParameterPlayer GollkiperEff { get; set; }

		//---------------------------удары
		/// <summary>
		/// Эффективность ударов по воротам в процентах
		/// </summary>
		IParameterPlayer KicksEff { get; set; }

		//-------------------------пасы
		/// <summary>
		/// Эффективность передач в процентах
		/// </summary>
		IParameterPlayer PassesEff { get; set; }

		//------------------------позиционная игра
		/// <summary>
		/// Эффективность позиционной игры в процентах
		/// </summary>
		IParameterPlayer PositionalPlayEff { get; set; }

		//-----------------------отборы
		/// <summary>
		/// Эффективность отбора мяча в процентах
		/// </summary>
		IParameterPlayer TacklingEff { get; set; }
		#endregion Properties


		#region Methods
		/// <summary>
		/// Расчитать эффектавность игрока на позиции
		/// </summary>
		/// <param name="player"></param>
		/// <param name="position"></param>
		/// <returns></returns>
		public byte CalculationEfiiciencyPosition(IFootballPlayer player, FootballPosition position)
		{
			IList<IParameterPlayer> playerStatsInfoList = player.ParameterPlayerList;

			IdentifyDataStatistics(playerStatsInfoList);

			PlayerProfile plProfile = IdentifyProfile(position);

			return (byte)ExecuteCalculatuon(plProfile);
		}

		/// <summary>
		/// Расчитать эффективность параметров игрока
		/// </summary>
		/// <param name="player"></param>
		public void CalculationEfiiciencyParameters(IBasicPlayer player)
		{
			IdentifyDataStatistics(player.ParameterPlayerList);
			CalculationBallControlEff();
			CalculationTopGameEff();
			CalculationDribblingEff();
			CalculationGollkiperEff();
			CalculationKicksEff();
			CalculationPassesEff();
			CalculationPositionalPlayEff();
			CalculationTacklingEff();
		}

		/// <summary>
		/// Расчитать рейтинг игрока
		/// </summary>
		/// <param name="player"></param>
		/// <param name="newRating"></param>
		/// <returns></returns>
		public float CalculationRating(IBasicPlayer player, float newRating)
		{
			float oldRating = player.Rating;
			int countGames = player.CountGames;

			float result;

			if (countGames > 0 & newRating > 0)
			{
				result = oldRating - (oldRating - newRating) / countGames;
			}
			else
			{
				result = oldRating;
			}
			return (result < 10) ? result : 10;
		}



		/// <summary>
		/// Инициализация профилей
		/// </summary>
		private void InitProfiles()
		{
			_profiles = new SortedList<FootballPosition, PlayerProfile>();

			_profiles.Add(FootballPosition.ВРТ, PlayerProfile.Gollkiper);

			_profiles.Add(FootballPosition.ЛЗ, PlayerProfile.WingBack);
			_profiles.Add(FootballPosition.ЛФЗ, PlayerProfile.WingBack);
			_profiles.Add(FootballPosition.ПФЗ, PlayerProfile.WingBack);
			_profiles.Add(FootballPosition.ПЗ, PlayerProfile.WingBack);

			_profiles.Add(FootballPosition.ЛЦЗ, PlayerProfile.CentralBack);
			_profiles.Add(FootballPosition.ЦЗ, PlayerProfile.CentralBack);
			_profiles.Add(FootballPosition.ПЦЗ, PlayerProfile.CentralBack);

			_profiles.Add(FootballPosition.ЛОП, PlayerProfile.Midfielder);
			_profiles.Add(FootballPosition.ЦОП, PlayerProfile.Midfielder);
			_profiles.Add(FootballPosition.ПОП, PlayerProfile.Midfielder);

			_profiles.Add(FootballPosition.ЛП, PlayerProfile.HalfBack);
			_profiles.Add(FootballPosition.ЛЦП, PlayerProfile.HalfBack);
			_profiles.Add(FootballPosition.ЦП, PlayerProfile.HalfBack);
			_profiles.Add(FootballPosition.ПЦП, PlayerProfile.HalfBack);
			_profiles.Add(FootballPosition.ПП, PlayerProfile.HalfBack);

			_profiles.Add(FootballPosition.ЛАП, PlayerProfile.AttackingMidfielder);
			_profiles.Add(FootballPosition.ЦАП, PlayerProfile.AttackingMidfielder);
			_profiles.Add(FootballPosition.ПАП, PlayerProfile.AttackingMidfielder);

			_profiles.Add(FootballPosition.ЛФА, PlayerProfile.Winger);
			_profiles.Add(FootballPosition.ПФА, PlayerProfile.Winger);

			_profiles.Add(FootballPosition.ЛФД, PlayerProfile.Forward);
			_profiles.Add(FootballPosition.ФРВ, PlayerProfile.Forward);
			_profiles.Add(FootballPosition.ЦФД, PlayerProfile.Forward);
			_profiles.Add(FootballPosition.ПФД, PlayerProfile.Forward);
		}

		/// <summary>
		/// Идентификация профиля
		/// </summary>
		/// <param name="position"></param>
		/// <returns></returns>
		private PlayerProfile IdentifyProfile(FootballPosition position)
		{
			return _profiles[position];
		}

		/// <summary>
		/// Определить показатели статистик игрока
		/// </summary>
		/// <param name="playerStatsInfoList"></param>
		private void IdentifyDataStatistics(IList<IParameterPlayer> playerStatsInfoList)
		{
			foreach (IParameterPlayer info in playerStatsInfoList)
			{
				switch (info.NameParameter)
				{
					case "Контроль мяча":
						{
							BallControlEff = info;
							break;
						}
					case "Игра головой":
						{
							TopGameEff = info;
							break;
						}
					case "Дриблинг":
						{
							DribblingEff = info;
							break;
						}
					case "Вратарь":
						{
							GollkiperEff = info;
							break;
						}
					case "Удары":
						{
							KicksEff = info;
							break;
						}
					case "Передачи":
						{
							PassesEff = info;
							break;
						}
					case "Позиционная игра":
						{
							PositionalPlayEff = info;
							break;
						}
					case "Отбор":
						{
							TacklingEff = info;
							break;
						}
				}
			}
		}

		/// <summary>
		/// Выполнить расчёт
		/// </summary>
		/// <param name="playerProfile"></param>
		/// <returns></returns>
		private float ExecuteCalculatuon(PlayerProfile playerProfile)
		{
			switch (playerProfile)
			{
				case PlayerProfile.Gollkiper:
					{
						return CalculationGollkiper();
					}
				case PlayerProfile.WingBack:
					{
						return CalculationWingBack();
					}
				case PlayerProfile.CentralBack:
					{
						return CalculationCentralBack();
					}
				case PlayerProfile.Midfielder:
					{
						return CalculationMildfielder();
					}
				case PlayerProfile.HalfBack:
					{
						return CalculationHalfBack();
					}
				case PlayerProfile.AttackingMidfielder:
					{
						return CalculationAttackingMidfielder();
					}
				case PlayerProfile.Forward:
					{
						return CalculationForward();
					}
				case PlayerProfile.Winger:
					{
						return CalculationWinger();
					}
				default:
					{
						return 0;
					}

			}
		}

		/// <summary>
		/// Возврвщает указанный процент от значения
		/// </summary>
		/// <param name="value"></param>
		/// <param name="percent"></param>
		/// <returns></returns>
		private float CalculatePercentageOfValue(float value, float percent)
		{
			float _percent = 100 - percent;
			return value - ((value / 100) * _percent);
		}

		/// <summary>
		/// Сумматор значений
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		private float GetSumValues(List<float> values)
		{
			float sum = 0;

			foreach (float value in values)
			{
				sum += value;
			}

			return sum;
		}

		/// <summary>
		/// Возвращает соотношение в процентах
		/// </summary>
		/// <param name="maxValue"></param>
		/// <param name="factValue"></param>
		/// <returns></returns>
		private float GetPercentEff(float maxValue, float factValue)
		{
			float value;

			if (maxValue > 0)
			{
				value = 100 / maxValue * factValue;
			}
			else
			{
				value = 0;
			}

			return (value < 100) ? value : 100;
		}


		#region CalculationProfiles
		/// <summary>
		/// Расчёт гк
		/// </summary>
		/// <returns></returns>
		float CalculationGollkiper()
		{
			List<float> values = new List<float>();

			values.Add(CalculatePercentageOfValue(GollkiperEff.ValueParameter, 85));
			values.Add(CalculatePercentageOfValue(TacklingEff.ValueParameter, 1));
			values.Add(CalculatePercentageOfValue(BallControlEff.ValueParameter, 1));
			values.Add(CalculatePercentageOfValue(PositionalPlayEff.ValueParameter, 1));
			values.Add(CalculatePercentageOfValue(PassesEff.ValueParameter, 10));
			//values.Add(CalculatePpercentageOfValue(TopGameEff, 5));
			values.Add(CalculatePercentageOfValue(DribblingEff.ValueParameter, 1));
			values.Add(CalculatePercentageOfValue(KicksEff.ValueParameter, 1));

			return GetSumValues(values);
		}

		/// <summary>
		/// Расчёт ценр. защитник
		/// </summary>
		/// <returns></returns>
		float CalculationCentralBack()
		{
			List<float> values = new List<float>();

			values.Add(CalculatePercentageOfValue(TacklingEff.ValueParameter, 20));
			values.Add(CalculatePercentageOfValue(BallControlEff.ValueParameter, 25));
			values.Add(CalculatePercentageOfValue(PositionalPlayEff.ValueParameter, 15));
			values.Add(CalculatePercentageOfValue(PassesEff.ValueParameter, 10));
			values.Add(CalculatePercentageOfValue(TopGameEff.ValueParameter, 20));
			values.Add(CalculatePercentageOfValue(DribblingEff.ValueParameter, 5));
			values.Add(CalculatePercentageOfValue(KicksEff.ValueParameter, 5));

			return GetSumValues(values);
		}

		/// <summary>
		/// Расчёт крайний защитник
		/// </summary>
		/// <returns></returns>
		float CalculationWingBack()
		{
			List<float> values = new List<float>();

			values.Add(CalculatePercentageOfValue(TacklingEff.ValueParameter, 20));
			values.Add(CalculatePercentageOfValue(BallControlEff.ValueParameter, 20));
			values.Add(CalculatePercentageOfValue(PositionalPlayEff.ValueParameter, 20));
			values.Add(CalculatePercentageOfValue(PassesEff.ValueParameter, 15));
			values.Add(CalculatePercentageOfValue(TopGameEff.ValueParameter, 5));
			values.Add(CalculatePercentageOfValue(DribblingEff.ValueParameter, 15));
			values.Add(CalculatePercentageOfValue(KicksEff.ValueParameter, 5));

			return GetSumValues(values);
		}

		/// <summary>
		/// Расчёт полузащитник опорник
		/// </summary>
		/// <returns></returns>
		float CalculationMildfielder()
		{
			List<float> values = new List<float>();

			values.Add(CalculatePercentageOfValue(TacklingEff.ValueParameter, 20));
			values.Add(CalculatePercentageOfValue(BallControlEff.ValueParameter, 10));
			values.Add(CalculatePercentageOfValue(PositionalPlayEff.ValueParameter, 20));
			values.Add(CalculatePercentageOfValue(PassesEff.ValueParameter, 20));
			values.Add(CalculatePercentageOfValue(TopGameEff.ValueParameter, 10));
			values.Add(CalculatePercentageOfValue(DribblingEff.ValueParameter, 10));
			values.Add(CalculatePercentageOfValue(KicksEff.ValueParameter, 10));

			return GetSumValues(values);
		}

		/// <summary>
		/// Расчёт полузащитник
		/// </summary>
		/// <returns></returns>
		float CalculationHalfBack()
		{
			List<float> values = new List<float>();

			values.Add(CalculatePercentageOfValue(TacklingEff.ValueParameter, 15));
			values.Add(CalculatePercentageOfValue(BallControlEff.ValueParameter, 15));
			values.Add(CalculatePercentageOfValue(PositionalPlayEff.ValueParameter, 20));
			values.Add(CalculatePercentageOfValue(PassesEff.ValueParameter, 20));
			values.Add(CalculatePercentageOfValue(TopGameEff.ValueParameter, 5));
			values.Add(CalculatePercentageOfValue(DribblingEff.ValueParameter, 10));
			values.Add(CalculatePercentageOfValue(KicksEff.ValueParameter, 15));

			return GetSumValues(values);
		}

		/// <summary>
		/// Расчёт полузащитник атакующий
		/// </summary>
		/// <returns></returns>
		float CalculationAttackingMidfielder()
		{
			List<float> values = new List<float>();

			values.Add(CalculatePercentageOfValue(TacklingEff.ValueParameter, 10));
			values.Add(CalculatePercentageOfValue(BallControlEff.ValueParameter, 10));
			values.Add(CalculatePercentageOfValue(PositionalPlayEff.ValueParameter, 15));
			values.Add(CalculatePercentageOfValue(PassesEff.ValueParameter, 30));
			values.Add(CalculatePercentageOfValue(TopGameEff.ValueParameter, 5));
			values.Add(CalculatePercentageOfValue(DribblingEff.ValueParameter, 15));
			values.Add(CalculatePercentageOfValue(KicksEff.ValueParameter, 15));

			return GetSumValues(values);
		}

		/// <summary>
		/// Расчёт форварда
		/// </summary>
		/// <returns></returns>
		float CalculationForward()
		{
			List<float> values = new List<float>();

			values.Add(CalculatePercentageOfValue(TacklingEff.ValueParameter, 5));
			values.Add(CalculatePercentageOfValue(BallControlEff.ValueParameter, 5));
			values.Add(CalculatePercentageOfValue(PositionalPlayEff.ValueParameter, 15));
			values.Add(CalculatePercentageOfValue(PassesEff.ValueParameter, 5));
			values.Add(CalculatePercentageOfValue(TopGameEff.ValueParameter, 15));
			values.Add(CalculatePercentageOfValue(DribblingEff.ValueParameter, 25));
			values.Add(CalculatePercentageOfValue(KicksEff.ValueParameter, 30));

			return GetSumValues(values);
		}

		/// <summary>
		/// Расчёт вингер
		/// </summary>
		/// <returns></returns>
		float CalculationWinger()
		{
			List<float> values = new List<float>();

			values.Add(CalculatePercentageOfValue(TacklingEff.ValueParameter, 5));
			values.Add(CalculatePercentageOfValue(BallControlEff.ValueParameter, 10));
			values.Add(CalculatePercentageOfValue(PositionalPlayEff.ValueParameter, 5));
			values.Add(CalculatePercentageOfValue(PassesEff.ValueParameter, 20));
			values.Add(CalculatePercentageOfValue(TopGameEff.ValueParameter, 5));
			values.Add(CalculatePercentageOfValue(DribblingEff.ValueParameter, 30));
			values.Add(CalculatePercentageOfValue(KicksEff.ValueParameter, 25));

			return GetSumValues(values);
		}
		#endregion CalculationProfiles



		#region CalculationStatsEff
		void CalculationBallControlEff()
		{
			ISubParameterPlayer possessionBall = BallControlEff.SubParameterList[0];
			ISubParameterPlayer clearance = BallControlEff.SubParameterList[1];

			float maxValue = possessionBall.Failed + possessionBall.SuccessFully;
			float factValue = (float)possessionBall.SuccessFully + (float)clearance.SuccessFully / 2;

			(BallControlEff as ParameterPlayer).ValueParameter = GetPercentEff(maxValue, factValue);
		}

		void CalculationTopGameEff()
		{
			ISubParameterPlayer topGame = TopGameEff.SubParameterList[0];

			float maxValue = topGame.Failed + topGame.SuccessFully;
			float factValue = topGame.SuccessFully;

			(TopGameEff as ParameterPlayer).ValueParameter = GetPercentEff(maxValue, factValue);
		}

		void CalculationDribblingEff()
		{
			ISubParameterPlayer ImportantDribbling = DribblingEff.SubParameterList[0];
			ISubParameterPlayer Foul = DribblingEff.SubParameterList[1];
			ISubParameterPlayer CompletedDribbling = DribblingEff.SubParameterList[2];

			float maxValue = (ImportantDribbling.SuccessFully * 2 + Foul.SuccessFully / 2) + CompletedDribbling.SuccessFully;
			float factValue = maxValue - BallControlEff.SubParameterList[0].Failed / 2;

            if(factValue < 0)
            {
                factValue = 0;
            }

			if (maxValue < factValue)
			{
				(DribblingEff as ParameterPlayer).ValueParameter = 0;
			}
			else
			{
				(DribblingEff as ParameterPlayer).ValueParameter = GetPercentEff(maxValue, factValue);
			}
		}

		void CalculationGollkiperEff()
		{
			ISubParameterPlayer missedGoals = GollkiperEff.SubParameterList[0];
			ISubParameterPlayer rescue = GollkiperEff.SubParameterList[1];
			ISubParameterPlayer interceptedCanopies = GollkiperEff.SubParameterList[2];
			ISubParameterPlayer shotBalls = GollkiperEff.SubParameterList[3];

            float maxValue = (interceptedCanopies.SuccessFully + shotBalls.SuccessFully) / 2 + missedGoals.Failed + rescue.SuccessFully;
			float factValue = (interceptedCanopies.SuccessFully + shotBalls.SuccessFully) / 2 + rescue.SuccessFully;

			(GollkiperEff as ParameterPlayer).ValueParameter = GetPercentEff(maxValue, factValue);
		}

		void CalculationKicksEff()
		{
			ISubParameterPlayer goals = KicksEff.SubParameterList[0];
			ISubParameterPlayer target = KicksEff.SubParameterList[1];

			float maxValue = target.SuccessFully + target.Failed;
			float factValue = (float)(goals.SuccessFully * 1.2) + (target.SuccessFully - goals.SuccessFully);

			if (factValue > 0)
			{
				(KicksEff as ParameterPlayer).ValueParameter = GetPercentEff(maxValue, factValue);
			}
			else
			{
				(KicksEff as ParameterPlayer).ValueParameter = 0;
			}
		}

		void CalculationPassesEff()
		{
			ISubParameterPlayer assistsPasses = PassesEff.SubParameterList[0];
			ISubParameterPlayer passes = PassesEff.SubParameterList[1];
			ISubParameterPlayer importantPasses = PassesEff.SubParameterList[2];
			ISubParameterPlayer canopies = PassesEff.SubParameterList[3];

			float maxValue = passes.SuccessFully + passes.Failed + canopies.SuccessFully + canopies.Failed;
			float factValue = (float)(assistsPasses.SuccessFully * 1.2 + importantPasses.SuccessFully * 1.1) +
				(passes.SuccessFully + canopies.SuccessFully - assistsPasses.SuccessFully - importantPasses.SuccessFully);

			(PassesEff as ParameterPlayer).ValueParameter = GetPercentEff(maxValue, factValue);
		}

		void CalculationPositionalPlayEff()
		{
			ISubParameterPlayer interceptions = PositionalPlayEff.SubParameterList[0];
			ISubParameterPlayer block = PositionalPlayEff.SubParameterList[1];
			ISubParameterPlayer IncorrectPosition = PositionalPlayEff.SubParameterList[2];

			float maxValue = interceptions.SuccessFully + block.SuccessFully;
			float factValue = maxValue - IncorrectPosition.Failed;

			if (factValue > 0)
			{
				(PositionalPlayEff as ParameterPlayer).ValueParameter = GetPercentEff(maxValue, factValue);
			}
			else
			{
				(PositionalPlayEff as ParameterPlayer).ValueParameter = 0;
			}
		}

		void CalculationTacklingEff()
		{
			ISubParameterPlayer tackling = TacklingEff.SubParameterList[0];
			ISubParameterPlayer foulTackling = TacklingEff.SubParameterList[1];
			ISubParameterPlayer penaltyFoul = TacklingEff.SubParameterList[2];

			float maxValue = tackling.SuccessFully + tackling.Failed;
			float factValue = maxValue - foulTackling.Failed - tackling.Failed - (float)(penaltyFoul.Failed * 1.2);

			if (factValue > 0)
			{
				(TacklingEff as ParameterPlayer).ValueParameter = GetPercentEff(maxValue, factValue);
			}
			else
			{
				(TacklingEff as ParameterPlayer).ValueParameter = 0;
			}
		}
		#endregion CalculationStatsEff
		#endregion Methods
	}
}
