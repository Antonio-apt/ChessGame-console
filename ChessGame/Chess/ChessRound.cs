﻿
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
            if(capturePiece != null)
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

            round++;
            ChangePlayer();
        }

        public void ValidOriginPosition(Position after)
        {
            if (board.Piece(after) == null)
            {
                throw new BoardException(" Não existe peça nessa posição de origem");
            }
            if(player !=board.Piece(after).Color)
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
            if(player == Color.White)
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
                if(x.Color == color)
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
            if(color == Color.White)
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
            foreach(Piece x in GamePieces(color))
            {
                if(x is King)
                {
                    return x;

                }
            }
            return null;
        }


        public bool IsInCheck(Color color)
        {
            Piece king = King(color);

            if(king == null)
            {
                throw new BoardException("Não há rei no tabuleiro");
            }

            foreach(Piece x in GamePieces(Adversary(color)))
            {
                bool[,] mat = x.PossibleMoves();
                if(mat[king.Position.Line, king.Position.Column])
                {
                    return true;
                }
            }
            return false;

        }

        public void PutNewPiece(char column, int line, Piece piece)
        {
            board.PutPiece(piece, new ChessPosition(column, line).ToPosition());
            listPiece.Add(piece);
        }

        private void PutPieces()
        {

            PutNewPiece('a', 8, new Pawn(board, Color.Black));
            PutNewPiece('b', 8, new Pawn(board, Color.Black));
            PutNewPiece('c', 8, new Pawn(board, Color.Black));
            PutNewPiece('d', 8, new Pawn(board, Color.Black));
            PutNewPiece('e', 8, new Pawn(board, Color.Black));
            PutNewPiece('f', 8, new Pawn(board, Color.Black));
            PutNewPiece('g', 8, new Pawn(board, Color.Black));
            PutNewPiece('h', 8, new Pawn(board, Color.Black));
            PutNewPiece('h', 2, new Pawn(board, Color.White));
            PutNewPiece('h', 3, new Rook(board, Color.White));
            PutNewPiece('a', 4, new King(board, Color.Black));
            PutNewPiece('d', 4, new King(board, Color.White));

            
            


        }
    }
}
