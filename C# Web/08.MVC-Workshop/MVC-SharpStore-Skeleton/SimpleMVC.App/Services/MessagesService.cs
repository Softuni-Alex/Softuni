using SharpStore.BindingModels;
using SharpStore.Data;
using SharpStore.Models;

namespace SharpStore.Services
{
    class MessagesService : Service
    {
        public MessagesService(SharpStoreContext context) : base(context) { }

        public void AddMessageFromBind(MessageBinding binding)
        {             
            Message message = new Message()
            {
                Email = binding.Email,
                MessageText = binding.Message,
                Subject = binding.Subject
            };

            this.context.Messages.Add(message);
            this.context.SaveChanges();
        }
    }
}
