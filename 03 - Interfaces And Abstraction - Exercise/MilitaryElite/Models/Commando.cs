

using MilitaryElite.Models.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corp, IReadOnlyCollection<IMission> missions) : base(id, firstName, lastName, salary, corp)
        {
            Missions= missions;
        }

        public IReadOnlyCollection<IMission> Missions {get; private set;}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine("Missions:");
            foreach (var mission in Missions)
            {
                sb.AppendLine("   " + mission.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
