using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Football.Player;

namespace FootballControls.ViewModels
{
	/// <summary>
	/// ViewModel добавления игрока
	/// </summary>
	public class AddPlayerViewModel : WPFHelper.BaseViewModel
	{
		#region Fields
		string _playerName;
		string _keyName;
		int _basicPlayPosition;
		IFootballPlayersListEditor _editor;
		ObservableCollection<int> _footballPositions = new ObservableCollection<int>();
		#endregion Fields



		#region Constructors
		/// <summary>
		/// Инициализация ViewModel'и добавления игрока 
		/// </summary>
		/// <param name="playerList"></param>
		public AddPlayerViewModel(IFootballPlayersListEditor editor)
		{
			_editor = editor;
			AddPlayer = Command(ExecuteAddPlayer);

			foreach (int valuePos in Enum.GetValues(typeof(FootballPosition)))
			{
				_footballPositions.Add(valuePos);
			}
		}
		#endregion Constructors



		#region Properties
		/// <summary>
		/// Имя игрока
		/// </summary>
		public string PlayerName
		{
			get { return _playerName; }
			set
			{
				if (value != _playerName)
				{
					_playerName = (value == null) ? value : value.Trim();
					OnPropertyChanged(nameof(PlayerName));
				}
			}
		}

		/// <summary>
		/// Ключевое имя игрока
		/// </summary>
		public string KeyName
		{
			get { return _keyName; }
			set
			{
				if (value != _keyName)
				{
					_keyName = (value == null) ? value : value.Trim();
					OnPropertyChanged(nameof(KeyName));
				}
			}
		}

		/// <summary>
		/// Базовая игровая позиция игрока
		/// </summary>
		public int BasicPlayPosition
		{
			get { return _basicPlayPosition; }
			set
			{
				if (value != _basicPlayPosition)
				{
					_basicPlayPosition = value;
					OnPropertyChanged(nameof(BasicPlayPosition));
				}
			}
		}

		/// <summary>
		/// Игровые позиции
		/// </summary>
		public ObservableCollection<int> FootballPositions
		{
			get { return _footballPositions; }
		}
		#endregion Properties



		#region Commands
		/// <summary>
		/// Команда "Добавить игрока"
		/// </summary>
		public ICommand AddPlayer { get; set; }
		private void ExecuteAddPlayer (object param)
		{
			_editor.AddNewPlayer(PlayerName, KeyName, (FootballPosition)BasicPlayPosition);

			PlayerName = string.Empty;
			KeyName = string.Empty;
			BasicPlayPosition = 0;
		}
		#endregion Commands
	}
}
