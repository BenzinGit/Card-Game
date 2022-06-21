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
        private string image; 

        public Card(int value, string suit)
        {
            this.value = value;
            this.suit = suit;
            assignValueName();
            assignImage();
        }

        public string Suit { get => suit; set => suit = value; }
        public int Value { get => value; set => this.value = value; }
        public string NameValue { get => nameValue; set => nameValue = value; }
        public string Image { get => image; set => image = value; }

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
            image = ("_"+nameValue + "_of_" + suit).ToLower(); 

        }

        public void printCard()
        {
            Console.WriteLine(image);

        }





    }
}
