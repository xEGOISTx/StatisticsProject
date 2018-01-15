using System;
using System.Collections.Generic;
using System.Windows;

namespace Messages
{
	public enum TitleMessage
	{
		/// <summary>
		/// Не верное заполнение
		/// </summary>
		NotCorrectInput,
		/// <summary>
		/// Игрок уже существует
		/// </summary>
		PlayerExists
	}

	public class ManagingMessages
    {
		List<string> messages = new List<string>();
		string[] titleMessage = new string[]
		{
			"Не верное заполнение","Игрок уже существует"
		};

		/// <summary>
		/// Показать уведомляющее сообщение
		/// </summary>
		/// <param name="title"></param>
		public void ShowMessageNotification(TitleMessage title)
		{
			if (CheckMessages)
			{
				string fullMessage = null;

				foreach (string message in messages)
				{
					fullMessage += message + "\n";
				}

				MessageBox.Show(fullMessage, titleMessage[(int)title], MessageBoxButton.OK, MessageBoxImage.Asterisk);

				messages.Clear();
			}
		}

		/// <summary>
		/// Проверить наличие сообщений
		/// </summary>
		public bool CheckMessages
		{
			get { return (messages.Count == 0) ? false : true; }
		}

		/// <summary>
		/// Добавляет в список сообщений сообщение "недопустимое имя"
		/// </summary>
		public void NotCorrectName()
		{
			messages.Add("Недопустимое имя");
		}

		/// <summary>
		/// Добавляет в список сообщений сообщение "Недопустимый идентификатор"
		/// </summary>
		public void NotCorrectKeyName()
		{
			messages.Add("Недопустимое ключевое имя.\nКлючевое имя может состоять только из латинских букв, цифр, а также допускается символ _");
		}

		public void NoPosition()
		{
			messages.Add("Не выбрана позиция");
		}

		public void MaxActivePlayers()
		{
			messages.Add("Кол-во активных игроков максимум 44.\nДля добавления нового игрока освободите место");
		}

		/// <summary>
		/// Добавляет в список сообщений сообщение "Игрок с ключевым именем уже существует"
		/// </summary>
		/// <param name="keyName"></param>
		public void KeyNameExists(string keyName)
		{
			messages.Add(string.Format("Игрок с ключевым именем '{0}' уже существует", keyName));
		}

	}
}
