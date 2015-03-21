using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordCase.CollectionModels;
using RecordCase.Core.Extensions;
using RecordCase.Core.Filesystem;
using RecordCase.Core.System;
using RecordCase.Repository;
using RecordCase.UI.Entities;

namespace RecordCase.UI.Services
{
    public class CollectionsService
    {
        public static List<CollectionMetadata> RecordCollections { get; set; }

        private static string collectionsMetadataFilename = AppProps.AppDataFolder + "collections.dat";


        static CollectionsService()
        {
            LoadCollectionMetadata();
        }

           

        public CollectionMetadata AddCollection()
        {

        }

    }
}
