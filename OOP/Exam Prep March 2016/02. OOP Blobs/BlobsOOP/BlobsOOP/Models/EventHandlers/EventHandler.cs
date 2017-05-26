using BlobsOOP.Models.Events;

namespace BlobsOOP.Models.EventHandlers
{
    public class EventHandler
    {

        public delegate void BehaviorToggledEventHandler(object sender, BehaviorToggledEventArgs e);

        public delegate void BlobDeadEventHandler(object sender, BlobDeadEventArgs e);
    }
}
