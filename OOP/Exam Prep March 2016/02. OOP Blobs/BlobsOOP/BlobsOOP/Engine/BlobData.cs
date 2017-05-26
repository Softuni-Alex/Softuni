using System.Collections.Generic;
using BlobsOOP.Interfaces;

namespace BlobsOOP.Engine
{
    public class BlobData : IBlobData
    {
        private readonly ICollection<IBlob> blobs;

        public BlobData(ICollection<IBlob> blobs)
        {
            this.blobs = blobs;
        }

        public IEnumerable<IBlob> Blobs
        {
            get
            {
                return this.blobs;
            }
        }

        public void AddBlob(IBlob blob)
        {
            this.blobs.Add(blob);
        }
    }
}
