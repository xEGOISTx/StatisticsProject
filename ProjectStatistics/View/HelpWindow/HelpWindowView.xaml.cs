using System;
using System.Windows;

namespace ProjectStatistics.View.HelpWindow
{
    /// <summary>
    /// Логика взаимодействия для HelpWindowView.xaml
    /// </summary>
    public partial class HelpWindowView : Window
    {
        public HelpWindowView()
        {
            InitializeComponent();
            DataContext = new ViewModel.HelpWindow.HelpWindowViewModel();
        }

    }
}
