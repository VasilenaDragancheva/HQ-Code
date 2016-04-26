namespace BookingSystem.Tests
{
    using ChepelareBookingSystem.Data;
    using ChepelareBookingSystem.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RepositoryGetMethodTest
    {
        [TestMethod]
        public void TestOfEmptyRepository_ShouldReturnNull()
        {
            // Arrange
            var repo = new Repository<Room>();

            // Act
            var room = repo.Get(0);

            // Asset
            Assert.IsNull(room, "Empty repository does not return null");
        }

        [TestMethod]
        public void TestORepositoryWithNElements_GreaterIndexShouldReturnNull()
        {
            // Arrange
            int n = 10;
            var repo = new Repository<Room>();
            for (int i = 0; i < n; i++)
            {
                repo.Add(new Room(i, i));
            }

            // Act
            var room = repo.Get(n + 1);

            // Asset
            Assert.IsNull(room, "Get greater id than repository count does not return null");
        }

        [TestMethod]
        public void TestOfRepositoryWithNElements_ValidIndexShouldReturnRoomWithSameID()
        {
            // Arrange
            int n = 10;
            var repo = new Repository<Room>();
            for (int i = 0; i < n; i++)
            {
                repo.Add(new Room(i, i));
            }

            // Act
            var room = repo.Get(1);

            // Assert
            Assert.AreEqual(1, room.Id, "Valid index does not return expected value!");
        }
    }
}