using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RecordCase.Collections;
using RecordCase.Collections.Entities;
using RecordCase.Core.System;

namespace RecordCase.UI.Services
{
    public static class CollectionsService
    {
        private static string collectionsMetadataFilename = AppProps.AppDataFolder + "\\collections.dat";

        private static ICollectionsContext collectionsContext;
        private static ICollectionsContext CollectionsContext
        {
            get
            {
                if(collectionsContext==null)
                    collectionsContext = new CollectionsContext(collectionsMetadataFilename);
                return collectionsContext;
            }
        }

        private static ObservableCollection<CollectionMetadata> collections;
        public static ObservableCollection<CollectionMetadata> Collections
        {
            get
            {
                if (collections == null)
                    collections = new ObservableCollection<CollectionMetadata>(CollectionsContext.LoadCollectionMetadata());
                return collections;
            }            
        }

        public static void AddRecordCollection(CollectionMetadata collection)
        {
            collection.Created = DateTime.Now;
            Collections.Add(collection);
        }


        public static void DeleteRecordCollection(CollectionMetadata collection)
        {
            Collections.Remove(collection);
        }

        public static void SaveRecordCollection()
        {
            CollectionsContext.SaveCollectionMetadata(Collections.ToList());
        }
    }
}
