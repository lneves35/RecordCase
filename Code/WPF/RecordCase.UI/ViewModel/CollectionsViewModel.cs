using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RecordCase.Collections.Entities;
using RecordCase.UI.Services;

namespace RecordCase.UI.ViewModel
{
    public class CollectionsViewModel : ViewModelBase
    {
        public ObservableCollection<CollectionMetadata> Collections
        {
            get
            {
                return CollectionsService.Collections;
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
                    var collection = new CollectionMetadata()
                    {
                        Name = AddCollectionText,
                        Created = DateTime.Now
                    };
                    CollectionsService.AddRecordCollection(collection);
                }));
            }

        }
        
    }
}
