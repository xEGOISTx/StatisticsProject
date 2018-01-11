using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseObjects;
using BaseObjects.BaseComponents;
using Football;
using System.Windows;
using BasicInfirmationProject;

namespace Football.Player
{
	public class PlayerEditor : IPlayerEditor
	{
		#region Fields
		private FootballPlayerList _players;
		private FootballPlayer _player;
		private FootballPlayer _editablePlayer;
		private SortedDictionary<string, FootballPlayer> _editedPlayers = new SortedDictionary<string, FootballPlayer>();
		private IFootballPalyerLoader _loader;
		#endregion Fields



		#region Constructors
		public PlayerEditor(FootballPlayerList players)
		{
            //Проверка временная для костыля переименовывания параметров
            if (players != null)
            {
                _players = players;
                _loader = players.Loader;
            }

		}
		#endregion Constructors



		#region Properties
		/// <summary>
		/// Признак налиция игрока в редакторе
		/// </summary>
		public bool IsPresentPlayer
		{
			get { return _player != null; }
		}

		public float CurrentRating
		{
			get{ return _player != null ? _player.Rating : 0; }
		}

		public float EditableRating
		{
			get { return _player != null ? _editablePlayer.Rating : 0; }
		}

		public ushort CurrentCountGames
		{
			get { return _player != null ? _player.CountGames : (ushort)0; }
		}

		public ushort EditableCountGames
		{
			get { return _player != null? _editablePlayer.CountGames : (ushort)0; }
		}

		public bool PresentChangedPlayers
		{
			get { return _editedPlayers.Count > 0; }
		}

        public FootballPosition CurrentBasicPosition
        {
            get { return _player != null ? _player.BasicPlayPosition : 0; }
        }

        public FootballPosition EditableBasicPosition
        {
            get { return _player != null ? _editablePlayer.BasicPlayPosition : 0; }
        }

        public string CurrentName
        {
            get { return _player != null ? _player.Name : string.Empty; }
        }

        public string EditableName
        {
            get { return _player != null ? _editablePlayer.Name : string.Empty; }
        }
        #endregion Properties



        #region Methods
        /// <summary>
        /// Очистить редактор. Удаляет игрока, а также очищает всё изменения всех изменённых игроков
        /// </summary>
        public void Clear()
		{
			_player = null;
			_editablePlayer = null;
			_editedPlayers.Clear();
		}

		/// <summary>
		/// Редактировать под параметер
		/// </summary>
		/// <param name="subParam"></param>
		/// <param name="successFully"></param>
		/// <param name="failed"></param>
		public void EditSubParameter(ref ISubParameterPlayer subParam, uint successFully, uint failed)
		{
			SubParameterPlayer sParam = (subParam as SubParameterPlayer);
			sParam.SuccessFully = successFully;
			sParam.Failed = failed;
			CheckChanges();
		}

		/// <summary>
		/// Редактировать рейтинг
		/// </summary>
		/// <param name="rating"></param>
		/// <param name="countGames"></param>
		public void EditRating(float rating,ushort countGames)
		{
			_editablePlayer.Rating = rating;
			_editablePlayer.CountGames = countGames;
			CheckChanges();
		}


        /// <summary>
        /// Редактировать имя и базовую позицию игрока
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="position"></param>
        public void EditBasicProperties(string playerName, FootballPosition position)
        {
            _editablePlayer.Name = playerName;
            _editablePlayer.BasicPlayPosition = position;
            CheckChanges();
        }

        /// <summary>
        /// Закончить редактирование
        /// </summary>
        /// <param name="acceptChange"></param>
        public void EndEditing(bool acceptChanged)
		{
			if (acceptChanged)
			{
				foreach (var pair in _editedPlayers)
				{
					IFootballPlayer editedPl = pair.Value;

					if (_players.Present(editedPl.KeyName))
					{
						IFootballPlayer pl = _players[editedPl.KeyName];

						FullPLayerEditing(editedPl, pl);						
						OnAcceptChanges();
					}
				}
				_editedPlayers.Clear();
				CreateEditableCopy();
			}
			else
			{
				_editedPlayers.Clear();
				CreateEditableCopy();
			}

		}

