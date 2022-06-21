using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Texas_Hold_em.Model
{
    internal class SharedCards
    {

        private List<Card> flop; // 3 cards
        private Card turn; // 4th card
        private Card river; // 5th and last card

        public SharedCards()
        {



        }

        internal List<Card> Flop { get => flop; set => flop = value; }
        internal Card Turn { get => turn; set => turn = value; }
        internal Card River { get => river; set => river = value; }

        public void removeCards()
        {
            flop.Clear();
            turn = null; 
            river = null;

        }
    }
}
