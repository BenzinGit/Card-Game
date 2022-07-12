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
            players.Add(new Player("1", 1));
            players.Add(new Player("2", 2));
            players.Add(new Player("3", 3));
            players.Add(new Player("4", 4));


            int pl1win = 0;
            int pl2win = 0;
            int pl3win = 0;
            int pl4win = 0;

            List<Card> removedCards = new List<Card>();
            List<Card> flop = new List<Card>(); 

            deck = new Deck();

            for (int i = 0; i < 10000 ; i++)
            {
                deck.shuffleDeck();

                foreach (var player in players)
                {
                    Card card1 = deck.drawCard();

                    Card card2 = deck.drawCard();

                    removedCards.Add(card1);
                    removedCards.Add(card2);

                    player.HoleCards.Card1 = card1;
                    player.HoleCards.Card2 = card2;

                }

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
         //       Console.WriteLine(winner.Name);
         //       if (winner.Name == "1")
         //           pl1win++;
        //        if (winner.Name == "2")
        /*            pl2win++;
                if (winner.Name == "3")
                    pl3win++;
                if (winner.Name == "4")
                    pl4win++;
                */


                deck.AddCards(removedCards);
                removedCards.Clear();
                sharedCards.RemoveCards(); 

            }

            Console.WriteLine("1 "+pl1win);
            Console.WriteLine("2 "+pl2win);
            Console.WriteLine("3 "+pl3win);
            Console.WriteLine("4 " +pl4win);


        }


    }
}
