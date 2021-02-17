namespace Chess
{
    using System.Collections.Generic;

    public class Board
    {
        public static int[] Square;

        public void Initialize()
        {
            Square = new int[64];

            Square[0] = Piece.Rook | Piece.Black;
            Square[1] = Piece.Bishop | Piece.Black;
            Square[5] = Piece.Pawn | Piece.White;
            Square[62] = Piece.King | Piece.White;
        }

        public int GetSquare(int i)
        {
            return Square[i];
        }
    }
}