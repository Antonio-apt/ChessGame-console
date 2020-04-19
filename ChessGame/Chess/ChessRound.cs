
using System.Collections.Generic;
using board;

namespace ChessGame.Chess
{
    class ChessRound
    {
        public Board board { get; private set; }
        public int round { get; private set; }
        public Color player { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> listPiece;
        private HashSet<Piece> listCaptured;
        public bool check { get; private set; }


        public ChessRound()
        {
            board = new Board(8, 8);
            round = 1;
            finished = false;
            player = Color.White;
            check = false;
            listPiece = new HashSet<Piece>();
            listCaptured = new HashSet<Piece>();
            PutPieces();
        }

        public void ValidateCoord(Position origin)
        {
            if (board.Piece(origin) == null)
            {
                throw new BoardException("cordenadas invalidas");
            }
        }

        public Piece ExecuteMove(Position origin, Position destiny)
        {

            Piece p = board.RemovePiece(origin);
            p.IncrementMoves();
            Piece capturePiece = board.RemovePiece(destiny);
            board.PutPiece(p, destiny);
            if (capturePiece != null)
            {
                listCaptured.Add(capturePiece);
            }

            return capturePiece;
        }

        public void UndoMove(Position origin, Position destiny, Piece capturePiece)
        {
            Piece p = board.RemovePiece(destiny);
            p.DecrementMoves();
            if (capturePiece != null)
            {
                board.PutPiece(capturePiece, destiny);
                listCaptured.Remove(capturePiece);

            }

            board.PutPiece(p, origin);
        }

        public void PlayRound(Position origin, Position destiny)
        {
            Piece capturePiece = ExecuteMove(origin, destiny);

            if (IsInCheck(player))
            {
                UndoMove(origin, destiny, capturePiece);
                throw new BoardException(" Você não pode se colocar xeque");
            }

            if (IsInCheck(Adversary(player)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if (Checkmate(Adversary(player)))
            {
                finished = true;
            }
            else
            {

                round++;
                ChangePlayer();

            }
        }

        public void ValidOriginPosition(Position after)
        {
            if (board.Piece(after) == null)
            {
                throw new BoardException(" Não existe peça nessa posição de origem");
            }
            if (player != board.Piece(after).Color)
            {
                throw new BoardException(" A peça de origem não é sua");
            }
            if (!board.Piece(after).PossibleMovesValidate())
            {
                throw new BoardException(" Não há movimentos possíveis para essa peça");
            }
        }

        public void ValidDestinyPosition(Position origin, Position destiny)
        {
            if (!board.Piece(origin).CanMoveFor(destiny))
            {
                throw new BoardException(" Posição de destino inválida!");
            }
        }




        private void ChangePlayer()
        {
            if (player == Color.White)
            {
                player = Color.Black;
            }
            else
            {
                player = Color.White;
            }
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> tempAux = new HashSet<Piece>();
            foreach (Piece x in listCaptured)
            {
                if (x.Color == color)
                {
                    tempAux.Add(x);
                }
            }
            return tempAux;
        }

        public HashSet<Piece> GamePieces(Color color)
        {
            HashSet<Piece> tempAux = new HashSet<Piece>();
            foreach (Piece x in listPiece)
            {
                if (x.Color == color)
                {
                    tempAux.Add(x);
                }
            }
            tempAux.ExceptWith(CapturedPieces(color));
            return tempAux;
        }

        public Color Adversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece King(Color color)
        {
            foreach (Piece x in GamePieces(color))
            {
                if (x is King)
                {
                    return x;

                }
            }
            return null;
        }


        public bool IsInCheck(Color color)
        {
            Piece king = King(color);

            if (king == null)
            {
                throw new BoardException("Não há rei no tabuleiro");
            }

            foreach (Piece x in GamePieces(Adversary(color)))
            {
                bool[,] mat = x.PossibleMoves();
                if (mat[king.Position.Line, king.Position.Column])
                {
                    return true;
                }
            }
            return false;

        }

        public bool Checkmate(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }
            foreach (Piece possible in GamePieces(color))
            {
                bool[,] mat = possible.PossibleMoves();
                for (int i = 0; i < board.Lines; i++)
                {
                    for (int j = 0; j < board.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = possible.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = ExecuteMove(origin, destiny);
                            bool check = IsInCheck(color);
                            UndoMove(origin, destiny, capturedPiece);
                            if (!check)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PutNewPiece(char column, int line, Piece piece)
        {
            board.PutPiece(piece, new ChessPosition(column, line).ToPosition());
            listPiece.Add(piece);
        }

        

        private void PutPieces()
        {
            //White
            PutNewPiece('a', 2, new Pawn(board, Color.White));
            PutNewPiece('b', 2, new Pawn(board, Color.White));
            PutNewPiece('c', 2, new Pawn(board, Color.White));
            PutNewPiece('d', 2, new Pawn(board, Color.White));
            PutNewPiece('e', 2, new Pawn(board, Color.White));
            PutNewPiece('f', 2, new Pawn(board, Color.White));
            PutNewPiece('g', 2, new Pawn(board, Color.White));
            PutNewPiece('h', 2, new Pawn(board, Color.White));
            PutNewPiece('h', 1, new Rook(board, Color.White));
            PutNewPiece('a', 1, new Rook(board, Color.White));
            PutNewPiece('b', 1, new Knight(board, Color.White));
            PutNewPiece('g', 1, new Knight(board, Color.White));
            PutNewPiece('c', 1, new Bishop(board, Color.White));
            PutNewPiece('f', 1, new Bishop(board, Color.White));
            PutNewPiece('d', 1, new King(board, Color.White));
            PutNewPiece('e', 1, new Queen(board, Color.White));



            //Black
            PutNewPiece('a', 7, new Pawn(board, Color.Black));
            PutNewPiece('b', 7, new Pawn(board, Color.Black));
            PutNewPiece('c', 7, new Pawn(board, Color.Black));
            PutNewPiece('d', 7, new Pawn(board, Color.Black));
            PutNewPiece('e', 7, new Pawn(board, Color.Black));
            PutNewPiece('f', 7, new Pawn(board, Color.Black));
            PutNewPiece('g', 7, new Pawn(board, Color.Black));
            PutNewPiece('h', 7, new Pawn(board, Color.Black));
            PutNewPiece('h', 8, new Rook(board, Color.Black));
            PutNewPiece('a', 8, new Rook(board, Color.Black));
            PutNewPiece('b', 8, new Knight(board, Color.Black));
            PutNewPiece('g', 8, new Knight(board, Color.Black));
            PutNewPiece('c', 8, new Bishop(board, Color.Black));
            PutNewPiece('f', 8, new Bishop(board, Color.Black));
            PutNewPiece('d', 8, new King(board, Color.Black));
            PutNewPiece('e', 8, new Queen(board, Color.Black));





        }
    }
}
