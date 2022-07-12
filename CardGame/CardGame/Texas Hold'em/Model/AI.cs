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
        public AI(Player player)
        {
            this.player = player;
            aggresiveIndex = 1; 
        }
        

        

        internal int MakeDecision(int cashToCall, int pot, List<Player> otherPlayers, List<Card> cardsOnTable)
        {
            if (cardsOnTable.Count == 0)
            {

                double choiceIndex = 50;
               
                int startingTier = CardEvaluator.EveluateStartingHand(player.HoleCards);
               
                if (startingTier == 1)
                {
                    choiceIndex = choiceIndex + (100 * aggresiveIndex);
                }
          
                else if(startingTier == 2)
                {
                    choiceIndex = choiceIndex + (80 * aggresiveIndex);

                }

                else if(startingTier == 3)
                {
                    choiceIndex = choiceIndex + (50 * aggresiveIndex);

                }
          
                double cashToBetRatio = 1 - (cashToCall - player.Bet) / (double)player.Cash;

                Console.WriteLine(cashToBetRatio);

                choiceIndex = (cashToBetRatio * choiceIndex); 
                Console.WriteLine(choiceIndex);


                if (choiceIndex >= 70)
                {
                    return 100; 
                }
                else if(choiceIndex >= 25 && choiceIndex < 70)
                {
                    return 1; 
                }
                else
                {
                    return -1; 
                }


               
            
            }
            else
            {
                return 1; 
            }
        }
    }
}
