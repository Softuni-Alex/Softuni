using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading;

namespace _01HarestingFields
{
    class HarvestingFieldsTest
    {
        static void Main()
        {
            string input = Console.ReadLine();
            FieldInfo[] fields =
                typeof(HarvestingFields).GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            while (!input.Equals("HARVEST"))
            {
                switch (input)
                {
                    case "private":
                        GetPrivate(fields);
                        break;
                    case "public":
                        GetPublic(fields);
                        break;
                    case "protected":
                        GetProtected(fields);
                        break;
                    case "all":
                        GetAll(fields);
                        break;
                }
                input = Console.ReadLine();
            }

        }

        private static void GetAll(FieldInfo[] fieldInfo)
        {
            foreach (var field in fieldInfo)
            {
                if (field.IsPrivate)
                {
                    Console.WriteLine($"private {field.FieldType.Name} {field.Name}");
                }
                if (field.IsFamily)
                {
                    Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
                }
                if (field.IsPublic)
                {
                    Console.WriteLine($"public {field.FieldType.Name} {field.Name}");
                }
            }
        }

        private static void GetPublic(FieldInfo[] fieldInfo)
        {
            var publics = fieldInfo.Where(fields => fields.IsPublic);

            foreach (var pub in publics)
            {
                Console.WriteLine($"{pub.Attributes.ToString().ToLower()} {pub.FieldType.Name} {pub.Name}");
            }
        }

        private static void GetProtected(FieldInfo[] fieldInfo)
        {
            var protectedFields = fieldInfo.Where(f => f.IsFamily);

            foreach (var protectedfield in protectedFields)
            {
                Console.WriteLine($"protected {protectedfield.FieldType.Name} {protectedfield.Name}");
            }
        }

        private static void GetPrivate(FieldInfo[] fieldInfo)
        {
            var privateFields = fieldInfo.Where(f => f.IsPrivate);

            foreach (var privateField in privateFields)
            {
                Console.WriteLine($"private {privateField.FieldType.Name} {privateField.Name}");
            }
        }
    }


    public class HarvestingFields
    {
        private int testInt;
        public double testDouble;
        protected string testString;
        private long testLong;
        protected double aDouble;
        public string aString;
        private Calendar aCalendar;
        public StringBuilder aBuilder;
        private char testChar;
        public short testShort;
        protected byte testByte;
        public byte aByte;
        protected StringBuilder aBuffer;
        private BigInteger testBigInt;
        protected BigInteger testBigNumber;
        protected float testFloat;
        public float aFloat;
        private Thread aThread;
        public Thread testThread;
        private object aPredicate;
        protected object testPredicate;
        public object anObject;
        private object hiddenObject;
        protected object fatherMotherObject;
        private string anotherString;
        protected string moarString;
        public int anotherIntBitesTheDust;
        private Exception internalException;
        protected Exception inheritableException;
        public Exception justException;
        public Stream aStream;
        protected Stream moarStreamz;
        private Stream secretStream;
    }
}
