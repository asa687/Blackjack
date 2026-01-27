public class Deck
{ 
    private Stack<Card> decklist = new Stack<Card>();
    public Deck()
    {
        initializeDeck(); 
        shuffleDeck();
    } 

    public Card drawCard()
    {
        return decklist.Pop(); 
    } 

    public void addCard(Card card)
    {
        decklist.Push(card);
    } 

    public void initializeDeck()
    {
        foreach (Card.Suit suit in Enum.GetValues(typeof(Card.Suit)))
        {
            foreach (Card.Rank rank in Enum.GetValues(typeof(Card.Rank)))
            {
                Card card = new Card(suit, rank);
                addCard(card);
            }
        }
    } 

    public void shuffleDeck()
    { 
        List<Card> cards = decklist.ToList();
        cards.Shuffle(); 
        decklist = new Stack<Card>(cards);
    }
}