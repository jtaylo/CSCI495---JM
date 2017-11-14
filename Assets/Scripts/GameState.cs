using System.Collections;
using System.Collections.Generic;

namespace JMCapstone
{
    public class GameState
    {

        bool aiTurn;
        public List<Piece> currentPieces;



        public GameState()
        {
            
            aiTurn = false;
            currentPieces = new List<Piece>();
        }

        public void AddPiece(Piece piece)
        {
            currentPieces.Add(piece);
        }

        public int GetId(int position)
        {
            return currentPieces[position].Id;
        }

        public int[,] SimplifiedBoardState()
        {
            int[,] boardState = new int[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    boardState[i, j] = Constants.None;
                }

            }

            for (int j = 0; j < currentPieces.Count; j++)
            {
                boardState[currentPieces[j].X, currentPieces[j].Y] = currentPieces[j].Id;
            }

            return boardState;

        }

    }

}
