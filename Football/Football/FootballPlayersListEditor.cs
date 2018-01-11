using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseObjects;
using Messages;
using Football.Player;

namespace Football
{
	/// <summary>
	/// Редактор списка футболистов
	/// </summary>
	public class FootballPlayersListEditor : IFootballPlayersListEditor
	{
		#region Fialds
		IFootballPlayerList _playerList;
		IFootballPalyerLoader _loader;
		ManagingMessages _managingMessages = new ManagingMessages();
		#endregion Fialds



		#region Constructors
		/// <summary>
		/// Инициализация редактора списка игроков
		/// </summary>
		/// <param name="playerList"></param>
		public FootballPlayersListEditor(IFootballPlayerList playerList)
		{
			_playerList = playerList;
			_loader = (_playerList as FootballPlayerList).Loader;
			
		}
		#endregion Constructors



		#region Methods
		/// <summary>
		/// Активировать/деактивировать игрока
		/// </summary>
		/// <param name="player"></param>
		public void ActivateDeactivatePlayer(IBasicPlayer player, bool value)
		{
			if((player as FootballPlayer).IsActive = false & value == true)
			{
				(_playerList as FootballPlayerList).CountActivePlayers++;
			}

			if ((player as FootballPlayer).IsActive = true & value == false)
			{
				(_playerList as FootballPlayerList).CountActivePlayers--;
			}

			(player as FootballPlayer).IsActive = value;

			_loader.SavePlayer(_playerList[player.KeyName]);
		}

		/// <summary>
		/// Добавить нового игрока в список
		/// </summary>
		/// <param name="name"></param>
		/// <param name="keyName"></param>
		/// <param name="basicPosition"></param>
		public void AddNewPlayer(string name, string keyName, FootballPosition basicPosition)
		{
			//тут проверка базовых значений
			if (CheckInputBasicData(name, keyName, basicPosition))
			{
				IFootballPlayer pl = new FootballPlayer { Name = name, KeyName = keyName, BasicPlayPosition = basicPosition, IsActive = true };
				(_playerList as FootballPlayerList).Add(pl);
			}
		}

		/// <summary>
		/// Полное удаление футболиста
		/// </summary>
		/// <param name="player"></param>
		public void DeletePlayer(IBasicPlayer player)
		{
			//_loader.DeletePlayer(_playerList[player.KeyName]);
			(_playerList as FootballPlayerList).Remove(_playerList[player.KeyName]);
		}

		/// <summary>
		/// Проверка ввода базовых данных игрока
		/// </summary>
		/// <returns></returns>
		private bool CheckInputBasicData(string name, string keyName, FootballPosition basicPosition)
		{
			bool error = false;

			//проверяем имя
			if (name == null || name.Trim() == "")
			{
				_managingMessages.NotCorrectName();
				error = true;
			}

			// проверяем корректность keyName
			if (keyName == null || keyName.Trim() == "")
			{
				_managingMessages.NotCorrectKeyName();
				error = true;
			}
			else
			{
				// проверяем на совпадение по keyName
				if (_playerList.Present(keyName))
				{
					_managingMessages.KeyNameExists(keyName);
					error = true;
				}


				for (byte i = 0; i < keyName.Trim().Length; i++)
				{
					if (!((keyName[i] >= 65 & keyName[i] <= 90) | (keyName[i] >= 97 & keyName[i] <= 122) | (keyName[i] >= 48 & keyName[i] <= 57)) & keyName[i] != '_')
					{
						_managingMessages.NotCorrectKeyName();
						error = true;
						break;
					}
				}
			}

			// проверяем наличие базовой позиции
			if (basicPosition == FootballPosition.Default)
			{
				_managingMessages.NoPosition();
				error = true;
			}

			//проверка максимума активных игроков
			if (_playerList.CountActivePlayers > 44)
			{
				_managingMessages.MaxActivePlayers();
				error = true;
			}


			if (_managingMessages.CheckMessages)
			{
				_managingMessages.ShowMessageNotification(TitleMessage.NotCorrectInput);
			}

			return (error) ? false : true;
		}
		#endregion Methods
	}
}
