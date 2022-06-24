using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Controller
    {

        private Deck deck; 

        public Controller()
        {
            deck = new Deck();
            deck.shuffleDeck();

 
        }



    }

    
}
