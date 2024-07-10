using System;
using ConsoleTables;

internal class GameHelp
{
    private string[] _gameMoves;
    private int _totalMoves;
    private ConsoleTable _table;
    const int _pageSize = 10;
    public GameHelp(string[] moves)
    {
        _gameMoves = moves;
        _totalMoves = moves.Length;
        _table = new ConsoleTable();
    }

    private void setHeader()
    {
        var header = new string[] { @"v PC \ User >" };
        header = header.Concat(_gameMoves).ToArray();
        _table.AddColumn(header);
    }

    private void setRows(int start, int end)
    {

        for (int i = start; i <= end; i++)
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
            _table.AddRow(row);
        }
    }
    public void DisplayHelp()
    {

        int currentPage = 1;
        int totalPages = (int)Math.Ceiling((double)_totalMoves / _pageSize);

        setHeader();

        while(true)
        {
            int startRow = (currentPage - 1) * _pageSize;
            int endRow = Math.Min(startRow + _pageSize, _totalMoves - 1);

            setRows(startRow, endRow);

            _table.Write();
            Console.WriteLine($"Page {currentPage} of {totalPages}");

            Console.Write("Press:");
            if (currentPage == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            Console.Write("\t p: Previous page");

            Console.ResetColor();
            if(currentPage == totalPages)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.Write("\t n: Next page");

            Console.ResetColor();

            Console.WriteLine("\t q: Quit");


            var key = Console.ReadKey();
            if(key.Key == ConsoleKey.N  && currentPage < totalPages)
            {
                currentPage++;
            }
            else if(key.Key == ConsoleKey.P && currentPage > 1)
            {
                currentPage--;
            }
            else if(key.Key == ConsoleKey.Q)
            {
                Console.WriteLine();
                break;
            }
        }
    }
}
