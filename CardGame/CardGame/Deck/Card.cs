using CardGame.Texas_Hold_em.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CardGame.Deck;

namespace CardGame.Texas_Hold_em.Model
{

    internal class Card
    {

        private Suit suit; 
        private int value;
        private int altValue; 
        private string nameValue;
        private string image; 
        
        public Card(int value, Suit suit)
        {
            this.value = value;
            this.suit = suit;
            assignValueName();
            assignImage();
        }

        public Card(int value)
        {
            this.value = value;
            assignValueName();

        }

        public Card(int value, string suit)
        {
            this.value = value;

            if (suit == "clubs")
                this.suit = new Suit(Suit.CardSuit.Clubs);

            if (suit == "hearts")
                this.suit = new Suit(Suit.CardSuit.Hearts);

            if (suit == "spades")
                this.suit = new Suit(Suit.CardSuit.Spades);

            if (suit == "diamonds")
                this.suit = new Suit(Suit.CardSuit.Diamonds);

            if(value == 14)
            {
                altValue = 1; 
            }
            assignValueName();
            assignImage();

        }


        public int Value { get => value; set => this.value = value; }
        public string NameValue { get => nameValue; set => nameValue = value; }
        public string Image { get => image; set => image = value; }
        internal Suit Suit { get => suit; set => suit = value; }
        public int AltValue { get => altValue; set => altValue = value; }

        private void assignValueName()
        {
            
            switch(value)
            {
               

                case 11: nameValue = "Jack"; break;
                case 12: nameValue = "Queen"; break;
                case 13: nameValue = "King"; break;
                case 14: nameValue = "Ace"; break;
                default: nameValue = value.ToString(); break;

            }

        }

        private void assignImage()
        {
            image = ("_"+nameValue + "_of_" + suit.cardSuit.ToString()).ToLower(); 

        }

        public void printCard()
        {
            Console.WriteLine(nameValue + " of " + suit.cardSuit.ToString()); 

        }

        public string print()
        {
           return nameValue + " of " + suit.cardSuit.ToString();

        }



    }
}
