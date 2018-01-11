using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
            var mW = new View.MainWindow() { DataContext = new ViewModel.MainWindowViewModel() };
            mW.Closing += MW_Closing;
            mW.Show();
        }

        private void MW_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            View.MainWindow mW = sender as View.MainWindow;
            ViewModel.MainWindowViewModel dataContext = mW.DataContext as ViewModel.MainWindowViewModel;
            dataContext.CloseAllWindows();
        }
    }
}
