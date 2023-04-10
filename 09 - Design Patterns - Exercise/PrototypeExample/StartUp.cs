using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeExample
{
    public class StartUp
    {
        static void Main()
        {
            SandwitchMenu sandwitchMenu = new SandwitchMenu();

            sandwitchMenu["BLT"] = new Sandwitch("Wheat", "Bacon", "", "Lettuce, Tomato");
            sandwitchMenu["PB&J"] = new Sandwitch("White", "", "", "Peanut Butter, Jelly");
            sandwitchMenu["Turkey"] = new Sandwitch("Rye", "Turkey", "Swiss", "Letuce, Onion, Tomato");


            sandwitchMenu["LoadedBLT"] = new Sandwitch("Wheat", "Turkey, Bacon", "American", "Letuce, Onion, Tomato, Olives");
            sandwitchMenu["ThreeMeatCombo"] = new Sandwitch("Rye", "Turkey, Ham, Salami", "Provolone", "Letuce, Onion");
            sandwitchMenu["Vegetarian"] = new Sandwitch("Wheat", "", "", "Letuce, Onion, Tomato, Olives, Spinach");

            Sandwitch sandwitch1 = sandwitchMenu["BLT"].Clone() as Sandwitch;
            Sandwitch sandwitch2 = sandwitchMenu["ThreeMeatCombo"].Clone() as Sandwitch;
            Sandwitch sandwitch3 = sandwitchMenu["Vegetarian"].Clone() as Sandwitch;

        }
    }
}
