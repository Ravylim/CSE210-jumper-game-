using System;
using System.Collections.Generic;


namespace Jumper_Game
{

    public class Jumper
    {

        private List<string> jumper = new List<string>();
        private int count;
        private int GotRight = 0;
        private TerminalService terminalService = new TerminalService();

        public Jumper()
        {

            jumper.Add("  ___");
            jumper.Add(" /___\\");
            jumper.Add(" \\   /");
            jumper.Add("  \\ /");
            jumper.Add("   O");
            jumper.Add("  /|\\");
            jumper.Add("  / \\");
        }

        public bool CheckInput(List<char> guesses, string CurrentGuess)
        {
            if (guesses.Contains(CurrentGuess[0]))
            {
                terminalService.WriteText("latter has already been guessed");
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckJumper(List<char> WordGuessed, int attempt)
        {
            count = 0;
            for (int i = 0; i < WordGuessed.Count; i++)
            {
                if (WordGuessed[i] != '_')
                {
                    count++;
                }

                else { }
            }
            if (count == WordGuessed.Count)
            {
                return false;
            }
            else if (attempt == 4)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void PrintJumper(int attempt)
        {
            if (attempt == GotRight)
            {

            }
            else if (attempt == 4)
            {
                jumper.RemoveRange(0, 1);
                jumper[0] ="   x";
            }

            else
            {
                jumper.RemoveRange(0, 1);
                GotRight++;
            }
            terminalService.WriteText(string.Format("{0}", string.Join("\n", jumper)));
        }

    }
}