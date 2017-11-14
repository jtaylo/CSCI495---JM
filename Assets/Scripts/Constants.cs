using System.Collections;
using System.Collections.Generic;

namespace JMCapstone
{
    static class Constants
    {

        // Piece ID values
        internal const int BlackRook = 0, BlackKnight = 1, BlackBishop = 2, BlackKing = 3, BlackQueen = 4,
            BlackPawn = 5, WhiteRook = 6, WhiteKnight = 7, WhiteBishop = 8, WhitekKing = 9, WhiteQueen = 10,
            WhitePawn = 11, None = -1;


        public static readonly int[] defaultPosition = new int[] { Constants.BlackRook, Constants.BlackKnight, Constants.BlackBishop, Constants.BlackKing,
            Constants.BlackQueen, Constants.BlackBishop, Constants.BlackKnight, Constants.BlackRook };


        public static readonly int[] pointValues = { -500, -320, -330, -20000, -900, -100, 500, 320, 330, 20000, 900, 100 }; // position corresponds to the Piece ID values above

        

        public static readonly int[] PawnPositionVal = { 0,  0,  0,  0,  0,  0,  0,  0,
                                                        50, 50, 50, 50, 50, 50, 50, 50,
                                                        10, 10, 20, 30, 30, 20, 10, 10,
                                                         5,  5, 10, 25, 25, 10,  5,  5,
                                                         0,  0,  0, 20, 20,  0,  0,  0,
                                                         5, -5,-10,  0,  0,-10, -5,  5,
                                                         5, 10, 10,-20,-20, 10, 10,  5,
                                                         0,  0,  0,  0,  0,  0,  0,  0};


        public static readonly int[] KnightPositionVal = {-50,-40,-30,-30,-30,-30,-40,-50,
                                                        -40,-20,  0,  0,  0,  0,-20,-40,
                                                        -30,  0, 10, 15, 15, 10,  0,-30,
                                                        -30,  5, 15, 20, 20, 15,  5,-30,
                                                        -30,  0, 15, 20, 20, 15,  0,-30,
                                                        -30,  5, 10, 15, 15, 10,  5,-30,
                                                        -40,-20,  0,  5,  5,  0,-20,-40,
                                                        -50,-40,-30,-30,-30,-30,-40,-50,};


        public static readonly int[] BishopPositionVal = {-20,-10,-10,-10,-10,-10,-10,-20,
                                                        -10,  0,  0,  0,  0,  0,  0,-10,
                                                        -10,  0,  5, 10, 10,  5,  0,-10,
                                                        -10,  5,  5, 10, 10,  5,  5,-10,
                                                        -10,  0, 10, 10, 10, 10,  0,-10,
                                                        -10, 10, 10, 10, 10, 10, 10,-10,
                                                        -10,  5,  0,  0,  0,  0,  5,-10,
                                                        -20,-10,-10,-10,-10,-10,-10,-20,};

        public static readonly int[] RookPositionVal = { 0,  0,  0,  0,  0,  0,  0,  0,
                                                          5, 10, 10, 10, 10, 10, 10,  5,
                                                         -5,  0,  0,  0,  0,  0,  0, -5,
                                                         -5,  0,  0,  0,  0,  0,  0, -5,
                                                         -5,  0,  0,  0,  0,  0,  0, -5,
                                                         -5,  0,  0,  0,  0,  0,  0, -5,
                                                         -5,  0,  0,  0,  0,  0,  0, -5,
                                                          0,  0,  0,  5,  5,  0,  0,  0};

        public static readonly int[] QueenPositionVal = { -20,-10,-10, -5, -5,-10,-10,-20,
                                                        -10,  0,  0,  0,  0,  0,  0,-10,
                                                        -10,  0,  5,  5,  5,  5,  0,-10,
                                                        -5,  0,  5,  5,  5,  5,  0, -5,
                                                         0,  0,  5,  5,  5,  5,  0, -5,
                                                        -10,  5,  5,  5,  5,  5,  0,-10,
                                                        -10,  0,  5,  0,  0,  0,  0,-10,
                                                        -20,-10,-10, -5, -5,-10,-10,-20};


        public static readonly int[] KingPositionVal = {-30,-40,-40,-50,-50,-40,-40,-30,
                                                        -30,-40,-40,-50,-50,-40,-40,-30,
                                                        -30,-40,-40,-50,-50,-40,-40,-30,
                                                        -30,-40,-40,-50,-50,-40,-40,-30,
                                                        -20,-30,-30,-40,-40,-30,-30,-20,
                                                        -10,-20,-20,-20,-20,-20,-20,-10,
                                                         20, 20,  0,  0,  0,  0, 20, 20,
                                                         20, 30, 10,  0,  0, 10, 30, 20 };

        public static readonly int[] KingPositionValLG = {-50,-40,-30,-20,-20,-30,-40,-50,
                                                        -30,-20,-10,  0,  0,-10,-20,-30,
                                                        -30,-10, 20, 30, 30, 20,-10,-30,
                                                        -30,-10, 30, 40, 40, 30,-10,-30,
                                                        -30,-10, 30, 40, 40, 30,-10,-30,
                                                        -30,-10, 20, 30, 30, 20,-10,-30,
                                                        -30,-30,  0,  0,  0,  0,-30,-30,
                                                        -50,-30,-30,-30,-30,-30,-30,-50};

    }
}
