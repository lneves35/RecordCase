using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RecordCase.UI.Services;

namespace RecordCase.UI.ViewModel
{
    public class CollectionsViewModel : ViewModelBase
    {
        private string addCollectionText;
        public string AddCollectionText
        {
            get
            {
                return addCollectionText;
            }

            set
            {
                addCollectionText = value;
                RaisePropertyChanged("AddCollectionText");
            }
        }

        private RelayCommand addCollectionCommand;
        public RelayCommand AddCollectionCommand
        {
            get
            {
                return addCollectionCommand ?? (addCollectionCommand = new RelayCommand(() => { SettingsService.AddDatabase(AddCollectionText); }));
            }

        }
        
    }
}
