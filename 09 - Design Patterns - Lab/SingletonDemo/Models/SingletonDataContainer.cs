using SingletonDemo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace SingletonDemo.Models
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private Dictionary<string, int> _capitals;

        private static SingletonDataContainer instance = new SingletonDataContainer();

        private SingletonDataContainer()
        {
            _capitals = new Dictionary<string, int>();

            Console.WriteLine("Initializing singleton object!");

            var elements = File.ReadAllLines("../../../capitals.txt");

            for (int i = 0; i < elements.Length; i += 2)
            {
                _capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }

        public static SingletonDataContainer Instance => instance;

        public int GetPopulation(string name)
        {
            return _capitals[name];
        }
    }
}
