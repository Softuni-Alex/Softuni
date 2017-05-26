namespace TestHotelBookingSystem
{
    using HotelBookingSystem.Data;
    using HotelBookingSystem.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RepositoryTests
    {
        private Repository<Venue> repository;

        [TestInitialize]
        public void TestInit()
        {
            this.repository = new Repository<Venue>();
        }

        [TestMethod]
        public void TestGet_NoItems_ShouldReturnNull()
        {
            var result = this.repository.Get(6);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestGet_ItemPresent_ShouldReturnItem()
        {
            var user = new User("alexredis", "alexalex", Roles.User);

            this.repository.Add(new Venue("Venue1", "Sofia", "Nqma1", user));
            this.repository.Add(new Venue("Venue2", "Sofia", "Nqma2", user));
            this.repository.Add(new Venue("Venue3", "Sofia", "Nqma3", user));

            var result = this.repository.Get(2);
            Assert.AreEqual("Nqma2", result.Description);
        }

        [TestMethod]
        public void TestGet_ItemPresent_ShouldReturnItemAddress()
        {
            var user = new User("alexredis", "alexalex", Roles.User);

            this.repository.Add(new Venue("Venue1", "Sofia", "Nqma1", user));
            this.repository.Add(new Venue("Venue2", "Sofia", "Nqma2", user));
            this.repository.Add(new Venue("Venue3", "Sofia", "Nqma3", user));

            var result = this.repository.Get(2);
            Assert.AreEqual("Sofia", result.Address);
        }

        [TestMethod]
        public void TestGet_ItemPresent_ShouldReturnItemId()
        {
            var user = new User("alexredis", "alexalex", Roles.User);

            this.repository.Add(new Venue("Venue1", "Sofia", "Nqma1", user));
            this.repository.Add(new Venue("Venue2", "Sofia", "Nqma2", user));
            this.repository.Add(new Venue("Venue3", "Sofia", "Nqma3", user));

            var result = this.repository.Get(2);
            Assert.AreEqual(2, result.Id);
        }

    }
}