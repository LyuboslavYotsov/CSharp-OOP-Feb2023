namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person testPerson;
        private Database testDatabase;
        private Database emptyDataBase;
        private List<Person> peopleList;


        [SetUp]
        public void SetUp()
        {
            List<Person> peopleArray = new List<Person>();
            for (int i = 0; i < 16; i++)
            {
                peopleArray.Add(new Person(i, $"User{i}"));
            }
            testDatabase = new Database(peopleArray.ToArray());
            emptyDataBase = new Database();
            peopleList = peopleArray;
        }

        [Test]
        public void PersonConstructor()
        {
            long testID = 1221;
            string testPersonName = "TestName";

            testPerson = new Person(testID, testPersonName);

            Assert.AreEqual(testID, testPerson.Id);
            Assert.AreEqual(testPersonName, testPerson.UserName);
        }

        [Test]
        public void DatabaseConstructorShouldAddArrayOfPeople()
        {
            int peopleToAdd = 5;
            emptyDataBase = new Database(peopleList.Take<Person>(peopleToAdd).ToArray());

            Assert.AreEqual(peopleToAdd, emptyDataBase.Count);
        }

        [Test]
        public void DatabaseConstructorShouldThrowIfArrayOfPeopleIsLargerThan16()
        {
            peopleList.Add(new Person(1221, "TestPerson"));

            Assert.Throws<ArgumentException>(() => emptyDataBase = new Database(peopleList.ToArray()));
        }

        [Test]
        public void CountShouldReturnExactNumberOfPeople()
        {
            int peopleCount = peopleList.Count();

            Assert.AreEqual(peopleCount, testDatabase.Count);
        }


        [Test]
        public void AddMethodShouldThrowIfPeopleCountIs16()
        {
            testPerson = new Person(1221, "TestName");
            Assert.Throws<InvalidOperationException>(() =>
            {
                testDatabase.Add(testPerson);
            });
        }

        [Test]
        public void AddMethodShouldThrowIfAddingPersonWithExistingUsername()
        {
            testPerson = new Person(1221, "TestName");
            Person sameUsername = new Person(2112, "TestName");

            emptyDataBase.Add(testPerson);

            Assert.Throws<InvalidOperationException>(() =>
            {
                emptyDataBase.Add(sameUsername);
            });
        }

        [Test]
        public void AddMethodShouldThrowIfAddingPersonWithExistingId()
        {
            testPerson = new Person(1221, "TestName");
            Person sameId = new Person(1221, "TestName2");

            emptyDataBase.Add(testPerson);

            Assert.Throws<InvalidOperationException>(() =>
            {
                emptyDataBase.Add(sameId);
            });
        }

        [Test]
        public void AddMethodShouldAddPersonAndIncreaseCount_IfThereIsRoom()
        {
            testPerson = new Person(1221, "TestName");

            emptyDataBase.Add(testPerson);

            Assert.IsTrue(emptyDataBase.Count > 0);
        }

        [Test]
        public void RemoveMethodShouldThrowIfCountIsZero()
        {
            Assert.Throws<InvalidOperationException>(() => emptyDataBase.Remove());
        }

        [Test]
        public void RemoveMethodShouldDecreaseCount()
        {
            int countBeforeRemove = testDatabase.Count;

            int peopleToRemove = 2;

            for (int i = 0; i < peopleToRemove; i++)
            {
                testDatabase.Remove();
            }

            Assert.AreEqual(countBeforeRemove - peopleToRemove, testDatabase.Count);
        }

        [Test]
        public void RemoveMethodRemoveLastPerson()
        {
            Person firstPerson = new Person(1, "First");
            Person secondPerson = new Person(2, "Second");
            Person lastPerson = new Person(3, "Last");

            emptyDataBase = new Database(new Person[] { firstPerson, secondPerson, lastPerson });

            emptyDataBase.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                emptyDataBase.FindByUsername("Last");
            });
        }

        [Test]
        public void FindByUsernameShouldThrowIfNameParameterIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                testDatabase.FindByUsername(null);
            });
        }

        [Test]
        public void FindByUsernameShouldThrowIfNameParameterIsEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                testDatabase.FindByUsername("");
            });
        }

        [Test]
        public void FindByUsernameShouldThrowIfNameDoesntExistInDatabase()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                testDatabase.FindByUsername("NoSuchName");
            });
        }

        [Test]
        public void FindByUsernameShouldReturnPersonWithGivenName()
        {
            Person firstPerson = new Person(1, "First");
            Person targetPerson = new Person(2, "Second");
            Person lastPerson = new Person(3, "Last");

            emptyDataBase = new Database(new Person[] { firstPerson, targetPerson, lastPerson });

            Person targetFromDatabase = emptyDataBase.FindByUsername(targetPerson.UserName);

            Assert.AreEqual(targetPerson.UserName, targetFromDatabase.UserName);
        }

        [Test]
        public void FindByIdShoudThrowIfIdParameterIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => testDatabase.FindById(-1));
        }

        [Test]
        public void FindByIdShoudThrowIfIdDoesNotExistInDatabase()
        {
            Assert.Throws<InvalidOperationException>(() => emptyDataBase.FindById(1001),"No user is present by this ID!");
        }

        [Test]
        public void FindByIdShoudReturnPersonWithGivenId()
        {
            Person firstPerson = new Person(1, "First");
            Person targetPerson = new Person(2, "Second");
            Person lastPerson = new Person(3, "Last");

            emptyDataBase = new Database(new Person[] { firstPerson, targetPerson, lastPerson });

            Person targetFromDatabase = emptyDataBase.FindById(targetPerson.Id);

            Assert.AreEqual(targetPerson.Id, targetFromDatabase.Id);
        }
    }
}
