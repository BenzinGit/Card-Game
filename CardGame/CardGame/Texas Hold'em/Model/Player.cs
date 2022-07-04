using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Texas_Hold_em.Model
{
    internal class Player
    {
        private string name;
        private int cash;
        private HoleCards holeCards;
      


        private int bet; 
        private Boolean isDealer; 
        private AI ai; 

        public Player(string name)
        {
            this.name = name;
            holeCards = new HoleCards(null, null);
            ai = new AI(); 
        }

        public string Name { get => name; set => name = value; }
        public int Cash { get => cash; set => cash = value; }
        public bool IsDealer { get => isDealer; set => isDealer = value; }
        public int Bet { get => bet; set => bet = value; }
    
        internal HoleCards HoleCards { get => holeCards; set => holeCards = value; }
      

        public void makeBet(int newBet)
        {
            bet = newBet;
            cash = cash - newBet;


        }

        internal int makeDecision(int cashToCall, int pot, int playersLeft, List<Card> cardsOnTable)
        {

            ai.evaluateStartingHand(holeCards);

            if(cardsOnTable.Count == 0)
            {
                CardEvaluator.eveluateStartingHand(this.holeCards);

            }
            else
            {


            }
            return 1; 


        }
    }


    
}
