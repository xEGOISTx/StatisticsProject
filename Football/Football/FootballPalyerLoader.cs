using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Football.Player;

namespace Football
{
	/// <summary>
	/// Загрузчик футболистов
	/// </summary>
	public class FootballPalyerLoader : IFootballPalyerLoader
	{
		#region Fields
		private string _footballPlayersPath;
		private const string _fileExtension = ".Info";
		#endregion Fields



		#region Constructors
		/// <summary>
		/// Инициализация загрузчика футболистов
		/// </summary>
		/// <param name="playerList"></param>
		public FootballPalyerLoader()
		{
			string currentDirectory = Directory.GetCurrentDirectory();
			_footballPlayersPath = currentDirectory + "\\PlayersInfo\\FootballPlayersInfo\\Players\\";
		}
		#endregion Constructors



		#region Methods
		/// <summary>
		/// Загрузить игроков. Возвращает массив футболистов
		/// </summary>
		/// <returns></returns>
		public IFootballPlayer[] LoadPlayers()
		{
			List<IFootballPlayer> players = new List<IFootballPlayer>();

            //Костыль
            PlayerEditor plEditor = new PlayerEditor(null);

			if (Directory.Exists(_footballPlayersPath))
			{
				string[] playersPath = Directory.GetFiles(_footballPlayersPath);

				if (playersPath.Length > 0)
				{
					BinaryFormatter formatter = new BinaryFormatter();

					foreach(string path in playersPath)
					{
						using (FileStream fStream = new FileStream(path, FileMode.Open))
						{
                            //Костыль
                           IFootballPlayer pl = plEditor.UpdateParametersNames((FootballPlayer)formatter.Deserialize(fStream));

                            players.Add(pl);
						}
					}

				}
			}
			return players.ToArray();
		}

		/// <summary>
		/// Срхранить футболиста
		/// </summary>
		/// <param name="player"></param>
		public void SavePlayer(IFootballPlayer player)
		{
			if (player != null)
			{
				if (!Directory.Exists(_footballPlayersPath))
				{
					Directory.CreateDirectory(_footballPlayersPath);
				}

				BinaryFormatter formatter = new BinaryFormatter();

				string path = _footballPlayersPath + player.KeyName + _fileExtension;

				using (FileStream fStream = new FileStream(path, FileMode.OpenOrCreate))
				{
					formatter.Serialize(fStream, (FootballPlayer)player);
				}
			}
			else
			{
				throw new NullReferenceException();
			}
		}

		/// <summary>
		/// Удалить Футболиста
		/// </summary>
		/// <param name="player"></param>
		public void DeletePlayer(IFootballPlayer player)
		{
			if (player != null)
			{
				string path = _footballPlayersPath + player.KeyName + _fileExtension;

				if (File.Exists(path))
				{
					File.Delete(path);
				}
			}
		}
		#endregion Methods
	}
}
