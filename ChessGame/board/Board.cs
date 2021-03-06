﻿

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
            if(line> Lines || column > Columns)
            {
                throw new BoardException(" Valores invalidos");
            }
            return Pieces[line, column];
        }

        public Piece Piece(Position after)
        {
            if (after.Line > Lines || after.Column > Columns || after.Line < 0 || after.Column < 0)
            {
                throw new BoardException(" Valores invalidos!!!");
            }
            return Pieces[after.Line, after.Column];
        }

        public bool PieceIn(Position after)
        {
            ValidatePosition(after);
            return Piece(after) != null;
        }

        public void PutPiece(Piece p, Position after)
        {
            if (PieceIn(after))
            {
                throw new BoardException("Já existe uma peça nesta posição");
            }
            Pieces[after.Line, after.Column] = p;
            p.Position = after;
        }

        public Piece RemovePiece(Position after)
        {
            if (Piece(after) == null)
            {
                return null;
            }
            Piece aux = Piece(after);
            aux.Position = null;
            Pieces[after.Line, after.Column] = null;
            return aux;

        } 

        

        public bool ValidPosition(Position after)
        {
            if(after.Line<0 || after.Column<0 || after.Line>=Lines || after.Column >=Columns)
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
