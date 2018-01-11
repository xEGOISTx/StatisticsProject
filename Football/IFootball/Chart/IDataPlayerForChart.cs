using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football.Player;
using System.Collections;

namespace Football.Chart
{
    public interface IDataPlayerForChart
    {
        bool PresentDate(DateTime dateTime);

        string PlayerKeyName { get; }

        IReadOnlyDictionary<FootballPosition, byte> GetByDate(DateTime dateTime);

        IReadOnlyDictionary<DateTime, IReadOnlyDictionary<FootballPosition, byte>> GetDataFromCurrentToSpecifiedDate(DateTime dateTime);

        void AddData(Dictionary<FootballPosition, byte> newData);
    }
}
