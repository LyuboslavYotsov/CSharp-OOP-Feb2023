using CollectionHierarchy.Models;
using CollectionHierarchy.Models.Interfaces;
using System;
using System.Text;

namespace CollectionHierarchy;

public class StartUp
{
    static void Main(string[] args)
    {
        string[] items = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        int removeCount = int.Parse(Console.ReadLine())
            ;
        AddCollection addCollecetion = new AddCollection();
        AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
        MyList myList = new MyList();

        Console.WriteLine(AddItem<AddCollection>(addCollecetion));
        Console.WriteLine(AddItem<AddRemoveCollection>(addRemoveCollection));
        Console.WriteLine(AddItem<MyList>(myList));

        Console.WriteLine(Remove<AddRemoveCollection>(addRemoveCollection, removeCount));
        Console.WriteLine(Remove<MyList>(myList, removeCount));


        

        string AddItem<T>(T collection) where T : IAddable
        {
            StringBuilder sb = new();
            for (int i = 0; i < items.Length; i++)
            {
                sb.Append(collection.Add(items[i]) + " ");
            }
            return sb.ToString().Trim();
        }

        string Remove<T>(T collectionToRemove, int removeCount) where T : IRemovable
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < removeCount; i++)
            {
                sb.Append(collectionToRemove.Remove() + " ");
            }
            return sb.ToString().TrimEnd();
        }
    }
}