using System;
using board;
using ChessGame.Chess;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {

            ChessRound chessRound = new ChessRound();

            while (!chessRound.finished)
            {
                try
                {
                    Console.Clear();
                    View.ViewGame(chessRound);

                    Console.Write(" Peça de origem: ");

                    Position origin = View.ReadChessPosition().ToPosition();
                    chessRound.ValidOriginPosition(origin);



                    bool[,] possibleMoves = chessRound.board.Piece(origin).PossibleMoves();
                    Console.Clear();
                    View.ViewBoard(chessRound.board, possibleMoves);

                    Console.WriteLine(" -------------------------------");
                    Console.Write(" Peça de destino: ");
                    Position destiny = View.ReadChessPosition().ToPosition();
                    chessRound.ValidDestinyPosition(origin, destiny);

                    chessRound.PlayRound(origin, destiny);
                }
                catch (BoardException e)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor = aux;
                    Console.ReadLine();
                }

            }
            Console.Clear();
            View.ViewGame(chessRound);

        }
    }
}
