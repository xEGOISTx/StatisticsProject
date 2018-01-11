using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football.Player;
using Data = System.Collections.Generic.IReadOnlyDictionary<System.DateTime, System.Collections.Generic.IReadOnlyDictionary<Football.Player.FootballPosition, byte>>;

namespace Football.Chart
{
    public class EfficiencyChart : IEfficiencyChart
    {
        public IReadOnlyDictionary<string, byte> GetData(IFootballPlayer player, short countDay, FootballPosition positon)
        {
            if (positon != FootballPosition.Default)
            {
                ChartsDataLoader loader = new ChartsDataLoader();

                IDataPlayerForChart allData = loader.LoadDataForChart(player);

                if (allData == null)
                {
                    return null;
                }

                return Filter(allData, countDay, positon);
            }

            return null;
        }

        private Dictionary<string, byte> Filter(IDataPlayerForChart allData,short countDay, FootballPosition positon)
        {
            DateTime date = (DateTime.Now).Subtract(new TimeSpan(countDay - 1,0,0,0));
               
            Data data = allData.GetDataFromCurrentToSpecifiedDate(date);

            Dictionary<string, byte> filteredData = new Dictionary<string, byte>();


            foreach(var d in data)
            {
                filteredData.Add(d.Key.ToString("dd/MM/yy"), d.Value[positon]);
            }

            return filteredData;
        }
    }
}
