using NUnit.Framework;
using System.Linq;

namespace RobotFactory.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FactoryConstructioShouldInitializePropertiesCorrectly()
        {
            Factory factory = new Factory("Name", 10);

            Assert.IsNotNull(factory);
            Assert.AreEqual("Name", factory.Name);
            Assert.AreEqual(10, factory.Capacity);
            Assert.IsNotNull(factory.Robots);
            Assert.IsNotNull(factory.Supplements);

            Assert.AreEqual(0, factory.Supplements.Count);
            Assert.AreEqual(0, factory.Robots.Count);
        }

        [Test]
        public void ProduceRobotShouldNoSucceedIfCapacityIsFull()
        {
            Factory factory = new Factory("Name", 0);

            string expectedResult = "The factory is unable to produce more robots for this production day!";

            Assert.AreEqual(expectedResult, factory.ProduceRobot("Model", 100, 2023));
        }

        [Test]
        public void ProduceRobotShouldProduceRobotWithGivenParametersAndReturnValidMessage()
        {
            Factory factory = new Factory("Name", 10);

            string robotModel = "Model";
            double robotPrice = 100;
            int robotInterface = 2023;

            Robot myRobot = new Robot(robotModel, robotPrice, robotInterface);

            string expectetResult = $"Produced --> {myRobot}";

            Assert.AreEqual(expectetResult, factory.ProduceRobot(robotModel, robotPrice, robotInterface));

            Assert.AreEqual(1, factory.Robots.Count);

            Assert.IsTrue(factory.Robots.Any(r => r.Model == myRobot.Model));
        }


        [Test]
        public void ProduceSupplementShouldAddNewSupplementToFactorySupplementsAndReturnValidMessage()
        {
            Factory factory = new Factory("Name", 10);

            string supplementName = "Supp";
            int supplementStandart = 2023;

            Supplement mySupplement = new Supplement(supplementName, supplementStandart);

            string expectedMessage = mySupplement.ToString();

            Assert.AreEqual(expectedMessage, factory.ProduceSupplement(supplementName, supplementStandart));

            Assert.IsTrue(factory.Supplements.Any(s => s.Name == mySupplement.Name));
            Assert.AreEqual(1, factory.Supplements.Count);
        }

        [Test]
        public void UpgradeRobotShouldReturnFalseIfSupplementAndRoborAreNotCompatible()
        {
            Factory factory = new Factory("Name", 10);

            string supplementName = "Supp";
            int supplementStandart = 2023;
            Supplement mySupplement = new Supplement(supplementName, supplementStandart);

            string robotModel = "Model";
            double robotPrice = 100;
            int robotInterface = 2022;

            Robot myRobot = new Robot(robotModel, robotPrice, robotInterface);

            Assert.IsFalse(factory.UpgradeRobot(myRobot, mySupplement));
        }

        [Test]
        public void UpgradeRobotShouldReturnFalseIfSupplementIsAllreadyInstalled()
        {
            Factory factory = new Factory("Name", 10);

            string supplementName = "Supp";
            int supplementStandart = 2023;
            Supplement mySupplement = new Supplement(supplementName, supplementStandart);

            string robotModel = "Model";
            double robotPrice = 100;
            int robotInterface = 2023;

            Robot myRobot = new Robot(robotModel, robotPrice, robotInterface);

            Assert.IsTrue(factory.UpgradeRobot(myRobot, mySupplement));

            Assert.IsTrue(myRobot.Supplements.Contains(mySupplement));

            Assert.AreEqual(myRobot.Supplements[0], mySupplement);

            Assert.IsFalse(factory.UpgradeRobot(myRobot, mySupplement));
        }

        [Test]
        public void SellRobotShouldReturnNullIfThereIsNoRobotsForGivenBudget()
        {
            Factory factory = new Factory("Name", 10);

            string robotModel = "Model";
            double robotPrice = 1000;
            int robotInterface = 2023;

            factory.ProduceRobot(robotModel, robotPrice, robotInterface);

            Assert.IsNull(factory.SellRobot(500));
        }

        [Test]
        public void SellRobotShouldReturnMoestExpensiveRobotForGivenBudget()
        {
            Factory factory = new Factory("Name", 10);

            string robotModel = "Model";
            double robotPrice = 1000;
            int robotInterface = 2023;

            factory.ProduceRobot(robotModel, robotPrice, robotInterface);
            factory.ProduceRobot("Model2", 1500, 2024);
            factory.ProduceRobot("Model3", 1600, 2025);

            double budget = 1550;

            Robot expectedRobot = new Robot("Model2", 1500, 2024);

            Assert.AreEqual(expectedRobot.Model, factory.SellRobot(budget).Model);
            Assert.AreEqual(expectedRobot.Price, factory.SellRobot(budget).Price);
            Assert.AreEqual(expectedRobot.InterfaceStandard, factory.SellRobot(budget).InterfaceStandard);
        }
    }
}