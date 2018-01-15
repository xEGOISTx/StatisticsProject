using System;
using System.Windows;

namespace ProjectStatistics.View.LicenseWindow
{
    /// <summary>
    /// Логика взаимодействия для LicenseWindowView.xaml
    /// </summary>
    public partial class LicenseWindowView : Window
    {
        public LicenseWindowView()
        {
            InitializeComponent();
        }


        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonAccept_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.LicenseAccepted = true;
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
