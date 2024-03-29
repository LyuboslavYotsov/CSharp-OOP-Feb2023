﻿

using Raiding.Models.Interfaces;
using System.Dynamic;

namespace Raiding.Models
{
    public abstract class BaseHero : IHero
    {
        protected BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public string Name { get; private set; }

        public  int Power { get; private set; }

        public abstract string CastAbility();
    }
}
