using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        private int[] data;

        [SetUp]
        public void Setup()
        {
            this.data = new int[]
            {
                1,2,3,4,5,6,7,8,9,10
            };

            this.database = new Database.Database(this.data);
        }

        [Test]
        public void CountProperty_WorksCorrectly()
        {
            // Assert
            int expectedResult = 10;
            int actualResult = this.database.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddMethod_WorksCorrectly()
        {
            // Act
            this.database.Add(11);

            // Assert
            int expectedCount = 11;
            int actualCount = this.database.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddMethod_OutOfTheCapacity()
        {
            // Arrange
            int[] data = new int[16];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i + 1;
            }

            this.database = new Database.Database(data);

            // Act and Assert
            string expectedExceptionMessage = "Array's capacity must be exactly 16 integers!";
            string actualExceptionMessage = Assert.Throws<InvalidOperationException>(() => this.database.Add(17)).Message;
            Assert.AreEqual(expectedExceptionMessage, actualExceptionMessage);
        }

        [Test]
        public void RemoveMethod_WorksCorrectly()
        {
            // Act
            this.database.Remove();

            // Assert
            int expectedCount = 9;
            int actualCount = this.database.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveMethod_FromEmptyCollection()
        {
            // Arrange
            this.database = new Database.Database();

            //Act and Assert
            string expectedExceptionMessage = "The collection is empty!";
            string actualExceptionMessage = Assert.Throws<InvalidOperationException>(() => this.database.Remove()).Message;
            Assert.AreEqual(expectedExceptionMessage, actualExceptionMessage);
        }

        [Test]
        public void FetchMethod_WorksCorrectly()
        {
            // Act
            int[] collection = this.database.Fetch();

            //Assert
            for (int i = 0; i < collection.Length; i++)
            {
                Assert.AreEqual(this.data[i], collection[i]);
            }
        }

        [Test]
        public void FetchMethod_WorksCorrectlyAfterAddingAnElement()
        {
            // Act
            this.database.Add(11);
            int[] collection = this.database.Fetch();

            //Assert
            for (int i = 0; i < this.data.Length; i++)
            {
                Assert.AreEqual(this.data[i], collection[i]);
            }

            Assert.AreEqual(11, collection[10]);
        }
    }
}