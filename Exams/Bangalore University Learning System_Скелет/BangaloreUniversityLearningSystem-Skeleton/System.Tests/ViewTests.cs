using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem
{
    using BangaloreUniversityLearningSystem;
    using BangaloreUniversityLearningSystem.Contracts;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Views.Users;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RegisterViewTests
    {

        [TestMethod]
        public void TestDisplay_UserResgiter()
        {
            // Arrange
            string username = "username";
            string password = "password";
            Role role = Role.Student;
            User user = new User(username, password, role);
            IView view = new Register(user);
            string expected = string.Format("User {0} registered successfully.", username);

            // Act
            string output = view.Display();

            // Assert

            Assert.AreEqual(expected, output);


        }

        //[TestClass]
        //public class RegisterViewTests
        //{

        //    [TestMethod]
        //    public void TestDisplay_UserResgiter()
        //    {
        //        // Arrange
        //        string username = "username";
        //        string password = "password";
        //        Role role = Role.Student;
        //        User user = new User(username, password, role);
        //        IView view = new Register(user);
        //        string expected = string.Format("User {0} registered successfully.", username);

        //        // Act
        //        string output = view.Display();

        //        // Assert

        //        Assert.AreEqual(expected, output);


            //}
        }
    }

