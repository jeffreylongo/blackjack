using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    class Program
    {   //this is creating my deck
        static List<Card> Deck()
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
        //this will deal the user 2 cards
        static List<Card> userDeal()
        {
            var gameDeck = Deck();
            List<Card> userHand = new List<Card>();
            List<Card> dealerHand = new List<Card>();
            var counter = 0;

            userHand.Add(gameDeck[counter]);
            counter++;
            userHand.Add(gameDeck[counter]);
            counter++;

            return userHand;
        }
        //this will deal the dealer 2 cards
        static List<Card> dealerDeal()
        {
            var gameDeck = Deck();
            List<Card> userHand = new List<Card>();
            List<Card> dealerHand = new List<Card>();
            var counter = 0;

            dealerHand.Add(gameDeck[counter]);
            counter++;
            dealerHand.Add(gameDeck[counter]);
            counter++;

            return dealerHand;
        }



        static void Main(string[] args)
        {

            foreach (var item in collection)
            {

            }

            Console.ReadLine();
        }
    }
}
