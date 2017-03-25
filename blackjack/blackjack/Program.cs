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
        }
        //this will prompt them to display dealer card
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

            //this is getting your card hand value 
            /*var cardValue = 0;
            foreach (Card card in userHand)
            {
                card.GetCardValue();
                cardValue = card.GetCardValue();
            }*/
            List<int> cardValue;
            foreach (Card card in userHand)
            {
                card.GetCardValue();
                cardValue = card.GetCardValue();
            }

            //this will display the value of the cards in the hand. 
            foreach (Card card in userHand)
            {
                Console.WriteLine(cardValue);
            }


            //this is showing one of the dealers cards. 
            DisplayHand(dealerHand.Take(1));


            Console.ReadLine();
        }
    }
}
