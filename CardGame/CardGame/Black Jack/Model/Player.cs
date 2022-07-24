using CardGame.Texas_Hold_em.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Black_Jack.Model
{
    internal class Player
    {

        private int cash;
        private int bet;
        private int cardValue;
        private List<Card> cards; 

        public Player()
        {

            cards = new List<Card>();   
        }
        public int Cash { get => cash; set => cash = value; }
        public int Bet { get => bet; set => bet = value; }
        public int CardValue { get => cardValue; set => cardValue = value; }
        internal List<Card> Cards { get => cards; set => cards = value; }


        public void SetValue()
        {
            cardValue = 0; 
            foreach (var card in Cards)
            {
                cardValue = cardValue + CardAdapter.GetValue(card);
            }

            if(cardValue > 21)
            {
               
                foreach (var card in cards)
                {
                    // Ace becomes 1 if 14
                    if(card.Value == 14)
                    {
                        cardValue = cardValue - 10; 
                    }
                }
            }
        }

        public void DoubleDown()
        {
            cash = cash - bet;
            bet = bet * 2;

        }


        public void AddCard(Card card)
        {
            cards.Add(card);
            SetValue(); 
        }

        internal void PlaceBet(int choice)
        {
            bet = choice;
            cash = cash - choice;

        }
        internal void Lose()
        {
            bet = 0;
        }

        internal void Win()
        {
            cash = cash + (bet * 2);
            bet = 0; 
        }

        internal void Tie()
        {
            cash = cash + bet;
            bet = 0;

        }
    }
}
