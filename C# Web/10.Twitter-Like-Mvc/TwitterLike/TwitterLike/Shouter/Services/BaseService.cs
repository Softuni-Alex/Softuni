using System;

namespace Shouter.Services
{
    public abstract class BaseService
    {
        protected BaseService(Data.Data data)
        {
            this.Data = data;
        }

        protected Data.Data Data { get; set; }

        protected void CheckModelForNull(object model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "The input model cannot be null");
            }
        }
    }
}
