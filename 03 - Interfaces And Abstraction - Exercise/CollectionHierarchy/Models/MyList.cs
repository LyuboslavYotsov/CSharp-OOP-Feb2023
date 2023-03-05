

using CollectionHierarchy.Models.Interfaces;
using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
    public class MyList : IAddable, IRemovable
    {
        public MyList()
        {
            Elements = new List<string>();
        }
        public List<string> Elements {get; private set;}
        public int Used => Elements.Count;

        public int Add(string element)
        {
            Elements.Insert(0, element);
            return 0;
        }

        public string Remove()
        {
            string element = Elements[0];
            Elements.RemoveAt(0);
            return element;
        }
    }
}
