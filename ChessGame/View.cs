using System;
using board;
using ChessGame.Chess;
using System.Collections.Generic;


namespace ChessGame
{
    class View
    {

        public static void ViewGame(ChessRound chessRound)
        {
            ViewBoard(chessRound.board);
            PrintCapturedPieces(chessRound);
            
            Console.WriteLine($" Turno: {chessRound.round}");
            Console.WriteLine($" Turno de : {chessRound.player}");
            if (chessRound.check)
            {
                Console.WriteLine(" XEQUE!");
            }
        }

        public static void PrintCapturedPieces(ChessRound round)
        {
            Console.WriteLine(" -------------------------------");
            Console.WriteLine(" Peças capturadas");
            Console.Write(" Brancas: ");
            PrintSet(round.CapturedPieces(Color.White));
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n Pretas: ");
            Console.ForegroundColor = aux;
            PrintSet(round.CapturedPieces(Color.Black));
            Console.WriteLine(" \n -------------------------------");
        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[ ");
            foreach(Piece x in set)
            {
                Console.Write(x +", ");
            }
            Console.Write("] ");
        }

        private static void ChessTitle()
        {
            Console.WriteLine("    --- --- --- --- --- --- --- ---");
            Console.WriteLine("    ---  X   A   D   R   E   Z  ---");
            Console.WriteLine("    --- --- --- --- --- --- --- ---");
            Console.WriteLine("\n    --- --- --- --- --- --- --- ---");
        }

        public static void ViewBoard(Board board)
        {
            ChessTitle();
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write($" {8 - i} |");
                for (int j = 0; j < board.Columns; j++)
                {

                    PrintPiece(board.Piece(i, j));
                    

                }
                Console.WriteLine("");

                Console.WriteLine("    --- --- --- --- --- --- --- ---");

            }
            Console.WriteLine("    -a- -b- -c- -d- -e- -f- -g- -h-");



        }


        public static void ViewBoard(Board board, bool[,] possibleMoves)
        {

            ChessTitle();
            ConsoleColor backgroundOriginal = Console.BackgroundColor;
            ConsoleColor backgroundNew = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write($" {8 - i} |");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possibleMoves[i, j])
                    {
                        Console.BackgroundColor = backgroundNew;
                    }
                    else
                    {
                        Console.BackgroundColor = backgroundOriginal;
                    }
                   
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = backgroundOriginal;



                }
                Console.WriteLine("");

                Console.WriteLine("    --- --- --- --- --- --- --- ---");

            }
            Console.WriteLine("    -a- -b- -c- -d- -e- -f- -g- -h-");
            Console.BackgroundColor = backgroundOriginal;



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
            //ConsoleColor backgroundOriginal = Console.BackgroundColor;
            //ConsoleColor backgroundNew = ConsoleColor.DarkGray;

            if (piece == null)
            {
                //Console.BackgroundColor = backgroundNew;
                Console.Write(" - ");
                //Console.BackgroundColor = backgroundOriginal;
                Console.Write("|");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(" ");
                    Console.Write(piece);
                    Console.Write(" ");
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" ");
                    Console.Write(piece);
                    Console.Write(" ");
                    Console.ForegroundColor = aux;
                }
                Console.Write("|");

            }
        }
    }
}
