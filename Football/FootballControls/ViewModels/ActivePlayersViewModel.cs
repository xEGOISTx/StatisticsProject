using Football.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFHelper;
using System.Collections.ObjectModel;
using WPFHelper.Controls;

namespace FootballControls.ViewModels
{
    public delegate void DeactivatePlayerEventHandler(object sender, EventArgs e);

    public class ActivePlayersViewModel : ItemsSortByGridViewColumnHeader<PlayerViewModel>
    {
        #region Fields
        private PlayerViewModel _selectedPlayer;
        private PlayerViewModel _deactivatedPlayer;
        private ObservableCollection<PlayerViewModel> _players = new ObservableCollection<PlayerViewModel>();
        #endregion Fields

        public ActivePlayersViewModel(IEnumerable<PlayerViewModel> activePlayers)
        {
            AddRange(activePlayers);
            SortByPropertyName("Name");
            Filling();

            DeactivatePlayer = Command(ExecuteDeactivatePlayer);
            DeletePlayer = Command(ExecuteDeletePlayer);
            SortByEff = Command(ExecuteSortByEff);
            SortByName = Command(ExecuteSortByName);
            SortByPos = Command(ExecuteSortByPos);
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
        /// Деактивированный игрок
        /// </summary>
        public PlayerViewModel DeactivatedPlayer
        {
            get { return _deactivatedPlayer; }
            set
            {
                _deactivatedPlayer = value;
            }
        }
        #endregion Properties



        #region Command
        /// <summary>
        /// Команда деактивации игрока
        /// </summary>
        public ICommand DeactivatePlayer { get; set; }
        void ExecuteDeactivatePlayer(object param)
        {
            if (SelectedPlayer != null)
            {
                DeactivatedPlayer = SelectedPlayer;
                OnPropertyChanged(nameof(DeactivatedPlayer));
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
                    if(IsPresent(plVM))
                    {
                        Remove(plVM);
                    }
                }
            }
        }

        public ICommand SortByEff { get; set; }
        private void ExecuteSortByEff(object param)
        {
            SortByPropertyName("BasicPositionEff");
            Filling();
        }

        public ICommand SortByName { get; set; }
        private void ExecuteSortByName(object param)
        {
            SortByPropertyName("Name");
            Filling();
        }

        public ICommand SortByPos { get; set; }
        private void ExecuteSortByPos(object param)
        {
            SortByPropertyName("BasicPosition");
            Filling();
        }
        #endregion Command


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
        /// Добавить игроков
        /// </summary>
        /// <param name="players"></param>
        public void AddPlayers(IEnumerable<PlayerViewModel> players)
        {
            AddRange(players);
            Sort();
            Filling();
        }


        /// <summary>
        /// Изъять выбранного игрока. Возвращает игрока
        /// </summary>
        /// <returns></returns>
        public PlayerViewModel WithdrawSelectedPlayer()
        {
            PlayerViewModel player = SelectedPlayer;
            Remove(SelectedPlayer);
            return player;
        }

        /// <summary>
        /// Изъять деактивированного игрока. Возвращает игрока
        /// </summary>
        /// <returns></returns>
        public PlayerViewModel WithdrawDeactivatedPlayer()
        {
            PlayerViewModel player = DeactivatedPlayer;
            Remove(DeactivatedPlayer);
            _deactivatedPlayer = null;
            return player;
        }

        ///// <summary>
        ///// Изъять выбранного игрока. Возвращает игрока
        ///// </summary>
        ///// <returns></returns>
        //public PlayerViewModel WithdrawSelectedPlayer()
        //{
        //    PlayerViewModel player = SelectedPlayer;
        //    Remove(SelectedPlayer);
        //    return player;
        //}

        ///// <summary>
        ///// Убрать полевых игроков. Возвращает список полевых игроков
        ///// </summary>
        ///// <returns></returns>
        //public List<PlayerViewModel> FieldersRemove()
        //{
        //    List<PlayerViewModel> playersInField = new List<PlayerViewModel>();

        //    foreach (PlayerViewModel plVM in SortedList)
        //    {
        //        if (plVM.CurrentPosition != FootballPosition.Default)
        //        {
        //            playersInField.Add(plVM);
        //        }
        //    }

        //    foreach (PlayerViewModel plVM in playersInField)
        //    {
        //        Remove(plVM);
        //    }
        //    return playersInField;
        //}

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

        /// <summary>
        /// Удалить игрока
        /// </summary>
        /// <param name="player"></param>
        public override void Remove(PlayerViewModel player)
        {
            base.Remove(player);
            Players.Remove(player);
        }

        public void Update()
        {
            Filling();
        }
        #endregion Methods

    }
}
