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
                Board Board = new Board(8, 8);

                Board.PutPiece(new Rook(Color.Black, Board), new Position(0, 0));
                Board.PutPiece(new Pawn(Color.Black, Board), new Position(9, 0));
                Board.PutPiece(new Queen(Color.Black, Board), new Position(5, 5));

                View.ViewBoard(Board);
            }catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
