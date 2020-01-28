using System;
using board;


namespace ChessGame
{
    class View
    {
        public static void ViewBoard(Board board)
        {
            Console.WriteLine(" --- --- --- --- --- --- --- ---");
            Console.WriteLine(" ---  X   A   D   R   E   Z  ---");
            Console.WriteLine(" --- --- --- --- --- --- --- ---");
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.Piece(i, j) == null)
                    {
                        Console.Write("- | ");
                        
                    }
                    else
                    {
                        Console.Write(board.Piece(i, j) + " ");
                    }
                    
                    
                }
                Console.WriteLine("");
                
                Console.WriteLine(" --- --- --- --- --- --- --- ---");
            }
        }
    }
}
