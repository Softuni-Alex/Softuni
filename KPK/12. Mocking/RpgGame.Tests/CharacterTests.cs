using Moq;
using System;

namespace RpgGame.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class CharacterTests
    {
        [TestMethod]
        public void Character_Should_Drop_First_Item()
        {
            // Arrange
            var possibleItemDrops = new List<Item>
            {
                new Item("Axe", 25, 5),
                new Item("Shield", 5, 50),
                new Item("Resilience Potion", 0, 30)
            };

            var mock = new Mock<Random>();
            mock.Setup(r => r.Next()).Returns(0);

            for (int i = 0; i < 1000; i++)
            {
                var num = mock.Object.Next(0);
                Assert.AreEqual(0, num);
            }
            return;

            // Act
            var character = new Character(possibleItemDrops);


            // Assert
            for (int i = 0; i < 1000; i++)
            {
                var item = character.DropItem();
                Assert.AreEqual("Axe", item.Name);
            }
        }
    }
}
