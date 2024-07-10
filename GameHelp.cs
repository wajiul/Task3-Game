using System;
using ConsoleTables;

internal class GameHelp
{
    private string[] _gameMoves;
    private int _totalMoves;
    public GameHelp(string[] moves)
    {
        _gameMoves = moves;
        _totalMoves = moves.Length;
    }
    public void DisplayHelp()
    {
        var header = new string[] { @"v PC \ User >" };
        header = header.Concat(_gameMoves).ToArray();

        var table = new ConsoleTable(header);

        for (int i = 0; i < _totalMoves; i++)
        {
            string[] row = new string[_totalMoves + 1];
            row[0] = _gameMoves[i];
            row[i + 1] = "Draw";
            int startIndex = i + 1;

            for (int j = 0; j < _totalMoves / 2; j++)
            {
                row[(startIndex % _totalMoves) + 1] = "Win";
                startIndex++;
            }

            for (int j = 0; j < _totalMoves / 2; j++)
            {
                row[(startIndex % _totalMoves) + 1] = "Lose";
                startIndex++;
            }
            table.AddRow(row);
        }

        table.Write();

        Console.WriteLine();
    }
}
