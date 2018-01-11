using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football.Player;

namespace Football.Chart
{
    /// <summary>
    /// Интерфейс диаграммы эффективности 
    /// </summary>
    public interface IEfficiencyChart
    {
        IReadOnlyDictionary<string, byte> GetData(IFootballPlayer player,short countDay, FootballPosition positon);
    }
}
