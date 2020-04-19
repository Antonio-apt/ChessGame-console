using board;

namespace ChessGame.Chess
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "C";
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

            after.DefineValues(Position.Line - 1, Position.Column - 2);
            if (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
            }

            after.DefineValues(Position.Line - 2, Position.Column - 1);
            if (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
            }

            after.DefineValues(Position.Line - 2, Position.Column + 1);
            if (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
            }

            after.DefineValues(Position.Line - 1, Position.Column + 2);
            if (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
            }
            
            after.DefineValues(Position.Line + 1, Position.Column + 2);
            if (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
            }

            after.DefineValues(Position.Line + 1, Position.Column - 2);
            if (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
            }


            after.DefineValues(Position.Line + 2, Position.Column - 1);
            if (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
            }
            
            after.DefineValues(Position.Line + 2, Position.Column + 1);
            if (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
            }

            return mat;

        }
    }
}
