namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car testCar;
        private string testCarMake;
        private string testCarModel;
        private double testCarFuelConsumption;
        private double testCarFuelCapacity;

        [SetUp] 
        public void SetUp()
        {
            testCarMake = "TestMake";
            testCarModel = "TestCarModel";
            testCarFuelConsumption = 12.2;
            testCarFuelCapacity = 55;
        }

        [Test]
        public void ConstructorsTest()
        {
            testCar = new Car(testCarMake,testCarModel, testCarFuelConsumption, testCarFuelCapacity);

            Assert.AreEqual(testCarMake, testCar.Make);
            Assert.AreEqual(testCarModel, testCar.Model);
            Assert.AreEqual(testCarFuelConsumption, testCar.FuelConsumption);
            Assert.AreEqual(testCarFuelCapacity, testCar.FuelCapacity);
            Assert.AreEqual(0, testCar.FuelAmount);
        }

        [Test]
        public void MakeSetShouldThrowIfValueIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(()=>
            {
                testCar = new Car(null, testCarModel, testCarFuelConsumption, testCarFuelCapacity);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                testCar = new Car(string.Empty, testCarModel, testCarFuelConsumption, testCarFuelCapacity);
            });
        }

        [Test]
        public void ModelSetShouldThrowIfValueIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                testCar = new Car(testCarMake, null, testCarFuelConsumption, testCarFuelCapacity);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                testCar = new Car(testCarMake, string.Empty, testCarFuelConsumption, testCarFuelCapacity);
            });
        }

        [Test]
        public void FuelConsuptionSetShouldThroIfValueIzZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                testCar = new Car(testCarMake, testCarModel, 0, testCarFuelCapacity);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                testCar = new Car(testCarMake, testCarModel, -12, testCarFuelCapacity);
            });
        }

        [Test]
        public void FuelCapacitySetShouldThroIfValueIzZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                testCar = new Car(testCarMake, testCarModel, testCarFuelConsumption, 0);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                testCar = new Car(testCarMake, testCarModel, testCarFuelConsumption, -12);
            });
        }

        [Test]
        public void RefuelMethodShoudThrowIfValueIsZeroOrNegative()
        {
            testCar = new Car(testCarMake, testCarModel, testCarFuelConsumption, testCarFuelCapacity);
            Assert.Throws<ArgumentException>(() =>
            {
                testCar.Refuel(0);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                testCar.Refuel(-12);
            });
        }

        [Test]
        public void RefuelMethodShoudAddGivenFuelToFuelAmount()
        {
            testCar = new Car(testCarMake, testCarModel, testCarFuelConsumption, testCarFuelCapacity);

            double addedFuel = 10;
            testCar.Refuel(addedFuel);

            Assert.AreEqual(addedFuel, testCar.FuelAmount);
        }


        [Test]
        public void RefuelMethodShoudNOTAddMoreThanFuelCapacity()
        {
            testCar = new Car(testCarMake, testCarModel, testCarFuelConsumption, testCarFuelCapacity);

            double addedFuel = 100;
            double maxCarFuel = testCarFuelCapacity;
            testCar.Refuel(addedFuel);

            Assert.AreEqual(maxCarFuel, testCar.FuelAmount);
        }

        [Test]
        public void DriveShouldThrowIfThereIsNOTEnoughFuelAmount()
        {
            testCar = new Car(testCarMake, testCarModel, testCarFuelConsumption, testCarFuelCapacity);

            double distance = 50;
            Assert.Throws<InvalidOperationException>(() => testCar.Drive(distance));
        }

        [Test]
        public void DriveShouldDecreaseFuelAmount()
        {
            testCar = new Car(testCarMake, testCarModel, testCarFuelConsumption, testCarFuelCapacity);
            testCar.Refuel(50);

            double distance = 10;
            double fuelNeeded = (distance / 100) * testCarFuelConsumption;

            double fuelRemaining = testCar.FuelAmount - fuelNeeded;
            testCar.Drive(distance);

            Assert.AreEqual(fuelRemaining, testCar.FuelAmount);
        }

    }
}