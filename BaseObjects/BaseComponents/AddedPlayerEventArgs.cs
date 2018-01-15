using System;

namespace BaseObjects.BaseComponents
{
	/// <summary>
	/// Обработчик события "добавлен игрок" 
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	public delegate void AddedPlayerEventHandler(object sender, AddedPlayerEventArgs e);

	/// <summary>
	/// Предоставляет данные о событи "добавлен игрок"
	/// </summary>
    public class AddedPlayerEventArgs : EventArgs
    {
		private string _keyNamePLayer;

		/// <summary>
		/// Инициализации экземрляра AddedPlayerEventArgs
		/// </summary>
		/// <param name="keyNamePLayer"></param>
		public AddedPlayerEventArgs(string keyNamePLayer)
		{
			_keyNamePLayer = keyNamePLayer;
		}

		/// <summary>
		/// Возвращает ключевое имя нового игрока
		/// </summary>
		public string KeyNamePLayer
		{
			get { return _keyNamePLayer; }
		}
    }
}
