using System;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;
using RecordCase.Collections.Entities;
using RecordCase.UI.Services;

namespace RecordCase.UI.Controls.Forms
{
    /// <summary>
    /// Interaction logic for CollectionForm.xaml
    /// </summary>
    public partial class CollectionForm : UserControl
    {
        public CollectionForm()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CollectionMetadataProperty =
             DependencyProperty.Register("CollectionMetadata", typeof(CollectionMetadata), typeof(CollectionForm));

        public CollectionMetadata CollectionMetadata
        {
            get
            {
                return (CollectionMetadata)GetValue(CollectionMetadataProperty);
            }
            set
            {
                SetValue(CollectionMetadataProperty, value);
            }
        }


        private RelayCommand<FrameworkElement> addCollectionCommand;
        public RelayCommand<FrameworkElement> AddCollectionCommand
        {
            get
            {
                return addCollectionCommand ?? (addCollectionCommand = new RelayCommand<FrameworkElement>((o) =>
                {
                    CollectionsService.AddRecordCollection(CollectionMetadata);
                    CollectionMetadata = new CollectionMetadata();
                    Navigator.Navigate(Services.Page.CollectionManager, o);
                }, (o) => String.IsNullOrEmpty(CollectionMetadata.Error)));
            }

        }
    }
}
