using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeExample
{
    public class SandwitchMenu
    {
        private Dictionary<string, SandwitchPrototype> sandwitches;

        public SandwitchMenu()
        {
            sandwitches = new Dictionary<string, SandwitchPrototype>();
        }

        public SandwitchPrototype this[string name]
        {
            get { return sandwitches[name]; }
            set { sandwitches.Add(name, value); }
        }
    }
}
