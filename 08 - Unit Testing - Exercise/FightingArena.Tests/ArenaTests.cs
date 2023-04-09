namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.ComponentModel;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena testArena;
        [SetUp] public void SetUp() 
        {
            testArena = new Arena();
        }

        [Test]
        public void ConstructorShouldInitializeWarriorsCollection()
        {
            Arena arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
        }


        [Test]
        public void CountShouldReturnValidCountOfWarriors()
        {
            int expectedCount = 0;
            Assert.AreEqual(expectedCount, testArena.Count);

            Warrior warrior = new Warrior("Pesho", 50, 100);

            testArena.Enroll(warrior);
            expectedCount++;
            Assert.AreEqual(expectedCount, testArena.Count);
        }

        [Test]
        public void EnrollMethodShouldAddWarriorToCollection()
        {
            Warrior warrior = new Warrior("Pesho", 50, 100);

            testArena.Enroll(warrior);

            Assert.AreEqual(warrior.Name, testArena.Warriors.First(w => w.Name == warrior.Name).Name);
        }

        [Test]
        public void EnrollMethodShouldThrowIfAddingWarriorWithExistingName()
        {
            Warrior warrior1 = new Warrior("Pesho", 50, 100);
            Warrior warrior2 = new Warrior("Pesho", 60, 120);

            testArena.Enroll(warrior1);


            Assert.Throws<InvalidOperationException>(() =>
            {
                testArena.Enroll(warrior2);
            }, "Warrior is already enrolled for the fights!");
        }


        [Test]
        public void AttackMethodShouldThrowIfAttackerNameIsNOTInTheWarriorsCollection()
        {
            Warrior warrior1 = new Warrior("Pesho", 20, 100);
            Warrior warrior2 = new Warrior("Gosho", 25, 120);

            testArena.Enroll(warrior2);


            Assert.Throws<InvalidOperationException>(() =>
            {
                testArena.Fight(warrior1.Name, warrior2.Name);
            }, $"There is no fighter with name {warrior1.Name} enrolled for the fights!");
        }

        [Test]
        public void AttackMethodShouldThrowIfDefenderNameIsNOTInTheWarriorsCollection()
        {
            Warrior warrior1 = new Warrior("Pesho", 20, 100);
            Warrior warrior2 = new Warrior("Gosho", 25, 120);

            testArena.Enroll(warrior1);


            Assert.Throws<InvalidOperationException>(() =>
            {
                testArena.Fight(warrior1.Name, warrior2.Name);
            }, $"There is no fighter with name {warrior1.Name} enrolled for the fights!");
        }

        [Test]
        public void AttackMethodShouldSucceedIfNamesAreValid()
        {
            Warrior warrior1 = new Warrior("Pesho", 20, 100);
            Warrior warrior2 = new Warrior("Gosho", 25, 120);

            testArena.Enroll(warrior1);
            testArena.Enroll(warrior2);

            int expectedW1HP = warrior1.HP - warrior2.Damage;
            int expectedW2HP = warrior2.HP - warrior1.Damage;

            testArena.Fight(warrior1.Name, warrior2.Name);

            Assert.AreEqual(expectedW1HP, warrior1.HP );
            Assert.AreEqual(expectedW2HP, warrior2.HP );
            
        }
    }
}
