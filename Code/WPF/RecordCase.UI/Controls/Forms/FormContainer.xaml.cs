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

namespace RecordCase.UI.Controls.Forms
{
    /// <summary>
    /// Interaction logic for FormContainer.xaml
    /// </summary>
    public partial class FormContainer
    {
        public FormContainer()
        {
            InitializeComponent();
        }


        public static readonly DependencyProperty TitleProperty =
             DependencyProperty.Register("Title", typeof(string), typeof(FormContainer));

        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }
    }
}
