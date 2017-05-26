using System;
using System.Reflection;

namespace _02BlackBoxInteger
{
    public class BlackBoxIntegerTests
    {
        public static void Main(string[] args)
        {
            var blackBox = typeof(BlackBoxInt)
                .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[0], null);

            var instance = (BlackBoxInt)blackBox.Invoke(null);

            MethodInfo method = typeof(BlackBoxInt).GetMethod("Add", BindingFlags.NonPublic | BindingFlags.Instance);
        }
    }
}
