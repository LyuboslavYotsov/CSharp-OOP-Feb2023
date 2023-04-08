using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private readonly List<ISupplement> models;

        public SupplementRepository()
        {
            models = new List<ISupplement>();
        }


        public void AddNew(ISupplement model) => models.Add(model);

        public ISupplement FindByStandard(int interfaceStandard) => models.FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);

        public IReadOnlyCollection<ISupplement> Models() => models.AsReadOnly();

        public bool RemoveByName(string typeName)
        {
            ISupplement supplement = models.FirstOrDefault(s => s.GetType().Name == typeName);

            return models.Remove(supplement);
        }
    }
}
