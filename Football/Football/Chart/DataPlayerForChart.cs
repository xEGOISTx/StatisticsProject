using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football.Player;
using System.Collections.ObjectModel;
using System.Collections;

namespace Football.Chart
{
    [Serializable]
    public class DataPlayerForChart : IDataPlayerForChart
    {
        private Dictionary<DateTime, Dictionary<FootballPosition, byte>> _data = new Dictionary<DateTime, Dictionary<FootballPosition, byte>>();

        public DataPlayerForChart(string playerKeyName)
        {
            PlayerKeyName = playerKeyName;
        }
        public string PlayerKeyName { get; }


        public bool PresentDate(DateTime dateTime)
        {
            return _data.ContainsKey(ResetTime(dateTime));
        }

        public void AddData(Dictionary<FootballPosition, byte> newData)
        {
            DateTime date = ResetTime(DateTime.Now);

            if (PresentDate(date))
            {
                Dictionary<FootballPosition, byte> dataValues = _data[date];
               
                foreach (var newValue in newData)
                {
                    dataValues[newValue.Key] = newValue.Value;
                }
            }
            else
            {
                _data.Add(ResetTime(DateTime.Now), newData);


                DateTime minDate = date - new TimeSpan(365, 0, 0, 0);
                List<DateTime> removedData = new List<DateTime>();

                foreach(var data in _data)
                {
                    if(data.Key < minDate)
                    {
                        removedData.Add(data.Key);
                    }
                    else
                    {
                        break;
                    }
                }

                if(removedData.Count > 0)
                {
                    foreach(DateTime d in removedData)
                    {
                        _data.Remove(d);
                    }
                }
            }      
        }

        public IReadOnlyDictionary<FootballPosition, byte> GetByDate(DateTime dateTime)
        {
            return _data[ResetTime(dateTime)];
        }

        public IReadOnlyDictionary<DateTime, IReadOnlyDictionary<FootballPosition, byte>> GetDataFromCurrentToSpecifiedDate(DateTime dateTime)
        {
            DateTime date = ResetTime(dateTime);
            Dictionary<DateTime, IReadOnlyDictionary<FootballPosition, byte>> d = new Dictionary<DateTime, IReadOnlyDictionary<FootballPosition, byte>>();

            foreach(var pair in _data)
            {
                if(pair.Key >= date)
                {
                    d.Add(pair.Key, pair.Value);
                }
            }
            return d;
        }

        private DateTime ResetTime(DateTime dateTime)
        {
            
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
        }


    }
}