		/// <summary>
		/// Возвращает список параметров с текущими значениями
		/// </summary>
		/// <returns></returns>
		public IList<ISubParameterPlayer> GetCurrentParametersValuesList()
		{
			if (IsPresentPlayer)
			{
				List<ISubParameterPlayer> subPList = new List<ISubParameterPlayer>();

				foreach (IParameterPlayer param in _player.ParameterPlayerList)
				{
					foreach (ISubParameterPlayer subParam in param.SubParameterList)
					{
						subPList.Add(subParam);
					}
				}

				return subPList;
			}
			else
			{
				throw new NullReferenceException("Отсутствует игрок");
			}
		}

		/// <summary>
		/// Возврашает список параметров для редактирования
		/// </summary>
		/// <returns></returns>
		public IList<ISubParameterPlayer> GetListForEditParameters()
		{
			if (IsPresentPlayer)
			{
				List<ISubParameterPlayer> subPList = new List<ISubParameterPlayer>();

				foreach (IParameterPlayer param in _editablePlayer.ParameterPlayerList)
				{
					foreach (ISubParameterPlayer subParam in param.SubParameterList)
					{
						subPList.Add(subParam);
					}
				}
				return subPList;
			}
			else
			{
				throw new NullReferenceException("Отсутствует игрок");
			}
		}

		/// <summary>
		/// Установить игрока для редактирования
		/// </summary>
		/// <param name="player"></param>
		public void SetPlayer(IFootballPlayer player)
		{
			_player = (player as FootballPlayer);
			CreateEditableCopy();
		}

		/// <summary>
		/// Возвращает игрока находящегося в редакторе. Если игрока нет возвращает null
		/// </summary>
		/// <returns></returns>
		public IFootballPlayer GetPlayer()
		{
			return _player;
		}


		/// <summary>
		/// Установить текущую позицию
		/// </summary>
		/// <param name="player"></param>
		/// <param name="position"></param>
		public void EditCurrentPosition(IFootballPlayer player, FootballPosition position)
		{
			(player as FootballPlayer).CurrentPlayPosition = position;

			if(position != FootballPosition.Default)
			{
				//перерасчёт эффективности на текущей позиции
				FootballPlayerCalculator calculator = new FootballPlayerCalculator();
				(player as FootballPlayer).CurrentPlayPositionEff = calculator.CalculationEfiiciencyPosition(player, position);
			}

			_loader.SavePlayer(player);
		}

		/// <summary>
		/// Установить текущий номер расположения на поле
		/// </summary>
		/// <param name="player"></param>
		/// <param name="numberLocPos"></param>
		public void EditCurrentNumberLocPos(IFootballPlayer player, byte numberLocPos)
		{
			(player as FootballPlayer).PlayBox = numberLocPos;
			_loader.SavePlayer(player);
		}

		/// <summary>
		/// Удалить игрока из редактора
		/// </summary>
		public void RemovePlayer()
		{
			_player = null;
			_editablePlayer = null;
		}

        /// <summary>
        /// Костыль для переименовывания параметров. ПЕРЕДЕЛАТЬ!
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        internal IFootballPlayer UpdateParametersNames(IFootballPlayer player)
        {
            IList<IParameterPlayer> parameters = player.ParameterPlayerList;

            (parameters[2].SubParameterList[1] as SubParameterPlayer).Name = "Заработанные нарушения";
            (parameters[7].SubParameterList[1] as SubParameterPlayer).Name = "Полученные нарушения";

            return player;
        }

		/// <summary>
		/// Проверить изменения
		/// </summary>
		private void CheckChanges()
		{
			if (IsChanged())
			{
				if (!_editedPlayers.ContainsKey(_editablePlayer.KeyName))
				{
					_editedPlayers.Add(_editablePlayer.KeyName, _editablePlayer);
				}
			}
			else
			{
				if (_editedPlayers.ContainsKey(_editablePlayer.KeyName))
				{
					_editedPlayers.Remove(_editablePlayer.KeyName);
				}
			}
		}

