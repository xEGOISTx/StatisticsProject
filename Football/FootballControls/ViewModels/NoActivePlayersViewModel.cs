using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFHelper.Controls;

namespace FootballControls.ViewModels
{
    public class NoActivePlayersViewModel : ItemsSortByGridViewColumnHeader<PlayerViewModel>
    {
        #region Fields
        private PlayerViewModel _selectedPlayer;
        private PlayerViewModel _activatedPlayer;
        private ObservableCollection<PlayerViewModel> _players = new ObservableCollection<PlayerViewModel>();
        #endregion Fields

        public NoActivePlayersViewModel(IEnumerable<PlayerViewModel> noActivePlayers)
        {
            AddRange(noActivePlayers);
            SortByPropertyName("Name");
            Filling();

            ActivatePlayer = Command(ExecuteActivatePlayer);
            DeletePlayer = Command(ExecuteDeletePlayer);
        }

        #region Properties;
        /// <summary>
        /// Список игроков для отображения
        /// </summary>
        public ObservableCollection<PlayerViewModel> Players
        {
            get { return _players; }
        }

        /// <summary>
        /// Выбранный игрок
        /// </summary>
        public PlayerViewModel SelectedPlayer
        {
            get { return _selectedPlayer; }
            set
            {
                if (_selectedPlayer != value)
                {
                    _selectedPlayer = value;

                    OnPropertyChanged(nameof(SelectedPlayer));
                }
            }
        }

        /// <summary>
        /// Активированный игрок
        /// </summary>
        public PlayerViewModel ActivatedPlayer
        {
            get { return _activatedPlayer; }
            set
            {
                _activatedPlayer = value;
            }
        }
        #endregion Properties


        #region Commands
        /// <summary>
        /// Команда активации игрока
        /// </summary>
        public ICommand ActivatePlayer { get; set; }
        void ExecuteActivatePlayer(object param)
        {
            if (SelectedPlayer != null)
            {
                ActivatedPlayer = SelectedPlayer;
                OnPropertyChanged(nameof(ActivatedPlayer));
            }
        }

        /// <summary>
        /// Команда удаления игрока
        /// </summary>
        public ICommand DeletePlayer { get; set; }
        void ExecuteDeletePlayer(object param)
        {
            PlayerViewModel plVM = (param as PlayerViewModel);
            if (plVM != null)
            {
                MessageBoxResult result = MessageBox.Show("Точно удалить " + plVM.Name + "?\nИнформация будет утеряна безвозвраьно!"
                    , "Удаление игрока", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.OK)
                {
                    plVM.DeletePlayer();
                    if (IsPresent(plVM))
                    {
                        Remove(plVM);
                    }
                }
            }
        }
        #endregion Commands


        #region Methods
        /// <summary>
        /// Добавить игрока
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayer(PlayerViewModel player)
        {
            Add(player);
            Sort();
            Filling();
        }

        /// <summary>
        /// Изъять активированного игрока. Возвращает игрока
        /// </summary>
        /// <returns></returns>
        public PlayerViewModel WithdrawActivatedPlayer()
        {
            PlayerViewModel player = ActivatedPlayer;
            Remove(ActivatedPlayer);
            _activatedPlayer = null;
            return player;
        }

        /// <summary>
        /// Заполнить из отсортированного списка
        /// </summary>
        private void Filling()
        {
            PlayerViewModel selectedPLayer = SelectedPlayer;
            Players.Clear();

            foreach (PlayerViewModel pl in SortedList)
            {
                Players.Add(pl);
            }
            SelectedPlayer = selectedPLayer;
        }

        public void Update()
        {
            Filling();
        }

        /// <summary>
        /// Удалить игрока
        /// </summary>
        /// <param name="player"></param>
        public override void Remove(PlayerViewModel player)
        {
            base.Remove(player);
            Players.Remove(player);
        }
        #endregion Methods
    }
}
