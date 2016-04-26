namespace InformationSystem
{
    using BangaloreUniversityLearningSystem;
    using BangaloreUniversityLearningSystem.Data;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseRepositoryTests
    {
        private Repository<Course> courses;

        [TestInitialize]
        public void CreateInstanceOfRepository()
        {
            this.courses = new Repository<Course>();
        }

        [TestMethod]
        public void TestGetMethod_EmptyRepositiry_ShouldReturnNull()
        {
            // Act
            var course = this.courses.Get(0);

            // Assert
            Assert.IsNull(course, "Empty repository does not return null");
        }

        [TestMethod]
        public void TestGetMethod_RepositoryWithNCourses_GreaterIdShouldReturnNull()
        {
            // Arrange
            int n = 20;
            for (int i = 1; i <= n; i++)
            {
                this.courses.Add(new Course(i + " course"));
            }

            // Act
            var course = this.courses.Get(n + 2);

            // Assert
            Assert.IsNull(course, "Greater id does not return null");
        }

        [TestMethod]
        public void TestGetMethod_RepositoryWithNCourses_ValidIdShouldReturnCourse()
        {
            // Arrange
            int n = 20;
            for (int i = 1; i <= n; i++)
            {
                this.courses.Add(new Course(i + " course"));
            }

            // Act
            var course = this.courses.Get(n - 2);

            // Assert
            Assert.AreEqual(course.Name, n - 2 + " course", "Valid Id does not return right course");
        }
    }
}