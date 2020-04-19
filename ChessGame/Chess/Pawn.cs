using board;

namespace ChessGame.Chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {

        }
        


        public override string ToString()
        {
            return "P";
        }


        public bool CanMove(Position after)
        {
            Piece p = Board.Piece(after);
            return p == null || p.Color != Color;
        }

        private bool HasEnemy(Position after)
        {
            Piece p = Board.Piece(after);
            return p != null && p.Color != Color;
        }

        private bool Free(Position after)
        {
            return Board.Piece(after) == null;
        }



        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position after = new Position(0, 0);

            if(Color == Color.White)
            {
                after.DefineValues(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(after) && Free(after))
                {
                    mat[after.Line, after.Column] = true;
                }

                after.DefineValues(Position.Line - 2, Position.Column);
                if (Board.ValidPosition(after) && Free(after) && Moves ==0)
                {
                    mat[after.Line, after.Column] = true;
                }

                after.DefineValues(Position.Line - 1, Position.Column - 1);
                if (Board.ValidPosition(after)  && HasEnemy(after))
                {
                    mat[after.Line, after.Column] = true;
                }

                after.DefineValues(Position.Line - 1, Position.Column + 1);
                if (Board.ValidPosition(after)  && HasEnemy(after))
                {
                    mat[after.Line, after.Column] = true;
                }
            }
            else
            {
                after.DefineValues(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(after) && Free(after))
                {
                    mat[after.Line, after.Column] = true;
                }

                after.DefineValues(Position.Line + 2, Position.Column);
                if (Board.ValidPosition(after) && Free(after) && Moves == 0)
                {
                    mat[after.Line, after.Column] = true;
                }

                after.DefineValues(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(after)  && HasEnemy(after))
                {
                    mat[after.Line, after.Column] = true;
                }

                after.DefineValues(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(after)  && HasEnemy(after))
                {
                    mat[after.Line, after.Column] = true;
                }
            }

            return mat;

        }
    }
}
