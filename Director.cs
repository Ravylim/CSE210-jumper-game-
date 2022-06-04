using System;
using System.Collections.Generic;

namespace Jumper_Game
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private bool isPlaying = true;
        private string ChosenWord;
        private Jumper jumper = new Jumper();
        private Words words = new Words();
        private TerminalService terminalService = new TerminalService();

        private int attempt = 0;
        private int NumOfGuesses = 0;
        private bool CheckInput;
        private string CurrentGuess = "test";
        private List<char> guessedLetters = new List<char>();


        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {

        }

        public void StartGame()
        {
            StartUp();
            while (isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }

        private void StartUp()
        {
            ChosenWord = words.ChoseRandomWord();
            words.listWord(ChosenWord);
            words.HiddenWord();
            words.printInput();
        }

        private void GetInputs()
        {
            terminalService.WriteText("");
            jumper.PrintJumper(attempt);
            CheckInput = true;

            while (CheckInput)
            {
                CurrentGuess = terminalService.ReadGuessed("\nGuess a letter [a-z]: ");
                CheckInput = jumper.CheckInput(guessedLetters, CurrentGuess);
            }
            guessedLetters.Add(CurrentGuess[0]);
        }

        private void DoUpdates()
        {
            NumOfGuesses = guessedLetters.Count;
            int UserAttempt = words.compare(guessedLetters, NumOfGuesses);
            attempt += UserAttempt;
            isPlaying = jumper.CheckJumper(words.input, attempt);
        }

        private void DoOutputs()
        {
            terminalService.WriteText("");
            if (isPlaying)
            {
                words.printInput();
            }
            else
            {
                jumper.PrintJumper(attempt);
                words.printTheAnswer();
                terminalService.WriteText("\n");
            }
        }
    }
}
