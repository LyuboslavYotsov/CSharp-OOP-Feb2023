using ShoppingSpree;
using System;
using System.Collections.Generic;
using System.Linq;

List<Person> people = new List<Person>();
List<Product> products = new List<Product>();

string peopleInput = Console.ReadLine();
string productsInput = Console.ReadLine();

string[] personAndMoney = peopleInput
    .Split(";", StringSplitOptions.RemoveEmptyEntries);
string[] productWithPrice = productsInput
    .Split(";", StringSplitOptions.RemoveEmptyEntries);

foreach (var personInfo in personAndMoney)
{
    string[] info = personInfo.Split("=");
    string name = info[0];
    decimal money = decimal.Parse(info[1]);
    try
    {
        Person newPerson = new Person(name, money);
        people.Add(newPerson);

    }
    catch (Exception exception)
    {

        Console.WriteLine(exception.Message);
        return;
    }
}

foreach (var product in productWithPrice)
{
    string[] info = product.Split("=");
    string name = info[0];
    decimal price = decimal.Parse(info[1]);
    try
    {
        Product currProduct = new Product(name, price);
        products.Add(currProduct);

    }
    catch (Exception exception)
    {

        Console.WriteLine(exception.Message);
        return;
    }
}

string input;
while ((input = Console.ReadLine()) != "END")
{
    string[] commArgs = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string personName = commArgs[0];
    string productName = commArgs[1];

    Product currentProduct = products.FirstOrDefault(p => p.Name == productName);
    foreach (var person in people)
    {
        if (person.Name == personName)
        {
            person.Buy(currentProduct);
            break;
        }
    }
}

foreach (var person in people)
{
    if (person.Products.Count > 0)
    {
        List<string> productsBag = new List<string>();
        foreach (var product in person.Products)
        {
            productsBag.Add(product.Name);
        }
        Console.WriteLine($"{person.Name} - {string.Join(", ", productsBag)}");
    }
    else
    {
        Console.WriteLine($"{person.Name} - Nothing bought");
    }
}
