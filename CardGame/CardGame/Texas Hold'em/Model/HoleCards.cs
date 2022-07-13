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
                SetCards(card1, card2);

            }


        }

        // card1 will always be higher than card2
        public void SetCards(Card card1, Card card2)
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

        internal Card Card1 { get => card1;  }
        internal Card Card2 { get => card2;  }
    }
}
