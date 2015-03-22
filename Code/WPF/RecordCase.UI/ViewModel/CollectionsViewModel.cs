using System;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using RecordCase.Collections.Entities;
using RecordCase.Core.Extensions;
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
                }, (o) => String.IsNullOrEmpty(NewCollectionMetadata.Error)));
            }

        }


        private RelayCommand openImageFileCommand;
        public RelayCommand OpenImageFileCommand
        {
            get
            {
                return openImageFileCommand ?? (openImageFileCommand = new RelayCommand(() =>
                {
                    var openFileDialog = new OpenFileDialog();
                    openFileDialog.Multiselect = false;
                    openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    if (openFileDialog.ShowDialog() == true)
                    {
                        NewCollectionMetadata.Image = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute)).ToByteArray();
                    }
                }));
            }

        }
    }
}
