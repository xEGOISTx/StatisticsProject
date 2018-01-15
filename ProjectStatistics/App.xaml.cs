using System;
using System.Windows;

namespace ProjectStatistics
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            RunProgram();
        }

        private void RunProgram()
        {
            var mW = new View.MainWindow() { DataContext = new ViewModel.MainWindowViewModel() };
            mW.Closing += MW_Closing;           
            mW.Show();
        
            if (!ProjectStatistics.Properties.Settings.Default.LicenseAccepted)
            {
                mW.ShowLicenseWindow();
            }
        }

        private void MW_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            View.MainWindow mW = sender as View.MainWindow;
            ViewModel.MainWindowViewModel dataContext = mW.DataContext as ViewModel.MainWindowViewModel;
            dataContext.CloseAllWindows();
        }


    }
}
