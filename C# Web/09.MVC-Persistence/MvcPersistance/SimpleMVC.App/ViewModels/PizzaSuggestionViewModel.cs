using System.Collections.Generic;
using SimpleMVC.App.Models;

namespace SimpleMVC.App.ViewModels
{
    public class PizzaSuggestionViewModel
    {
        public string Email { get; set; }

        public ICollection<Pizza> PizzaSuggestions { get; set; }
    }
}
