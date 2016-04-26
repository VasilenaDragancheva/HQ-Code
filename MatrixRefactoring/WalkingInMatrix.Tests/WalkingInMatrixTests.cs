namespace WalkingInMatrix.Tests
{
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WalkInMatrix.Models;

    [TestClass]
    public class WalkingInMatrixTests
    {
        [TestMethod]
        public void TestWalkingInMatrix_WithSizeOne_ShouldReturnOne()
        {
            // Arrange
            var matrix = new WalkingInMatrix(1);
            var expected = new StringBuilder();
            expected.AppendFormat("{0,3}", 1).AppendLine();
            matrix.WalkInMatrix();

            // Act
            string actual = matrix.Print();

            // Assert
            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void TestWalkingInMatrix_WithSizeFive_ShouldReturnRightMatrix()
        {
            // Arrange
            var matrix = new WalkingInMatrix(5);
            var expected = this.ExpectedMatrix(5);
            matrix.WalkInMatrix();

            // Act
            string actual = matrix.Print();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private string ExpectedMatrix(int p)
        {
            int[,] matrix =
                {
                    { 1, 13, 14, 15, 16 }, { 12, 2, 21, 22, 17 }, { 11, 25, 3, 20, 18 }, { 10, 24, 23, 4, 19 }, 
                    { 9, 8, 7, 6, 5 }
                };
            var result = new StringBuilder();

            for (int r = 0; r < p; r++)
            {
                for (int c = 0; c < p; c++)
                {
                    result.AppendFormat("{0,3}", matrix[r, c]);
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}