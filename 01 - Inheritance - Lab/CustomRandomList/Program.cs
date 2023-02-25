using System;

namespace CustomRandomList;

public class StartUp
{
    static void Main(string[] args)
    {
        RandomList randomList = new RandomList();

        randomList.Add("1");
        randomList.Add("334");
        randomList.Add("2341");
        randomList.Add("154");
        randomList.Add("11234");
        randomList.Add("1adsd");
        randomList.Add("13433");

        Console.WriteLine(randomList.RandomString());
    }
}