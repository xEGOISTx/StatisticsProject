using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football.Player;

namespace Football.Chart
{
    public interface IChartsDataLoader
    {
        void SaveDataForChart(IDataPlayerForChart data);

        IDataPlayerForChart LoadDataForChart(IFootballPlayer player);
    }
}
