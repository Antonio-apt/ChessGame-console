
using board;

namespace ChessGame.Chess
{
    class ChessRound
    {
        public Board board { get; set; }
        private int round;
        private Color player;
        public bool finished { get; private set; }


        public ChessRound()
        {
            board = new Board(8, 8);
            round = 1;
            finished = false;
            player = Color.White;
            PutPieces();
        }

        public void ExecuteMove(Position origin, Position destiny)
        {
            Piece p = board.RemovePiece(origin);
            p.IncrementMoves();
            Piece capturePiece = board.RemovePiece(destiny);
            board.PutPiece(p, destiny);
        }

        private void PutPieces()
        {
            board.PutPiece(new Pawn(Color.Black, board), new ChessPosition('a', 7).ToPosition());
            board.PutPiece(new Pawn(Color.Black, board), new ChessPosition('b', 7).ToPosition());
            board.PutPiece(new Pawn(Color.Black, board), new ChessPosition('c', 7).ToPosition());
            board.PutPiece(new Pawn(Color.Black, board), new ChessPosition('d', 7).ToPosition());
            board.PutPiece(new Pawn(Color.Black, board), new ChessPosition('e', 7).ToPosition());
            board.PutPiece(new Pawn(Color.Black, board), new ChessPosition('f', 7).ToPosition());
            board.PutPiece(new Pawn(Color.Black, board), new ChessPosition('g', 7).ToPosition());
            board.PutPiece(new Pawn(Color.Black, board), new ChessPosition('h', 7).ToPosition());
            board.PutPiece(new Rook(Color.Black, board), new ChessPosition('a', 8).ToPosition());
            board.PutPiece(new Rook(Color.Black, board), new ChessPosition('h', 8).ToPosition());
            board.PutPiece(new Knight(Color.Black, board), new ChessPosition('b', 8).ToPosition());
            board.PutPiece(new Knight(Color.Black, board), new ChessPosition('g', 8).ToPosition());
            board.PutPiece(new Bishop(Color.Black, board), new ChessPosition('c', 8).ToPosition());
            board.PutPiece(new Bishop(Color.Black, board), new ChessPosition('f', 8).ToPosition());
        }
    }
}
