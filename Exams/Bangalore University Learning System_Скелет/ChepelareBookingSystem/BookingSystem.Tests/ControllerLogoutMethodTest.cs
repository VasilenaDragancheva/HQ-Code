using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Tests
{
    using ChepelareBookingSystem.Controllers;
    using ChepelareBookingSystem.Data;
    using ChepelareBookingSystem.Identity;
    using ChepelareBookingSystem.Infrastructure;
    using ChepelareBookingSystem.Interfaces;
    using ChepelareBookingSystem.Models;

    [TestClass]
    public class ControllerLogoutMethodTest
    {

        private IHotelBookingSystemData database;

        [TestInitialize]
        public void InstanceOfDatabase()
        {
            this.database = new HotelBookingSystemData();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Logout_NullUser_ShouldThrowException()
        {
            //Arrange
            var controller = new UsersController(this.database, null);
            // Act
            controller.Logout();
        }

        [TestMethod]
        public void AuthorizedMethod_LoggedUser_ControllerShouldHaveNullUser()
        {
            //Arrange
            string username = "username";
            string password = "password";
            var role = Roles.User;
            var user = new User(username, password, role);
            var controller = new UsersController(this.database, user);

            //Act
            controller.Logout();

            //Assert
            Assert.IsNull(controller.CurrentUser);


        }

        [TestMethod]
        public void AuthorizedMethod_LoggedAdminUser_ControllerShouldHaveNullUser()
        {
            //Arrange
            string username = "username";
            string password = "password";
            var user = new User(username, password,Roles.VenueAdmin);
            var controller = new UsersController(this.database, user);

            //Act
            controller.Logout();

            //Assert
            Assert.IsNull(controller.CurrentUser);


        }


    }
}
