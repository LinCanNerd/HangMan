using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Hangman hg = new Hangman();
            while (hg.Gamestat()) {
                hg.Drawgame();
                hg.Guess();
            }
            Console.ReadLine();
        }
    }
}
