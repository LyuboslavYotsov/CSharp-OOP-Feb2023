
using System.Collections.Generic;

namespace CollectionHierarchy.Models.Interfaces
{
    public interface IAddable
    {
        List<string> Elements { get; }

        int Add(string element);
    }
}
