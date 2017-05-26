using RepositoryLayer.Interfaces;
using System;

namespace ServiceLayer.Services
{
    public abstract class BaseService
    {
        protected BaseService(IIssueTrackerData data)
        {
            this.Data = data;
        }

        protected IIssueTrackerData Data { get; set; }

        protected void CheckIfNull(object model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "The binding model cannot be null.");
            }
        }
    }
}
