namespace Chess
{
    public static class Piece
    {
        public const int None = 0;      // 0b00000
        public const int Pawn = 1;      // 0b00001
        public const int Knight = 2;    // 0b00010
        public const int Bishop = 3;    // 0b00011
        public const int Rook = 4;      // 0b00100
        public const int Queen = 5;     // 0b00101
        public const int King = 6;      // 0b00110

        public const int White = 8;     // 0b01000
        public const int Black = 16;    // 0b10000

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
