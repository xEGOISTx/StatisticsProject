using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballControls.ViewModels;
using FootballControls.ViewModels.Parameters;
using Football;
using Football.Field;
using System.Collections.ObjectModel;
using Football.Player;
using Football.Chart;
using FootballControls.ViewModels.Chart;

namespace FootballControls
{
	public class PlayersManager
	{
		#region Fields
		private bool _selectedParametersEditor;
		private IFootballPlayerList _players;
		private IPlayerEditor _playerEditor;
        private bool _selectedChart;
        private bool _selectedField;

        private PLayersViewModel _playersVM;
		private FieldViewModel _fieldVM;
		private AddPlayerViewModel _addPlayersVM;
		private ParametersEditorViewModel _parametersEditorVM;
        private ChartViewModel _chartVM;
		#endregion Fields


		public PlayersManager(IFootballPlayerList players, IFootballField field,IEfficiencyChart chart)
		{
			players.LoadPlayers();
			_players = players;
			_playerEditor = players.GetPlayerEditor();
			_playerEditor.AcceptChanges += _playerEditor_AcceptChanges;
			_players.AddedPlayer += Players_AddedPlayer;
			_addPlayersVM = new AddPlayerViewModel(players.Editor);
			_parametersEditorVM = new ParametersEditorViewModel(_playerEditor);
            _chartVM = new ChartViewModel(chart);

            _selectedField = true;
            DistributePlayers(players, field);
		}


		#region Properties
		/// <summary>
		/// ViewModel панели игроков
		/// </summary>
		public PLayersViewModel PlayersVM { get { return _playersVM; } }

		/// <summary>
		/// ViewModel панели добавления игроков
		/// </summary>
		public AddPlayerViewModel AddPlayersVM { get { return _addPlayersVM; } }

		/// <summary>
		/// ViewModel поля
		/// </summary>
		public FieldViewModel FieldVM { get { return _fieldVM; } }

        /// <summary>
        /// ViewModel графика эффективности
        /// </summary>
        public ChartViewModel ChartVM { get { return _chartVM; } }

		/// <summary>
		/// ViewModel редактора параметров
		/// </summary>
		public ParametersEditorViewModel ParametersEditorVM
		{
			get { return _parametersEditorVM; }
		}

        public bool SelectedField
        {
            get { return _selectedField; }
            set
            {
                _selectedField = value;

                if(value)
                {
                    MoveFieldersOnField();
                    if (_playersVM.ActivePlayersVM.SelectedPlayer != null)
                    {
                        _fieldVM.HighlightPositions();
                    }
                }
                else
                {
                    MoveAllPlayersFromField();
                    _fieldVM.ResetHighlight();
                    _fieldVM.SelectedBox = null;
                }
            }
        }

		/// <summary>
		/// Признак выбрана вкладка редактора параметров
		/// </summary>
		public bool SelectedParametersEditor
		{
			get { return _selectedParametersEditor; }
			set
			{
				_selectedParametersEditor = value;

				if(value)
				{
					if (_playersVM.SelectedTabPlayers == TabPlayers.Active & _playersVM.ActivePlayersVM.SelectedPlayer != null)
					{
						_parametersEditorVM.SetPlayer(_players[_playersVM.ActivePlayersVM.SelectedPlayer.KeyName]);
					}
					else if (_playersVM.SelectedTabPlayers == TabPlayers.NoActive & _playersVM.NoActivePlayersVM.SelectedPlayer != null)
					{
						_parametersEditorVM.SetPlayer(_players[_playersVM.NoActivePlayersVM.SelectedPlayer.KeyName]);
					}

                }
				else
				{
					_parametersEditorVM.Clear();
				}
			}
		}

        public bool SelectedChart
        {
            get { return _selectedChart; }
            set
            {
                _selectedChart = value;

                if (value)
                {
                    if (_playersVM.SelectedTabPlayers == TabPlayers.Active & _playersVM.SelectedActivePlayer != null)
                    {
                        _chartVM.SetPlayer(_players[_playersVM.SelectedActivePlayer.KeyName]);
                    }
                    else if (_playersVM.SelectedTabPlayers == TabPlayers.NoActive & _playersVM.SelectedNoActivePlayer != null)
                    {
                        _chartVM.SetPlayer(_players[_playersVM.SelectedNoActivePlayer.KeyName]);
                    }
                }
                else
                {
                    _chartVM.Clear();
                }
            }
        }
        #endregion Properties



        #region Methods
        /// <summary>
        /// Переместить всех игроков с поля на панель игроков без сброса текущей позиции
        /// </summary>
        public void MoveAllPlayersFromField()
        {
            List<PlayerViewModel> plVMs = _fieldVM.ClearBoxes();
            _playersVM.AddPlayersFromField(plVMs);
        }

        /// <summary>
        /// Переместить полевых игроков с панели игроков на их позиции если таковые там имеются
        /// </summary>
        public void MoveFieldersOnField()
        {
            List<PlayerViewModel> plVMs = _playersVM.FieldersRemove();
            _fieldVM.AddPlayers(plVMs);
        }

