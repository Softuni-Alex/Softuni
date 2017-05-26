using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpStore.ViewModels
{
    public class EditProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public override string ToString()
        {
            string representation = $"<input hidden=\"hidden\" type=\"number\" name=\"id\" value=\"{Id}\"/>" +
                                    "<label for= \"name\" > Name: </ label >" +
                                    $"<input type=\"text\" id=\"name\" name=\"name\" value=\"{Name}\"/>" +
                                    "<br/>" + 
                                    "<label for= \"price\" > price: </ label >" +
                                    $"<input type=\"number\" id=\"price\" name=\"price\" value=\"{Price}\"/>" +
                                    "<br/>" +
                                    "<label for= \"imageUrl\" > price: </ label >" +
                                    $"<input type=\"text\" id=\"imageUrl\" name=\"imageUrl\" value=\"{ImageUrl}\"/>";
            return representation;
        }
    }
}
