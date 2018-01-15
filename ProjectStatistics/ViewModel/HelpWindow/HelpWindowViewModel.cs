using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectStatistics.ViewModel.HelpWindow
{
    public class HelpWindowViewModel : WPFHelper.BaseViewModel
    {
        private UserControl _helpContent;
        private string _helpHeader;

        public HelpWindowViewModel()
        {
            ShowAbout = Command(ExecuteShowAbout);
            ShowHelpAddPlayer = Command(ExecuteShowHelpAddPlayer);
            ShowHelpPlayersPanel = Command(ExecuteShowHelpPlayersPanel);
            ShowHelpMovePlayer = Command(ExecuteShowHelpMovePlayer);
            ShowHelpEditor = Command(ExecuteShowHelpEditor);
            ShowHelpField = Command(ExecuteShowHelpField);
            ShowHelpChart = Command(ExecuteShowHelpChart);

            ExecuteShowAbout(null);
        }


        public UserControl HelpContent
        {
            get { return _helpContent; }
            set
            {
                if(_helpContent != value)
                {
                    _helpContent = value;
                    OnPropertyChanged(nameof(HelpContent));
                }
            }
        }

        public string HelpHeader
        {
            get { return _helpHeader; }
            set
            {
                if(_helpHeader != value)
                {
                    _helpHeader = value;
                    OnPropertyChanged(nameof(HelpHeader));
                }
            }
        }

        public ICommand ShowAbout { get; set; }
        private void ExecuteShowAbout(object param)
        {
            HelpContent = new View.HelpWindow.HelpContent.About();
            HelpHeader = "О программе";
        }

        public ICommand ShowHelpAddPlayer { get; set; }
        private void ExecuteShowHelpAddPlayer(object param)
        {
            HelpContent = new View.HelpWindow.HelpContent.HelpAddPlayerView();
            HelpHeader = "Добавление игрока";
        }

        public ICommand ShowHelpPlayersPanel { get; set; }
        private void ExecuteShowHelpPlayersPanel(object param)
        {
            HelpContent = new View.HelpWindow.HelpContent.HelpPlayersPanel();
            HelpHeader = "Панель игрока";
        }

        public ICommand ShowHelpMovePlayer { get; set; }
        private void ExecuteShowHelpMovePlayer(object param)
        {
            HelpContent = new View.HelpWindow.HelpContent.HelpMovePlayer();
            HelpHeader = "Перемещение игрока";
        }

        public ICommand ShowHelpEditor { get; set; }
        private void ExecuteShowHelpEditor(object param)
        {
            HelpContent = new View.HelpWindow.HelpContent.HelpEditorView();
            HelpHeader = "Редактор игроков";
        }

        public ICommand ShowHelpField { get; set; }
        private void ExecuteShowHelpField(object param)
        {
            HelpContent = new View.HelpWindow.HelpContent.HelpFieldView();
            HelpHeader = "Поле";
        }

        public ICommand ShowHelpChart { get; set; }
        private void ExecuteShowHelpChart(object param)
        {
            HelpContent = new View.HelpWindow.HelpContent.HelpChartView();
            HelpHeader = "График";
        }
    }
}
