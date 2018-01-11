using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Messages;
using WPFHelper;


namespace ProjectStatistics.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
		#region Fields
		FootballControls.ViewModels.FootballViewModel _footballVM;
        View.HelpWindow.HelpWindowView _helpWindow;
        #endregion Fields

        public MainWindowViewModel()
		{
			Football.FootballPlayerList plList = new Football.FootballPlayerList();
			Football.Field.FootballField footballField = new Football.Field.FootballField();
            Football.Chart.EfficiencyChart chart = new Football.Chart.EfficiencyChart();
            _footballVM = new FootballControls.ViewModels.FootballViewModel(plList, footballField, chart);

            OpenHelp = Command(ExecuteOpenHelp);
		}



		#region Properties
		/// <summary>
		/// ViewModel футбол
		/// </summary>
		public FootballControls.ViewModels.FootballViewModel FootballVM
		{
			get { return _footballVM; }
		}

        public ICommand OpenHelp { get; set; }
        private void ExecuteOpenHelp(object param)
        {
            if (_helpWindow == null)
            {
                _helpWindow = new View.HelpWindow.HelpWindowView();
                _helpWindow.Closing += _helpWindow_Closing;
                _helpWindow.Show();
            }
            else
            {
                _helpWindow.WindowState = WindowState.Normal;
                _helpWindow.Activate();
            }

        }

        private void _helpWindow_Closing(object sender, CancelEventArgs e)
        {
            _helpWindow.Closing -= _helpWindow_Closing;
            _helpWindow = null;
        }


        public void CloseAllWindows()
        {
            if (_helpWindow != null)
                _helpWindow.Close();
        }
        #endregion Properties	
    }
}
