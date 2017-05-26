using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace DirectoryTraversal.Tests
{
    [TestClass]
    public class DIrectoryTraverserTests
    {
        [TestMethod]
        public void GetChildDirectories_ShouldReturnDirectoryNames()
        {
            //Arange
            var fakeDirectoryProvider = new FakeDirectoryProviderComplexPaths();
            var traverser = new DirectoryTraverser(string.Empty, fakeDirectoryProvider);

            var expectedDirectories = new string[]
            {
                "bin",
                "nonempty",
            };

            Array.Sort(expectedDirectories);

            //Act
            var childDirectories = traverser.GetChildDirectories().ToArray();

            //Assert 
            CollectionAssert.AreEqual(expectedDirectories, childDirectories);
        }

        [TestMethod]
        public void GetChilsDirectories_ShouldCorrectlySortPaths()
        {
            var fakeDirectoryProvider = new FakeUnsortedPaths();
            var traverser = new DirectoryTraverser(string.Empty, fakeDirectoryProvider);

            var expectedDirectories = fakeDirectoryProvider.GetDirectories(string.Empty);

            Array.Sort(expectedDirectories);

            //Act
            var childDirectories = traverser.GetChildDirectories().ToArray();

            //Assert 
            CollectionAssert.AreEqual(expectedDirectories, childDirectories);
        }
    }
}
