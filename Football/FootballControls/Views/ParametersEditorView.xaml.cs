using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FootballControls.Views
{
	/// <summary>
	/// Логика взаимодействия для ParametersEditorView.xaml
	/// </summary>
	public partial class ParametersEditorView : UserControl
	{

		public ParametersEditorView()
		{
			InitializeComponent();
		}

		//private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		//{
		//	const char comma = (char)44;
		//	TextBox tB = (sender as TextBox);
		//	char ch = char.Parse(e.Text.Replace('.',','));

		//	if (!char.IsDigit(ch) && ch != comma)
		//	{
		//		e.Handled = true;
		//	}

		//		if ((ch == comma) && ((tB.Text.IndexOf(comma) != -1) || (tB.Text.IndexOf('.') != -1) || (tB.Text == string.Empty)))
		//	{
		//		e.Handled = true;
		//	}

		//}

		//private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		//{
		//	const char comma = (char)44;
		//	TextBox tB = (sender as TextBox);

		//	bool presetnComma = false;
		//	byte sStart = (byte)tB.SelectionStart;
		//	string text = tB.Text.Replace('.', ',');
		//	string newText = string.Empty;

		//	foreach (char ch in text)
		//	{
		//		if (char.IsDigit(ch))
		//		{
		//			newText += ch;
		//		}
		//		else
		//		{
		//			if (ch == comma & !presetnComma & text.IndexOf(ch) != 0)
		//			{
		//				newText += ch;
		//				presetnComma = true;
		//			}
		//		}
		//	}
		//	tB.Text = newText;
		//	tB.SelectionStart = sStart;
		//}

		private void int_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox tB = (sender as TextBox);
			byte sStart = (byte)tB.SelectionStart;
			string newText = string.Empty;

			if (tB.Text != string.Empty)
			{
				foreach (char ch in tB.Text)
				{
					if (char.IsDigit(ch))
					{
						newText += ch;
					}
				}
			}
			else
			{
				newText = "0";
				sStart = 1;
			}

			tB.Text = newText;
			tB.SelectionStart = sStart;
		}
	}
}
