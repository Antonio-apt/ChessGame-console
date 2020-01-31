using board;


namespace ChessGame.Chess
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "Q";
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
            if (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
            }
            //ne
            after.DefineValues(Position.Line - 1, Position.Column + 1);
            if (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
            }
            //Direita
            after.DefineValues(Position.Line, Position.Column + 1);
            if (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
            }
            //se
            after.DefineValues(Position.Line + 1, Position.Column + 1);
            if (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
            }
            //Abaixo
            after.DefineValues(Position.Line + 1, Position.Column);
            if (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
            }
            //so
            after.DefineValues(Position.Line + 1, Position.Column - 1);
            if (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
            }
            //Esquerda
            after.DefineValues(Position.Line, Position.Column - 1);
            if (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
            }
            //no
            after.DefineValues(Position.Line - 1, Position.Column - 1);
            if (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
            }

            return mat;

        }

    }
}
