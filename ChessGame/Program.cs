using System;
using board;
using ChessGame.Chess;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = new Board(8, 8);

                board.PutPiece(new Queen(Color.Black, board), new Position(0,0));

                View.ViewBoard(board);
                
            }catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
