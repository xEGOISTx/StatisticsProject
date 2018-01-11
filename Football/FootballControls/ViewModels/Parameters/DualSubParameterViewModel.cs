using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseObjects;
using Football;
using Football.Player;

namespace FootballControls.ViewModels.Parameters
{
	/// <summary>
	/// ViewModel сдвоенного значения подпараметра. Текущее значение и редактируемое
	/// </summary>
	public class DualSubParameterViewModel : WPFHelper.BaseViewModel
	{
		#region Fields
		ISubParameterPlayer _editableSubParameter;
		ISubParameterPlayer _currentSubParameter;
		IPlayerEditor _editor;
		#endregion Fields


		#region Conctructors
		/// <summary>
		/// Инициализация ViewModel'и сдвоенного значения подпараметра
		/// </summary>
		/// <param name="edirableSubParameter"></param>
		/// <param name="currentSubParameter"></param>
		/// <param name="editor"></param>
		public DualSubParameterViewModel(ISubParameterPlayer currentSubParameter, ISubParameterPlayer edirableSubParameter, IPlayerEditor editor)
		{
			_editableSubParameter = edirableSubParameter;
			_currentSubParameter = currentSubParameter;
			_editor = editor;
		}
		#endregion Conctructors



		#region Properties
		public string Name
		{
			get { return _editableSubParameter.Name; }
		}

		/// <summary>
		/// Признак блокировки свойства "успешно"
		/// </summary>
		public bool IsNotBlockedSuccessFully
        {
			get { return _editableSubParameter.IsNotBlockedSuccessFully; }
		}

		/// <summary>
		/// Признак блокировки свойства "неуспешно"
		/// </summary>
		public bool IsNotBlockedFailed
        {
			get { return _editableSubParameter.IsNotBlockedFailed; }
		}

		/// <summary>
		/// Текущее успешное значение 
		/// </summary>
		public uint CurrentSuccessfulValue
		{
			get { return _currentSubParameter.SuccessFully; }
		}

		/// <summary>
		/// Текущее неуспешное значение 
		/// </summary>
		public uint CurrentFailedValue
		{
			get { return _currentSubParameter.Failed; }
		}

		/// <summary>
		/// Показатель "успешно"
		/// </summary>
		public uint SuccessFully
		{
			get { return _editableSubParameter.SuccessFully; }
			set
			{
				_editor.EditSubParameter(ref _editableSubParameter, value, Failed);
				OnPropertyChanged(nameof(SuccessFully));
			}
		}

		/// <summary>
		/// Показатель "неуспешно"
		/// </summary>
		public uint Failed
		{
			get { return _editableSubParameter.Failed; }
			set
			{
				_editor.EditSubParameter(ref _editableSubParameter, SuccessFully, value);
				OnPropertyChanged(nameof(Failed));
			}
		}

		public void Update()
		{
			OnPropertyChanged(nameof(CurrentSuccessfulValue));
			OnPropertyChanged(nameof(CurrentFailedValue));
			OnPropertyChanged(nameof(SuccessFully));
			OnPropertyChanged(nameof(Failed));
		}
		#endregion Properties
	}
}
