using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WPFHelper;
using Football.Chart;
using Football.Player;
using LiveCharts;

namespace FootballControls.ViewModels.Chart
{
    public class ChartViewModel : BaseViewModel
    {
        private IEfficiencyChart _chart;
        private int _position;
        private ObservableCollection<int> _positions = new ObservableCollection<int>();
        private ObservableCollection<short> _periods;
        private short _period = 7;
        private IFootballPlayer _player;
        private ChartValues<int> _values = new ChartValues<int>();
        private IEnumerable<string> _dates = new List<string>(0);

        public ChartViewModel(IEfficiencyChart chart)
        {
            _chart = chart;
            Init();
        }

        public bool PresentPlayer
        {
            get { return _player != null; }
        }

        public int Position
        {
            get { return _position; }
            set
            {
                if(_position != value)
                {
                    _position = value;
                    LoadData();
                }
            }
        }

        public short Period
        {
            get { return _period; }
            set
            {
                if(_period != value)
                {
                    _period = value;
                    LoadData();
                }
            }
        }

        public ChartValues<int> Values
        {       
            get { return _values; }
        }

        public string[] Dates
        {
            get { return _dates.ToArray(); }
        }

        public ObservableCollection<int> Positions
        {
            get { return _positions; }
        }

        public ObservableCollection<short> Periods
        {
            get { return _periods; }
        }

        public double MinWidthChart
        {
            get { return 100 + Values.Count * 100; }
        }

        private void Init()
        {
            foreach(int pos in Enum.GetValues(typeof(FootballPosition)))
            {
                _positions.Add(pos);
            }

            _periods = new ObservableCollection<short>()
            {
                7,30,90,180,360
            };
        }

        public void SetPlayer(IFootballPlayer player)
        {
            if (player != null)
            {
                _player = player;
                _position = (int)player.BasicPlayPosition;
                LoadData();

            }
            else
            {
                Clear();
            }

        }

        public void Clear()
        {
            _player = null;
            _values.Clear();
            _dates = new List<string>(0);
            _position = 0;
            Update();
        }

        private void LoadData()
        {
            if(_player != null)
            {
                IReadOnlyDictionary<string, byte> data = _chart.GetData(_player, Period, (FootballPosition)Position);

                _values.Clear();
                _dates = new List<string>(0);

                if (data != null)
                {                  
                    foreach (byte val in data.Values)
                    {
                        _values.Add((int)val);
                    }

                    _dates = data.Keys;
                }

                Update();
            }
        }

        private void Update()
        {
            OnPropertyChanged(nameof(Position));
            OnPropertyChanged(nameof(Values));
            OnPropertyChanged(nameof(Dates));
            OnPropertyChanged(nameof(MinWidthChart));
            OnPropertyChanged(nameof(PresentPlayer));
        }
    }
}
