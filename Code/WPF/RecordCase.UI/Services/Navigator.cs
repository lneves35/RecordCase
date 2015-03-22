using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FirstFloor.ModernUI.Windows.Controls;

namespace RecordCase.UI.Services
{
    public enum Page
    {
        CollectionManager
    }

    public static class Navigator
    {
        private static Dictionary<Page, string> PageResolver = new Dictionary<Page, string>()
        {
            {Page.CollectionManager, "/Pages/CollectionManager.xaml" }
        };

        private static BBCodeBlock _BBCodeBlock;
        private static BBCodeBlock BBCodeBlock
        {
            get
            {
                if (_BBCodeBlock == null)
                {
                    _BBCodeBlock = new BBCodeBlock();
                }
                return _BBCodeBlock;
            }
        }

        public static void Navigate(Page page, FrameworkElement elem)
        {
            BBCodeBlock.LinkNavigator.Navigate(new Uri(PageResolver[page], UriKind.Relative), elem);
        }
    }
}
