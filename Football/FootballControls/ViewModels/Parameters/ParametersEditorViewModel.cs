using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WPFHelper;
using BaseObjects;
using Football.Player;
using System.Windows.Input;
using System.Windows;
using BasicInfirmationProject;


namespace FootballControls.ViewModels.Parameters
{
	/// <summary>
	/// ViewModel редактора параметров игрока
	/// </summary>
	public class ParametersEditorViewModel : BaseViewModel
	{
		private bool _isEditing;
		private ObservableCollection<DualSubParameterViewModel> _dualSubParameters = new ObservableCollection<DualSubParameterViewModel>();
		private IPlayerEditor _playerEditor;
        private ObservableCollection<int> _positions = new ObservableCollection<int>(); 

        /// <summary>
        /// Инициализация ViewModel'и редактора параметров
        /// </summary>
        /// <param name="playerList"></param>
        public ParametersEditorViewModel(IPlayerEditor playerEditor)
		{
			_playerEditor = playerEditor;

			TurnOffEnableEdit = Command(ExecuteTurnOffEnableEdit);

            InitPositions();
		}


		#region Properties
		/// <summary>
		/// Признак редактирования
		/// </summary>
		public bool IsEditing
		{
			get { return _isEditing; }
			set
			{
				if (_isEditing != value)
				{
					_isEditing = value;

					if (!value)
					{
						UpdateDSubParams();
						Update();
					}

					OnPropertyChanged(nameof(IsEditing));
				}
			}
		}

		public bool IsPresentPlayer
		{
			get { return _playerEditor.IsPresentPlayer; }
		}


		public string CurrentRating
		{
			get { return string.Format("{0:0.00}", _playerEditor.CurrentRating); }
		}

		public byte EditableRatingLeft
		{
			get { return (byte)_playerEditor.EditableRating; }
			set
			{
				if(value < 10)
				{
					float rating = GetFloatRating(value, EditableRatingRight);
					_playerEditor.EditRating(rating, EditableCountGames);					
				}
				else
				{
					_playerEditor.EditRating(10, EditableCountGames);
					OnPropertyChanged(nameof(EditableRatingRight));
				}
				if(value > 0)
				{
					EditableCountGames = 1;
				}
				else
				{
					EditableCountGames = 0;
				}
			}
		}

		public byte EditableRatingRight
		{
			get
			{				
				string[] arr = _playerEditor.EditableRating.ToString().Split(',');
				if (arr.Length > 1)
				{
					return byte.Parse(arr[1]);
				}
				else
				{
					return 0;
				}
			}
			set
			{
				if (EditableRatingLeft < 10)
				{
					float rating = GetFloatRating(EditableRatingLeft, value);
					_playerEditor.EditRating(rating, EditableCountGames);
				}
				else
				{
					float rating = GetFloatRating(EditableRatingLeft, 0);
					_playerEditor.EditRating(rating, EditableCountGames);
				}
				//OnPropertyChanged(nameof(EditableRatingRight));
			}
		}


		public ushort CurrentCountGames
		{
			get { return _playerEditor.CurrentCountGames; }
		}

		public ushort EditableCountGames
		{
			get { return _playerEditor.EditableCountGames; }
			set
			{
				if (_playerEditor.EditableCountGames != value)
				{
					float rating = GetFloatRating(EditableRatingLeft, EditableRatingRight);
					_playerEditor.EditRating(rating, value);
					OnPropertyChanged(nameof(EditableCountGames));
				}
			}
		}

		/// <summary>
		/// Список сдвоенных подпараметров
		/// </summary>
		public ObservableCollection<DualSubParameterViewModel> DualSubParameters
		{
			get { return _dualSubParameters; }
		}

        
        public int CurrentBasicPosition
        {
            get { return (int)_playerEditor.CurrentBasicPosition; }
        }

        public int EditableBasicPosition
        {
            get { return (int)_playerEditor.EditableBasicPosition; }
            set
            {
                if ((int)_playerEditor.EditableBasicPosition != value)
                {
                        _playerEditor.EditBasicProperties(EditableName, (FootballPosition)value);
                    OnPropertyChanged(nameof(EditableBasicPosition));
                }
            }
        }

        public string CurrentName
        {
            get { return _playerEditor.CurrentName; }
        }

        public string EditableName
        {
            get { return _playerEditor.EditableName; }
            set
            {
                if(_playerEditor.EditableName != value)
                {
                    _playerEditor.EditBasicProperties(value, (FootballPosition)EditableBasicPosition);
                    OnPropertyChanged(nameof(EditableName));
                }
            }
        }

        public ObservableCollection<int> Positions
        {
            get { return _positions; }
        }
        #endregion Properties



        #region Command
        public ICommand TurnOffEnableEdit { get; set; }
		void ExecuteTurnOffEnableEdit(object param)
		{
			if(IsEditing)
			{
				if(_playerEditor.PresentChangedPlayers)
				{
					MessageBoxResult result = MessageBox.Show("Применить изменения?", BasicInformation.FullName, MessageBoxButton.YesNoCancel, MessageBoxImage.Information);

					if(result == MessageBoxResult.Yes)
					{
						_playerEditor.EndEditing(true);
						IsEditing = false;
					}
					else if(result == MessageBoxResult.No)
					{
						_playerEditor.EndEditing(false);
						IsEditing = false;
					}
				}
				else
				{
					IsEditing = false;
				}
			}
			else
			{
				IsEditing = true;
			}
		}
		#endregion Command



		#region Methods     
		/// <summary>
		/// Установить игрока для редактирования
		/// </summary>
		/// <param name="player"></param>
		public void SetPlayer(IFootballPlayer player)
		{
            if (player != null)
            {
                _playerEditor.SetPlayer(player);
                UpdateDSubParams();
                Update();
            }
            else
            {
                Clear();
            }

		}

		public void Clear()
		{
			if (_playerEditor.IsPresentPlayer)
			{
				DualSubParameters.Clear();
				_playerEditor.RemovePlayer();
				Update();
			}
		}

		private void Update()
		{
			OnPropertyChanged(nameof(CurrentRating));
			OnPropertyChanged(nameof(EditableRatingLeft));
			OnPropertyChanged(nameof(EditableRatingRight));
			OnPropertyChanged(nameof(CurrentCountGames));
			OnPropertyChanged(nameof(EditableCountGames));
            OnPropertyChanged(nameof(CurrentBasicPosition));
            OnPropertyChanged(nameof(EditableBasicPosition));
            OnPropertyChanged(nameof(CurrentName));
            OnPropertyChanged(nameof(EditableName));
            OnPropertyChanged(nameof(IsPresentPlayer));
		}

        private void InitPositions()
        {
            foreach(int pos in Enum.GetValues(typeof(FootballPosition)))
            {
                if (pos > 0)
                    _positions.Add(pos);
            }
        }

		private void UpdateDSubParams()
		{
			DualSubParameters.Clear();
			if (_playerEditor.IsPresentPlayer)
			{
				IList<ISubParameterPlayer> currentSubParameters = _playerEditor.GetCurrentParametersValuesList();
				IList<ISubParameterPlayer> editableSubParameters = _playerEditor.GetListForEditParameters();

				for (byte i = 0; i < currentSubParameters.Count; i++)
				{
					DualSubParameterViewModel dSubParam = new DualSubParameterViewModel(currentSubParameters[i], editableSubParameters[i], _playerEditor);
					_dualSubParameters.Add(dSubParam);
				}
			}		
		}

		private float GetFloatRating(int left,int right)
		{
			return float.Parse(string.Format("{0},{1}", left, right));
		}
		#endregion Methods
	}
}
