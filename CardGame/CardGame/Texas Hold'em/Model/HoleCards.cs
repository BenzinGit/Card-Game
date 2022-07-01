using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Texas_Hold_em.Model
{
    internal class HoleCards
    {
        private Card card1;
        private Card card2; 
        

        public HoleCards(Card card1, Card card2)
        {
            if(card1 != null)
            {
                setCards(card1, card2);

            }


        }

        public void setCards(Card card1, Card card2)
        {
            

            if (card1.Value < card2.Value)
            {
                this.card1 = card2;
                this.card2 = card1;
            }
            else
            {

                this.card1 = card1;
                this.card2 = card2;
            }


        }

        internal Card Card1 { get => card1; set => card1 = value; }
        internal Card Card2 { get => card2; set => card2 = value; }
    }
}
