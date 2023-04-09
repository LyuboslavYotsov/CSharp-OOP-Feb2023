namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database fullDataBase;
        private Database emptyDataBase;
        private int[] fullDataBaseInput = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

        [SetUp]
        public void SetUp()
        {
            fullDataBase = new Database(fullDataBaseInput);
            emptyDataBase = new Database();

        }
        [Test]
        public void StoringArrayCapacityLenghtShouldBeExactly16()
        {
            
            Assert.AreEqual(16, fullDataBase.Count);
        }

        [Test]
        public void ConstructorInputArray_CannotRecieveMoreThan16Integers()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                fullDataBase = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16,17);
            });
        }

        [Test]
        public void AddOperationShouldAddElementOnNextFreeCell()
        {
            emptyDataBase.Add(2);
            Assert.AreEqual(2, emptyDataBase.Fetch()[0]);
        }

        [Test]
        public void AddOpperationShouldThrowIfArrayIsFull()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                fullDataBase.Add(2);
            });
        }

        [Test]
        public void RemoveOperationShouldThrowIfDataBaseIsEmpty()
        {
            Assert.Throws(typeof(InvalidOperationException), () =>
            {
                emptyDataBase.Remove();
            });
        }

        [Test]
        public void RemoveOperationShouldRemoveLastIndexElement()
        {
            fullDataBase.Remove();
            int lastElement = fullDataBase.Fetch()[fullDataBase.Count- 1];

            Assert.AreEqual(15, lastElement);

            fullDataBase.Remove();
            lastElement = fullDataBase.Fetch()[fullDataBase.Count - 1];

            Assert.AreEqual(14, lastElement);
        }

        [Test]
        public void FetchMethodShouldReturnAllElementsInArray()
        {
            int[] fetchedNumbers = fullDataBase.Fetch();

            for (int i = 0; i < fetchedNumbers.Length; i++)
            {
                Assert.AreEqual(fullDataBaseInput[i], fetchedNumbers[i]);
            }
        }

    }
}
