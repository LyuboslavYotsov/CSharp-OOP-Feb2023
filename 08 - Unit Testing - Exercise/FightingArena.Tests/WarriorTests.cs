namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void ConstructorShouldSetPropertiesWithValidValues()
        {
            string expectedName = "Pesho";
            int expectedDamage = 50;
            int expectedHP = 100;


            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP);

            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHP, warrior.HP);

        }

        [TestCase("Pesho")]
        [TestCase("P")]
        [TestCase("Peshooooo peshh")]
        public void NameGetterShouldReturnWarriorName(string name)
        {
            Warrior warrior = new Warrior(name, 50, 100);

            Assert.AreEqual(name, warrior.Name);
        }


        [TestCase("   ")]
        [TestCase(null)]
        [TestCase("")]
        public void NameSetterShouldThowIfNameIsInvalid(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 50, 100);
            }, "Name should not be empty or whitespace!");
        }

        [TestCase(50)]
        [TestCase(1)]
        [TestCase(1500)]
        public void DamageGetterShouldReturnWarriorDamageWithValidValues(int damage)
        {
            Warrior warrior = new Warrior("Pesho", damage, 100);

            Assert.AreEqual(damage, warrior.Damage);
        }


        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(-66)]
        public void DamageSetterShouldThrowIfValueIsNegativeOrZero(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", damage, 100);
            }, "Damage value should be positive!");

        }

        [TestCase(0)]
        [TestCase(10)]
        [TestCase(100)]
        public void HPGetterShouldReturnWarriorHPWithValidValues(int HP)
        {
            Warrior warrior = new Warrior("Pesho", 50, HP);

            Assert.AreEqual(HP, warrior.HP);
        }


        [TestCase(-1)]
        [TestCase(-1000)]
        [TestCase(-66)]
        public void HPSetterShouldThrowIfValueIsNegative(int HP)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Pesho", 50, HP);
            }, "HP should not be negative!");

        }

        [TestCase(30)]
        [TestCase(2)]
        public void AttackMethodShouldThrowIfAttackerHPIsLowerOrEqualTo30(int attackerHP)
        {
            Warrior attacker = new Warrior("Pesho", 10, attackerHP);
            Warrior defender = new Warrior("Gosho", 10, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [TestCase(30)]
        [TestCase(2)]
        public void AttackMethodShouldThrowIfDefenderHPIsLowerOrEqualTo30(int defenderHP)
        {
            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 10, defenderHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }


        [TestCase(31)]
        [TestCase(49)]
        public void AttackMethodShouldThrowIfAttackerHPIsLowerThanDefenderDamage(int attackerHP)
        {
            Warrior attacker = new Warrior("Pesho", 10, attackerHP);
            Warrior defender = new Warrior("Gosho", 50, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void AttackMethodShouldDecreaseAttackerHPIfSuccesfull()
        {
            Warrior attacker = new Warrior("Pesho", 20, 100);
            Warrior defender = new Warrior("Gosho", 30, 100);

            int expectedAttackerHP = attacker.HP - defender.Damage;

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP,attacker.HP);

        }

        [Test]
        public void AttackMethodShouldDecreaseDefenderHPIfSuccesfull()
        {
            Warrior attacker = new Warrior("Pesho", 20, 100);
            Warrior defender = new Warrior("Gosho", 30, 100);

            int expectedDefenderHP = defender.HP - attacker.Damage;

            attacker.Attack(defender);

            Assert.AreEqual(expectedDefenderHP, defender.HP);

        }

        [Test]
        public void AttackMethodShouldDecreaseDefenderHPToZeroIfHeLoosesAllOrMoreThanHisHP()
        {
            Warrior attacker = new Warrior("Pesho", 120, 100);
            Warrior defender = new Warrior("Gosho", 30, 100);

            int expectedDefenderHP = 0;

            attacker.Attack(defender);

            Assert.AreEqual(expectedDefenderHP, defender.HP);

        }

    }
}