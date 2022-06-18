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
            Random rnd = new Random();
            int num = rnd.Next(0,52 );

            Card card = deck[num];
            deck.Remove(card);

            return card;




        }



    }
}
