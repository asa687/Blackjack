using System.Runtime.CompilerServices;

public class Card
{  
    private Suit suit; 
    private Rank rank; 

    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    } 
    public enum Rank
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 10,
        Queen = 10,
        King = 10,
        Ace = 11
    } 

    public Card()
    {
        
    } 

    public Card(Suit suit, Rank rank)
    {
        this.suit = suit;
        this.rank = rank;
    } 

    public Suit GetSuit()
    {
        return suit;
    } 

    public Rank GetRank()
    {
        return rank;
    }
    
}