using SharpStore.Data;

namespace SharpStore.Services
{
    public abstract class Service
    {
        protected SharpStoreContext context;
        public Service(SharpStoreContext context)
        {
            this.context = context;
        }
    }
}
