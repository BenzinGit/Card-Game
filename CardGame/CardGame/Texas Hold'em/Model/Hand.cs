using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Texas_Hold_em.Model
{
    internal class Hand
    {


        private int handValue;
        private string handName;
        // 5 cards 
        private List<Card> cards; 

        

        public Hand(int handValue, List<Card> cards)
        {
            this.handValue = handValue;

            switch (handValue)
            {
                case 10:
                    handName = "Royal Flush";
                    break; 
                case 9:
                    handName = "Straight Flush";
                 break;

                case 8:
                    handName = "Four-of-a-Kind"; 
                  break;
                case 7:
                    handName = "Full House";
                    break;

                case 6:
                    handName = "Flush"; 
                 break;
            
                case 5:
                    handName = "Straight"; 
                 break;

                case 4:
                    handName = "Three-of-a-Kind";
                    break;

                case 3:
                    handName = "Two-Pair";
                    break;

                case 2:
                    handName = "One-Pair";
                    break;

                case 1:
                    handName = "High Card";
                    break;


                default:
                    break;
            }
        }   
    }
}
