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
        private Card card1, card2;
        private int bet; 
        private Boolean isDealer; 
        private AI ai; 

        public Player(string name)
        {
            this.name = name; 

        }

        public string Name { get => name; set => name = value; }
        public int Cash { get => cash; set => cash = value; }
        public bool IsDealer { get => isDealer; set => isDealer = value; }
        public int Bet { get => bet; set => bet = value; }
        internal Card Card1 { get => card1; set => card1 = value; }
        internal Card Card2 { get => card2; set => card2 = value; }


        public void makeBet(int newBet)
        {
            bet = newBet;
            cash = cash - newBet;


        }


    }


    
}
