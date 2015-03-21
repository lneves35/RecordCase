using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RecordCase.UI.Entities;
using RecordCase.UI.Properties;
using RecordCase.UI.Services;

namespace RecordCase.UI.ViewModel
{
    public class CollectionsViewModel : ViewModelBase
    {
        public ListCollectionView collections;
        public ListCollectionView Collections
        {
            get
            {
                if (collections == null)
                {
                    collections = new ListCollectionView(CollectionsService.RecordCollections);
                }
                return collections;
            }

        }


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
                return addCollectionCommand ?? (addCollectionCommand = new RelayCommand(() =>
                {
                    CollectionsService.AddRecordCollection(new CollectionMetadata()
                    {
                        Name =  AddCollectionText
                    });

                    Collections.Refresh();
                }));
            }

        }
        
    }
}
