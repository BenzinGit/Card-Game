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


        int wins1 = 0;
        int wins2 = 0;
        int wins3 = 0; 
        int wins4 = 0; 

        public TestingController()
        {

            players = new List<Player>();   
            sharedCards = new SharedCards();
            deck = new Deck(); 
        }


        private void AwardWinner(int playerIndex)
        {
            switch (playerIndex)
            {
                case 1:
                wins1++; 
                break;

                case 2:
                wins2++;
                break;

                case 3:
                wins3++;
                break;

                case 4:
                wins4++;
                break;
            }


        }

        public void RunTest()
        {
            Card cardA = new Card(14, "spades");
            Card cardB = new Card(14, "hearts");
            deck.Shuffle(); 
             


            List<Card> sharedCards = new List<Card>();

           Card card1 = new Card(14, "diamonds");
           Card card2 = new Card(7, "hearts");
          
           Card card3 = new Card(2, "spades");

          Card card4  = new Card(3, "hearts");
          Card card5 = new Card(4, "clubs");

            

            sharedCards.Add(card1);
            sharedCards.Add(card2);
            sharedCards.Add(card3);
          //  sharedCards.Add(card4);
          //  sharedCards.Add(card5);
          
            HoleCards holeCards = new HoleCards(cardA, cardB);
           var h =  CardEvaluator.EveluateHand(holeCards, sharedCards); 
            var f = CardEvaluator.SimulateRound(holeCards, sharedCards, 24, 10000);
            Console.WriteLine(h.HandName);
            Console.WriteLine(f);


        }

        public void RunTest2()
        {


            players.Add(new Player("1", 1));
            players.Add(new Player("2", 2)); 
            players.Add(new Player("3", 3));
            players.Add(new Player("4", 4));




            List<Card> removedCards = new List<Card>();
            List<Card> flop = new List<Card>(); 

            deck = new Deck();



            Card cardA = new Card(13, "hearts");
            Card cardB = new Card(13, "clubs");

            players[0].HoleCards.SetCards(cardA, cardB);
            deck.RemoveCard(cardA); 
            deck.RemoveCard(cardB);
            



            for (int i = 0; i < 10000; i++)
            {

                deck.Shuffle();
              
                for (int j = 1; j < 4; j++)
                {
                    Card card1 = deck.DrawCard();

                    Card card2 = deck.DrawCard();

                    removedCards.Add(card1);
                    removedCards.Add(card2);


                    players[j].HoleCards.SetCards(card1, card2);
                }
               

               



                Card card3 = deck.DrawCard();
                Card card4 = deck.DrawCard();
                Card card5 = deck.DrawCard();
                flop.Add(card3);
                flop.Add(card4);
                flop.Add(card5);
                sharedCards.SetFlop(flop);

                removedCards.Add(card3);
                removedCards.Add(card4);
                removedCards.Add(card5);

                Card card6 = deck.DrawCard();
                removedCards.Add(card6);
                sharedCards.SetTurn(card6);

                Card card7 = deck.DrawCard();
                removedCards.Add(card7);
                sharedCards.SetRiver(card7);

               var winner = CardEvaluator.DecideWinner(players, sharedCards.GetCards());

                foreach (var item in winner)
                {
                    AwardWinner(item.Id); 


                }
               

                deck.AddCards(removedCards);
                removedCards.Clear();
                sharedCards.RemoveCards(); 

            }

            Console.WriteLine(wins1);
            Console.WriteLine(wins2);
            Console.WriteLine(wins3);
            Console.WriteLine(wins4);



        }


    }
}
