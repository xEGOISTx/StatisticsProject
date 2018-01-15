using System;
using System.Windows;


namespace ProjectStatistics.View
{
	public partial class MainWindow : Window
	{		
		public MainWindow()
		{
			InitializeComponent();
        }

        private void LW_Closed(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.LicenseAccepted)
            {
                Close();
            }
        }

        internal void ShowLicenseWindow()
        {
            var lW = new LicenseWindow.LicenseWindowView();
            ViewModel.LicenseWindow.LicenseWindowViewModel lWDataContext = new ViewModel.LicenseWindow.LicenseWindowViewModel();
            lW.DataContext = lWDataContext;
            lW.Closed += LW_Closed;
            lW.ShowDialog();           
        }
    }
}
