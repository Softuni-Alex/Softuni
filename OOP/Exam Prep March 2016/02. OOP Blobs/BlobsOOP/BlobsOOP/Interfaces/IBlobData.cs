using System.Collections.Generic;

namespace BlobsOOP.Interfaces
{
    public interface IBlobData
    {
        IEnumerable<IBlob> Blobs { get; }

        void AddBlob(IBlob blob);
    }
}
