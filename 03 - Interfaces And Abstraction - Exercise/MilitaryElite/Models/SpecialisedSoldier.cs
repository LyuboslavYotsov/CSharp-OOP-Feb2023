using System;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, Corps corp) : base(id, firstName, lastName, salary)
        {
            Corps = corp;
        }

        public Corps Corps { get; private set; }

        public override string ToString() => base.ToString();
    }
}
