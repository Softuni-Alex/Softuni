using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Web.Script.Serialization;

namespace Tests
{
    public class JsonTest
    {
        public static void Main(string[] args)
        {
            Child child = new Child(1, "Alex", 20);
            child.Children.Add(new Child(2, "Elica", 18));
            //
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            var objToJson = serializer.Serialize(child);
            //            var jsonToObj = serializer.Deserialize<Child>(objToJson);
            //
            //            Console.WriteLine(objToJson);
            //            Console.WriteLine(jsonToObj.Name);
            //
            //            Dictionary<string, int> digits = new Dictionary<string, int>()
            //            {
            //                {"one", 1},
            //                {"two", 2}
            //            };

            //            var serializer = new JavaScriptSerializer();
            //
            //            var objToJson = serializer.Serialize(digits);
            //            var jsonToObj = serializer.Deserialize<Dictionary<string, int>>(objToJson);
            //
            //            Console.WriteLine(objToJson);
            //            Console.WriteLine(string.Join(" ", jsonToObj.Values));

            //NEWTONJSON
            //            //serialize
            //            var childer = JsonConvert.SerializeObject(child, Formatting.Indented);
            //            Console.WriteLine(childer);
            //
            //            //deserialize
            //            var objToJson = JsonConvert.SerializeObject(child);
            //            var template = new
            //            {
            //                User = string.Empty,
            //                Age = 0,
            //                Id = 0
            //            };
            //
            //            var obj = JsonConvert.DeserializeAnonymousType(objToJson, template);
            //
            //            Console.WriteLine(obj.User);

            var jsonObj = JObject.Parse(objToJson);
            Console.WriteLine("Places in {0}:", jsonObj["User"]);

            int index = 1;
            jsonObj["places"].Select(
                pl =>
                    string.Format("{0} {1} {2}", index++, pl["id"],
                        string.Join(", ", pl["Children"].Select(cat => cat["User"]))));
        }
    }
}