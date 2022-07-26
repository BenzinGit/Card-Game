using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Sound
{
    internal class SoundManager
    {

        public static void PlaySound(string soundEffect)
        {
            SoundPlayer sound = new SoundPlayer("../../Sound/SoundEffects/" + soundEffect + ".wav");
            sound.Play();


        }
    }
}
