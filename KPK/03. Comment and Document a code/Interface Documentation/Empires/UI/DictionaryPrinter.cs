using System.Collections.Generic;
using System.Text;

namespace Empires.UI
{
    public class DictionaryPrinter
    {

        public static string Print<T>(string label, Dictionary<T, int> dictionary)
        {

            var result = new StringBuilder(label + ":");
            if (dictionary.Count == 0)
                result.Append("\nN/A");
            foreach (var element in dictionary.Keys)
            {
                result.Append("\n--" + element.ToString() + ": " + dictionary[element]);
            }

            return result.ToString();
        }

    }
}
