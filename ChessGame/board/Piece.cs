
namespace board
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color{ get; set; }
        public  int Moves{ get; set; }
        public Board Board { get; set; }

        public Piece(Color color, Board board)
        {
            Position = null;
            Color = color;
            Moves = 0;
            Board = board;
        }
    }
}
