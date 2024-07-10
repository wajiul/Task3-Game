using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_Game
{
    internal class GameResult
    {
        private int TotalMoves;
        public GameResult(int totalMoves)
        {
            TotalMoves = totalMoves;
        }

        public string DetermineResult(int userMove, int computerMove)
        {
            if (userMove == computerMove)
                return "Draw";

            int startOfWinMove = (computerMove + 1) % TotalMoves;
            int endOfWinMove = (computerMove + (TotalMoves / 2)) % TotalMoves;

            if (startOfWinMove <= endOfWinMove && userMove >= startOfWinMove && userMove <= endOfWinMove)
                return "Win";

            if (startOfWinMove > endOfWinMove && (userMove >= startOfWinMove || userMove <= endOfWinMove))
                return "Win";

            return "Lose";
        }

    }
}
