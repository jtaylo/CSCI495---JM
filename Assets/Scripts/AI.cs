using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Resources Used
 * 
 * https://medium.freecodecamp.org/simple-chess-ai-step-by-step-1d55a9266977 this link lead to the link below 
 * https://chessprogramming.wikispaces.com/Simplified+evaluation+function is what I'm actually using
 * 
 */
namespace JMCapstone
{
    public class AI // lies, this thing has no intelligence
    {
        
        int[,] BoardState;

        private int Eval()
        {
            int total = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    if (BoardState[i, j] != -1)
                    {
                        total += Constants.pointValues[BoardState[i, j]];

                        switch (BoardState[i, j])
                        {

                            case Constants.BlackRook:
                                
                                total += Constants.RookPositionVal[(63 - (8 * j) - (i - 7))];
                                Debug.Log(Constants.RookPositionVal[(63 - (8 * j) - (i - 7))]);

                                break;
                            case Constants.BlackKnight:
                                total += Constants.KnightPositionVal[(63 - (8 * j) - (i - 7))];
                                Debug.Log(Constants.KnightPositionVal[(63 - (8 * j) - (i - 7))]);
                                break;
                            case Constants.BlackBishop:
                                total += Constants.BishopPositionVal[(63 - (8 * j) - (i - 7))];
                                Debug.Log(Constants.BishopPositionVal[(63 - (8 * j) - (i - 7))]);
                                break;
                            case Constants.BlackKing:
                                total += Constants.KingPositionVal[(63 - (8 * j) - (i - 7))];
                                Debug.Log(Constants.KingPositionVal[(63 - (8 * j) - (i - 7))]);
                                break;
                            case Constants.BlackQueen:
                                total += Constants.QueenPositionVal[(63 - (8 * j) - (i - 7))];
                                Debug.Log(Constants.QueenPositionVal[(63 - (8 * j) - (i - 7))]);
                                break;
                            case Constants.BlackPawn:
                                total += Constants.PawnPositionVal[(63 - (8 * j) - (i - 7))];
                                Debug.Log(Constants.PawnPositionVal[(63 - (8 * j) - (i - 7))]);
                                break;                                
                        }
                    }
                    
                }
            }

            return total;

        }




            public int getMove(int[,] boardState)
        {
            BoardState = boardState;


            return 1;
        }

        public void Update(int[,] boardState)
        {
            BoardState = boardState;
        }




    }
}


/*
        private int Eval()
        {
            int total = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (BoardState[i, j] != -1)
                    {
                        total +=  Constants.pointValues[BoardState[i, j]];

                    }

                }
            }

            return total;

            /*
            switch statement for each piece type



             



        }
        */
