﻿using System;
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
        static void DisplayHand(List<Card> hand)
        {
            foreach (Card card in hand)
            {
                Console.WriteLine(card);
            }
        }

        static void Greeting()
        {
            Console.WriteLine("Welcome to Ghetto BlackJack...if you're lucky, if you press ::RETURN:: you will get 2 cards.");
        }

        static void ShowDealerCardMessage()
        {
            Console.WriteLine("Press ::RETURN:: to see the dealers dirt");
        }

        static void Main(string[] args)
        {

            deck = CreateAndShuffleDeck();
            var userHand = DealHand();
            var dealerHand = DealHand();

            Greeting();
            Console.ReadKey();

            DisplayHand(userHand);
            ShowDealerCardMessage();
            Console.ReadKey();
            
            DisplayHand(dealerHand);

            /*foreach (var i in deck)
            {
                Console.WriteLine(i);
            }*/
            Console.ReadLine();
        }
    }
}
