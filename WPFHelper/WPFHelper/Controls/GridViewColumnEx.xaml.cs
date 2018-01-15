using System;
using System.Windows;
using System.Windows.Controls;


namespace WPFHelper.Controls
{
    /// <summary>
    /// Логика взаимодействия для GridViewColumnEx.xaml
    /// </summary>
    public partial class GridViewColumnEx : UserControl
    {
        private bool _isAscending;
        private bool _isLocal;

        public GridViewColumnEx()
        {
            InitializeComponent();
        }



        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(GridViewColumnEx), new PropertyMetadata(TextChanged));

        private static void TextChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            GridViewColumnEx gVC = (GridViewColumnEx)depObj;
            gVC.toggButt.Content = args.NewValue.ToString();
        }

        public bool IsAscending
        {
            get{ return (bool)GetValue(IsAscendingProperty);}
            set
            {
                //_isAscending = value;
                SetValue(IsAscendingProperty, value);
            }
        }

        public static readonly DependencyProperty IsAscendingProperty =
            DependencyProperty.Register("IsAscending", typeof(bool), typeof(GridViewColumnEx)
              ,new PropertyMetadata(true));



        public string SortPropertyName
        {
            get { return (string)GetValue(SortPropertyNameProperty); }
            set{ SetValue(SortPropertyNameProperty, value);}
        }

        public static readonly DependencyProperty SortPropertyNameProperty =
            DependencyProperty.Register("SortPropertyName", typeof(string), typeof(GridViewColumnEx));


        public string CurrentSortPropertyName
        {
            get { return (string)GetValue(CurrentSortPropertyNameProperty); }
            set
            {

                SetValue(CurrentSortPropertyNameProperty, value);
            }
        }

        public static readonly DependencyProperty CurrentSortPropertyNameProperty =
            DependencyProperty.Register("CurrentSortPropertyName", typeof(string), typeof(GridViewColumnEx), new PropertyMetadata(CurrentSortPropertyNameChanged));

        

        private static void CurrentSortPropertyNameChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            GridViewColumnEx gVC = (GridViewColumnEx)depObj;

            if (args.NewValue != null)
            {
                if (gVC._isLocal == false)
                {
                    if (gVC.SortPropertyName == args.NewValue.ToString())
                    {
                        ResourceDictionary rd = gVC.Resources;
                        (rd["up"] as Viewbox).Visibility = Visibility.Visible;
                        (rd["down"] as Viewbox).Visibility = Visibility.Visible;

                        if (gVC._isAscending == true)
                        {
                            gVC.IsAscending = false;
                            gVC.toggButt.IsChecked = false;
                            gVC._isAscending = false;
                        }
                        else
                        {
                            gVC.IsAscending = true;
                            gVC.toggButt.IsChecked = true;
                            gVC._isAscending = true;
                        }
                    }
                    else if (args.NewValue.ToString() != string.Empty)
                    {
                        ResourceDictionary rd = gVC.Resources;
                        (rd["up"] as Viewbox).Visibility = Visibility.Hidden;
                        (rd["down"] as Viewbox).Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    gVC._isLocal = false;
                }
            }
            else
            {
                gVC._isLocal = true;
            }
        }
    }
}
