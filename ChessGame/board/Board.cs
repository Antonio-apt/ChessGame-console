using System;
using System.Collections.Generic;
using System.Text;

namespace board
{
    class Board
    {

        public int Lines { get; set; }
        public int Columns{ get; set; }
        private Piece[,] Pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece Piece(int line, int column)
        {
            return Pieces[line, column];
        }

        public Piece Piece(Position after)
        {
            return Pieces[after.Line, after.Column];
        }

        public bool PieceIn(Position after)
        {
            ValidatePosition(after);
            return Piece(after) != null;
        }

        public void PutPiece(Piece p, Position after)
        {
            if (    PieceIn(after))
            {
                throw new BoardException("Já existe uma peça nesta posição");
            }
            Pieces[after.Line, after.Column] = p;
            p.Position = after;
        }

        

        public bool ValidPosition(Position after)
        {
            if(after.Line<0 || after.Column<0 || after.Line>Lines || after.Column > Columns)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position after)
        {
            if (!ValidPosition(after))
            {
                throw new BoardException("Posição Invalida");
            }
        }


    }
}
