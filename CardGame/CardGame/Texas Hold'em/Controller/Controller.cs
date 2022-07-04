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
        private int cashToCall = 0; 

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

            assignDealer(rand.Next(0, players.Count));

            foreach (var player in players)
            {
                player.Cash = startingCash; 
            }

            view.setUpGame(players, startingCash);

            
            
            int startingPlayer = setUpFirstRound();
           
            startRound(startingPlayer);

        }

        private void startRound(int startingPlayer)
        {
            view.highlightPlayer(startingPlayer);

            // Delete
           DrawFlop();
           DrawTurn();
            DrawRiver();
            // Delete

            Card card1 = new Card(13, "diamonds");
            Card card2 = new Card(11, "diamonds");
            Card card3 = new Card(9, "spades");
            Card card4 = new Card(8, "diamonds");
            Card card5 = new Card(13, "hearts");

            Card card7 = new Card(11, "hearts");
            Card card8 = new Card(3, "spades");

         //   DrawCustomCommunityCards(card1, card2, card3, card4, card5);
         //   DealCustomCards(startingPlayer, card7, card8); 
            int call = players[startingPlayer].makeDecision(cashToCall, pot.pot, players.Count, sharedCards.getCards());

            Hand hand = CardEvaluator.eveluateHand(players[startingPlayer].HoleCards, sharedCards.getCards());
            view.displayCardHandCombo(hand.HandName); 

        }

        private void DrawFlop()
        {
            List<Card> cards = deck.drawCards(3);
            sharedCards.setFlop(cards);
            view.displayFlop(cards[0].Image, cards[1].Image, cards[2].Image);
        }

      

        private void DrawTurn()
        {
            Card turnCard = deck.drawCard();
            sharedCards.setTurn(turnCard);
            view.displayTurn(turnCard.Image);

        }

        private void DrawRiver()
        {
            Card riverCard = deck.drawCard();
            sharedCards.setRiver(riverCard);
            view.displayRiver(riverCard.Image);
        }


        private void DrawCustomCommunityCards(Card flop1, Card flop2, Card flop3, Card turn, Card river)
        {
            List<Card> flopCards = new List<Card>();
            flopCards.Add(flop1);
            flopCards.Add(flop2);
            flopCards.Add(flop3);

            sharedCards.setFlop(flopCards);
            view.displayFlop(flopCards[0].Image, flopCards[1].Image, flopCards[2].Image);

            sharedCards.setTurn(turn);
            view.displayTurn(turn.Image);

            sharedCards.setRiver(river);
            view.displayRiver(river.Image);

        }

        private void DealCustomCards(int playerIndex, Card card1, Card card2)
        {
            players[playerIndex].HoleCards.setCards(card1, card2);
            showPlayerCards(playerIndex);


        }


        private int setUpFirstRound()
        {
            assignNextDealer(); 
            deck.shuffleDeck();
            dealCards();
            int bigBlindIndex = setBlinds();
            updatePot(); 
            view.updateBoard();
            showPlayerCards(0);
           
            // only debugging
            showAllPlayerCards(); 
           
            return getNextPlayer(bigBlindIndex);  
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
        

        private void startBetting(int startingPlayerIndex)
        {
            Console.WriteLine(startingPlayerIndex + " ska börja");

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
            cashToCall = bigBlind; 
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
                player.HoleCards.setCards(deck.drawCard(), deck.drawCard());     
                    

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

            view.displayPlayerCards(playerIndex, players[playerIndex].HoleCards.Card1.Image, players[playerIndex].HoleCards.Card2.Image);

        }

        private void showAllPlayerCards()
        {

            for(int i = 0; i < players.Count; i++)
            {
                view.displayPlayerCards(i, players[i].HoleCards.Card1.Image, players[i].HoleCards.Card2.Image);


            }


        }

    }
}