        /// <summary>
        /// Распределить игроков
        /// </summary>
        /// <param name="players"></param>
        /// <param name="field"></param>
        private void DistributePlayers(IFootballPlayerList players, IFootballField field)
		{
			ObservableCollection<PlayerViewModel> _activePlayers = new ObservableCollection<PlayerViewModel>();
			ObservableCollection<PlayerViewModel> _noActivePlayers = new ObservableCollection<PlayerViewModel>();
			ObservableCollection<PlayerViewModel> _playersInField = new ObservableCollection<PlayerViewModel>();

			foreach (IFootballPlayer player in players)
			{
				if (player.IsActive & player.PlayBox == 0)
				{
					PlayerViewModel playerVM = new PlayerViewModel(player, players.Editor, _playerEditor);
					_activePlayers.Add(playerVM);
				}
				else if(player.IsActive & player.PlayBox > 0)
				{
					PlayerViewModel playerVM = new PlayerViewModel(player, players.Editor, _playerEditor);
					_playersInField.Add(playerVM);
				}
				else if (!player.IsActive)
				{
					PlayerViewModel playerVM = new PlayerViewModel(player, players.Editor, _playerEditor);
					_noActivePlayers.Add(playerVM);
				}

			}

			_playersVM = new PLayersViewModel(_activePlayers, _noActivePlayers);
			_playersVM.PropertyChanged += PlayersVM_PropertyChanged;
            _playersVM.ActivePlayersVM.PropertyChanged += ActivePlayersVM_PropertyChanged;
            _playersVM.NoActivePlayersVM.PropertyChanged += NoActivePlayersVM_PropertyChanged;

			_fieldVM = new FieldViewModel(_playersInField, field);
			_fieldVM.BoxSelected += _fieldVM_BoxSelected;
			_fieldVM.PreRemovalPlayer += _fieldVM_PreRemovalPlayer;
		}

		/// <summary>
		/// Действия перед удалением игрока из бокса
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _fieldVM_PreRemovalPlayer(object sender, EventArgs e)
		{
			PlayerViewModel plVM = (sender as PlayBoxViewModel).WithdrawPlayer();
			_playersVM.ActivePlayersVM.AddPlayer(plVM);
		}

		/// <summary>
		/// Действия при выборе игрового бокса
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _fieldVM_BoxSelected(object sender, EventArgs e)
		{
			if (_playersVM.SelectedActivePlayer != null)
			{
				if (_fieldVM.SelectedBox.IsPlayerPresent)
				{
					PlayerViewModel playerFromField = _fieldVM.SelectedBox.WithdrawPlayer();
					PlayerViewModel selectedPlayer = _playersVM.ActivePlayersVM.WithdrawSelectedPlayer();
					_fieldVM.SetPLayer(selectedPlayer);
					_playersVM.AddPlayer(playerFromField);
				}
				else
				{
					PlayerViewModel selectedPlayer = _playersVM.ActivePlayersVM.WithdrawSelectedPlayer();
					_fieldVM.SetPLayer(selectedPlayer);
				}
			}
		}

		/// <summary>
		/// Отследить выбранную вкладку Players
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PlayersVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
            if(e.PropertyName == nameof(_playersVM.SelectedTabPlayers))
            {
                if (_playersVM.SelectedTabPlayers == TabPlayers.Active)
                {
                    PlayerViewModel pl = _playersVM.ActivePlayersVM.SelectedPlayer;
                    SetPlayerToSelectedModule(pl);
                }
                else
                {
                    PlayerViewModel pl = _playersVM.NoActivePlayersVM.SelectedPlayer;
                    SetPlayerToSelectedModule(pl);                 
                }
            }      	
		}

        /// <summary>
        /// Установить игрока в выбранный модуль(редактор или график)
        /// </summary>
        /// <param name="plVM"></param>
        private void SetPlayerToSelectedModule(PlayerViewModel plVM)
        {
            if (plVM != null)
            {
                if (SelectedParametersEditor)
                {
                    _parametersEditorVM.SetPlayer(_players[plVM.KeyName]);
                }
                else if (SelectedChart)
                {
                    _chartVM.SetPlayer(_players[plVM.KeyName]);
                }
            }
            else
            {
                if (SelectedParametersEditor)
                {
                    _parametersEditorVM.SetPlayer(null);
                }
                else if (SelectedChart)
                {
                    _chartVM.SetPlayer(null);
                }
            }
        }

        /// <summary>
        /// Действия при добавлении нового игрока
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Players_AddedPlayer(object sender, BaseObjects.BaseComponents.AddedPlayerEventArgs e)
		{
			IFootballPlayer pl = _players[e.KeyNamePLayer];
			PlayerViewModel plVM = new PlayerViewModel(pl, _players.Editor, _playerEditor);
			_playersVM.AddPlayer(plVM);
		}

        /// <summary>
        /// Отследить выбранного активного игрока
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActivePlayersVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            ActivePlayersViewModel playersVM = (sender as ActivePlayersViewModel);

            if (e.PropertyName == nameof(playersVM.SelectedPlayer))
            {
                if (SelectedField)
                {
                    if (playersVM.SelectedPlayer != null)
                    {
                        if (_fieldVM.SelectedBox == null)
                        {
                            _fieldVM.HighlightPositions();
                        }
                        else
                        {
                            PlayerViewModel playerFromField = _fieldVM.SelectedBox.WithdrawPlayer();
                            PlayerViewModel selectedPlayer = playersVM.WithdrawSelectedPlayer();
                            _fieldVM.SetPLayer(selectedPlayer);
                            playersVM.AddPlayer(playerFromField);
                        }
                    }
                    else
                    {
                        _fieldVM.ResetHighlight();
                    }
                }
                else
                {
                    SetPlayerToSelectedModule(playersVM.SelectedPlayer);
                }
            }
        }

        /// <summary>
        /// Отследить выбранного не активного игрока
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoActivePlayersVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            NoActivePlayersViewModel playersVM = (sender as NoActivePlayersViewModel);
            if(e.PropertyName == nameof(playersVM.SelectedPlayer))
            {
                SetPlayerToSelectedModule(playersVM.SelectedPlayer);
            }          
        }

        /// <summary>
        /// Действия при применение изменений в редакторе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _playerEditor_AcceptChanges(object sender, EventArgs e)
		{
			_playersVM.UpdatePlayersView();
		}
		#endregion Methods
	}
}
