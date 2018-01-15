using System;

namespace BasicInfirmationProject
{
	/// <summary>
	/// Содержит информацию о проэкте
	/// </summary>
    public static class BasicInformation
    {
		/// <summary>
		/// Полное имя программы. Возврвщает название ,статус и версию сборки одной строкой
		/// </summary>
		public static string FullName
		{
			get
			{
				string fullName = "Statistics Project. Alpha";

				return string.Format("{0} v.{1}", fullName, typeof(BasicInformation).Assembly.GetName().Version.ToString());
			}
		}
    }
}
