﻿using System;
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
            flop = new List<Card>();


        }


        public void removeCards()
        {
            flop.Clear();
            turn = null; 
            river = null;

        }

      

        public void setFlop(List<Card> cards)
        {
            flop.AddRange(cards); 
        }

        public void setTurn(Card card)
        {
            this.turn = card; 
        }

        public void setRiver(Card card)
        {
            this.river = card; 
        }

        public List<Card> getCards()
        {

            List<Card> cards = new List<Card>();

            if (flop.Count != 0)
            {
                cards.Add(flop[0]);
                cards.Add(flop[1]);
                cards.Add(flop[2]);
            }
            if (turn != null)
                cards.Add(turn);
            if (river != null)
                cards.Add(river);


            return cards; 
        }
    }
}
