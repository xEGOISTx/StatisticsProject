using System;
using System.Windows.Input;

namespace WPFHelper
{
	/// <summary>
	/// Класс команда
	/// </summary>
	public class DelegateCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		Action<object> _execute;

		/// <summary>
		/// Инициализирует команду
		/// </summary>
		/// <param name="execute"></param>
		public DelegateCommand(Action<object> execute)
		{
			_execute = execute;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			_execute(parameter);
		}
	}
}
