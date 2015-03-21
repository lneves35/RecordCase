using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordCase.Collections.Entities;
using RecordCase.Core.Filesystem;

namespace RecordCase.Collections
{
    public class CollectionsContext : ICollectionsContext
    {
        private readonly string collectionsMetadataFilename;

        public CollectionsContext(string collectionsMetadataFilename)
        {
            this.collectionsMetadataFilename = collectionsMetadataFilename;
        }

        public void SaveCollectionMetadata(List<CollectionMetadata> collections)
        {
            FileIO.SerializeObject(collections, collectionsMetadataFilename);
        }

        public List<CollectionMetadata> LoadCollectionMetadata()
        {
            if (File.Exists(collectionsMetadataFilename))
                return FileIO.DeSerializeObject<List<CollectionMetadata>>(collectionsMetadataFilename);
            else
                return new List<CollectionMetadata>();
        }     
    }
}
