using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFHelper
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string arg)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(arg));
		}

		/// <summary>
		/// Инициализирует и возвращает команду
		/// </summary>
		/// <param name="execute"></param>
		/// <returns></returns>
		protected DelegateCommand Command(Action<object> execute)
		{
			return new DelegateCommand(execute);
		}
	}
}
