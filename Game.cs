
using Task3_Game;

class Game
{
    public void Play(string[] moves)
    {
        int totalMoves = moves.Length;
        int keyLength = 32;

        RandomGenerator randomGenerator = new RandomGenerator();

        var computerMoveId = randomGenerator.GetRandomNumber(0, totalMoves);
        var hmacKey = randomGenerator.GetRandomKey(keyLength);
        var hmac = randomGenerator.GetHMAC(moves[computerMoveId], hmacKey);

        var gameHelp = new GameHelp(moves);
        var ui = new UserInterface(moves, hmac, gameHelp);
        var gameResult = new GameResult(totalMoves);

        ui.DisplayMenu();

        string userInput;

        while (true)
        {
            userInput = ui.GetUserMove();
            if (userInput == "?")
            {
                ui.DisplayHelp();
                ui.DisplayMenu();
            }

            else if (int.TryParse(userInput, out int number))
            {
                if (number == 0)
                {
                    Environment.Exit(0);
                }

                if (number < 0 || number > totalMoves)
                {
                    ui.DisplayErrorMessage($"Invalid input. Correct input are {0} to {totalMoves} and ?. Try again");
                    ui.DisplayMenu();
                }
                else
                {
                    int userMoveId = Convert.ToInt32(userInput) - 1;

                    ui.DisplayUserMove(moves[userMoveId]);

                    var result = gameResult.DetermineResult(userMoveId, computerMoveId);

                    ui.DisplayComputerMove(moves[computerMoveId]);

                    ui.DisplayResult(result);

                    ui.DisplayHMACKey(Convert.ToHexString(hmacKey));
                    break;
                }
            }
            else
            {
                ui.DisplayErrorMessage($"Invalid input. Correct input are {0} to {totalMoves} and ?. Try again");
                ui.DisplayMenu();

            }
        }
    }

    public static void Main(string[] argc)
    {
        string[] m = { "rock", "paper", "scissor" };
        System.Console.WriteLine("len = " + argc.Length);
        if(argc.Length % 2 == 0 || argc.Length < 3) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Number of moves must be odd and greater than 1 \n");
            Console.ResetColor();
            return;
        } 
        Game game = new Game();
        game.Play(argc);
        // int tcase = 10;
        // var r = new Random();
        // while(tcase -- > 0)
        // {
        //     Console.WriteLine(r.Next(0, 3));
        // }
        
    }
}