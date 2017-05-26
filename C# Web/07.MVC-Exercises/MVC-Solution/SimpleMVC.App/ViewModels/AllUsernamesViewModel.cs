using System.Collections.Generic;

namespace SimpleMVC.App.ViewModels
{
    public class AllUsernamesViewModel
    {
        public int UserId { get; set; }

        public IList<string> Usernames { get; set; }
    }
}

