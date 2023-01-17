// Black Jack by Jordan. A
#nullable disable
List<Cards> fullDeck = new List<Cards>{};
fullDeck.Add(new Cards("♠", "A", 11));
fullDeck.Add(new Cards("♠", "2", 2));
fullDeck.Add(new Cards("♠", "3", 3));
fullDeck.Add(new Cards("♠", "4", 4));
fullDeck.Add(new Cards("♠", "5", 5));
fullDeck.Add(new Cards("♠", "6", 6));
fullDeck.Add(new Cards("♠", "7", 7));
fullDeck.Add(new Cards("♠", "8", 8));
fullDeck.Add(new Cards("♠", "9", 9));
fullDeck.Add(new Cards("♠", "10", 10));
fullDeck.Add(new Cards("♠", "J", 10));
fullDeck.Add(new Cards("♠", "Q", 10));
fullDeck.Add(new Cards("♠", "K", 10));
fullDeck.Add(new Cards("♥", "A", 11));
fullDeck.Add(new Cards("♥", "2", 2));
fullDeck.Add(new Cards("♥", "3", 3));
fullDeck.Add(new Cards("♥", "4", 4));
fullDeck.Add(new Cards("♥", "5", 5));
fullDeck.Add(new Cards("♥", "6", 6));
fullDeck.Add(new Cards("♥", "7", 7));
fullDeck.Add(new Cards("♥", "8", 8));
fullDeck.Add(new Cards("♥", "9", 9));
fullDeck.Add(new Cards("♥", "10", 10));
fullDeck.Add(new Cards("♥", "J", 10));
fullDeck.Add(new Cards("♥", "Q", 10));
fullDeck.Add(new Cards("♥", "K", 10));
fullDeck.Add(new Cards("♦", "A", 11));
fullDeck.Add(new Cards("♦", "2", 2));
fullDeck.Add(new Cards("♦", "3", 3));
fullDeck.Add(new Cards("♦", "4", 4));
fullDeck.Add(new Cards("♦", "5", 5));
fullDeck.Add(new Cards("♦", "6", 6));
fullDeck.Add(new Cards("♦", "7", 7));
fullDeck.Add(new Cards("♦", "8", 8));
fullDeck.Add(new Cards("♦", "9", 9));
fullDeck.Add(new Cards("♦", "10", 10));
fullDeck.Add(new Cards("♦", "J", 10));
fullDeck.Add(new Cards("♦", "Q", 10));
fullDeck.Add(new Cards("♦", "K", 10));
fullDeck.Add(new Cards("♣", "A", 11));
fullDeck.Add(new Cards("♣", "2", 2));
fullDeck.Add(new Cards("♣", "3", 3));
fullDeck.Add(new Cards("♣", "4", 4));
fullDeck.Add(new Cards("♣", "5", 5));
fullDeck.Add(new Cards("♣", "6", 6));
fullDeck.Add(new Cards("♣", "7", 7));
fullDeck.Add(new Cards("♣", "8", 8));
fullDeck.Add(new Cards("♣", "9", 9));
fullDeck.Add(new Cards("♣", "10", 10));
fullDeck.Add(new Cards("♣", "J", 10));
fullDeck.Add(new Cards("♣", "Q", 10));
fullDeck.Add(new Cards("♣", "K", 10));


