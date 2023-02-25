﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Team
    {
		private string name;
		private List<Person> firstTeam;
		private List<Person> reserveTeam;

        public Team(string name)
        {
            Name = name;
			firstTeam= new List<Person>();
			reserveTeam= new List<Person>();
        }

        public IReadOnlyCollection<Person> ReserveTeam
		{
			get { return reserveTeam.AsReadOnly(); }
		}


		public IReadOnlyCollection<Person> FirstTeam
        {
			get { return firstTeam.AsReadOnly(); }
			
		}


		public string Name
		{
			get { return name; }
			private set { name = value; }
		}

		public void AddPlayer(Person person)
		{
			if (person.Age < 40)
			{
				firstTeam.Add(person);
			}
			else
			{
				reserveTeam.Add(person);
			}
		}

        public override string ToString()
        {
			return $"First team has {firstTeam.Count} players.{Environment.NewLine}Reserve team has {reserveTeam.Count} players.";
        }
    }
}
