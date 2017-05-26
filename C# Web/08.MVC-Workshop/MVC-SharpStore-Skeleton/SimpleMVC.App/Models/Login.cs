using System.Runtime.Serialization;

namespace SharpStore.Models
{
    public class Login
    {
        public int Id { get; set; }

        public string SessionId { get; set; }

        public virtual User User { get; set; }

        public bool isActive { get; set; }
    }
}
