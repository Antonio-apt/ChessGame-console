
namespace board
{
   abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color{ get; set; }
        public  int Moves{ get; set; }
        public Board Board { get; set; }

        public Piece(Board board, Color color)
        {
            Position = null;
            Color = color;
            Moves = 0;
            Board = board;
        }

        public void IncrementMoves()
        {
            Moves++;
        }

        public bool PossibleMovesValidate()
        {
            bool[,] mat = PossibleMoves();
            for(int i=0; i < Board.Lines; i++)
            {
                for(int j=0; j < Board.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;    
                    }
                }
            }
            return false;
        }

        public bool CanMoveFor(Position after)
        {
            return PossibleMoves()[after.Line, after.Column];
        }

        public abstract bool[,] PossibleMoves();
        
    }
}
