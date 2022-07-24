using CardGame.Texas_Hold_em.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Black_Jack.Model
{
    internal static class CardAdapter
    {


        public static int GetValue(Card card)
        {
            if(card.Value == 14)
            {
                return 11; 
            }
            else if (card.Value > 10)
            {
                return 10;
            }
            
            else return card.Value; 


        }


    }
}
