
using CollectionHierarchy.Models.Interfaces;
using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddable, IRemovable
    {
        public AddRemoveCollection()
        {
            Elements = new List<string>();
        }
        public List<string> Elements {get;private set;}

        public int Add(string element)
        {
            Elements.Insert(0, element);
            return 0;
        }

        public string Remove()
        {
            string element = Elements[Elements.Count - 1];
            Elements.RemoveAt(Elements.Count - 1);
            return element;
        }
    }
}
