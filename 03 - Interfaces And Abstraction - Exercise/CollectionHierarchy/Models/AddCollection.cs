

using CollectionHierarchy.Models.Interfaces;
using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
    public class AddCollection : IAddable
    {
        public AddCollection()
        {
            Elements = new List<string>();
        }
        public List<string> Elements { get; private set; }

        public int Add(string element)
        {
            int index = Elements.Count;
           
            Elements.Insert(index, element);
            return index;
        }
    }
}
