using board;

namespace ChessGame.Chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "B";
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

            //ne
            after.DefineValues(Position.Line - 1, Position.Column + 1);
            
            while (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
                if (Board.Piece(after) != null && Board.Piece(after).Color != Color)
                {
                    break;
                }

                //after.DefineValues(Position.Line - 1, Position.Column + 1);
                after.Line = after.Line - 1;
                after.Column = after.Column + 1;
            }

            //se
            after.DefineValues(Position.Line + 1, Position.Column + 1);

            while (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
                if (Board.Piece(after) != null && Board.Piece(after).Color != Color)
                {
                    break;
                }

                //after.DefineValues(Position.Line + 1, Position.Column + 1);
                after.Line = after.Line + 1;
                after.Column = after.Column + 1;

            }

            //so
            after.DefineValues(Position.Line + 1, Position.Column - 1);
            while (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
                if (Board.Piece(after) != null && Board.Piece(after).Color != Color)
                {
                    break;
                }

                //after.DefineValues(Position.Line + 1, Position.Column - 1);
                after.Line = after.Line + 1;
                after.Column = after.Column - 1;
            }

            //no
            after.DefineValues(Position.Line - 1, Position.Column - 1);

            while (Board.ValidPosition(after) && CanMove(after))
            {
                mat[after.Line, after.Column] = true;
                if (Board.Piece(after) != null && Board.Piece(after).Color != Color)
                {
                    break;
                }

               
                //after.DefineValues(Position.Line - 1, Position.Column - 1);
                after.Line = after.Line - 1;
                after.Column = after.Column - 1;

            }




            return mat;

        }

        

    }
}
