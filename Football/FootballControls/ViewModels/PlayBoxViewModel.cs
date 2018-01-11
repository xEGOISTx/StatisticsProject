using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football;
using Football.Field;
using System.Windows;
using WPFHelper;
using System.Windows.Media;
using System.Windows.Input;
using Football.Player;

namespace FootballControls.ViewModels
{
	public delegate void BoxEventHandler(object sender, EventArgs e);

	public class PlayBoxViewModel : BaseViewModel
	{
		private ILocationPosition _locPos;
		private Brush _highlightPosition;

		private PlayerViewModel _playerVM;



		#region Constructors
		/// <summary>
		/// Инициализация игрового бокса
		/// </summary>
		/// <param name="locPos"></param>
		public PlayBoxViewModel(ILocationPosition locPos)
		{
			IdentifyLocPos(locPos);
			_highlightPosition = Brushes.Transparent;

			SelectBox = Command(ExecuteSelectBox);
			RemovePlayer = Command(ExecuteRemovePlayer);
		}
		#endregion Constructors



		#region Properties
		#region LocPos
		/// <summary>
		/// Номер расположения
		/// </summary>
		public byte LocNumber
		{
			get { return _locPos.NumberLocation; }
		}

		/// <summary>
		/// Номер колонки
		/// </summary>
		public byte Column
		{
			get { return _locPos.GetLocCell.Column; }
		}

		/// <summary>
		/// Номер ряда
		/// </summary>
		public byte Row
		{
			get { return _locPos.GetLocCell.Row; }
		}

		/// <summary>
		/// Вертикальная позиция
		/// </summary>
		public VerticalAlignment Vertical
		{
			get { return _locPos.GetLocInCell.Vertical; }
		}

		/// <summary>
		/// Горизонтальная позиция
		/// </summary>
		public HorizontalAlignment Horizontal
		{
			get { return _locPos.GetLocInCell.Horizontal; }
		}

		/// <summary>
		/// Игровая позиция
		/// </summary>
		public FootballPosition Position
		{
			get { return _locPos.Position; }
		}

		/// <summary>
		/// Подсведка позиции
		/// </summary>
		public Brush HighlightPosition
		{
			get { return _highlightPosition; }
			set
			{
				if(_highlightPosition != value)
				{
					_highlightPosition = value;
					OnPropertyChanged(nameof(HighlightPosition));
				}
			}
		}
		#endregion LocPos



		#region Player
		/// <summary>
		/// Признак игрока в игровом боксе
		/// </summary>
		public bool IsPlayerPresent
		{
			get
			{
				return _playerVM != null;
			}
		}

		/// <summary>
		/// Эффективность игрока на текущей позиции
		/// </summary>
		public byte PlayerEff
		{
			get { return _playerVM != null ? _playerVM.CurrentPositionEff : (byte)0; }
		}

		/// <summary>
		/// Имя игрока
		/// </summary>
		public string PlayerName
		{
			get { return _playerVM != null ? _playerVM.Name : string.Empty; }
		}

		/// <summary>
		/// Параметры игрока
		/// </summary>
		public IList<BaseObjects.IParameterPlayer> Parameters
		{
			get { return _playerVM.Parameters; }
		}

		/// <summary>
		/// ViewModel игрока
		/// </summary>
		public PlayerViewModel Player
		{
			get { return _playerVM; }
		}
		#endregion Player
		#endregion Properties



		#region Commands
		/// <summary>
		/// Команда выбрать игровой бокс
		/// </summary>
		public ICommand SelectBox { get; set; } 
		private void ExecuteSelectBox(object param)
		{
			OnBoxSelected();
		}

		/// <summary>
		/// Команда удалить игрока
		/// </summary>
		public ICommand RemovePlayer { get; set; }
		private void ExecuteRemovePlayer(object param)
		{
			OnPreRemovalPlayer();
			Clear();
		}
		#endregion Commands


		#region Methods
		/// <summary>
		/// Установить расположение игрового бокса
		/// </summary>
		/// <param name="locPos"></param>
		public void SetLocPos(ILocationPosition locPos)
		{
			IdentifyLocPos(locPos);
		}

		/// <summary>
		/// Установить игрока в игровой бокс
		/// </summary>
		/// <param name="player"></param>
		public void SetPlayer(PlayerViewModel player)
		{
			_playerVM = player;

			if (_playerVM.CurrentLocNumber != LocNumber)
			{
				_playerVM.CurrentLocNumber = LocNumber;
			}

			if(_playerVM.CurrentPosition != Position)
			{
				_playerVM.CurrentPosition = Position;
			}

			UpdatePlayerInfo();
		}

		/// <summary>
		/// Изъять игрока из бокса. Возвращает игрока
		/// </summary>
		/// <returns></returns>
		public PlayerViewModel WithdrawPlayer()
		{
			if (_playerVM != null)
			{
				_playerVM.CurrentLocNumber = 0;
				_playerVM.CurrentPosition =  FootballPosition.Default;

				PlayerViewModel player = _playerVM;
				Clear();
				return player;
			}
			else
			{
				throw new NullReferenceException();
			}
		}

		/// <summary>
		/// Очистить бокс
		/// </summary>
		public void Clear()
		{
			_playerVM = null;
			UpdatePlayerInfo();
		}

		/// <summary>
		/// Идентификация позиции
		/// </summary>
		/// <param name="locPos"></param>
		private void IdentifyLocPos(ILocationPosition locPos)
		{
			if (_locPos != null)
			{
				if (locPos.NumberLocation == _locPos.NumberLocation)
				{
					_locPos = locPos;
					UodateLocPos();
					if(_playerVM != null)
					{
						_playerVM.CurrentPosition = _locPos.Position;
						OnPropertyChanged(nameof(PlayerEff));
					}
				}
				else
				{
					throw new Exception("Несоответствие номера позиции");
				}
			}
			else
			{
				_locPos = locPos;
				UodateLocPos();
				if (_playerVM != null)
				{
					_playerVM.CurrentPosition = _locPos.Position;
					OnPropertyChanged(nameof(PlayerEff));
				}
			}


		}

		/// <summary>
		/// Обновить расположение
		/// </summary>
		private void UodateLocPos()
		{
			OnPropertyChanged(nameof(LocNumber));
			OnPropertyChanged(nameof(Column));
			OnPropertyChanged(nameof(Row));
			OnPropertyChanged(nameof(Vertical));
			OnPropertyChanged(nameof(Horizontal));
			OnPropertyChanged(nameof(Position));
		}

		/// <summary>
		/// Обновить ифу по игроку
		/// </summary>
		private void UpdatePlayerInfo()
		{
			OnPropertyChanged(nameof(PlayerEff));
			OnPropertyChanged(nameof(PlayerName));
			OnPropertyChanged(nameof(Parameters));
			OnPropertyChanged(nameof(Player));
			OnPropertyChanged(nameof(IsPlayerPresent));
		}

		/// <summary>
		/// Оповещаем подписчиков
		/// </summary>
		private void OnBoxSelected()
		{
			BoxSelected?.Invoke(this, new EventArgs());
		}

		private void OnPreRemovalPlayer()
		{
			PreRemovalPlayer?.Invoke(this, new EventArgs());
		}
		#endregion Methods


		#region Events
		/// <summary>
		/// Возникает при выборе игрового бокса
		/// </summary>
		public event BoxEventHandler BoxSelected;

		/// <summary>
		/// Происходит перед удалением игрока из бокса
		/// </summary>
		public event BoxEventHandler PreRemovalPlayer;
		#endregion Events
	}
}
