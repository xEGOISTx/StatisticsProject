using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseObjects;
using BaseObjects.BaseComponents;
using Football.Player;
using Football.Chart;

namespace Football
{
	/// <summary>
	/// Список футболистов
	/// </summary>
	public class FootballPlayerList : IFootballPlayerList
	{
		#region Fields
		SortedDictionary<string, IFootballPlayer> _playerList = new SortedDictionary<string, IFootballPlayer>();
		IFootballPalyerLoader _loader;
		IFootballPlayersListEditor _editor;
		#endregion Fields



		#region Constructors
		/// <summary>
		/// Инициализация списка футболистов
		/// </summary>
		public FootballPlayerList()
		{
			_loader = new FootballPalyerLoader();
			_editor = new FootballPlayersListEditor(this);
		}
		#endregion Constructors



		#region Properties
		/// <summary>
		/// Редактор списка
		/// </summary>
		public IFootballPlayersListEditor Editor
		{
			get { return _editor; }
		}

		/// <summary>
		/// Загрузчик
		/// </summary>
		public IFootballPalyerLoader Loader
		{
			get{ return _loader; }
		}


		/// <summary>
		/// Кол-во футболистов в списке
		/// </summary>
		public int Count
		{
			get{ return _playerList.Count; }
		}

		/// <summary>
		/// Кол-во активных футболистов в списке
		/// </summary>
		public int CountActivePlayers { get; internal set; }
		#endregion Properties



		#region Methods
		/// <summary>
		/// Возвращает перечислитель
		/// </summary>
		/// <returns></returns>
		public IEnumerator GetEnumerator()
		{
			return _playerList.Values.GetEnumerator();
		}

		/// <summary>
		/// Проверить наличие футболиста в списке по ключевому имени
		/// </summary>
		/// <param name="keyName"></param>
		/// <returns></returns>
		public bool Present(string keyName)
		{
			if(keyName != null)
			{
				if(_playerList.ContainsKey(keyName.ToLower().Trim()))
				{
					return true;
				}
			}
			else
			{
				throw new NullReferenceException();
			}

			return false;
		}

		/// <summary>
		/// Добавить футболиста в список
		/// </summary>
		/// <param name="player"></param>
		internal void Add(IFootballPlayer player)
		{
			if (!Present(player.KeyName))
			{
				_loader.SavePlayer(player);
				_playerList.Add(player.KeyName.ToLower().Trim(), player);
				CountActivePlayers++;	
				OnAddedPlayer(player.KeyName);
			}
			else
			{
				throw new ArgumentException("Элемент с такам ключевым именем уже существует");
			}
		}

		/// <summary>
		/// Удалить игрока
		/// </summary>
		/// <param name="player"></param>
		internal void Remove(IFootballPlayer player)
		{
			if(Present(player.KeyName))
			{
				_loader.DeletePlayer(player);
                ChartsDataLoader chartLoader = new ChartsDataLoader();
                chartLoader.RemoveDataForChart(player);
				_playerList.Remove(player.Name.ToLower());
			}
		}

		/// <summary>
		/// Загрузить футболистов в список
		/// </summary>
		public void LoadPlayers()
		{
			IFootballPlayer[] players = _loader.LoadPlayers();

			_playerList.Clear();

			foreach(IFootballPlayer player in players)
			{
				_playerList.Add(player.KeyName.ToLower().Trim(), player);
				if(player.IsActive)
				{
					CountActivePlayers++;
				}
			}
		}

		/// <summary>
		/// Возвращает футболиста по ключевому имени
		/// </summary>
		/// <param name="keyName"></param>
		/// <returns></returns>
		public IFootballPlayer this[string keyName]
		{
			get
			{
				if (Present(keyName))
				{
					return _playerList[keyName.ToLower()];
				}
				else
				{
					throw new KeyNotFoundException();
				}

			}
		}

		/// <summary>
		/// Возвращает копию списка
		/// </summary>
		/// <returns></returns>
		public IFootballPlayerList GetCopy()
		{
			FootballPlayerList listCopy = new FootballPlayerList();

			foreach(var pair in _playerList)
			{
				string keyName = pair.Key;
				IFootballPlayer player = pair.Value.GetCopy();

				listCopy._playerList.Add(keyName, player);
				listCopy.CountActivePlayers = listCopy.Count;
			}

			return listCopy;
		}

		/// <summary>
		/// Возврещает редактор игрока
		/// </summary>
		/// <returns></returns>
		public IPlayerEditor GetPlayerEditor()
		{
			return new PlayerEditor(this);
		}

		/// <summary>
		/// Оповестить подписчиков "добавлен новый футболист"
		/// </summary>
		/// <param name="keyNamePlayer"></param>
		private void OnAddedPlayer(string keyNamePlayer)
		{
			AddedPlayer?.Invoke(this, new AddedPlayerEventArgs(keyNamePlayer));
		}
		#endregion Methods



		#region Events
		/// <summary>
		/// Возникает при успешном добавлении нового футболиста в список
		/// </summary>
		public event AddedPlayerEventHandler AddedPlayer;
		#endregion Events
	}
}
