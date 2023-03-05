
using MilitaryElite.Models.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corp, IReadOnlyCollection<IRepair> repairs) : base(id, firstName, lastName, salary, corp)
        {
            Repairs = repairs;
        }

        public IReadOnlyCollection<IRepair> Repairs { get; private set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Repairs:");
            foreach (var repair in Repairs)
            {
                sb.AppendLine("   " + repair.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
