using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Texas_Hold_em.Model
{
    internal static class CardEvaluator
    {

        

        // Card 1 will always be higher than card 2
        public static int eveluateStartingHand(HoleCards hand)
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
            if(hand.Card1.Value == 14 && hand.Card2.Value == 12)
            {

                return 2; 
            }

            // A & J->8 Suited
            if((hand.Card1.Value == 14 && hand.Card2.Value >= 8) && (hand.Card1.Suit.cardSuit == hand.Card2.Suit.cardSuit))
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

        internal static string eveluateHand(HoleCards hand, List<Card> cardsOnTable)
        {
            List<Card> cards = new List<Card>();
              cards.Add(hand.Card1);
              cards.Add(hand.Card2);
               cards.AddRange(cardsOnTable);



  

            cards = cards.OrderBy(card => card.Value).ToList();

           


            if (isStraightFlush(cards))
                return "isStraightFlush";
            if (isFourOfAKind(cards))
                return "isFourOfAKind";
            if (isFullHouse(cards))
                return "isFullHouse";
            if (isFlush(cards))
                return "isFlush";
            if (isStraight(cards))
                return "isStraight";
            if (isThreeOfAKind(cards))
                return "isThreeOfAKind";
            if (isTwoPair(cards) != null)
                return "isTwoPair";
            if (isPair(cards) != null)
                return "isPair"; 

            return "nothin"; 
        }

        private static Boolean isStraightFlush(List<Card> cards)
        {
            if (isFlush(cards) && (isStraight(cards)))
             {
                return true; 
            }
            return false;
        }


        private static Boolean isFlush(List<Card> cards)
        {
            int hearts = 0;
            int clubs = 0;
            int diamonds = 0;
            int spades = 0;


            foreach (var card in cards)
            {
                if(card.Suit.cardSuit == Suit.CardSuit.Spades)
                {
                    spades++; 
                }
                if (card.Suit.cardSuit == Suit.CardSuit.Clubs)
                {
                    clubs++;
                }
                if (card.Suit.cardSuit == Suit.CardSuit.Diamonds)
                {
                    diamonds++;
                }
                if (card.Suit.cardSuit == Suit.CardSuit.Hearts)
                {
                    hearts++;
                }
            }


            if(spades >= 5 || clubs >= 5 || diamonds >= 5 || hearts >= 5)
            {
                return true; 
            }
            return false; 

            


        }

     

        private static Boolean isThreeOfAKind(List<Card> cards)
        {
            for (int i = 0; i < cards.Count - 2; i++)
            {
                if (cards[i].Value == cards[i + 1].Value && cards[i].Value == cards[i+2].Value)
                {
                    return true;

                }
            }
            return false; 
        }

        private static Boolean isStraight(List<Card> cards)
        {
            if (cards.Count <= 5)
            {

                // Removes dublicates of cards by value 
                // https://stackoverflow.com/questions/9993172/remove-objects-with-a-duplicate-property-from-list
                cards = cards.GroupBy(card => card.Value).Select(card => card.First()).ToList();


                for (int i = 0; i < cards.Count - 4; i++)
                {

                    if ((cards[i +0].Value == (cards[i + 1].Value - 1)) &&
                       (cards[i + 1].Value == (cards[i + 2].Value - 1)) &&
                       (cards[i + 2].Value == (cards[i + 3].Value - 1)) &&
                       (cards[i + 3].Value == (cards[i + 4].Value - 1)))
                    {
                        return true;

                    }
                }
            }
                return false;

            
        }

        private static Boolean isFullHouse(List<Card> cards)
        {
         //   if(isPair(cards) && isThreeOfAKind(cards))
          //  {
                // Fixa så inte triss blir fullt hus
                // if pair.value != threeofakind.value
           //     return true; 
          //  }
            return false; 
        }

     

        private static Boolean isFourOfAKind(List<Card> cards)
        {
            for (int i = 0; i < cards.Count - 3; i++)
            {
                if (cards[i].Value == cards[i + 1].Value && 
                    cards[i].Value == cards[i + 2].Value && 
                    cards[i].Value == cards[i + 3].Value)
                {
                    return true;

                }
            }
            return false;
        }

        private static Hand isTwoPair(List<Card> cardsIn)
        {

            int pairCounter = 0;
            List<Card> handCards = new List<Card>();
            List<Card> cards = cardsIn.ToList();

            for (int i = 0; i < cards.Count - 1; i++)
            {
                if (cards[i].Value == cards[i + 1].Value)
                {
                    handCards.Add(cards[i]);
                    handCards.Add(cards[i + 1]);
                    cards.RemoveRange(i, 2); 
                    pairCounter++;

                }
            }

            if (pairCounter == 2)
            {
                handCards.Add(cards[cards.Count - 1]);

                foreach (var card in handCards)
                {
                    card.printCard(); 
                }

                return new Hand(8, handCards); 
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

                    List<Card> handCards = new List<Card>();

                    handCards.Add(cards[i]);
                    handCards.Add(cards[i + 1]);

                    // Removing the pair
                    cards.RemoveRange(i, 2); 


                    // Kickers
                    handCards.Add(cards[cards.Count - 1]);
                    handCards.Add(cards[cards.Count - 2]);
                    handCards.Add(cards[cards.Count - 3]);

                    

                    return new Hand(9, handCards);

                }
            }
            return null; 
        }
    }



}
