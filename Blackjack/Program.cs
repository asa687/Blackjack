
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
        while(!gameOver)
        {
            bool roundOver = false; 
            bool reveal = true;
            while (!roundOver)
            {
                displayHands(playerHand, dealerHand, reveal); 
                reveal = false;
                IOOutput(1);
                string choice = IOInput();
                switch (choice)
                {
                    case "1":
                        hit(deck, playerHand, dealerHand);
                        roundOver = checkScore(playerHand, dealerHand);
                        break;
                    case "2":
                        stand(deck, playerHand, dealerHand);  
                        displayHands(playerHand, dealerHand, reveal);
                        checkEndScore(playerHand, dealerHand);
                        roundOver = true;
                        break;
                    case "3":
                        resetGame(deck, playerHand, dealerHand);
                        break; 
                    case "4":
                        IOOutput(2);
                        roundOver = true;
                        gameOver = true;
                        break;
                    default:
                        IOOutput(3);
                        break;
                }  
            } 
            resetGame(deck, playerHand, dealerHand);
            
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
        IOOutput(4);
        foreach (Card card in playerHand.getCardsInHand())
        {
            Console.WriteLine($"{card.GetRank()} of {card.GetSuit()}");
        }
        Console.WriteLine($"Total Value: {playerHand.calculateHandValue()}");

        IOOutput(5);
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
            IOOutput(6);
            return true;
        } 
        else if(playerHand.calculateHandValue() > 21)
        {
            IOOutput(7);
            return true; 
        } 
        else if(playerHand.calculateHandValue() == 21)
        {
            IOOutput(8);  
            return true;
        } 
        else if(dealerHand.calculateHandValue() == 21)
        {
            IOOutput(9); 
            return true;
        }
        else
        {
            return false;
        }
    } 

    public static void checkEndScore(Hand playerHand, Hand dealerHand)
    {
        int playerScore = playerHand.calculateHandValue();
        int dealerScore = dealerHand.calculateHandValue();

        if (playerScore > dealerScore)
        {
            IOOutput(10);
        }
        else if (dealerScore > playerScore)
        {
            IOOutput(11);
        }
        else
        {
            IOOutput(12);
        }
    } 

    private static void IOOutput(int input)
    {
        switch (input)
        {
            case 1:
                Console.WriteLine("Choose an action: 1) Hit 2) Stand 3) Reset Game");
                break;
            case 2:
                Console.WriteLine("Game over.");
                break;
            case 3:
                Console.WriteLine("Invalid choice. Please choose again.");
                break;
            case 4:
                Console.WriteLine("Player's Hand:");
                break; 
            case 5:
                Console.WriteLine("\nDealer's Hand:");
                break; 
            case 6: 
                Console.WriteLine("Dealer bust"); 
                break; 
            case 7: 
                Console.WriteLine("Player bust");  
                break; 
            case 8: 
                Console.WriteLine("Blackjack! Player wins");  
                break; 
            case 9: 
                Console.WriteLine("Blackjack! Dealer wins"); 
                break; 
            case 10:
                Console.WriteLine("Player wins!");
                break; 
            case 11: 
                Console.WriteLine("Dealer wins!");
                break; 
            case 12: 
                Console.WriteLine("It's a tie!");
                break;
            default:
                Console.WriteLine("Invalid choice. Please choose again.");
                break;
        }
    } 

    private static String IOInput()
    {
        return Console.ReadLine();
    }
}
