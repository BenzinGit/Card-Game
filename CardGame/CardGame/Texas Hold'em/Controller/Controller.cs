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
        private int startingCash = 5000;
        private int bigBlind = 50; 
        private int smallBlind = 25; 


        private Deck deck; 
        private List<Player> players;
        private SharedCards sharedCards;
        private Pot pot; 
        private TexasHoldem view;
        
        public Controller(TexasHoldem view)
        {
            this.view = view;
         
            players = new List<Player>();
            deck = new Deck();
            sharedCards =  new SharedCards();
            pot = new Pot(); 

        }

        public void setUpGame()
        {
            players.Add(new Player("You"));
            players.Add(new Player("Johnny"));
            players.Add(new Player("Barry"));
            players.Add(new Player("Jericho"));


            Random rand = new Random();

            assignDealer(rand.Next(0, 4));

            foreach (var player in players)
            {
                player.Cash = startingCash; 
            }

            view.setUpGame(players, startingCash);  

            startFirstRound();

        }

        private void startFirstRound()
        {
            assignNextDealer(); 
            deck.shuffleDeck();
            dealCards();
            int bigBlindIndex = setBlinds();
            updatePot(); 
            view.updateBoard();
            showPlayerCards(0);
            startBettingRound(bigBlindIndex);

            Card card1 = deck.drawCard();
            Card card2 = deck.drawCard();
            Card card3 = deck.drawCard();

            view.displayFlop(card1.Image, card2.Image, card3.Image); 
        }



        private int getNextPlayer(int playerIndex)
        {
            int nextPlayerIndex = playerIndex + 1; 
            if (nextPlayerIndex >= players.Count)
            {
                return 0;

            }
            else
            {
                return nextPlayerIndex;
            }
        }
        private void startBettingRound(int bigBlindIndex)
        {
            int startingPlayer = bigBlindIndex + 1;
            if (startingPlayer >= players.Count)
            {
                startingPlayer = 0;

            }



        }
        private void updatePot()
        {
            int totalPot = 0;
            foreach (var player in players)
            {
                totalPot += player.Bet; 
            }

            pot.pot = totalPot; 
        }

        private int setBlinds()
        {
            int i = currentDealer();

            int smallBlindIndex = i + 1;
            int bigBlindIndex = i + 2;

            if (smallBlindIndex >= players.Count)
            {
                smallBlindIndex = 0;

            }

            if (bigBlindIndex >= players.Count + 1)
            {
                bigBlindIndex = 1;
            }

            else if (bigBlindIndex >= players.Count)
            {
                bigBlindIndex = 0;  
            }


            players[smallBlindIndex].makeBet(smallBlind);
            players[bigBlindIndex].makeBet(bigBlind);

            return bigBlindIndex; 

        }

        public int getPlayerCash(int i)
        {

            return players[i].Cash;

        }

        public int getPlayerBet(int i)
        {
            return players[i].Bet; 

        }


        public int getPot()
        {
            return pot.pot; 

        }


        private void assignNextDealer()
        {
            int i = currentDealer(); 


            if (i+1 == players.Count)
            {
                assignDealer(0);
            }
            else
            {
                assignDealer(i + 1);
            }

        }

        private int currentDealer()
        {
            int i = 0; 
            foreach (var player in players)
            {
                if (player.IsDealer)
                {
                    break;
                }
                i++;
            }
            return i; 

        }

        private void dealCards()
        {
            foreach (var player in players)
            {
                player.Card1 = deck.drawCard();

            }

            foreach (var player in players)
            {
                player.Card2 = deck.drawCard();
            }


        }

        private void assignDealer(int playerIndex)
        {

            foreach (var player in players)
            {
                player.IsDealer = false; 
            }
         
            players[playerIndex].IsDealer = true;

            view.displayDealer(playerIndex); 

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
