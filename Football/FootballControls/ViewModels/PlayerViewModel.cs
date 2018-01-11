using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football;
using BaseObjects;
using Football.Player;

namespace FootballControls.ViewModels
{
	/// <summary>
	/// ViewModel игрока
	/// </summary>
	public class PlayerViewModel
	{
		#region Fields
		IFootballPlayer _player;
		IFootballPlayersListEditor _editor;
		IEditorLocationPlayer _editorLocPlayer;
		#endregion Fields



		#region Constructors
		/// <summary>
		/// Инициализация ViewModel'и игрока
		/// </summary>
		/// <param name="player"></param>
		/// <param name="editor"></param>
		public PlayerViewModel(IFootballPlayer player, IFootballPlayersListEditor editor, IEditorLocationPlayer editorLocPlayer)
		{
			_player = player;
			_editor = editor;
			_editorLocPlayer = editorLocPlayer;
			
		}
		#endregion Constructors



		#region Properties
		/// <summary>
		/// Имя игрока
		/// </summary>
		public string Name
		{
			get { return _player.Name; }
		}

		/// <summary>
		/// Ключевое имя игрока
		/// </summary>
		public string KeyName
		{
			get { return _player.KeyName; }
		}

		/// <summary>
		/// Базовая позиция игрока
		/// </summary>
		public FootballPosition BasicPosition
		{
			get { return _player.BasicPlayPosition; }
		}

		/// <summary>
		/// Текущая позиция
		/// </summary>
		public FootballPosition CurrentPosition
		{
			get { return _player.CurrentPlayPosition; }
			set
			{
				if(_player.CurrentPlayPosition != value)
				{
					_editorLocPlayer.EditCurrentPosition(_player, value);
				}
			}
		}

		/// <summary>
		/// Текущий номер расположения
		/// </summary>
		public byte CurrentLocNumber
		{
			get { return _player.PlayBox; }
			set
			{
				if(_player.PlayBox != value)
				{
					_editorLocPlayer.EditCurrentNumberLocPos(_player, value);
				}
			}
		}

		/// <summary>
		/// Эффективность на базовой позиции
		/// </summary>
		public byte BasicPositionEff
		{
			get { return _player.BasicPlayPositionEff; }
		}

		/// <summary>
		/// Эффективность на текущей позиции
		/// </summary>
		public byte CurrentPositionEff
		{
			get { return _player.CurrentPlayPositionEff; }
		}

		/// <summary>
		/// Рейтинг игрока
		/// </summary>
		public float Rating
		{
			get { return _player.Rating; }
		}

		/// <summary>
		/// Параметры игрока
		/// </summary>
		public IList<IParameterPlayer> Parameters
		{
			get { return _player.ParameterPlayerList; }
		}

		/// <summary>
		/// Признак активного игрока
		/// </summary>
		public bool IsActive
		{
			get { return _player.IsActive; }
			set
			{
				if(_player.IsActive != value)
				{
					_editor.ActivateDeactivatePlayer(_player, value);
				}
			}
		}
		#endregion Properties



		#region Methods
		/// <summary>
		/// Удалить игрока
		/// </summary>
		public void DeletePlayer()
		{
			_editor.DeletePlayer(_player);
		}
		#endregion Methods
	}
}
