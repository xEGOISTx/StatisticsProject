using BaseObjects;
using Football;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Player
{
	/// <summary>
	/// Класс футболист
	/// </summary>
	[Serializable]
	public class FootballPlayer : BasicPlayer , IFootballPlayer
	{
		#region Constructors
		/// <summary>
		/// Инициализация футболиста
		/// </summary>
		public FootballPlayer()
		{
			FillPlayerParameterList();
		}
		#endregion Constructors



		#region Properties
		/// <summary>
		/// Базовая позиция футболиста
		/// </summary>
		public FootballPosition BasicPlayPosition { get; set; }

		/// <summary>
		/// Текущая позиция футболиста
		/// </summary>
		public FootballPosition CurrentPlayPosition { get; set; }
		#endregion Properties



		#region Methods
		/// <summary>
		/// Возвращает копию
		/// </summary>
		/// <returns></returns>
		public IFootballPlayer GetCopy()
		{
			FootballPlayer FP = new FootballPlayer();

			FP.BasicPlayPosition = BasicPlayPosition;
			FP.BasicPlayPositionEff = BasicPlayPositionEff;
			FP.CountGames = CountGames;
			FP.CurrentPlayPosition = CurrentPlayPosition;
            FP.CurrentPlayPositionEff = CurrentPlayPositionEff;
			FP.ID = ID;
			FP.IsActive = IsActive;
			FP.KeyName = KeyName;
			FP.Name = Name;
			FP.ParameterPlayerList = GetCopyParameters();
			FP.PlayBox = PlayBox;
			FP.Rating = Rating;

			return FP;
		}

		/// <summary>
		/// Заполнить список параметров футболиста
		/// </summary>
		/// <returns></returns>
		private void FillPlayerParameterList()
		{			
			ParameterPlayer ballControl = new ParameterPlayer {  NameParameter = "Контроль мяча" };
			ballControl.SubParameterList.Add(new SubParameterPlayer { Name = "Владение мячом" });
            ballControl.SubParameterList.Add(new SubParameterPlayer { Name = "Выносы", IsNotBlockedFailed = false });
			ParameterPlayerList.Add(ballControl);


			ParameterPlayer topGame = new ParameterPlayer { NameParameter = "Игра головой" };
			topGame.SubParameterList.Add(new SubParameterPlayer { Name = "Удары головой" });
			ParameterPlayerList.Add(topGame);


			ParameterPlayer dribbling = new ParameterPlayer { NameParameter = "Дриблинг" };
			dribbling.SubParameterList.Add(new SubParameterPlayer { Name = "Ключ. обводки", IsNotBlockedFailed = false });
			dribbling.SubParameterList.Add(new SubParameterPlayer { Name = "Заработанные нарушения", IsNotBlockedFailed = false });
			dribbling.SubParameterList.Add(new SubParameterPlayer { Name = "Дриблинг 1 на 1", IsNotBlockedFailed = false });
			ParameterPlayerList.Add(dribbling);


			ParameterPlayer gollkiper = new ParameterPlayer { NameParameter = "Вратарь" };
			gollkiper.SubParameterList.Add(new SubParameterPlayer { Name = "Пропущ. голы" ,IsNotBlockedSuccessFully = false});
            gollkiper.SubParameterList.Add(new SubParameterPlayer { Name = "Сейвы", IsNotBlockedFailed = false });
			gollkiper.SubParameterList.Add(new SubParameterPlayer { Name = "Перехвач. навесы", IsNotBlockedFailed = false });
			gollkiper.SubParameterList.Add(new SubParameterPlayer { Name = "Снятые мячи" , IsNotBlockedFailed = false });
			ParameterPlayerList.Add(gollkiper);


			ParameterPlayer kicks = new ParameterPlayer { NameParameter = "Удары" };
			kicks.SubParameterList.Add(new SubParameterPlayer { Name = "Голы", IsNotBlockedFailed = false });
			kicks.SubParameterList.Add(new SubParameterPlayer { Name = "В створ" });
			ParameterPlayerList.Add(kicks);


			ParameterPlayer passes = new ParameterPlayer { NameParameter = "Передачи" };
			passes.SubParameterList.Add(new SubParameterPlayer { Name = "Голевые передачи", IsNotBlockedFailed = false });
			passes.SubParameterList.Add(new SubParameterPlayer { Name = "Пасы" });
			passes.SubParameterList.Add(new SubParameterPlayer { Name = "Важные передачи" , IsNotBlockedFailed = false });
			passes.SubParameterList.Add(new SubParameterPlayer { Name = "Навесы" });
			ParameterPlayerList.Add(passes);


			ParameterPlayer positionalPlay = new ParameterPlayer { NameParameter = "Позиционная игра" };
			positionalPlay.SubParameterList.Add(new SubParameterPlayer { Name = "Парехваты", IsNotBlockedFailed = false });
			positionalPlay.SubParameterList.Add(new SubParameterPlayer { Name = "Блоки", IsNotBlockedFailed = false });
			positionalPlay.SubParameterList.Add(new SubParameterPlayer { Name = "Выходы с позиции",IsNotBlockedSuccessFully = false });
			ParameterPlayerList.Add(positionalPlay);


			ParameterPlayer tackling = new ParameterPlayer { NameParameter = "Отбор" };
			tackling.SubParameterList.Add(new SubParameterPlayer { Name = "Отборы" });
			tackling.SubParameterList.Add(new SubParameterPlayer { Name = "Полученные нарушения", IsNotBlockedSuccessFully = false });
			tackling.SubParameterList.Add(new SubParameterPlayer { Name = "Полученные пенальти", IsNotBlockedSuccessFully = false });
			ParameterPlayerList.Add(tackling);

		}
		#endregion Methods
	}
}
