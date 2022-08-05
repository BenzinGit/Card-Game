using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Texas_Hold_em.Model
{
    internal class AI
    {
        
        private Player player;
        private Boolean hasRaised;
        private int aggresiveIndex; 
        private Random random;
        public AI(Player player)
        {
            this.player = player;
            aggresiveIndex = 1;
            random = new Random();
            hasRaised = false; 
        }
        

        internal int MakeDecision(int cashToCall, int pot, int bigBlind, List<Player> otherPlayers, List<Card> cardsOnTable)
        {
            if (cardsOnTable.Count == 0)
           {
                return StartingHandDecision(cashToCall, bigBlind);
            }
            else
            {
                int chanceOfWinning = (int) (CardEvaluator.SimulateRound(player.HoleCards, cardsOnTable, otherPlayers.Count, 1000) * 100);
                Console.WriteLine(player.Name + ": " + chanceOfWinning);

                int choice = 1; 

                if(chanceOfWinning > 30 + random.Next(1, 20))
                {
                    if(player.Cash > 0)
                    choice = (int)(((player.Cash / 20) * (chanceOfWinning / 10)) / 2) + (cashToCall);

                }
                else if (chanceOfWinning < 15)
                {
                    if (cashToCall < bigBlind * random.Next(1, 5))  
                    {
                        // Bluff
                        if(random.Next(1, 10) == 5)
                        {
                            Console.WriteLine(player.Name + " is bluffing");
                                if (player.Cash > 0)
                                choice = (int)(((player.Cash / 20) * (random.Next(10, 90) / 10))) + (cashToCall);
                        }
                        else
                        {
                            choice = 1; 
                        }

                    }
                    else
                    {

                        choice = -1; 
                    }

                }
                else
                {
                    // Bluff
                    if (random.Next(1, 10) == 5)
                    {
                        Console.WriteLine(player.Name + " is bluffing");
                        if (player.Cash > 0)
                        choice = (int)(((player.Cash / 20) * (random.Next(10, 90) / 10))) + (cashToCall);
                    }

                    choice = 1; 
                }


                if (choice > player.Cash)
                {
                    return player.Cash;
                }
                else
                {
                    return choice; 
                }

            }
        }



        private int StartingHandDecision(int cashToCall, int bigBlind)
        {
            int powerRating = CardEvaluator.EveluateStartingHand(player.HoleCards);


            // if cashToCall == bigBlind or less
            if (cashToCall <= bigBlind)
            {
                // if powerrating > 8-11 = Raise
                if (powerRating > (8 + random.Next(3)))
                {
                    hasRaised = true;
                    return bigBlind + ((player.Cash / 20) + ((bigBlind / 10) * (powerRating - 10) * random.Next(1, 5)));
                }
                // else check
                else
                {
                    hasRaised = false; 
                    return 1;
                }

            }

            // if raised
            else
            {
                // Call raise
                if (powerRating > (5 + random.Next(4)))
                {
                    // Reraise
                    if (powerRating >= 16 && !hasRaised)
                    {
                        hasRaised = true;
                        return (player.Cash / 20) + ((bigBlind / 10) * (powerRating - 10) * random.Next(1, 5));
                    }
                    else if (cashToCall < bigBlind * random.Next(1, 4))
                    {
                        hasRaised = false; 

                        return 1;

                    }
                    else
                    {
                        hasRaised = false; 
                        return -1;
                    }

                }
                // Fold
                else
                {
                    hasRaised = false; 
                    return -1;
                }


            }
        }
    }
}
