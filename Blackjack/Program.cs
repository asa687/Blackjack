
using System.Configuration.Assemblies;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Blackjack!"); 
        Deck deck = new Deck();
        Hand playerHand = new Hand();
        Hand dealerHand = new Hand();
        dealInitialCards(deck, playerHand, dealerHand);
        gameLoop(deck, playerHand, dealerHand);
    }    

    public static void gameLoop(Deck deck, Hand playerHand, Hand dealerHand)
    {
        bool gameOver = false; 
        bool reveal = true;
        while (!gameOver)
        {
            displayHands(playerHand, dealerHand, reveal); 
            reveal = false;
            Console.WriteLine("Choose an action: 1) Hit 2) Stand 3) Reset Game");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    hit(deck, playerHand, dealerHand);
                    gameOver = checkScore(playerHand, dealerHand);
                    break;
                case "2":
                    stand(deck, playerHand, dealerHand);
                    gameOver = checkScore(playerHand, dealerHand);
                    break;
                case "3":
                    resetGame(deck, playerHand, dealerHand);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }  
            displayHands(playerHand, dealerHand, reveal);

        }
    }

    public static void resetGame(Deck deck, Hand playerHand, Hand dealerHand)
    {
        playerHand.clearHand();
        dealerHand.clearHand();
        deck = new Deck();
        dealInitialCards(deck, playerHand, dealerHand);
    }

    public static void stand(Deck deck, Hand playerHand, Hand dealerHand)
    {
        while (dealerHand.calculateHandValue() < 17)
        {
            dealerHand.addCardToHand(deck.drawCard());
        }
    } 




    public static void hit(Deck deck, Hand playerHand, Hand dealerHand)
    {
        playerHand.addCardToHand(deck.drawCard()); 
    }

    public static void dealInitialCards(Deck deck, Hand playerHand, Hand dealerHand)
    {
        playerHand.addCardToHand(deck.drawCard());
        dealerHand.addCardToHand(deck.drawCard());
        playerHand.addCardToHand(deck.drawCard());
        dealerHand.addCardToHand(deck.drawCard());
    } 

    public static void displayHands(Hand playerHand, Hand dealerHand, bool hideDealerCard)
    {
        Console.WriteLine("Player's Hand:");
        foreach (Card card in playerHand.getCardsInHand())
        {
            Console.WriteLine($"{card.GetRank()} of {card.GetSuit()}");
        }
        Console.WriteLine($"Total Value: {playerHand.calculateHandValue()}");

        Console.WriteLine("\nDealer's Hand:");
        if (hideDealerCard)
        {
            Card firstCard = dealerHand.getCardsInHand()[0];
            Console.WriteLine($"{firstCard.GetRank()} of {firstCard.GetSuit()}");
            Console.WriteLine("Hidden Card");
        }
        else
        {
            foreach (Card card in dealerHand.getCardsInHand())
            {
                Console.WriteLine($"{card.GetRank()} of {card.GetSuit()}");
            }
            Console.WriteLine($"Total Value: {dealerHand.calculateHandValue()}");
        }
    } 

    public static Boolean checkScore(Hand playerHand, Hand dealerHand)
    {
        if(dealerHand.calculateHandValue() > 21)
        {
            Console.WriteLine("Dealer bust"); 
            return true;
        } 
        else if(playerHand.calculateHandValue() > 21)
        {
            Console.WriteLine("Player bust");  
            return true; 
        } 
        else if(playerHand.calculateHandValue() == 21)
        {
            Console.WriteLine("Blackjack! Player wins");  
            return true;
        } 
        else if(dealerHand.calculateHandValue() == 21)
        {
            Console.WriteLine("Blackjack! Dealer wins"); 
            return true;
        }
        else
        {
            return false;
        }
    }
}
