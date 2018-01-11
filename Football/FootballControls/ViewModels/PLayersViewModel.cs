using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football;
using System.Collections.ObjectModel;
using BaseObjects.BaseComponents;
using System.Windows.Input;
using System.Windows;
using Football.Player;

namespace FootballControls.ViewModels
{
    public enum TabPlayers
    {
        Active = 0,
        NoActive = 1
    }

    /// <summary>
    /// ViewModel футболистов
    /// </summary>
    public class PLayersViewModel : WPFHelper.BaseViewModel
	{
		#region Fields
		TabPlayers _selectedTabPlayers;

		//private PlayerViewModel _isSelectedPlayer;
		//private PlayerViewModel _isSelectedNoActivePlayer;
        private PlayerViewModel _tempSelectedActivePlayer;

		private ObservableCollection<PlayerViewModel> _activePlayers = new ObservableCollection<PlayerViewModel>();
		private ObservableCollection<PlayerViewModel> _noActivePlayers = new ObservableCollection<PlayerViewModel>();

        private ActivePlayersViewModel _activePlayersVM;
        private NoActivePlayersViewModel _noActivePlayersVM;
		#endregion Fields



		#region Constructors
		/// <summary>
		/// Инициализация ViewModel'и футбоистов
		/// </summary>
		/// <param name="playerList"></param>
		public PLayersViewModel(ObservableCollection<PlayerViewModel> activePlayers, ObservableCollection<PlayerViewModel> noActivePlayers)
		{
            _activePlayersVM = new ActivePlayersViewModel(activePlayers);
            _activePlayersVM.PropertyChanged += _activePlayersVM_PropertyChanged;

            _noActivePlayersVM = new NoActivePlayersViewModel(noActivePlayers);
            _noActivePlayersVM.PropertyChanged += _noActivePlayersVM_PropertyChanged;


            _activePlayers = activePlayers;
			_noActivePlayers = noActivePlayers;
            _selectedTabPlayers = TabPlayers.Active;

		}

        #endregion Constructors


        #region Properties
        public ActivePlayersViewModel ActivePlayersVM
        {
            get { return _activePlayersVM; }
        }

        public NoActivePlayersViewModel NoActivePlayersVM
        {
            get { return _noActivePlayersVM; }
        }

        /// <summary>
        /// Выбранный активный игрок
        /// </summary>
        public PlayerViewModel SelectedActivePlayer
		{
			get { return ActivePlayersVM.SelectedPlayer; }
			set
			{
				if(ActivePlayersVM.SelectedPlayer != value)
				{
                    ActivePlayersVM.SelectedPlayer = value;					
				}
			}
		}

		/// <summary>
		/// Выбранный неактивный игрок
		/// </summary>
		public PlayerViewModel SelectedNoActivePlayer
		{
			get { return _noActivePlayersVM.SelectedPlayer; }
			set
			{
				if(_noActivePlayersVM.SelectedPlayer != value)
				{
                    _noActivePlayersVM.SelectedPlayer = value;					
				}
			}
		}

		public TabPlayers SelectedTabPlayers
		{
			get { return _selectedTabPlayers; }
			set
			{
				if(_selectedTabPlayers != value)
				{
					_selectedTabPlayers = value;

                    if(value == TabPlayers.NoActive)
                    {
                        _tempSelectedActivePlayer = _activePlayersVM.SelectedPlayer;
                        _activePlayersVM.SelectedPlayer = null;
                    }
                    else
                    {
                        if(_tempSelectedActivePlayer != null)
                        {
                            _activePlayersVM.SelectedPlayer = _tempSelectedActivePlayer;
                            _tempSelectedActivePlayer = null;
                        }
                    }


					OnPropertyChanged(nameof(SelectedTabPlayers));
				}
			}
		}
		#endregion Properties



		#region Methods
		/// <summary>
		/// Добавить игрока
		/// </summary>
		/// <param name="player"></param>
		public void AddPlayer(PlayerViewModel player)
		{
            ActivePlayersVM.AddPlayer(player);
		}

		/// <summary>
		/// Добавить игроков с поля
		/// </summary>
		/// <param name="players"></param>
		public void AddPlayersFromField(List<PlayerViewModel> players)
		{
            ActivePlayersVM.AddPlayers(players);
		}

		/// <summary>
		/// Убрать полевых игроков. Возвращает список полевых игроков
		/// </summary>
		/// <returns></returns>
		public List<PlayerViewModel> FieldersRemove()
		{
			List<PlayerViewModel> playersInField = new List<PlayerViewModel>();

            foreach (PlayerViewModel plVM in ActivePlayersVM.Players)
            {
                if (plVM.CurrentPosition != FootballPosition.Default)
                {
                    playersInField.Add(plVM);
                }
            }

            foreach (PlayerViewModel plVM in playersInField)
            {
                ActivePlayersVM.Remove(plVM);
            }

            return playersInField;
		}

		/// <summary>
		/// Изъять выбранного игрока. Возвращает игрока
		/// </summary>
		/// <returns></returns>
		public PlayerViewModel WithdrawSelectedPlayer()
		{
			PlayerViewModel player = SelectedActivePlayer;
            ActivePlayersVM.Remove(SelectedActivePlayer);
            return player;
		}

		///// <summary>
		///// Сортировка по имени
		///// </summary>
		///// <param name="playerList"></param>
		//private void SortByName(ObservableCollection<PlayerViewModel> playerList)
		//{
		//	IEnumerable<PlayerViewModel> sotr = playerList.OrderBy(pl => pl.Name);
		//	List<PlayerViewModel> sortPlayers = new List<PlayerViewModel>(playerList.Count);

		//	foreach (PlayerViewModel pl in sotr)
		//	{
		//		sortPlayers.Add(pl);
		//	}

		//	playerList.Clear();
		//	foreach(PlayerViewModel pl in sortPlayers)
		//	{
		//		playerList.Add(pl);
		//	}
		//}

		public void UpdatePlayersView()
		{
            ActivePlayersVM.Update();
            NoActivePlayersVM.Update();
		}

        public void ResetSelected()
        {
            if(SelectedTabPlayers == TabPlayers.Active)
            {
                _activePlayersVM.SelectedPlayer = null;
                _tempSelectedActivePlayer = null;
            }
            else
            {
                _noActivePlayersVM.SelectedPlayer = null;
            }
        }

        private void _activePlayersVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ActivePlayersVM.SelectedPlayer))
            {
                OnPropertyChanged(nameof(SelectedActivePlayer));
            }

            if(e.PropertyName == nameof(ActivePlayersVM.DeactivatedPlayer))
            {
                PlayerViewModel pl = _activePlayersVM.WithdrawDeactivatedPlayer();
                pl.IsActive = false;
                pl.CurrentPosition = FootballPosition.Default;
                pl.CurrentLocNumber = 0;

                _noActivePlayersVM.AddPlayer(pl);
            }
        }

        private void _noActivePlayersVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_noActivePlayersVM.SelectedPlayer))
            {
                OnPropertyChanged(nameof(SelectedNoActivePlayer));
            }

            if(e.PropertyName == nameof(_noActivePlayersVM.ActivatedPlayer))
            {
                PlayerViewModel pl = _noActivePlayersVM.WithdrawActivatedPlayer();
                pl.IsActive = true;
                _activePlayersVM.AddPlayer(pl);
            }
        }
        #endregion Methods
    }
}
