using System.Collections.Generic;
using UnityEngine;

namespace JMCapstone
{
    public class BoardManager : MonoBehaviour
    {

        public List<GameObject> Pieces;
        private List<ActivePiece> ActivePieces;
        public GameState GameState;


        // Use this for initialization
        void Start()
        {
            
            ActivePieces = new List<ActivePiece>();
            GameState = new GameState();

            SetUpBoard();
            MovePiece(0);

        }

        // Update is called once per frame
        void Update()
        {

        }


        public Vector3 Get3DCoordinates(int x, int z)
        {
            float xPosition = (((x * 9) + 4.5f)*0.02f -0.72f);
            float zPosition = (((z * 9) + 4.5f)*0.02f -0.72f);

            return new Vector3(xPosition, 2.1f, zPosition);
        }


        private void SetUpBoard()
        {
            int count = 0;

            for (int i = 0; i < 8; i++)
            {
                

                SpawnPiece(i, 0, Constants.defaultPosition[i]);
                GameState.AddPiece(new Piece(i, 0, Constants.defaultPosition[i], count++));

                SpawnPiece(i, 1, Constants.BlackPawn);
                GameState.AddPiece(new Piece(i, 1, Constants.BlackPawn, count++));


                SpawnPiece(i, 7, Constants.defaultPosition[i] + 6);
                GameState.AddPiece(new Piece(i, 7, Constants.defaultPosition[i] + 6, count++));

                SpawnPiece(i, 6, Constants.WhitePawn);
                GameState.AddPiece(new Piece(i, 6, Constants.WhitePawn, count++));
            }
        }


        private void SpawnPiece(int x, int y, int piece)
        {
            Vector3 pos = Get3DCoordinates(x, y);
            GameObject newPiece = Instantiate(Pieces[piece], pos, Quaternion.identity) as GameObject;
            ActivePieces.Add(new ActivePiece(ActivePieces.Count, newPiece));

        }

        public void MovePiece(int piecee)
        {
            ActivePieces[piecee].setPosition(Get3DCoordinates(0,4));
        }


        private class ActivePiece
        {
            int Id;
            GameObject Piece;

            public ActivePiece(int id, GameObject piece)
            {
                Id = id;
                Piece = piece;
            }

            public GameObject getPiece()
            {
                return Piece;
            }

            public void setPosition(Vector3 pos)
            {
                Piece.transform.position = pos;
            }
        }

        
    }
}


