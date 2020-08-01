using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class Hangman
    {
        private Random rnd = new Random();
        private String filePath, theChosen,tries="Hai provato con:    ";
        private List<Lettera> unknown=new List<Lettera>();
        private List<string> words;
        private int possibilita;
 

        //costruttore
        public Hangman() 
        {
            filePath = @" C:\Users\Utente\Desktop\Scuola\C#\Hangman\Words.txt";
            words = File.ReadAllLines(filePath).ToList();
            theChosen = words[rnd.Next(words.Count-1)].ToUpper();
            possibilita = 6;
            
            for (int i = 0; i < theChosen.Length; i++) {
                unknown.Add(new Lettera(theChosen[i]));
            }
        }

        //printa tutto il gioco
        public void Drawgame()
        {
            ShowResult();
            DrawMan();
            ShowUnknown();
        }


        //printa l'omino
       private void DrawMan()
        {
            switch (possibilita)
            {
                case 6:
                    Console.WriteLine(" ______");
                    Console.WriteLine("|      |");
                    Console.WriteLine("|    ");
                    Console.WriteLine("|    ");
                    Console.WriteLine("|    ");
                    Console.WriteLine("|    ");
                    Console.WriteLine("|   \n\n ");
                    break;
                case 5:
                    Console.WriteLine(" ______");
                    Console.WriteLine("|      |");
                    Console.WriteLine("|      O");
                    Console.WriteLine("|    ");
                    Console.WriteLine("|    ");
                    Console.WriteLine("|    ");
                    Console.WriteLine("|   \n\n ");
                    break;
                case 4:
                    Console.WriteLine(" ______");
                    Console.WriteLine("|      |");
                    Console.WriteLine("|      O");
                    Console.WriteLine("|      |");
                    Console.WriteLine("|    ");
                    Console.WriteLine("|    ");
                    Console.WriteLine("|   \n\n ");
                    break;
                case 3:
                    Console.WriteLine(" ______");
                    Console.WriteLine("|      |");
                    Console.WriteLine("|      O");
                    Console.WriteLine("|     /|");
                    Console.WriteLine("|    ");
                    Console.WriteLine("|    ");
                    Console.WriteLine("|   \n\n ");
                    break;
                case 2:
                    Console.WriteLine(" ______");
                    Console.WriteLine("|      |");
                    Console.WriteLine("|      O");
                    Console.WriteLine(@"|     /|\");
                    Console.WriteLine("|    ");
                    Console.WriteLine("|    ");
                    Console.WriteLine("|   \n\n ");
                    break;
                case 1:
                    Console.WriteLine(" ______");
                    Console.WriteLine("|      |");
                    Console.WriteLine("|      O");
                    Console.WriteLine(@"|     /|\");
                    Console.WriteLine("|     /");
                    Console.WriteLine("|    ");
                    Console.WriteLine("|   \n\n ");
                    break;         
            }

        }
 
        //printa il risultato
        private void ShowResult() {
            Console.WriteLine("Hai ancora " + possibilita + " possibilita!");
            tries.Remove(tries.Length-1);
            Console.WriteLine(tries);
        }

        private void Lose()
        {
            Console.WriteLine(" ______");
            Console.WriteLine("|      |");
            Console.WriteLine("|      O");
            Console.WriteLine(@"|     /|\");
            Console.WriteLine(@"|     / \");
            Console.WriteLine("|    ");
            Console.WriteLine("|   \n\n ");
            Console.WriteLine("Hai perso la parola era:   " + theChosen);
            
        }

        private bool Win() {
            Console.WriteLine("Hai vinto!  la parola era:   " + theChosen);
            return false;
        }

        //restituisce bool dello stato del gioco
        public bool Gamestat()
        {
            if( checkUnknown()==false )
            {
                if(possibilita >= 1) { return true; }
                else {
                    Lose();
                    return false;
                }
            }
            else if (checkUnknown() == true) { Win(); }
            return true;
        }

        private bool checkUnknown() {
            bool check = true;
            for (int i = 0; i < unknown.Count(); i++)
            {
                if (unknown[i].GetVisible()==false) { check = false; }
            }
            return check;
        }

        //printa la frase nascosta
        private void ShowUnknown()
        {
            for (int i = 0; i < unknown.Count; i++)
            {
 
                Console.Write(unknown[i]);
            }
        }

        //metodo per input della scelta
       public void Guess()
        {
            Console.WriteLine("Scegli la lettera da indovinare");
            string x = Console.ReadLine().ToUpper();
            tries += x + ", "; 
            if (theChosen.Contains(x))
            {
                for(int i = 0; i < theChosen.Length; i++)
                {
                    if (theChosen[i]==Convert.ToChar(x)) {
                        unknown[i].setVisible(); 
                    }
                }
            }
            else
            {
                possibilita--;
            }
        }


    }
}
