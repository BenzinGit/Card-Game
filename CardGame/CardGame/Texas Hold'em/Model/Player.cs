using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Texas_Hold_em.Model
{
    internal class Player
    {
        private string name;
        private int markers;
        private Card card1, card2; 
        

        public Player(string name)
        {
            this.name = name; 

        }

        public string Name { get => name; set => name = value; }
        public int Markers { get => markers; set => markers = value; }
        internal Card Card1 { get => card1; set => card1 = value; }
        internal Card Card2 { get => card2; set => card2 = value; }
    }
}
