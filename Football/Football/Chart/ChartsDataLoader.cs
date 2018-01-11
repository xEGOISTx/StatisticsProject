using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football.Player;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Football.Chart
{
    public class ChartsDataLoader : IChartsDataLoader
    {

        private const string _fileExtension = ".Info";
        private string _chartsDataPath;

        public ChartsDataLoader()
        {
            string _currentDirectory = Directory.GetCurrentDirectory();
            _chartsDataPath = _currentDirectory + "\\PlayersInfo\\FootballPlayersInfo\\ChartsData\\";
        }

        public IDataPlayerForChart LoadDataForChart(IFootballPlayer player)
        {
            if(Directory.Exists(_chartsDataPath))
            {
                string dataForPlayerPaht = _chartsDataPath + player.KeyName + _fileExtension;

                if(File.Exists(dataForPlayerPaht))
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    using (FileStream fs = new FileStream(dataForPlayerPaht, FileMode.Open))
                    {
                        return (IDataPlayerForChart)formatter.Deserialize(fs);
                    }
                }
            }
            return null;
        }

        public void SaveDataForChart(IDataPlayerForChart data)
        {
            if (!Directory.Exists(_chartsDataPath))
            {
                Directory.CreateDirectory(_chartsDataPath);
            }

            string dataForPlayerPaht = _chartsDataPath + data.PlayerKeyName + _fileExtension;

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(dataForPlayerPaht, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, data);
            }
        }

        public void RemoveDataForChart(IFootballPlayer player)
        {
            if(Directory.Exists(_chartsDataPath))
            {
                if(File.Exists(_chartsDataPath + player.KeyName + _fileExtension))
                {
                    File.Delete(_chartsDataPath + player.KeyName + _fileExtension);
                }
            }
        }
    }
}
