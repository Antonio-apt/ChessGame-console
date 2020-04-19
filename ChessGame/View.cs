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

            if (!chessRound.finished)
            {
                Console.WriteLine($" Turno: {chessRound.round}");
                Console.Write(" Turno de : ");
                ConsoleColor aux = Console.ForegroundColor;
                if (chessRound.player == Color.Black)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                Console.WriteLine(chessRound.player);
                Console.ForegroundColor = aux;
                if (chessRound.check)
                {
                    Console.WriteLine(" XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUE-MATE!!!");
                Console.WriteLine($"Vencedor: {chessRound.player}");
            }
        }

        public static void PrintCapturedPieces(ChessRound round)
        {
            Console.WriteLine(" -------------------------------");
            Console.WriteLine(" Peças capturadas");
            Console.Write(" Brancas: ");
            PrintSet(round.CapturedPieces(Color.White));
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\n Pretas: ");
            Console.ForegroundColor = aux;
            PrintSet(round.CapturedPieces(Color.Black));
            Console.WriteLine(" \n -------------------------------");
        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[ ");
            foreach (Piece x in set)
            {
                Console.Write(x + ", ");
            }
            Console.Write("] ");
        }

        private static void ChessTitle()
        {
            Console.WriteLine("    --- --- --- --- --- --- --- ---");
            Console.Write("    ---  ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  X  A  D  R  E  Z   ");
            Console.ForegroundColor = aux;
            Console.Write("  ---\n");
            Console.WriteLine("    --- --- --- --- --- --- --- ---");
            Console.WriteLine("\n    --- --- --- --- --- --- --- ---");
        }

        public static void ViewBoard(Board board)
        {
            ChessTitle();
            ConsoleColor aux = Console.ForegroundColor;
            for (int i = 0; i < board.Lines; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($" {8 - i} ");
                Console.ForegroundColor = aux;
                Console.Write("|");
                for (int j = 0; j < board.Columns; j++)
                {

                    PrintPiece(board.Piece(i, j));


                }
                Console.WriteLine("");

                Console.WriteLine("    --- --- --- --- --- --- --- ---");

            }
            
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("    -a- -b- -c- -d- -e- -f- -g- -h-");
            Console.ForegroundColor = aux;
            



        }


        public static void ViewBoard(Board board, bool[,] possibleMoves)
        {

            ChessTitle();
            ConsoleColor backgroundOriginal = Console.BackgroundColor;
            ConsoleColor backgroundNew = ConsoleColor.DarkGray;
            ConsoleColor aux = Console.ForegroundColor;

            for (int i = 0; i < board.Lines; i++)
            {
                
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($" {8 - i} ");
                Console.ForegroundColor = aux;
                Console.Write("|");
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
            
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("    -a- -b- -c- -d- -e- -f- -g- -h-");
            Console.ForegroundColor = aux;
            Console.BackgroundColor = backgroundOriginal;



        }

        public static ChessPosition ReadChessPosition()
        {
            string position = Console.ReadLine();
            if(String.IsNullOrWhiteSpace(position))
            {
                throw new BoardException(" Valor nulo!!");
            }

            if(position.Length != 2)
            {
                throw new BoardException(" Quantidade da valores invalidos!!");
            }
            if (!char.IsDigit(position[1]))
            {
                throw new BoardException(" Formato invalido!!");
            }

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
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
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
