using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football;
using WPFHelper;
using Football.Field;
using FootballControls.ViewModels.Parameters;
using Football.Chart;
using System.Windows.Controls;
using FootballControls.ViewModels.Chart;

namespace FootballControls.ViewModels
{
	/// <summary>
	/// ViewModel футбол
	/// </summary>
	public class FootballViewModel : BaseViewModel
	{
		#region Fields
		private PlayersManager _playersManeger;
		private IFootballPlayerList _playerList;
		private int _selectedTabIndex;
		#endregion Fields



		#region Conctructors
		/// <summary>
		/// Инициализация ViewModel'и футбол
		/// </summary>
		/// <param name="playerList"></param>
		public FootballViewModel(IFootballPlayerList playerList, IFootballField field,IEfficiencyChart chart)
		{
			_playerList = playerList;
            _playersManeger = new PlayersManager(playerList, field, chart);
			_selectedTabIndex = 0;
		}
		#endregion Conctructors



		#region Properties
		/// <summary>
		/// Выбранная вкладка
		/// </summary>
		public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set
            {
                if (_selectedTabIndex != value)
                {
                    _selectedTabIndex = value;

                    if (value == 0)
                    {
                        _playersManeger.SelectedField = true;
                        _playersManeger.SelectedParametersEditor = false;
                        _playersManeger.SelectedChart = false;
                    }

                    if (value == 1)
                    {
                        _playersManeger.SelectedField = false;
                        _playersManeger.SelectedParametersEditor = true;
                        _playersManeger.SelectedChart = false;
                    }

                    if (value == 2)
                    {
                        _playersManeger.SelectedField = false;
                        _playersManeger.SelectedParametersEditor = false;
                        _playersManeger.SelectedChart = true;
                    }

                    OnPropertyChanged(nameof(SelectedTabIndex));
                }
            }
        }

		/// <summary>
		/// ViewModel панели игроков
		/// </summary>
		public PLayersViewModel PlayersVM
		{
			get { return _playersManeger.PlayersVM; }
		}

		/// <summary>
		/// ViewModel панели добавления игроков
		/// </summary>
		public AddPlayerViewModel AddPlayerVM
		{
			get { return _playersManeger.AddPlayersVM; }
		}

		/// <summary>
		/// ViewModel поля
		/// </summary>
		public FieldViewModel FieldVM
		{
			get { return _playersManeger.FieldVM; }
		}

        /// <summary>
        /// ViewModel графика эффективности
        /// </summary>
        public ChartViewModel ChartVM
        {
            get { return _playersManeger.ChartVM; }
        }

		/// <summary>
		/// ViewModel редактора параметров
		/// </summary>
		public ParametersEditorViewModel ParametersEditorVM
		{
			get { return _playersManeger.ParametersEditorVM; }
		}

		#endregion Properties

	}
}
