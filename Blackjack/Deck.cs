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
        Random rng = new Random(); 
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = rng.Next(0, i + 1); 
            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        } 
        decklist.Clear();  
        foreach (Card card in cards)
        {
            decklist.Push(card);
        }
    }
}