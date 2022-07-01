using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Texas_Hold_em.Model
{
    internal class Suit
    {
        public CardSuit cardSuit; 

        public enum CardSuit
        {
            Hearts, Diamonds, Clubs, Spades
        };

        public Suit(CardSuit cardSuit)
        {
            this.cardSuit = cardSuit;
        }   
    }
}
