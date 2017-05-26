using System;
using System.Linq;
using System.Reflection;
using BlobsOOP.Interfaces;

namespace BlobsOOP.Engine.Factories
{
    public class AttackFactory : IAttackFactory
    {
        private const string ExceptionMessage = "Unknown attack type";

        public IAttack Create(string attackName)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == attackName);

            if (type == null)
            {
                throw new ArgumentException(ExceptionMessage);
            }

            var attack = Activator.CreateInstance(type);

            return attack as IAttack;
        }
    }
}
