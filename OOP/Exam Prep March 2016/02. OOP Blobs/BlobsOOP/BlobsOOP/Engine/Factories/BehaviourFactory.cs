using System;
using System.Linq;
using System.Reflection;
using BlobsOOP.Interfaces;

namespace BlobsOOP.Engine.Factories
{
    public class BehaviorFactory : IBehaviorFactory
    {
        private const string ExceptionMessage = "Unknown behaviors type";

        public IBehavior Create(string behaviorName)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == behaviorName);

            if (type == null)
            {
                throw new ArgumentException(ExceptionMessage);
            }

            var behavior = Activator.CreateInstance(type);

            return behavior as IBehavior;
        }
    }
}
