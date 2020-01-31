using board;

namespace ChessGame.Chess
{
    class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "T";
        }

        public bool CanMove(Position after)
        {
            Piece p = Board.Piece(after);
            return p == null || p.Color != Color;
        }



        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position after = new Position(0, 0);

            //Acima
            after.DefineValues(Position.Line - 1, Position.Column);
            while (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
                if(Board.Piece(after) != null && Board.Piece(after).Color != Color)
                {
                    break;
                }

                after.Line = after.Line - 1;
            }
            
            //Direita
            after.DefineValues(Position.Line, Position.Column + 1);
            while (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
                if (Board.Piece(after) != null && Board.Piece(after).Color != Color)
                {
                    break;
                }   

                after.Column = after.Column + 1;
            }

            //Abaixo
            after.DefineValues(Position.Line + 1, Position.Column);
            while (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
                if (Board.Piece(after) != null && Board.Piece(after).Color != Color)
                {
                    break;
                }

                after.Line = after.Line + 1;
            }

            //Esquerda
            after.DefineValues(Position.Line, Position.Column - 1);
            while (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
                if (Board.Piece(after) != null && Board.Piece(after).Color != Color)
                {
                    break;
                }

                after.Column = after.Column - 1;
            }



            return mat;

        }

    }
}
