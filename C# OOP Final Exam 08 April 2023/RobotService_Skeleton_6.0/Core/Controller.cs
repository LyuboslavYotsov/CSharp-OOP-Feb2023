using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly IRepository<ISupplement> supplements;
        private readonly IRepository<IRobot> robots;

        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            if (typeName != nameof(DomesticAssistant) && typeName != nameof(IndustrialAssistant))
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            IRobot robot = null;
            if (typeName == nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
            }
            else
            {
                robot = new IndustrialAssistant(model);
            }

            robots.AddNew(robot);

            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != nameof(LaserRadar) && typeName != nameof(SpecializedArm))
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            ISupplement supplement = null;
            if (typeName == nameof(LaserRadar))
            {
                supplement = new LaserRadar();
            }
            else
            {
                supplement = new SpecializedArm();
            }
            supplements.AddNew(supplement);

            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements.Models().FirstOrDefault(s => s.GetType().Name == supplementTypeName);

            IEnumerable<IRobot> compatibleRobots = robots.Models()
                .Where(r => r.Model == model && !r.InterfaceStandards.Contains(supplement.InterfaceStandard));

            if (!compatibleRobots.Any())
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }

            IRobot robot = compatibleRobots.FirstOrDefault();
            robot.InstallSupplement(supplement);
            supplements.RemoveByName(supplementTypeName);

            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            IOrderedEnumerable<IRobot> compatibleRobots = robots.Models()
                .Where(r => r.InterfaceStandards.Contains(intefaceStandard))
                .OrderByDescending(r => r.BatteryLevel);

            if (!compatibleRobots.Any())
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            int robotsTotalBattery = compatibleRobots.Sum(r => r.BatteryLevel);

            if (robotsTotalBattery < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - robotsTotalBattery);
            }

            int robotsCounter = 0;

            foreach (var robot in compatibleRobots)
            {
                if (robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    robotsCounter++;
                    break;
                }
                else
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                    robotsCounter++;
                }
            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, robotsCounter);
        }

        public string RobotRecovery(string model, int minutes)
        {
            IEnumerable<IRobot> compatibleRobots = robots.Models()
                .Where(r => r.BatteryLevel < r.BatteryCapacity / 2 && r.Model == model);

            int fedCount = 0;

            foreach (var robot in compatibleRobots)
            {
                robot.Eating(minutes);
                fedCount++;
            }

            return string.Format(OutputMessages.RobotsFed, fedCount);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            IOrderedEnumerable<IRobot> orderedRobots = robots.Models()
                .OrderByDescending(r => r.BatteryLevel)
                .ThenBy(r => r.BatteryCapacity);

            foreach (var robot in orderedRobots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
