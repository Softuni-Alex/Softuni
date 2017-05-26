using System.Collections.Generic;
using SimpleMVC.App.Models;

namespace SimpleMVC.App.ViewModels
{
    public class PizzasViewModel
    {
        public ICollection<Pizza> PizzaSuggestions { get; set; }
    }
}
