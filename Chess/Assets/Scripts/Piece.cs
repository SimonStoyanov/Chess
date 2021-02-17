namespace Chess
{
    public static class Piece
    {
        public const int None = 0;
        public const int Pawn = 1;
        public const int Knight = 2;
        public const int Bishop = 3;
        public const int Rook = 4;
        public const int Queen = 5;
        public const int King = 6;

        public const int White = 8;
        public const int Black = 16;

        const int typeMask = 0b00111;
        const int blackMask = 0b10000;
        const int whiteMask = 0b01000;
        const int colourMask = whiteMask | blackMask;

        public static bool isColour(int piece, int colour)
        {
            return (piece & colourMask) == colour;
        }

        public static int PieceType(int piece)
        {
            return piece & typeMask;
        }
    }
}
