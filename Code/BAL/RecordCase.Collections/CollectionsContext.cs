using System.Collections.Generic;
using System.IO;
using LinqKit;
using RecordCase.Collections.Entities;
using RecordCase.Core.Filesystem;
using RecordCase.Core.Validation;
using RecordCase.Core.WPF;

namespace RecordCase.Collections
{
    public class CollectionsContext : ICollectionsContext
    {
        private readonly string collectionsMetadataFilename;

        public CollectionsContext(string collectionsMetadataFilename)
        {
            this.collectionsMetadataFilename = collectionsMetadataFilename;

            var ValidationRulesEngine = new ValidationRulesEngine();
            ValidationRulesEngine.AddValidation(PredicateBuilder.True<CollectionMetadata>().And(c => !string.IsNullOrWhiteSpace(c.Name)), "Collection name required.", "Name");
            ViewModelBaseValidating.AddValidationRulesEngine(ValidationRulesEngine);
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
