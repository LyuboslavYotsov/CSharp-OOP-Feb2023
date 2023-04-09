using System;
using System.Collections.Generic;
using System.Linq;

List<Card> cardList = new List<Card>();
string cardsInfo = Console.ReadLine();
string[] cards = cardsInfo
    .Split(",", StringSplitOptions.RemoveEmptyEntries);

foreach (var card in cards)
{
    string[] cardInfo = card.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string face = cardInfo[0];
    string suit = cardInfo[1];

    try
    { 
        cardList.Add(CreateCard(face,suit));
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

Console.WriteLine(string.Join(" ", cardList));

Card CreateCard(string face, string suit) => new Card(face, suit);
class Card
{
    private IReadOnlyCollection<string> validFaces = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", };
    private IReadOnlyDictionary<string, string> validSuits = new Dictionary<string, string>
    {
        {"S","♠" },
        {"H","♥" },
        {"D","♦" },
        {"C","♣" }

    };
    private string face;
    private string suit;

    public Card(string face, string suit)
    {
        Face = face;
        Suit = suit;
    }
    public string Suit
    {
        get { return suit; }
        private set
        {
            if (validSuits.Keys.Any(s => s == value))
            {
                suit = value;
            }
            else
            {
                throw new ArgumentException("Invalid card!");
            }
        }
    }


    public string Face
    {
        get { return face; }
        private set
        {
            if (validFaces.Any(f => f == value))
            {
                face = value;
            }
            else
            {
                throw new ArgumentException("Invalid card!");
            }
        }
    }

    public override string ToString()
    {
        return $"[{Face}{validSuits[Suit]}]";
    }


}