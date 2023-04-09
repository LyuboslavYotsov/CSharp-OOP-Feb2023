using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        private int attackPoints;
        private int durabilityPoints;

        [SetUp]
        public void SetUp()
        {
            attackPoints = 10;
            durabilityPoints = 15;
            axe = new Axe(attackPoints, durabilityPoints);
            dummy = new Dummy(100, 100);

        }
        [Test]
        public void AxeShouldLoseDurabilityPoitsWhenAttack()
        {
            axe.Attack(dummy);
            Assert.AreEqual(durabilityPoints - 1, axe.DurabilityPoints);

            axe.Attack(dummy);
            Assert.AreEqual(durabilityPoints - 2, axe.DurabilityPoints);

            axe.Attack(dummy);
            Assert.AreEqual(durabilityPoints - 3, axe.DurabilityPoints);
        }

        [Test]
        public void AxeShouldThrowException_WhenDurabilityIsZeroOrLess()
        {
            Axe brokenAxe = new Axe(attackPoints, 0);

            Assert.Throws<InvalidOperationException>(() =>
            {
                brokenAxe.Attack(dummy);
            });

            Axe brokenAxe2 = new Axe(attackPoints, -12);

            Assert.Throws<InvalidOperationException>(() =>
            {
                brokenAxe.Attack(dummy);
            });
        }
    }
}