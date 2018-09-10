using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.ProcessStart(@"C:\Users\Andii\Music\AlanWalker-Faded(Lyrics).mp3");
        }

        static public void playSimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer();
            simpleSound.Play();
        }
    }
}
