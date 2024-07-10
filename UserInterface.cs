using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_Game
{
    internal class UserInterface
    {
        private string[] _gameMoves;
        private GameHelp _help;
        private string _hmac;
        private int _totalMoves;
        public UserInterface(string[] moves, string hmac, GameHelp gameHelp)
        {
            _gameMoves = moves;
            _hmac = hmac;
            _help = gameHelp;
            _totalMoves = moves.Length;
        }
        public void DisplayMenu()
        {
            Console.Write("HMAC: ");
            DisplayColoredText(_hmac, ConsoleColor.Cyan);

            DisplayMoves();
        }



        public string GetUserMove()
        {
            Console.Write("Enter your move: ");
            var input = Console.ReadLine();
            return input;
        }

        public void DisplayUserMove(string move)
        {
            Console.WriteLine("Your move: " + move);
        }
        public void DisplayComputerMove(string move)
        {
            Console.WriteLine("Computer move: " + move);
        }
        public void DisplayHMACKey(string hmacKey)
        {
            Console.Write("HMAC Key: ");
            DisplayColoredText(hmacKey, ConsoleColor.DarkMagenta);
        }

        public void DisplayResult(string result)
        {
            Console.Write("Result : ");
            if (result.ToLower() == "draw")
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("You " + result + "!");
            }
        }

        public void DisplayHelp()
        {
            DisplayColoredText("Here are the outcomes of your moves against the computer:", ConsoleColor.Blue);
            _help.DisplayHelp();
        }

        public void DisplayErrorMessage(string message)
        {
            Console.WriteLine();
            DisplayColoredText(message, ConsoleColor.Red);
            Console.WriteLine();
        }


        private void DisplayMoves()
        {
            Console.WriteLine("Available moves:");
            for (int i = 0; i < _totalMoves; i++)
            {
                Console.WriteLine($"{i + 1} - {_gameMoves[i]}");
            }

            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
        }

        private void DisplayColoredText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

    }
}
