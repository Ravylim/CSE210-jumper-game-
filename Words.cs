using System;
using System.Collections.Generic;
using System.IO;


namespace Jumper_Game
{

    public class Words
    {
        private string word;
        public List<char> input = new List<char>();
        private List<char> theAnswer = new List<char>();
        private TerminalService terminalService = new TerminalService();

        public Words()
        {

        }


        public string ChoseRandomWord()
        {
            List<string> lines = new List<string> (File.ReadLines("english-no-swears.txt"));
            Random rand = new Random();
            int randomIndex = rand.Next(0, lines.Count);
            string randomWord = lines[randomIndex];
            return randomWord;

        }

        public void listWord(string ripWord)
        {
            theAnswer.AddRange(ripWord.ToLower());
        }


        public void HiddenWord ()
        {
            foreach (int i in theAnswer)
            {
                input.Add('_');
            }
        }

        public void printInput()
        {
            terminalService.WriteText(string.Format("{0}", string.Join(" ", input)));
        }


        public int compare (List <char> PreviousGuesses, int NumOfGuesses)
        {
            for (int i = 0; i < theAnswer.Count; i ++)
            {
                if (PreviousGuesses.Contains(theAnswer[i]))
                {
                    input[i] = theAnswer[i];
                }
            }
            if (theAnswer.Contains(PreviousGuesses[NumOfGuesses-1]))
            {
                return 0;
            }
            else 
            {
                return 1;
            }
        }

        public void printTheAnswer ()
        {
            terminalService.WriteText(string.Format("{0}", string.Join(" ", theAnswer)));
        }
        


    }
}