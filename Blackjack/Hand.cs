public class Hand
{
    private List<Card> cardsInHand = new List<Card>();

    public Hand()
    {

    } 

    public void addCardToHand(Card card)
    {
        cardsInHand.Add(card);
    } 

    public List<Card> getCardsInHand()
    {
        return cardsInHand;
    } 

    public void clearHand()
    {
        cardsInHand.Clear();
    } 

    public int calculateHandValue()
    {
        int handValue = 0;
        int aceCount = 0;

        foreach (Card card in cardsInHand)
        {
            handValue += (int)card.GetRank();
            if (card.GetRank() == Card.Rank.Ace)
            {
                aceCount++;
            }
        } 

        while (handValue > 21 && aceCount > 0)
        {
            handValue -= 10;
            aceCount--;
        } 

        return handValue;
    } 
    


}