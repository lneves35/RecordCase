using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;
using RecordCase.Collections.Entities;
using RecordCase.UI.Services;

namespace RecordCase.UI.Controls.Collections
{
    /// <summary>
    /// Interaction logic for CollectionList.xaml
    /// </summary>
    public partial class CollectionList
    {
        public CollectionList()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ItemsSourceProperty =
             DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(CollectionList));

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }





        public static readonly DependencyProperty SelectedItemProperty =
             DependencyProperty.Register("SelectedItem", typeof(CollectionMetadata), typeof(CollectionList));

        public CollectionMetadata SelectedItem
        {
            get { return (CollectionMetadata)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }


        private RelayCommand<CollectionMetadata> deleteCommand;
        public RelayCommand<CollectionMetadata> DeleteCommand
        {
            get
            {
                return deleteCommand ?? (deleteCommand = new RelayCommand<CollectionMetadata>((o) =>
                {
                    CollectionsService.DeleteRecordCollection(o);
                }));
            }

        }

        private RelayCommand<CollectionMetadata> editCommand;
        public RelayCommand<CollectionMetadata> EditCommand
        {
            get
            {
                return editCommand ?? (editCommand = new RelayCommand<CollectionMetadata>((o) =>
                {
                    //CollectionsService.DeleteRecordCollection(o);
                }));
            }

        }
        
    }
}
