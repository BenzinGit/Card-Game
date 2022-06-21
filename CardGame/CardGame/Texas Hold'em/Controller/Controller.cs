using CardGame.Texas_Hold_em.Model;
using CardGame.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame.Texas_Hold_em.Controller
{
    internal class Controller
    {


        private Deck deck; 
        private List<Player> players;
        private SharedCards sharedCards;
        private Pot pot; 

        private int startingCash = 1000;
        private TexasHoldem view;

        public Controller(TexasHoldem view)
        {
            this.view = view;
         
            players = new List<Player>();
            deck = new Deck();
            sharedCards =  new SharedCards();
            pot = new Pot(); 
            startGame();

        }

        private void startGame()
        {

            players.Add(new Player("Player"));
            players.Add(new Player("Johnny"));
            players.Add(new Player("Huckleberry"));
            players.Add(new Player("Jericho"));


            foreach (var player in players)
            {
                player.Markers = startingCash; 
            
            }

            startRound();

            Card card1 = deck.drawCard();
            Card card2 = deck.drawCard();
            Card card3 = deck.drawCard();
            Card card4 = deck.drawCard();
            Card card5 = deck.drawCard();

            view.displayFlop(card1.Image, card2.Image, card3.Image);
            view.displayTurn(card4.Image);
            view.displayRiver(card5.Image);

        }

        private void startRound()
        {
            deck.shuffleDeck();

            foreach (var player in players)
            {
                player.Card1 = deck.drawCard();
                
            }

            foreach (var player in players)
            {
                player.Card2 = deck.drawCard();
            }

            showAllPlayerCards(); 

        }

        private void showPlayerCards(int playerIndex)
        {

            view.displayPlayerCards(playerIndex, players[playerIndex].Card1.Image, players[playerIndex].Card2.Image);

        }

        private void showAllPlayerCards()
        {

            for(int i = 0; i < players.Count; i++)
            {
                view.displayPlayerCards(i, players[i].Card1.Image, players[i].Card2.Image);


            }


        }

    }
}
