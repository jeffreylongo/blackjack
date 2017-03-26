using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    class Program
        {   
        static List<Card> deck;
        //this is creating my deck
        static List<Card> CreateAndShuffleDeck()
        {
            var deck = new List<Card>();

            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                    deck.Add(new Card(s, r));
                }
            }
            //sort the deck. NOTICE that the variable 'deck' is unchanged, but 'randomDeck' is the actual sorted deck.
            var randomDeck = deck.OrderBy(x => Guid.NewGuid()).ToList();
            return randomDeck;
        }
        //this will deal a card from the top of the deck and remove it from the List 
        static List<Card> DealHand()
        {
            List<Card> hand = new List<Card>();
            var newCard = deck[0];
            deck.RemoveAt(0);
            hand.Add(newCard);

            newCard = deck[0];
            deck.RemoveAt(0);
            hand.Add(newCard);
            return hand;
        }
        //This will show the hand. 
        static void DisplayHand(IEnumerable<Card> hand)
        {
            foreach (Card card in hand)
            {
                Console.WriteLine(card);
            }
        }
        //this will greet the player and prompt them for return key
        static void Greeting()
        {
            Console.WriteLine("Welcome to Ghetto BlackJack...if you're lucky, if you press ::RETURN:: you will get 2 cards.");
            Console.ReadKey();
        }
        //this will prompt them to display dealer card
        static void ShowDealerCardMessage()
        {
            Console.WriteLine("Press ::RETURN:: to see the dealers dirt.");
            Console.ReadKey();
        }
        //this will prompt user to display their total
        static void DisplayUserHandTotalMessage()
        {
            Console.WriteLine("Press ::RETURN:: to see your total card value in case you cant add.");
            Console.ReadKey();
        }
        //this will prompt the user to hit or stay and store the users answer
        static List<Card> HitOrStayPromptAndUserInput(List<Card> hand)
        {
            Console.WriteLine("Enter (H) to HIT or Enter (S) to STAY.");
            var result = Console.ReadLine();
            if (result == "H")
            {
                deck.RemoveAt(0);
                hand.Add(deck[0]);
                return hand;
            }
            else if (result == "S") 
            {
                return hand;
            }
            else 
            {
                while(result != "H" && result != "S")
                {
                    Console.WriteLine("I said Enter (S) or (H)");
                }
            }
        }


        static void Main(string[] args)
        {

            deck = CreateAndShuffleDeck();
            var userHand = DealHand();
            var dealerHand = DealHand();

            Greeting();
            DisplayHand(userHand);
            DisplayUserHandTotalMessage();

            //this will get and display user hand value
            List<int> cardValue = new List<int>();
            foreach (Card card in userHand)
            {
                cardValue.Add(card.GetCardValue());
            }
            Console.WriteLine(cardValue.Sum(x => Convert.ToInt32(x)));


            //this will calculate the dealer hands value
            List<int> dealerCardValue = new List<int>();
            foreach (Card card in dealerHand)
            {
                dealerCardValue.Add(card.GetCardValue());
            }

            ShowDealerCardMessage();

            //this is showing one of the dealers cards. 
            DisplayHand(dealerHand.Take(1));

            HitOrStayPrompt();


            Console.ReadLine();
        }
    }
}
