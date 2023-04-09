using Raiding.Factories;
using Raiding.Models;
using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Raiding;
public class StartUp
{
    static void Main(string[] args)
    {
        int heroCount = int.Parse(Console.ReadLine());
        List<IHero> raidParty = new List<IHero>();
        IHeroFactory heroFactory = new HeroFactory();

        while (heroCount > 0)
        {
            string heroName = Console.ReadLine();
            string heroType = Console.ReadLine();

            try
            {
                raidParty.Add(heroFactory.CreateHero(heroName, heroType));
                heroCount--;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception)
            {
                throw;
            }
        }

        int bossPower = int.Parse(Console.ReadLine());

        int heroesPower = 0;
        foreach (var hero in raidParty)
        {
            Console.WriteLine(hero.CastAbility());
            heroesPower += hero.Power;
        }

        if (heroesPower >= bossPower)
        {
            Console.WriteLine("Victory!");
        }
        else
        {
            Console.WriteLine("Defeat...");
        }
    }
}