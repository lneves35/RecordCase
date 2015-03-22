using System;
using System.Collections.ObjectModel;
using System.Windows;
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


        private CollectionMetadata _newCollectionMetadata;
        public CollectionMetadata NewCollectionMetadata
        {
            get
            {
                if (_newCollectionMetadata == null)
                    _newCollectionMetadata = new CollectionMetadata();
                return _newCollectionMetadata;
            }

            set
            {
                if (_newCollectionMetadata != value)
                {
                    _newCollectionMetadata = value;
                    RaisePropertyChanged("NewCollectionMetadata");
                }

            }


        }

        private RelayCommand<FrameworkElement> addCollectionCommand;
        public RelayCommand<FrameworkElement> AddCollectionCommand
        {
            get
            {
                return addCollectionCommand ?? (addCollectionCommand = new RelayCommand<FrameworkElement>((o) =>
                {
                    CollectionsService.AddRecordCollection(NewCollectionMetadata);
                    NewCollectionMetadata = new CollectionMetadata();
                    Navigator.Navigate(Page.CollectionManager, o);
                }));
            }

        }
        
    }
}
