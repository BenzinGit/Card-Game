using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{

    internal class Card
    {

     

        private string suit; 
        private int value;
        private string nameValue; 


        public Card(int value, string suit)
        {
            this.value = value;
            this.suit = suit;
            assignValueName(); 
        }

        public string Suit { get => suit; set => suit = value; }
        public int Value { get => value; set => this.value = value; }
        public string NameValue { get => nameValue; set => nameValue = value; }


        private void assignValueName()
        {
            
            switch(value)
            {
                case 2: nameValue = "Two";break;
                case 3: nameValue = "Three";break;
                case 4: nameValue = "Four"; break;
                case 5: nameValue = "Five"; break;
                case 6: nameValue = "Six"; break;
                case 7: nameValue = "Seven"; break;
                case 8: nameValue = "Eight"; break;
                case 9: nameValue = "Nine"; break;
                case 10: nameValue = "Ten"; break;
                case 11: nameValue = "Jack"; break;
                case 12: nameValue = "Queen"; break;
                case 13: nameValue = "King"; break;
                case 14: nameValue = "Ace"; break;

            }

        }

        public void printCard()
        {
            Console.WriteLine(nameValue + " of " + suit + " ("+value+")");

        }





    }
}
