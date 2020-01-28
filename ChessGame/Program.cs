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
                ChessRound chessRound = new ChessRound();

                while (!chessRound.finished)
                {
                    Console.Clear();
                    View.ViewBoard(chessRound.board);

                    Console.Write("Peça de origem: ");
                    Position origin = View.ReadChessPosition().ToPosition();

                    Console.Write("Peça de origem: ");
                    Position destiny = View.ReadChessPosition().ToPosition();

                    chessRound.ExecuteMove(origin, destiny);
                }


            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
