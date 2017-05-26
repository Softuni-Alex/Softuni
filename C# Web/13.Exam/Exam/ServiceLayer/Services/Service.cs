using RepositoryLayer.Interfaces;
using System;

namespace ServiceLayer.Services
{
    public abstract class Service
    {
        protected Service(ISoftuniStoreData data)
        {
            this.Data = data;
        }

        protected ISoftuniStoreData Data { get; set; }

        protected void CheckIfNull(object model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "The binding model cannot be null.");
            }
        }
    }
}
