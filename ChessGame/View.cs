using System;
using board;
using ChessGame.Chess;


namespace ChessGame
{
    class View
    {
        public static void ViewBoard(Board board)
        {
            Console.WriteLine("    --- --- --- --- --- --- --- ---");
            Console.WriteLine("    ---  X   A   D   R   E   Z  ---");
            Console.WriteLine("    --- --- --- --- --- --- --- ---");
            Console.WriteLine("\n    --- --- --- --- --- --- --- ---");
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write($" {8 - i} | ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.Piece(i, j) == null)
                    {
                        Console.Write("- | ");

                    }
                    else
                    {
                        PrintPiece(board.Piece(i, j));
                        Console.Write(" | ");
                    }


                }
                Console.WriteLine("");

                Console.WriteLine("    --- --- --- --- --- --- --- ---");

            }
            Console.WriteLine("    -a- -b- -c- -d- -e- -f- -g- -h-");



        }

        public static ChessPosition ReadChessPosition()
        {
            string position = Console.ReadLine();
            char column = position[0];
            int line = int.Parse(position[1] + "");

            return new ChessPosition(column, line);
        }

        public static void PrintPiece(Piece piece)
        {
            if(piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
