using System;
using board;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board Board = new Board(8,8);

            View.ViewBoard(Board);
        }
    }
}
