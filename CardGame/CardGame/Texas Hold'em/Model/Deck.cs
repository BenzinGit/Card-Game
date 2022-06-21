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
        private enum Suit
        {
            Hearts, Diamonds, Clubs, Spades

        }



        public Deck()
        {

            deck = new List<Card>();
            setUpDeck();
        }


        private void setUpDeck()
        {
            foreach (string suit in Enum.GetNames(typeof(Suit)))
            { 
                for (int i = 2; i < 15; i++)
                {
                    deck.Add(new Card(i, suit));
                    
                }

             }
        }

        public Card drawCard()
        {

            Card card = deck[0];
            deck.Remove(card);

            return card;




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
