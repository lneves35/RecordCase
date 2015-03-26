using System;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using RecordCase.Collections.Entities;
using RecordCase.UI.Services;
using RecordCase.Core.Utils;

namespace RecordCase.UI.Controls.Collections
{
    /// <summary>
    /// Interaction logic for CollectionList.xaml
    /// </summary>
    public partial class CollectionList
    {
        private static TimeSpan searchDelay = TimeSpan.FromMilliseconds(250);

        public CollectionList()
        {
            InitializeComponent();
        }

        #region Dependency Props

        public static readonly DependencyProperty ItemsSourceProperty =
             DependencyProperty.Register("ItemsSource", typeof(IList), typeof(CollectionList));

        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
             DependencyProperty.Register("SelectedItem", typeof(CollectionMetadata), typeof(CollectionList));

        public CollectionMetadata SelectedItem
        {
            get { return (CollectionMetadata)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }


        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(CollectionList), new PropertyMetadata(OnFilterTextChanged));



        private static void OnFilterTextChanged(DependencyObject source, 
        DependencyPropertyChangedEventArgs e)
        {
            CollectionList control = source as CollectionList;
            control.DeferedRefresh.Defer(searchDelay);
        }


        public string FilterText
        {
            get
            {
                return (string)GetValue(FilterTextProperty);
            }
            set
            {
                SetValue(FilterTextProperty, value);
            }
        }

        #endregion Dependency Props


        //List Collection view
        private ICollectionView itemsSourceView;
        public ICollectionView ItemsSourceView
        {
            get
            {
                if (itemsSourceView == null)
                {
                    itemsSourceView = new ListCollectionView(ItemsSource);


                    itemsSourceView.Filter += delegate(object item)
                    {
                        var m = (CollectionMetadata)item;
                        
                        //Filter by Artist                        
                        if (FilterText!=null && m.Name.IndexOf(FilterText, StringComparison.OrdinalIgnoreCase) == -1)
                            return false;
                        return true;
                    };
                }
                return itemsSourceView;
            }
        }



        private DeferredAction deferedRefresh;
        public DeferredAction DeferedRefresh
        {
            get
            {
                if (deferedRefresh == null)
                    deferedRefresh = DeferredAction.Create(() => ItemsSourceView.Refresh());
                return deferedRefresh;
            }
        }


        //Colocar Events e colocar comandos fora da lista

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
