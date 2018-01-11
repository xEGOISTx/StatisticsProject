using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football;
using Football.Field;
using System.Collections.ObjectModel;
using WPFHelper;
using System.Windows.Media;
using FootballControls.Properties;

namespace FootballControls.ViewModels
{
	/// <summary>
	/// ViewModel  поля
	/// </summary>
	public class FieldViewModel : BaseViewModel
	{
		#region Fields

		ISchemeList _schemes;
		FootballScheme _selectedScheme;
		ObservableCollection<PlayBoxViewModel> _playBoxVMs = new ObservableCollection<PlayBoxViewModel>();
		ObservableCollection<PlayerViewModel> _players;
		#endregion Fields



		#region Constructors
		/// <summary>
		/// Инициализация ViewModel'и поля
		/// </summary>
		/// <param name="players"></param>
		/// <param name="field"></param>
		public FieldViewModel(ObservableCollection<PlayerViewModel> players, IFootballField field)
		{
			_players = players;
			_schemes = field.Schemes;
			SelectedScheme = (FootballScheme)Settings.Default.CurrentSheme;
        }
		#endregion Constructors



		#region Properties
		/// <summary>
		/// Выбранная схема
		/// </summary>
		public FootballScheme SelectedScheme
		{
			get { return _selectedScheme; }
			set
			{
				_selectedScheme = value;
                Settings.Default.CurrentSheme = (byte)_selectedScheme;
                Settings.Default.Save();

                if (_playBoxVMs.Count == 0)
				{
					InitPLayBoxVMs();
				}
				else
				{
					SetScheme();
				}

				OnPropertyChanged(nameof(SelectedScheme));
			}
		}

		/// <summary>
		/// Список наименований схем
		/// </summary>
		public	ObservableCollection<FootballScheme> SchemesNames
		{
			get
			{
				ObservableCollection<FootballScheme> sNames = new ObservableCollection<FootballScheme>();

				foreach (int indexS in Enum.GetValues(typeof(FootballScheme)))
				{
					sNames.Add((FootballScheme)indexS);
				}

				return sNames;
			}
		}

		public PlayBoxViewModel SelectedBox { get; set; }

		/// <summary>
		/// Признак перемешения игроков в поле. True в поле, false из вне
		/// </summary>
		private bool MovementInField { get; set; }

		#region PlayBoxViewModels
		public PlayBoxViewModel BoxVM1
		{
			get { return _playBoxVMs[0]; }
		}
		public PlayBoxViewModel BoxVM2
		{
			get { return _playBoxVMs[1]; }
		}
		public PlayBoxViewModel BoxVM3
		{
			get { return _playBoxVMs[2]; }
		}
		public PlayBoxViewModel BoxVM4
		{
			get { return _playBoxVMs[3]; }
		}
		public PlayBoxViewModel BoxVM5
		{
			get { return _playBoxVMs[4]; }
		}
		public PlayBoxViewModel BoxVM6
		{
			get { return _playBoxVMs[5]; }
		}
		public PlayBoxViewModel BoxVM7
		{
			get { return _playBoxVMs[6]; }
		}
		public PlayBoxViewModel BoxVM8
		{
			get { return _playBoxVMs[7]; }
		}
		public PlayBoxViewModel BoxVM9
		{
			get { return _playBoxVMs[8]; }
		}
		public PlayBoxViewModel BoxVM10
		{
			get { return _playBoxVMs[9]; }
		}
		public PlayBoxViewModel BoxVM11
		{
			get { return _playBoxVMs[10]; }
		}
		#endregion PlayBoxViewModels
		#endregion Properties


		#region Methods
		/// <summary>
		/// Инициализация боксов и расстановка по схеме
		/// </summary>
		private void InitPLayBoxVMs()
		{
			IScheme scheme = _schemes.GetScheme(SelectedScheme);

			foreach(ILocationPosition locPos in scheme)
			{
				PlayBoxViewModel plBoxVM = new PlayBoxViewModel(locPos);
				plBoxVM.BoxSelected += PlBoxVM_BoxSelected;
				plBoxVM.PreRemovalPlayer += PlBoxVM_PreRemovalPlayer;
				_playBoxVMs.Add(plBoxVM);				
			}

			if(_players.Count > 0)
			{
				foreach(PlayerViewModel plVM in _players)
				{
					_playBoxVMs[plVM.CurrentLocNumber - 1].SetPlayer(plVM);
				}
			}
		}

		private void PlBoxVM_PreRemovalPlayer(object sender, EventArgs e)
		{
			OnPreRemovalPlayer(sender, e);

			if((sender as PlayBoxViewModel) == SelectedBox)
			{
				SelectedBox = null;
				ResetHighlight();
			}
		}

