using System.Collections.Generic;
using RecordCase.Collections.Entities;

namespace RecordCase.Collections
{
    public interface ICollectionsContext
    {
        void SaveCollectionMetadata(List<CollectionMetadata> collections);
        List<CollectionMetadata> LoadCollectionMetadata();
    }
}