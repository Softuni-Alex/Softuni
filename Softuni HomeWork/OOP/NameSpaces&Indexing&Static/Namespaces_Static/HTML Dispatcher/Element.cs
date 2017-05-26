using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTML_Dispatcher
{
    class ElementBuilder
    {
        private string tag;
        private List<string[]> attributes = new List<string[]>();
        private string content;

        public ElementBuilder(string tag)
        {
            this.Tag = tag;
        }

        public static string operator *(ElementBuilder el, int num)
        {
            if (num < 1)
                throw new ArgumentOutOfRangeException();
            else
            {
                string output = String.Empty;
                string htmlElement = el.ToString();

                for (int i = 0; i < num; i++)
                {
                    output += htmlElement;
                }

                return output;
            }

        }

        public string Tag
        {
            get { return this.tag; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentNullException("The tag can't be empty");
                this.tag = value;
            }
        }

        public void AddAttribute(string attribute, string value)
        {
            string[] temp = new string[2];
            temp[0] = attribute;
            temp[1] = value;
            this.attributes.Add(temp);
        }

        public void AddContent(string content)
        {
            if (String.IsNullOrEmpty(content))
                throw new ArgumentNullException();
            this.content = content;
        }

        public override string ToString()
        {
            string output = "<" + this.tag;

            if (this.attributes.Count() > 0)
            {
                foreach (string[] attr in attributes)
                {
                    output += " " + attr[0] + "=\"" + attr[1] + "\"";
                }
                output += ">";
            }
            else
                output += ">";

            output += this.content + "</" + this.tag + ">";

            return output;
        }
    }
}
