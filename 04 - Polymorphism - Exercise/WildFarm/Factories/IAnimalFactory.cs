

using WildFarm.Models.Interfaces;

namespace WildFarm.Factories
{
    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(string[] animalInfo);
    }
}
