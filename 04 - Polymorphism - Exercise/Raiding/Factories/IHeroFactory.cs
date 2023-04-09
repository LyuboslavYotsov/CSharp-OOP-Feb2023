using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Factories
{
    public interface IHeroFactory
    {
        IHero CreateHero(string name, string type);
    }
}
