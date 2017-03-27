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
        //this will deal 1 card and remote it from the deck
        static Card DealCard()
        {
            var newCard = deck[0];
            deck.RemoveAt(0);
            return newCard;
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
        static List<Card> HitOrStayPromptAndUserInput(List<Card> userHand)
        {
            Console.WriteLine("Enter (H) to HIT or Enter (S) to STAY.");
            var result = Console.ReadLine();
            while (result != "H" && result != "S")
            {
                Console.WriteLine("I said Enter (S) or (H)");
                result = Console.ReadLine();
            }
            if (result == "H")
            {
                deck.RemoveAt(0);
                userHand.Add(deck[0]);
                return userHand;
            }
            else
            {
                return userHand;
            }
        }


        static void Main(string[] args)
        {
            //Start:
            deck = CreateAndShuffleDeck();
            var userHand = DealHand();
            var dealerHand = DealHand();

            Greeting();
            DisplayHand(userHand);
            DisplayUserHandTotalMessage();

            //this will get and display user hand value
            var userCardValueSum = 0;
            List<int> cardValue = new List<int>();
            foreach (Card card in userHand)
            {
                cardValue.Add(card.GetCardValue());
                userCardValueSum = cardValue.Sum(x => Convert.ToInt32(x));
            }
            Console.WriteLine(userCardValueSum);


            //this will calculate the dealer hands value
            var dealerCardValueSum = 0;
            List<int> dealerCardValue = new List<int>();
            foreach (Card card in dealerHand)
            {
                dealerCardValue.Add(card.GetCardValue());
                dealerCardValueSum = dealerCardValue.Sum(x => Convert.ToInt32(x));
            }

            ShowDealerCardMessage();

            //this is showing one of the dealers cards. 
            DisplayHand(dealerHand.Take(1));


            HitOrStayPromptAndUserInput(userHand);
            DisplayHand(userHand);
            DisplayUserHandTotalMessage();

            //this will get and display user hand value
            List<int> cardValueUpdate = new List<int>();
            foreach (Card card in userHand)
            {
                cardValueUpdate.Add(card.GetCardValue());
            }
            Console.WriteLine(cardValueUpdate.Sum(x => Convert.ToInt32(x)));

            //this will run the hit option for user again
            /*HitOrStayPromptAndUserInput(userHand);
            DisplayHand(userHand);
            DisplayUserHandTotalMessage();*/

            //this will get and display user hand value
            var cardValueUpdate2Sum = 0;
            List<int> cardValueUpdate2 = new List<int>();
            foreach (Card card in userHand)
            {
                cardValueUpdate2.Add(card.GetCardValue());
            }
            cardValueUpdate2Sum = cardValueUpdate2.Sum(x => Convert.ToInt32(x));

            //this will hit for the dealer if he has less than 17
            var newDealerCard = deck[0];
            while (dealerCardValueSum < 17 && dealerCardValueSum >= 21)
            {
                DealCard();
                dealerHand.Add(newDealerCard);
            }

            //this will calculate the dealers hand value again
            var dealerCardValue2Sum = 0;
            List<int> dealerCardValue2 = new List<int>();
            foreach (Card card in dealerHand)
            {
                dealerCardValue2.Add(card.GetCardValue());
            }
            dealerCardValue2Sum = dealerCardValue2.Sum(x => Convert.ToInt32(x));

            //this will compare user hand and dealer hand value. 
            if (dealerCardValue2Sum == 21)
            {
                Console.WriteLine("You lose, dealer has 21.");
                Console.ReadKey();
            }
            else if (cardValueUpdate2Sum > 21)
            {
                Console.WriteLine("You bust...that means lose.");
                Console.ReadKey();
            }
            else if (cardValueUpdate2Sum <= 21 && cardValueUpdate2Sum > dealerCardValue2Sum)
            {
                Console.WriteLine("You win, hooray.");
            }
            else
            {
                Console.WriteLine("You lose.");
            }
            Console.WriteLine("The dealer has: " + dealerCardValue2Sum);
            Console.WriteLine("You have: " + cardValueUpdate2Sum);

            Console.ReadLine();
            //goto Start;
        }
        


    }
}
