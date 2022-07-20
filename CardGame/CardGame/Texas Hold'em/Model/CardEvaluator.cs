using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Texas_Hold_em.Model
{
    internal static class CardEvaluator
    {


        public static float SimulateRound(HoleCards handCards, List<Card> cardsOnTable, int playersN, int iterations)
        {
            Deck deck = new Deck(); 
          
            List<Player> players = new List<Player>();
            for (int i = 0; i < playersN; i++)
            {
                players.Add(new Player("", i)); 
            }

            players[0].HoleCards.SetCards(handCards.Card1, handCards.Card2);
           
            deck.RemoveCard(handCards.Card1);
            deck.RemoveCard(handCards.Card2);

            foreach (var card in cardsOnTable)
            {
                deck.RemoveCard(card); 

            }
           

            

            

            List<Card> removedCards = new List<Card>();
            List<Card> sharedCards = new List<Card>();

            int victories = 0; 

            for (int i = 0; i < iterations; i++)
            {
                sharedCards.AddRange(cardsOnTable);
                deck.Shuffle();

                for (int j = 1; j < playersN; j++)
                {
                    Card card1 = deck.DrawCard();
                    Card card2 = deck.DrawCard();

                    removedCards.Add(card1);
                    removedCards.Add(card2);


                    players[j].HoleCards.SetCards(card1, card2);
                }

                // Flop
                if (sharedCards.Count < 3)
                {
                    Card flop1 = deck.DrawCard();
                    Card flop2 = deck.DrawCard();
                    Card flop3 = deck.DrawCard();
                    removedCards.Add(flop1);
                    removedCards.Add(flop2);
                    removedCards.Add(flop3);
                    sharedCards.Add(flop1);
                    sharedCards.Add(flop2);
                    sharedCards.Add(flop3);

                }

                // Turn
                if (sharedCards.Count < 4)
                {

                    Card turn = deck.DrawCard();
                    removedCards.Add(turn);
                    sharedCards.Add(turn);

                }

                // River
                if (sharedCards.Count < 5)
                {

                    Card river = deck.DrawCard();
                    removedCards.Add(river);
                    sharedCards.Add(river);

                }




                var winner = DecideWinner(players, sharedCards);
                foreach (var player in winner)
                {
                    if(player.Id == 0)
                    {
                        victories++;
                    }
                  

                }
                deck.AddCards(removedCards);
                removedCards.Clear();
                sharedCards.Clear();

            }


            float m = (float) victories / iterations;
            return m; 


        }

        // Based on Chen formula, by Bill Chen (20 - -1).
        public static int EveluateStartingHand(HoleCards hand)
        {
            double points = 0;
            // Highest Card
            switch (hand.Card1.Value)
            {
                // A
                case 14:
                points = 10;

                    break;
              
                // K
                case 13:
                points = 8;
                break;

                // Q
                case 12:
                points = 7;

                    break;
               
                // J
                case 11:
                points = 6;

                    break;

                default:
                points = ((double)hand.Card1.Value / 2);

                    break; 
            }

            // Pairs
            if(hand.Card1.Value == hand.Card2.Value)
            {
                if(hand.Card1.Value > 5)
                {
                    points = points * 2;

                }
                else
                {
                    points = points + 5; 
                }
            }

            // Suited
            if (hand.Card1.Suit == hand.Card2.Suit)
            {
                points = points + 2; 
            }


            // Closeness
            if ((hand.Card1.Value - hand.Card2.Value) == 1)
            {
                if(hand.Card1.Value < 12)
                {
                    points++; 
                }

            }

            else if ((hand.Card1.Value - hand.Card2.Value) == 2)
            {
                points--;
               
                if (hand.Card1.Value < 12)
                {
                    points++;
                }
            }
            else if ((hand.Card1.Value - hand.Card2.Value) == 3)
            {
                points = points - 2; 
            }
            else if ((hand.Card1.Value - hand.Card2.Value) == 4)
            {
                points = points - 4;
            }
            else if ((hand.Card1.Value - hand.Card2.Value) >= 5)
            {
                points = points - 5;
            }

            return (int) Math.Ceiling(points); 


        }

        // Card 1 will always be higher than card 2
        public static int EveluateStartingHand2(HoleCards hand)
        {
            // Tiers are based on Phil Hellmuth's Play Poker Like the Pros (2003)
            //   Hand hand = new Hand(new Card(5, new Suit(Suit.CardSuit.Clubs)), new Card(6, new Suit(Suit.CardSuit.Clubs))); 

            // TIER 1
            // Pair AA -> 99 
            if ((hand.Card1.NameValue == hand.Card2.NameValue) && hand.Card1.Value >= 9)
            {

                return 1;
            }

            // AK
            if (hand.Card1.Value == 14 && hand.Card2.Value == 13)
            {

                return 1;
            }

            // TIER 2
            // All pairs
            if (hand.Card1.NameValue == hand.Card2.NameValue)
            {

                return 2;
            }
            // AQ
            if (hand.Card1.Value == 14 && hand.Card2.Value == 12)
            {

                return 2;
            }

            // A & J->8 Suited
            if ((hand.Card1.Value == 14 && hand.Card2.Value >= 8) && (hand.Card1.Suit.cardSuit == hand.Card2.Suit.cardSuit))
            {

                return 2;
            }

            // TIER 3

            if ((hand.Card1.Value == 14) && (hand.Card1.Suit.cardSuit == hand.Card2.Suit.cardSuit))
            {

                return 3;
            }

            // KQ
            if (hand.Card1.Value == 13 && hand.Card2.Value == 12)
            {

                return 3;
            }

            // QJs, JTs, T9s, 98s, 87s, 76s, 65s	
            if (((hand.Card1.Value - hand.Card2.Value) == 1) && (hand.Card1.Suit.cardSuit == hand.Card2.Suit.cardSuit) && (hand.Card2.Value >= 5))
            {
                return 3;

            }

            return 0;
        }


        public static List<Player> DecideWinner(List<Player> playersIn, List<Card> cardsOnTable)
        {
            List<Player> players = playersIn; 
            List<Player> winners = new List<Player>();


            foreach (var player in players)
            {
                if (!player.HasFolded)
                {
                    winners.Add(player);
                }

            }

            // If only 1 player left
            if (winners.Count == 1)
            {
                winners[0].EndHand = new Hand(15, null, null); 
                winners[0].EndHand.HandName = "Win by fold"; 
                return winners;
            }

            foreach (var player in players)
            {
                if (!player.HasFolded)
                {
                    player.EndHand = EveluateHand(player.HoleCards, cardsOnTable);
                }
            }

            winners = winners.OrderBy(winner => winner.EndHand.HandValue).Reverse().ToList();
            List<Player> losers = new List<Player>();


            for (int i = 0; i < winners.Count; i++)
            {
                if (winners[0].EndHand.HandValue != winners[i].EndHand.HandValue)
                {
                    losers.Add(winners[i]);
                }
            }
         
            winners = winners.Except(losers).ToList();
            losers.Clear(); 

            if(winners.Count > 1)
            {
                winners = winners.OrderBy(winner => winner.EndHand.MainCard.Value).Reverse().ToList();
            
                for (int i = 0; i < winners.Count; i++)
                {
                    if (winners[0].EndHand.MainCard.Value != winners[i].EndHand.MainCard.Value)
                    {
                        losers.Add(winners[i]); 
                    }
                }
            }
 
            winners = winners.Except(losers).ToList();
            losers.Clear();


            for (int k = 0; k < 2; k++)
            {
                if (winners.Count > 1)
                {
                    if (winners[0].EndHand.Kickers != null && winners[0].EndHand.Kickers.Count > k)
                    {

                        winners = winners.OrderBy(winner => winner.EndHand.Kickers[k].Value).Reverse().ToList();

                        for (int i = 0; i < winners.Count; i++)
                        {
                            if (winners[0].EndHand.Kickers[k].Value != winners[i].EndHand.Kickers[k].Value)
                            {
                                losers.Add(winners[i]);
                            }
                        }
                    }
                     
                }
                winners = winners.Except(losers).ToList();
                losers.Clear();

            }


            return winners; 
        }



        internal static Player DecideWinner2(List<Player> players, List<Card> cardsOnTable)
        {
            List<Hand> hands = new List<Hand>();

            List<Player> playersLeft = new List<Player>();
            foreach (var player in players)
            {
                if (!player.HasFolded)
                {
                    playersLeft.Add(player);
                }
            }


            foreach (var player in playersLeft)
            {
                var hand = EveluateHand(player.HoleCards, cardsOnTable); 
                hands.Add(hand);
                player.EndHand = hand; 
            }

            Hand winnerHand = hands[0];
            int winnerIndex = 0; 
            for (int i = 1; i < hands.Count; i++)
            {
                // Det blir bara en vinnare, även om det teknsikt sätt kan vara mer, om händerna är lika. 
                // En liista som tar bort de som inte " går vidare"

               int w = CompareHands(winnerHand, hands[i]); 

                if(w == 0)
                {

                }

                 if (CompareHands(winnerHand, hands[i]) == 2)
                {
                    winnerHand = hands[i];
                    winnerIndex = i; 
                }
            }


            return players[winnerIndex]; 
        }

        private static int CompareCards(Card card1, Card card2)
        {
            if(card1.Value > card2.Value)
            {
                return 1;
            }
            else if(card1.Value < card2.Value)
            {
                return 2;
            }
            else
            {
                return 0; 
            }

        }

        private static int CompareHands(Hand hand1, Hand hand2)
        {
            if(hand1.HandValue == hand2.HandValue)
            {

                int bestCard = CompareCards(hand1.MainCard, hand2.MainCard);
                if (bestCard == 0)
                {


                    if(hand1.Kickers == null || hand1.Kickers.Count == 0)
                    {
                        return 0; 
                    }


                    bestCard = CompareCards(hand1.Kickers[0], hand2.Kickers[0]);

                    // Tie
                    if (bestCard == 0)
                    {
                        if (hand1.Kickers.Count == 1)
                        {
                            return 0;
                        }

                        bestCard = CompareCards(hand1.Kickers[1], hand2.Kickers[1]);
                       
                        // Tie
                        if (bestCard == 0)
                        {
                            if (hand1.Kickers.Count == 2)
                            {
                                return 0;
                            }
                            bestCard = CompareCards(hand1.Kickers[2], hand2.Kickers[2]);

                            // Tie
                            if (bestCard == 0)
                            {
                                return 0;
                            }
                        }
                    }
                }
                return bestCard;
            }
            else if (hand1.HandValue > hand2.HandValue)
            {
                return 1;
            }
            else
            {

                return 2; 
            }



        }

        internal static Hand EveluateHand(HoleCards holeCards, List<Card> cardsOnTable)
        {
            List<Card> cards = new List<Card>();
              cards.Add(holeCards.Card1);
              cards.Add(holeCards.Card2);
               cards.AddRange(cardsOnTable);



  

            cards = cards.OrderBy(card => card.Value).Reverse().ToList();

            Hand hand = null;

            hand = isStraightFlush(cards);
            if(hand != null)
            {
                return hand; 
            }
            hand = isFourOfAKind(cards);
            if (hand != null)
            {
                return hand;
            }
            hand = isFullHouse(cards);
            if (hand != null)
            {
                return hand;
            }
            hand = isFlush(cards);
            if (hand != null)
            {
                return hand;
            }
            hand = isStraight(cards);
            if (hand != null)
            {
                return hand;
            }
            hand = isThreeOfAKind(cards);
            if (hand != null)
            {
                return hand;
            }
            hand = isTwoPair(cards);
            if (hand != null)
            {
                return hand;
            }
            hand = isPair(cards);
            if (hand != null)
            {
                return hand;
            }
            return isHighCard(cards); 

        }

        private static Hand isHighCard(List<Card> cardsIn)
        {
            List<Card> cards = cardsIn.ToList();
            List<Card> kickers = new List<Card>();

            for (int i = 1; i < 4; i++)
            {
                
                    kickers.Add(cards[i]);

                
            }

           

            return new Hand(1, cards[0], kickers); 
        }


        private static Hand isStraightFlush(List<Card> cardsIn)
        {
            List<Card> cards = cardsIn.ToList();

            Hand isFlushCards = isFlush(cards); 

            if (isFlushCards != null)
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    if (!cards[i].Suit.cardSuit.ToString().Equals(isFlushCards.MainCard.Suit.cardSuit.ToString()))
                    {
                      

                        cards.RemoveAt(i); 
                    }

                }

                if (isStraight(cards) != null)
                {
                    // Royal straight flush
                    if (isFlushCards.MainCard.Value == 14)
                    {
                        return new Hand(10, isFlushCards.MainCard, null);
                    }
                    else
                    {
                        return new Hand(9, isFlushCards.MainCard, null);

                    }
                }
                return null; 
            }
            return null;


        }








        private static Hand isFourOfAKind(List<Card> cardsIn)
        {
            List<Card> cards = cardsIn.ToList();

            for (int i = 0; i < cards.Count - 3; i++)
            {
                if (cards[i].Value == cards[i + 1].Value && 
                    cards[i].Value == cards[i + 2].Value && 
                    cards[i].Value == cards[i + 3].Value)
                {
                    Card mainCard = cards[i];
                    cards.RemoveRange(i, 4);  
                    List<Card> kickers = new List<Card>();
                    kickers.Add(cards[0]); 
                    return new Hand(8, mainCard, kickers);

                }
            }
            return null;
        }

        private static Hand isFullHouse(List<Card> cardsIn)
        {
            List<Card> cards = cardsIn.ToList();

            Hand threeofAKindHands = isThreeOfAKind(cards);
           
            if(threeofAKindHands != null)
            {
                for (int i = 0; i < cards.Count; i++)   
                {
                    if (cards[i].Value == threeofAKindHands.MainCard.Value)
                    {
                        cards.RemoveAt(i); 
                    }
                }

                Hand pairHands = isPair(cards);

                if(pairHands != null)
                {
                    if (pairHands.HandValue != threeofAKindHands.HandValue)
                    {
                        List<Card> kickers = new List<Card>();
                        kickers.Add(pairHands.MainCard);
                        return new Hand(7, threeofAKindHands.MainCard, kickers);

                    }

                }
            }
            else
            {
                return null; 
            }
            
            return null;
        }


        private static Hand isFlush(List<Card> cardsIn)
        {
            List<Card> cards = cardsIn.ToList();

            int hearts = 0;
            int clubs = 0;
            int diamonds = 0;
            int spades = 0;

            Suit suit = null;
            foreach (var card in cards)
            {
                if (card.Suit.cardSuit == Suit.CardSuit.Spades)
                {
                    spades++;
                    if(spades == 5)
                    {
                        suit = new Suit(Suit.CardSuit.Spades); 
                    }
                }
                if (card.Suit.cardSuit == Suit.CardSuit.Clubs)
                {
                    clubs++;
                    if (clubs == 5)
                    {
                        suit = new Suit(Suit.CardSuit.Clubs);
                    }
                }
                if (card.Suit.cardSuit == Suit.CardSuit.Diamonds)
                {
                    diamonds++;
                    if (diamonds == 5)
                    {
                        suit = new Suit(Suit.CardSuit.Diamonds);
                    }
                }
                if (card.Suit.cardSuit == Suit.CardSuit.Hearts)
                {
                    hearts++;
                    if (hearts == 5)
                    {
                        suit = new Suit(Suit.CardSuit.Hearts);
                    }
                }
            }


            if (spades >= 5 || clubs >= 5 || diamonds >= 5 || hearts >= 5)
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    if (cards[i].Suit.cardSuit != suit.cardSuit)
                    {
                        cards.RemoveAt(i);
                    }
                }

                List<Card> kickers = new List<Card>();
                kickers.Add(cards[1]);
                kickers.Add(cards[2]);
                kickers.Add(cards[3]);
                kickers.Add(cards[4]);


                return new Hand(6, cards[0], kickers);
            }
            return null;




        }


        private static Hand isStraight(List<Card> cardsIn)
        {
            List<Card> cards = cardsIn.ToList();

                // Removes dublicates of cards by value 
                // https://stackoverflow.com/questions/9993172/remove-objects-with-a-duplicate-property-from-list
                cards = cards.GroupBy(card => card.Value).Select(card => card.First()).ToList();
       
            for (int i = 0; i < cards.Count - 4; i++)
                {

                    if ((cards[i + 0].Value == (cards[i + 1].Value + 1)) &&
                        (cards[i + 1].Value == (cards[i + 2].Value + 1)) &&
                        (cards[i + 2].Value == (cards[i + 3].Value + 1)) &&
                        (cards[i + 3].Value == (cards[i + 4].Value + 1)))
                    {

                        return new Hand(5, cards[i], null);

                    }
                }

            // A -> 5

            if (cards[0].AltValue == 1)
            {
                cards = cards.OrderBy(card => card.Value).ToList();


                if ( cards[0].Value == 2 &&
                     cards[1].Value == 3 &&
                     cards[2].Value == 4 &&
                     cards[3].Value == 5)
                {
                    return new Hand(5, cards[3], null);
                }

            }

            return null; 
                

        }

        // Done
        private static Hand isThreeOfAKind(List<Card> cardsIn)
        {

            List<Card> cards = cardsIn.ToList();

            for (int i = 0; i < cards.Count - 2; i++)
            {
                if (cards[i].Value == cards[i + 1].Value && cards[i].Value == cards[i + 2].Value)
                {
                    Card mainCard = cards[i];
                    List<Card> kickers = new List<Card>();

                    cards.RemoveRange(i, 3);
                    kickers.Add(cards[0]);
                    kickers.Add(cards[1]);

                    return new Hand(4, mainCard, kickers); 
                }
            }
            return null;
        }

        private static Hand isTwoPair(List<Card> cardsIn)
        {
            List<Card> cards = cardsIn.ToList();

   
          
            int pairCounter = 0; 
            List<Card> kickers = new List<Card>();

            Card mainCard = null;


            for (int i = 0; i < cards.Count - 1; i++)
            {
               

                if (cards[i].Value == cards[i + 1].Value)
                {
                    pairCounter++;
                    if (pairCounter == 1)
                    {
                        mainCard = cards[i];

                        cards.RemoveRange(i, 2);
                        i = -1;

                    }
                    else if (pairCounter == 2)  
                    {
                        kickers.Add(cards[i]);
                        cards.RemoveRange(i, 2);


                    }


                }
            }
            if (pairCounter == 2)
            {

                kickers.Add(cards[0]);

              

                return new Hand(3, mainCard, kickers); 
            }

            return null;

        }


        private static Hand isPair(List<Card> cardsIn)
        {
            // To not modify the origninal list
            List<Card> cards = cardsIn.ToList(); 

            for (int i = 0; i < cards.Count - 1; i++)
            {
                if (cards[i].Value == cards[i + 1].Value)
                {

                    List<Card> kickers = new List<Card>();

                    Card mainCard = cards[i]; 
                    
                    // Removing the pair
                    cards.RemoveRange(i, 2); 


                    // Kickers
                    kickers.Add(cards[0]);
                    kickers.Add(cards[1]);
                    kickers.Add(cards[2]);

                    

                    return new Hand(2, mainCard, kickers);

                }
            }
            return null; 
        }



    }
}



