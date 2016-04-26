using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem
{
    using BangaloreUniversityLearningSystem;
    using BangaloreUniversityLearningSystem.Contracts;
    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class CoursesControllerTests
    {
        private CoursesController controller;

        [TestInitialize]
        public void InstanceOfController_NullUser()
        {
            Course course = new Course("AdvancedC#");
            var mockData = new Mock<IBangaloreUniversityData>();
            var mockRepository = new Mock<IRepository<Course>>();
            mockRepository.Setup(repo => repo.Get(It.IsAny<int>())).Returns(course);
            mockData.Setup(data => data.Courses).Returns(mockRepository.Object);

            this.controller = new CoursesController(mockData.Object, null);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddLecture_NullUser_ShouldThrowException()
        {
            // Act
            this.controller.AddLecture(3, "Polymorphysm");
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void TestAddLecture_UseWithRoleStudent_ShouldThrowException()
        {
            // Arrange
            this.controller.User = new User("username", "password", Role.Student);
            // Act
            this.controller.AddLecture(3, "Polymorphysm");
        }

        [TestMethod]
       
        public void TestAddLecture_UseWithRoleLecture_ShouldAddLecture()
        {
            // Arrange
            this.controller.User = new User("username", "password", Role.Lecturer);
            // Act
            this.controller.AddLecture(3, "Polymorphysm");

            // Assert
            var actualCount = this.controller.Data.Courses.Get(3).Lectures.Count();
            Assert.AreEqual(1,actualCount);
        }
    }
}
