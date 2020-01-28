using board;

namespace ChessGame.Chess
{
    class Rook : Piece
    {
        public Rook(Color color, Board board) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "T";
        }
    }
}
