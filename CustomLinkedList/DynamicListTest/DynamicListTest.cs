namespace DynamicListTest
{
    using System;

    using CustomLinkedList;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAtNegativeIndex_ShouldThrowException()
        {
            // Arrange
            int n = 10000;
            var list = ListOfString(n);

            // Act
            string returnedValue = list.RemoveAt(-1);
        }

        [TestMethod]
        public void TestAddOneElement_ShouldCountBeEqualToOne()
        {
            // Arrange
            DynamicList<int> list = new DynamicList<int>();

            // act
            list.Add(0);

            // Assert
            Assert.AreEqual(
                1, 
                list.Count, 
                string.Format("After instance and adding 1 element list count should be 1, but is {0}", list.Count));
        }

        [TestMethod]
        public void TestAddSeveralElements_ShouldCountBeEqualToCountOfAddedElements()
        {
            // Arrange
            int countOfElements = 100;
            DynamicList<int> list = new DynamicList<int>();

            // Action
            for (int i = 0; i < countOfElements; i++)
            {
                list.Add(i);
            }

            // Assert
            Assert.AreEqual(
                countOfElements, 
                list.Count, 
                string.Format("After instance and adding 1 element list count should be 1, but is {0}", list.Count));
        }

        [TestMethod]
        public void TestContainsExistingValue_ShouldReturnTrue()
        {
            // Arrange
            int n = 1000;
            var list = ListOfInt(n);
            int searchedValue = n / 2;

            // Act
            bool contains = list.Contains(n / 2);

            // Assert
            Assert.IsTrue(contains, "COntains method does not return true, for value that is in list");
        }

        [TestMethod]
        public void TestContainsNotExistingValue_ShouldReturnFalse()
        {
            // Arrange
            int n = 1000;
            var list = ListOfInt(n);
            int searchedValue = n + 2;

            // Act
            bool contains = list.Contains(searchedValue);

            // Assert
            Assert.IsFalse(contains, "COntains method does not return false, for value that is not in list");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIndexatorGetterListWithNElements_IndexingElementAtIndexNShouldThrowException()
        {
            // Arrange
            int n = 100;
            var list = ListOfInt(n);

            // Act
            int i = list[n];
        }

        [TestMethod]
        public void TestIndexatorGetterListWithNElements_IndexNlessOneShouldReturnLastElement()
        {
            // Arrange
            int n = 100;
            var list = ListOfInt(n);
            int lastElement = 101;
            list.Add(lastElement);

            // Act
            int actualValue = list[list.Count - 1];

            // Assert
            Assert.AreEqual(lastElement, actualValue, "Actual value returned is not equal to the expected");

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIndexatorGetterListWithNElements_NegativeIndexShouldThrowException()
        {
            // Arrange
            int n = 100;
            var list = ListOfInt(n);

            // Act
            int i = list[-1];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIndexatorSetterListWithNElements_IndexingElementAtIndexNShouldThrowException()
        {
            // Arrange
            int n = 100;
            var list = ListOfInt(n);

            // Act
            list[n] = 0;
        }

        [TestMethod]
        public void TestIndexatorSetterListWithNElements_IndexNlessOneShouldReturnLastElement()
        {
            // Arrange
            int n = 100;
            var list = ListOfInt(n);
            int lastElement = 101;
            list.Add(lastElement);

            // Act
            list[list.Count - 1] = 101;

            // Assert
            Assert.AreEqual(lastElement, list[list.Count - 1], "Actual value returned is not equal to the expected");

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIndexatorSetterListWithNElements_NegativeIndexShouldThrowException()
        {
            // Arrange
            int n = 100;
            var list = ListOfInt(n);

            // Act
            list[-1] = 0;
        }

        [TestMethod]
        public void TestIndexOfExistingElement_ShouldReturnIndex()
        {
            // Arrange
            int n = 500;
            var list = ListOfInt(n);

            // Act
            int index = list.IndexOf(n / 2);

            // Assert
            Assert.AreEqual(
                list[index], 
                n / 2, 
                "The value on index returned by IndexOf method does not correspondtp the searched one");
        }

        [TestMethod]
        public void TestIndexOfNotExistingElement_ShouldReturnNegative()
        {
            // Arrange
            int n = 100;
            var list = ListOfInt(n);

            // Act
            int index = list.IndexOf(n);

            // Assert
            Assert.AreEqual(-1, index, "Index of does not return -1 for not existing element");
        }

        [TestMethod]
        public void TestInstanceOfClass_ShouldHaveCountZero()
        {
            // Arrange
            DynamicList<int> list = new DynamicList<int>();

            // Assert
            Assert.AreEqual(
                0, 
                list.Count, 
                string.Format("Instance of list should have 0 count but has {0}", list.Count));
        }

        [TestMethod]
        public void TestRemoveAtElement_ListWithOneElement_ShouldHaveCountZero()
        {
            // Arrange
            int n = 1;
            var list = ListOfString(1);

            // Act
            var removedValue = list.RemoveAt(0);

            // Assert
            Assert.AreEqual(0, list.Count, "List does not  contains  zero needed elements");
        }

        [TestMethod]
        public void TestRemovedAt()
        {
            // Arrange
            int n = 10000;
            var list = ListOfString(n);

            // Act
            string returnedValue = list.RemoveAt(n / 2);

            // Assert
            Assert.AreEqual((n / 2).ToString(), returnedValue, "Returned value is not da same as expected");
        }

        [TestMethod]
        public void TestRemoveMethod_WhichContainedValue_ShouldReturnIndexOfValueAndDecrementCount()
        {
            // Arrange
            int n = 1000;
            var list = ListOfString(n);
            string stringToRemove = (n / 2).ToString();

            // act
            int indexRemoved = list.Remove(stringToRemove);

            // Assert
            Assert.AreEqual(indexRemoved, n / 2, "Does not return correct index of removed item");
            Assert.AreEqual(n - 1, list.Count, "COunt of list does not decrement properly");
        }

        [TestMethod]
        public void TestRemoveMethod_WhichDoesNotContainsValue_ShouldReturnNegativeIndex()
        {
            // Arrange
            int n = 1000;
            var list = ListOfString(n);
            string stringToRemove = (n * 2).ToString();

            // act
            int indexRemoved = list.Remove(stringToRemove);

            // Assert
            Assert.AreEqual(indexRemoved, -1, "Does not return correct index of removed item");
        }

        private static DynamicList<int> ListOfInt(int countOFElements)
        {
            DynamicList<int> list = new DynamicList<int>();
            for (int i = 0; i < countOFElements; i++)
            {
                list.Add(i);
            }

            return list;
        }

        private static DynamicList<string> ListOfString(int countOFElements)
        {
            if (countOFElements <= 0)
            {
                throw new ArgumentOutOfRangeException("Count should be positi");
            }

            DynamicList<string> list = new DynamicList<string>();
            for (int i = 0; i < countOFElements; i++)
            {
                list.Add(i.ToString());
            }

            return list;
        }
    }
}