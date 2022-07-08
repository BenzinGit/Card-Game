﻿using System;
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
        private Boolean isPassive;
        private Boolean hasFolded;


        private int bet; 
        private Boolean isDealer; 
        private AI ai;
        private Hand endHand; 

        public Player(string name)
        {
            this.name = name;
            holeCards = new HoleCards(null, null);
            ai = new AI();
            isPassive = false;
            hasFolded = false; 
        }

        public string Name { get => name; set => name = value; }
        public int Cash { get => cash; set => cash = value; }
        public bool IsDealer { get => isDealer; set => isDealer = value; }
        public int Bet { get => bet; set => bet = value; }
    
        internal HoleCards HoleCards { get => holeCards; set => holeCards = value; }
        public bool IsPassive { get => isPassive; set => isPassive = value; }
        internal AI Ai { get => ai; set => ai = value; }
        public bool HasFolded { get => hasFolded; set => hasFolded = value; }
        internal Hand EndHand { get => endHand; set => endHand = value; }




        // returns 1 = call
        // returns >cashToCall = raise
        // returns -1 = fold
        internal int MakeDecision(int cashToCall, int pot, int playersLeft, List<Card> cardsOnTable)
        {
            

                if (cardsOnTable.Count == 0)
                {
                    ai.MakeDecision(2);
                    return 1;
                }

                else
                {
                    return 1;
                }

            
            

        }

       



        public void Call(int newBet)
        {
            int diff = newBet - bet;
            bet = newBet;
            cash = cash - diff;

            isPassive = true;
        }

        public void Raise(int newBet)
        {

            bet = newBet + bet;
            cash = cash - newBet;

        }

        internal void Fold()
        {
            hasFolded = true;
            isPassive = true;

        }
    }


    
}