		/// <summary>
		/// Признак изменения свойств игрока
		/// </summary>
		/// <returns></returns>
		private bool IsChanged()
		{

			if(_editablePlayer.Rating == 0 & _editablePlayer.CountGames == 0 & 
                _editablePlayer.BasicPlayPosition == _player.BasicPlayPosition & _editablePlayer.Name == _player.Name)
			{
				foreach (IParameterPlayer param in _editablePlayer.ParameterPlayerList)
				{
					foreach (ISubParameterPlayer subParam in param.SubParameterList)
					{
						if((subParam as SubParameterPlayer).Failed != 0 || (subParam as SubParameterPlayer).SuccessFully != 0)
						{
							return true;
						}					
					}
				}
			}
			else
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Полное редактирование игрока с сохранением
		/// </summary>
		/// <param name="editedPl"></param>
		/// <param name="pl"></param>
		private void FullPLayerEditing(IFootballPlayer editedPl, IFootballPlayer pl)
		{
			FootballPlayerCalculator calculator = new FootballPlayerCalculator();

			(pl as FootballPlayer).CountGames += editedPl.CountGames;
			(pl as FootballPlayer).Rating = calculator.CalculationRating(pl, editedPl.Rating);
            (pl as FootballPlayer).BasicPlayPosition = editedPl.BasicPlayPosition;
            (pl as FootballPlayer).Name = editedPl.Name;


            for (int i = 0; i < pl.ParameterPlayerList.Count; i++)
			{
				for (byte j = 0; j < pl.ParameterPlayerList[i].SubParameterList.Count; j++)
				{
					SubParameterPlayer subParamPL = (pl.ParameterPlayerList[i].SubParameterList[j] as SubParameterPlayer);
					ISubParameterPlayer subParamEditePl = editedPl.ParameterPlayerList[i].SubParameterList[j];

					subParamPL.Failed += subParamEditePl.Failed;
					subParamPL.SuccessFully += subParamEditePl.SuccessFully;
				}
			}

			calculator.CalculationEfiiciencyParameters(pl);
			(pl as FootballPlayer).BasicPlayPositionEff = calculator.CalculationEfiiciencyPosition(pl, pl.BasicPlayPosition);
			_players.Loader.SavePlayer(pl);
            SaveDataForChart(pl, calculator);

        }

		/// <summary>
		/// Создание копии для редактирования
		/// </summary>
		private  void CreateEditableCopy()
		{
			if (_editedPlayers.ContainsKey(_player.KeyName))
			{
				_editablePlayer = _editedPlayers[_player.KeyName];
			}
			else
			{
				_editablePlayer = (_player.GetCopy() as FootballPlayer);
				_editablePlayer.Rating = 0;
				_editablePlayer.CountGames = 0;

				foreach (IParameterPlayer param in _editablePlayer.ParameterPlayerList)
				{
					foreach (ISubParameterPlayer subParam in param.SubParameterList)
					{
						(subParam as SubParameterPlayer).Failed = 0;
						(subParam as SubParameterPlayer).SuccessFully = 0;
					}
				}
			}
		}

        /// <summary>
        /// Сохранить данные для графика
        /// </summary>
        /// <param name="player"></param>
        /// <param name="calculator"></param>
        private void SaveDataForChart(IFootballPlayer player, IFootballPlayerCalculator calculator)
        {
            Chart.ChartsDataLoader loader = new Chart.ChartsDataLoader();
            Chart.IDataPlayerForChart data = loader.LoadDataForChart(player);

            if (data == null)
            {
                data = new Chart.DataPlayerForChart(player.KeyName);
            }
            Dictionary<FootballPosition, byte> newData = new Dictionary<FootballPosition, byte>();

            foreach(FootballPosition fp in Enum.GetValues(typeof(FootballPosition)))
            {
                if(fp != FootballPosition.Default)
                {
                    byte posEff = calculator.CalculationEfiiciencyPosition(player, fp);
                    newData.Add(fp, posEff);
                }
            }

            data.AddData(newData);
            loader.SaveDataForChart(data);
        }

		private void OnAcceptChanges()
		{
			AcceptChanges?.Invoke(this, new EventArgs());
		}
		#endregion Methods



		#region Events
		/// <summary>
		/// Возникает при применении изменений
		/// </summary>
		public event AcceptChangesEventHandler AcceptChanges;
		#endregion Events

	}
}
