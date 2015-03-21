using System.Collections.Specialized;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace RecordCase.UI.ViewModel
{    
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand CloseCommand
        {
            get
            {                
                return WPF.UI.App.CloseCommand;
            }

        }
    }
}