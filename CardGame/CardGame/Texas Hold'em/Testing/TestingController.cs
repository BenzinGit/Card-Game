using CardGame.Texas_Hold_em.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Texas_Hold_em.Testing
{
    internal class TestingController
    {

        private Deck deck;
        private List<Player> players;
        private SharedCards sharedCards; 


        public TestingController()
        {

            players = new List<Player>();   
            sharedCards = new SharedCards();
        }

        public void RunTest()
        {
            Player dumbPlayer = new Player("2", 2); 


            players.Add(new Player("1", 1));
            players.Add(new Player("2", 2));

         


            List<Card> removedCards = new List<Card>();
            List<Card> flop = new List<Card>(); 

            deck = new Deck();

            for (int i = 0; i < 1; i++)
            {

                deck.shuffleDeck();

                foreach (var player in players)
                {
                    Card card1 = deck.drawCard();

                    Card card2 = deck.drawCard();

                    removedCards.Add(card1);
                    removedCards.Add(card2);

                   
                    player.HoleCards.SetCards(card1, card2); 
                }

               // players[0].HoleCards.SetCards(new Card(9, "diamonds"), new Card(9, "hearts"));
                players[0].HoleCards.Card1.printCard();
                players[0].HoleCards.Card2.printCard();

                int f = CardEvaluator.EveluateStartingHand(players[0].HoleCards);
                Console.WriteLine(f);

                Card card3 = deck.drawCard();
                Card card4 = deck.drawCard();
                Card card5 = deck.drawCard();
                flop.Add(card3);
                flop.Add(card4);
                flop.Add(card5);
                sharedCards.setFlop(flop);

                removedCards.Add(card3);
                removedCards.Add(card4);
                removedCards.Add(card5);

                Card card6 = deck.drawCard();
                removedCards.Add(card6);
                sharedCards.setTurn(card6);

                Card card7 = deck.drawCard();
                removedCards.Add(card7);
                sharedCards.setRiver(card7);

               var winner = CardEvaluator.DecideWinner(players, sharedCards.getCards());

               

                deck.AddCards(removedCards);
                removedCards.Clear();
                sharedCards.RemoveCards(); 

            }
          

           


        }


    }
}
