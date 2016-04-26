using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem
{
    using BangaloreUniversityLearningSystem;
    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UsersControllerTests
    {
        private UsersController controller;

        [TestInitialize]
        public void UserControllerInstanceNullCurrentUser()
        {
            var database = new BangaloreUniversityData();
            this.controller = new UsersController(database, null);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "There is no currently logged in user.")]
        public void TestLogoutMethod_HasNoCurrentUser_ShouldThrowException()
        {
            // Act
            this.controller.Logout();
        }

        [TestMethod]
        public void TestLogoutMethod_HasCurrentUser_ShouldReturnNullUser()
        {
            // Arrange
            string username = "username";
            this.controller.User = new User(username, "password", Role.Lecturer);
            // Act
            this.controller.Logout();
            // Assert
            Assert.IsNull(this.controller.User);
        }
    }
}
