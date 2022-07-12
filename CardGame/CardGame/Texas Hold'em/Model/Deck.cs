using CardGame.Texas_Hold_em.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Deck
    {
        private List<Card> deck;

    

        public Deck()
        {

            deck = new List<Card>();
            setUpDeck();
        }


        private void setUpDeck()
        {
            List<Suit> suitList = new List<Suit>();
            suitList.Add(new Suit(Suit.CardSuit.Clubs));
            suitList.Add(new Suit(Suit.CardSuit.Spades));
            suitList.Add(new Suit(Suit.CardSuit.Hearts));
            suitList.Add(new Suit(Suit.CardSuit.Diamonds));

            foreach (var suits in suitList)
            {
                for (int i = 2; i < 15; i++)
                {
                    deck.Add(new Card(i, suits));
                }
             }
        }

        public void AddCards(List<Card> cards)
        {
            foreach (var card in cards)
            {
                deck.Add(card); 
            }

        }

        public Card drawCard()
        {

            Card card = deck[0];
            deck.Remove(card);

            return card;
        }

        public List<Card> drawCards(int x)
        {
            List<Card> cards = new List<Card>();

            for (int i = 0; i < x; i++)
            {
              cards.Add(drawCard());
            }

            return cards;
        }


        public int cardsLeft()
        {
            return deck.Count;
        }



        public void shuffleDeck()
        {
            Random random = new Random(); 


            for (int i = 0; i < 52; i++)
            {
                int randNum = random.Next(0, deck.Count);
                Card temp = deck[i];
                deck[i] = deck[randNum];
                deck[randNum] = temp;

            }


        }

        public void printDeck()
        {

            foreach (var card in deck)
            {

                card.printCard();

            }


        }



    }
}
