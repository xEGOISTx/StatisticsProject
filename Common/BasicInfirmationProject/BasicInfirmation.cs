using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BasicInfirmationProject
{
	/// <summary>
	/// Содержит информацию о проэкте
	/// </summary>
    public static class BasicInfirmation
    {
		/// <summary>
		/// Полное имя программы. Возврвщает название ,статус и версию сборки одной строкой
		/// </summary>
		public static string FullName
		{
			get
			{
				string fullName = "Statistics Project. Alpha";

				return string.Format("{0} v.{1}", fullName, typeof(BasicInfirmation).Assembly.GetName().Version.ToString());
			}
		}
    }
}
