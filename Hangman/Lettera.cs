using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Lettera
    {
        private bool visible;
        private char c;
        public Lettera(char c){
            this.c = c;
            this.visible = false;
            }

        public char getChar() { return c; }
        public bool GetVisible() { return visible; }
        public void setVisible() { this.visible = true; }
        public override string ToString()
        {
            if (visible)
            {
                return c + " ";
            }
            else
            {
                return "_ ";
            }
        }
    }
}