		/// <summary>
		/// Действия при выборе игрового бокса
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PlBoxVM_BoxSelected(object sender, EventArgs e)
		{

			PlayBoxViewModel newSelectedBox = sender as PlayBoxViewModel;

			MovementInField = true;

			if (SelectedBox == null)
			{
				SelectedBox = newSelectedBox;
				OnBoxSelected();

				if(MovementInField)
				{
					if(newSelectedBox.IsPlayerPresent)
					{
						LocalHighlightPositions();
					}
					else
					{
						SelectedBox = null;
					}
				}
			}
			else
			{
				if(newSelectedBox.IsPlayerPresent)
				{
					if (newSelectedBox != SelectedBox)
					{
						PlayerViewModel plNSB = newSelectedBox.WithdrawPlayer();
						PlayerViewModel plSB = SelectedBox.WithdrawPlayer();
						newSelectedBox.SetPlayer(plSB);
						SelectedBox.SetPlayer(plNSB);
						ResetHighlight();
						SelectedBox = null;
					}

				}
				else
				{
					PlayerViewModel plSB = SelectedBox.WithdrawPlayer();
					newSelectedBox.SetPlayer(plSB);
					ResetHighlight();
					SelectedBox = null;
				}
			}		
		}

		/// <summary>
		/// Установить игрока на позицию
		/// </summary>
		/// <param name="player"></param>
		public void SetPLayer(PlayerViewModel player)
		{
			if (SelectedBox != null)
			{
				SelectedBox.SetPlayer(player);
				MovementInField = false;
				SelectedBox = null;
				ResetHighlight();
			}
		}

		/// <summary>
		/// Установить схему
		/// </summary>
		private void SetScheme()
		{
			IScheme scheme = _schemes.GetScheme(SelectedScheme);

			foreach(PlayBoxViewModel plBoxVM in _playBoxVMs)
			{
                ILocationPosition locPos = scheme.GetLocation(plBoxVM.LocNumber);
                plBoxVM.SetLocPos(locPos);
			}
		}

		private void LocalHighlightPositions()
		{
			foreach (PlayBoxViewModel plBoxVM in _playBoxVMs)
			{
				if(plBoxVM == SelectedBox)
				{
					plBoxVM.HighlightPosition = Brushes.Red;
				}
				else
				{
					plBoxVM.HighlightPosition = Brushes.Yellow;
				}
			
			}
		}

		/// <summary>
		/// Подсветить позиции
		/// </summary>
		public void HighlightPositions()
		{
			foreach(PlayBoxViewModel plBoxVM in _playBoxVMs)
			{
				plBoxVM.HighlightPosition = Brushes.Yellow;
			}
		}

		/// <summary>
		/// Сбросить подсветку позиций
		/// </summary>
		public void ResetHighlight()
		{
			foreach (PlayBoxViewModel plBoxVM in _playBoxVMs)
			{
				plBoxVM.HighlightPosition = Brushes.Transparent;
			}
		}

		/// <summary>
		/// Очистить все боксы от игроков. Возвращает список игроков
		/// </summary>
		public List<PlayerViewModel> ClearBoxes()
		{
			List<PlayerViewModel> plVMs = new List<PlayerViewModel>();

			foreach (PlayBoxViewModel bVM in _playBoxVMs)
			{
				if(bVM.IsPlayerPresent)
				{
					plVMs.Add(bVM.Player);
					bVM.Clear();
					_players.Clear();
				}
			}

			return plVMs;
		}

		/// <summary>
		/// Добавть игроков на поле. Если у игрока определены текущая позиция и текущий номер расположения игрок будет установлен на позицию
		/// </summary>
		/// <param name="playerVMs"></param>
		public void AddPlayers(List<PlayerViewModel> playerVMs)
		{
			if (playerVMs.Count > 0)
			{
				foreach (PlayerViewModel plVM in playerVMs)
				{
					_players.Add(plVM);
					if(plVM.CurrentLocNumber > 0)
					{
						_playBoxVMs[plVM.CurrentLocNumber - 1].SetPlayer(plVM);
					}
				}
			}
		}


		/// <summary>
		/// Оповестить подписчиков ,что выбран игровой бокс
		/// </summary>
		/// <param name="sender"></param>
		private void OnBoxSelected()
		{
			BoxSelected?.Invoke(this, new EventArgs());
		}

		private void OnPreRemovalPlayer(object sender, EventArgs e)
		{
			PreRemovalPlayer?.Invoke(sender, e);
		}
		#endregion Methods

		#region Events
		
		public event BoxEventHandler BoxSelected;

		/// <summary>
		/// Возникает перед удалением игрока из бокса
		/// </summary>
		public event BoxEventHandler PreRemovalPlayer;
		#endregion Events
	}
}