bool gameLoop = true;
while (gameLoop)
{
    Console.WriteLine("1: Start a new game");
    Console.WriteLine("2: Exit");
    string gameOption = Console.ReadLine();

    if (gameOption == "1")
    {
        // Initialize Cards
        Console.Clear();
        List<Cards> newDeck = new List<Cards>(fullDeck);
        List<Cards> dealerHand = new List<Cards>{};
        List<Cards> playerHand = new List<Cards>{};

        addRandomCard(newDeck, dealerHand);
        addRandomCard(newDeck, dealerHand);

        addRandomCard(newDeck, playerHand);
        addRandomCard(newDeck, playerHand);

        // Log initial cards
        
        int dealerHandTotal = dealerHand.Sum(Cards => Cards.Value);
        int playerHandTotal = playerHand.Sum(Cards => Cards.Value);
        
        bool stand = false;
        while (dealerHandTotal < 21 && playerHandTotal < 21)
        {
            if (stand == false)
            {
                updateAndLogCardInfo(dealerHand, playerHand, false);
                Console.WriteLine("TYPE 1 TO HIT | TYPE 2 TO STAND");
                string choice = Console.ReadLine();
                if (choice == "1") {
                    addRandomCard(newDeck, playerHand);
                } 
                else if (choice == "2") 
                {
                    if (dealerHandTotal < 17)
                    {
                        stand = true;
                    }
                    else
                    {
                        break;
                    }
                } 
            }


            if (dealerHandTotal < 17)
            {
                addRandomCard(newDeck, dealerHand);
            }
            else if (stand == true && dealerHandTotal >= 17)
            {
                break;
            }

            dealerHandTotal = dealerHand.Sum(Cards => Cards.Value);
            playerHandTotal = playerHand.Sum(Cards => Cards.Value);
        }
        updateAndLogCardInfo(dealerHand, playerHand, true);
        if (dealerHandTotal == 21 && playerHandTotal != 21) 
        {
            Console.WriteLine("Lose the dealer got to 21 before you");
        } 
        else if (playerHandTotal == 21 && dealerHandTotal != 21) 
        {
            Console.WriteLine("Win you got to 21 before the dealer");
        } 
        else if (playerHandTotal > 21 && dealerHandTotal > 21)
        {
            Console.WriteLine("Player Bust");
        }
        else if (dealerHandTotal > 21) 
        {
            Console.WriteLine("Dealer Bust");
        } 
        else if (playerHandTotal > 21) 
        {
            Console.WriteLine("Player Bust");
        } 
        else if (playerHandTotal == dealerHandTotal)
        {
            Console.WriteLine("Tie");
        } 
        else if (dealerHandTotal > playerHandTotal)
        {
            Console.WriteLine("Dealer Win");
        } 
        else if (playerHandTotal > dealerHandTotal)
        {
            Console.WriteLine("Player Win");
        } 
    }
    else if (gameOption == "2")
    {
        gameLoop = false;
    }
}

static void updateAndLogCardInfo(List<Cards> DH, List<Cards> PH, bool gameComplete)
{   
    Console.Clear();
    string dealerInfo = "";
    string playerInfo = "";
    int dealerTotal = DH.Sum(Cards => Cards.Value);
    int playerTotal = PH.Sum(Cards => Cards.Value);

        if (gameComplete)
        {
            for (int n = 0; n < DH.Count; n++)
            {
                dealerInfo += $"|{DH[n].getCardInfo()}|";
            }
        } 
        else
        {
            dealerInfo += $"|{DH[0].getCardInfo()}|";
            for (int n = 0; n < DH.Count - 1; n++)
            {
                dealerInfo += "|?|";
            }
        }

    

    for (int n = 0; n < PH.Count; n++)
    {
        playerInfo += $"|{PH[n].getCardInfo()}|";
    }

    // Log to console
    if (gameComplete)
    {
        Console.WriteLine("(Dealer)");
        Console.WriteLine(dealerInfo);
        Console.WriteLine($"Total: {dealerTotal}");
        Console.WriteLine("(Player)");
        Console.WriteLine(playerInfo);
        Console.WriteLine($"Total: {playerTotal}");
    } 
    else
    {
        Console.WriteLine("(Dealer)");
        Console.WriteLine(dealerInfo);
        Console.WriteLine($"Total: ?");
        Console.WriteLine("(Player)");
        Console.WriteLine(playerInfo);
        Console.WriteLine($"Total: {playerTotal}");
    }

}

static void addRandomCard(List<Cards> deck, List<Cards> hand)
{
    Random rnd = new Random();
    int i = rnd.Next(0, deck.Count);
    // ACE
    if (deck[i].Symbol == "A" && (hand.Sum(Cards => Cards.Value) + 11 > 21))
    {
        hand.Add(new Cards(deck[i].Type, deck[i].Symbol, 1));
    }
    else
    {
    hand.Add(deck[i]);
    }
    deck.RemoveAt(i);
}

public class Cards
{
    public string Type { get; }
    public string Symbol { get; }
    public int Value { get; }

    public string getCardInfo() 
    {
        return $"{Type} {Symbol}";
    }

    public Cards(string type, string symbol, int value)
    {
        this.Type = type;
        this.Symbol = symbol;
        this.Value = value;
    }
}
