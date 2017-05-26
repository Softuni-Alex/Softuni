using HotelBookingSystem.Identity;
using HotelBookingSystem.Interfaces;
using HotelBookingSystem.Models;
using Moq;
using System;
using System.Text;

namespace TestHotelBookingSystem
{
    using HotelBookingSystem.Controllers;
    using HotelBookingSystem.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;


    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAuthorize_NotLoggedUser_ShouldReturnException()
        {
            var database = new HotelBookingSystemData();
            var controller = new VenuesController(database, null);

            controller.Details(1);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void TestAuthorize_NoSufficientRights_ShouldReturnException()
        {
            var database = new HotelBookingSystemData();
            var controller = new VenuesController(database, new User("Alex123", "alexredis", Roles.User));

            controller.Add("No name", "Sofia", "Omg");
        }


        [TestMethod]
        public void TestAuthorize_NoSufficientRights_ShouldPass()
        {
            var database = new HotelBookingSystemData();
            var controller = new VenuesController(database, new User("Alex123", "alexredis", Roles.VenueAdmin));

            controller.Add("No name", "Sofia", "Omg");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestLogout_WithoutLoggedUser_ShouldThrow()
        {
            var database = new HotelBookingSystemData();
            var controller = new UsersController(database, null);

            controller.Logout();
        }

        [TestMethod]
        public void TestLogout_WithLoggedUser_ShouldPass()
        {
            var database = new HotelBookingSystemData();
            var controller = new UsersController(database, new User("Alex123", "alexredis", Roles.VenueAdmin));

            controller.Logout();

            var result = controller.CurrentUser;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestAllVenuesWithoutVenuesCorrectReturnString()
        {
            const string expected = "There are currently no venues to show.";
            var database = new HotelBookingSystemData();
            var controller = new VenuesController(database, null);

            var result = controller.All().Display();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestAllVenuesWithVenuesCorrectReturnString()
        {
            var newresultString = new StringBuilder();

            newresultString.AppendLine("*[1] parvo venue, located at Chepelare")
                .AppendLine("Free rooms: 0");
            newresultString.AppendLine("*[2] Manifestaciq, located at Pred narodnoto")
                .AppendLine("Free rooms: 0");

            string expected = newresultString.ToString().Trim();
            var database = new HotelBookingSystemData();
            var controller = new VenuesController(database, new User("Alex123", "alexredis", Roles.VenueAdmin));

            controller.Add("parvo venue", "Chepelare", "omg");
            controller.Add("Manifestaciq", "Pred narodnoto", "oasdmg");

            var result = controller.All().Display();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestRoomAdd_ValidateRoom_ShouldPresent()
        {
            string expected = "The room with ID 2 has been created successfully.";

            var user = new User("admin", "admin123", Roles.VenueAdmin);

            int nextId = 1;

            var roomsRepoMock = new Mock<IRepository<Room>>();
            roomsRepoMock.Setup(b => b.Add(It.IsAny<Room>())).Callback((Room r) => r.Id = nextId++);

            var vanueRepo = new Mock<IRepository<Venue>>();
            vanueRepo.Setup(v => v.Get(It.IsAny<int>())).Returns(new Venue("Venue1", "Sofia", "Descr", user));

            var mockData = new Mock<IHotelBookingSystemData>();
            mockData.Setup(d => d.RoomsRepository).Returns(roomsRepoMock.Object);

            mockData.Setup(d => d.VenuesRepository).Returns(vanueRepo.Object);

            var controller = new RoomsController(mockData.Object, user);

            controller.Add(1, 100, 100M);

            var result = controller.Add(2, 100, 100M).Display();

            Assert.AreEqual(expected, result);
        }
    }
}