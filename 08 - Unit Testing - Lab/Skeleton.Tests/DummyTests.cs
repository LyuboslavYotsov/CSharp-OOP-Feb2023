using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private int health;
        private int experience;
        private Dummy dummy;
        private Dummy deadDummy;


        [SetUp]
        public void SetUp()
        {
            health = 50;
            experience = 10;
            dummy = new Dummy(health, experience);
            deadDummy = new Dummy(0, experience);
        }

        [Test]
        public void DummyShouldLoseHealthWhenAttacked()
        {
            int attackDamage = 10;
            dummy.TakeAttack(attackDamage);

            Assert.AreEqual(health - attackDamage, dummy.Health);
        }


        [Test]
        public void DeadDummySouldThrowExceptionIfAttacked()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                deadDummy.TakeAttack(1);
            });
        }


        [Test]
        public void DeadDummyShouldGiveXP()
        {
            int givenXP = deadDummy.GiveExperience();

            Assert.AreEqual(experience, givenXP);
        }


        [Test]
        public void AliveDummyShouldNOTGiveXP()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }
    }
}