// See https://aka.ms/new-console-template for more information

using System.Reflection;
using System.Security.Cryptography.X509Certificates;

public abstract class Card : IComparable<Card>
{
    public abstract int GetValue();
    public int CompareTo(Card other)
    {
      return this.GetValue().CompareTo(other.GetValue());
    }
}

public enum Suit { Hearts, Spades, Clubs, Diamonds }
public class PlayingCard : Card
{
    public Suit Suit { get; set; }
    public int Value { get; set; }
    private  Dictionary<string, int> _dict;

    public  Dictionary<string, int> Dict
    {
        get
        {
            if (_dict == null)
            {
                _dict = new Dictionary<string, int>()
              {
                {"A", 1},
                {"J", 11},
                {"Q", 12},
                {"K", 13},
              };
            }
            for (int i = 2; i <= 10; i++)
            {
                _dict.Add(i.ToString(), i);
            }
            return _dict;
        }
        
    }

    public override string ToString()
    {
        var key = _dict.FirstOrDefault(c => c.Value == Value).Key;
        return key+" of "+Suit.ToString();
    }



    public PlayingCard(string suit,string value)
    {
        Suit = ConvertStringToSuitEnum(suit);
        Value = ConvertStringToIntValue(value);
        
    }

    private int ConvertStringToIntValue(string value)
    {
        return Dict[value];
    }

    private Suit ConvertStringToSuitEnum(string suit)
    {
        Enum.TryParse(suit, out Suit suitEnum);
        return suitEnum;
    }

    public override int GetValue()
    {
        return Value;
      
    }

}

public class Game
{
    public List<PlayingCard> PlayingCards { get; set; } = new List<PlayingCard>();
    internal void AddCard(string suit, string value)
    {
       PlayingCards.Add(new PlayingCard(suit, value));
        
    }

    internal bool CardBeats(int card1, int card2)
    {
         if (PlayingCards[card1].CompareTo(PlayingCards[card2]) > 0)
        {
            return true;
        }
        return false;
    }

    internal string CardString(int card)
    {
       return  PlayingCards[card].ToString();
    }
}