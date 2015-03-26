using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace RecordCase.WPFControls.Text
{
    /// <summary>
    /// Interaction logic for RcTextBox.xaml
    /// </summary>
    public partial class RcTextBox
    {
        public RcTextBox()
        {
            InitializeComponent();
        }


        public static readonly DependencyProperty FilterProperty =
             DependencyProperty.Register("Filter", typeof(string), typeof(RcTextBox));

        public string Filter
        {
            get
            {
                return (string)GetValue(FilterProperty);
            }
            set
            {
                SetValue(FilterProperty, value);
            }
        }

        private void ClrBtn_OnClick(object sender, RoutedEventArgs e)
        {
            Filter = String.Empty;
        }
    }
}
