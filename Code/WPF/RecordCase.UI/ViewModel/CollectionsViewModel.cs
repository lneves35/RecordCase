using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
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

    }
}
