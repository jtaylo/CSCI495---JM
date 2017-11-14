using System.Collections;
using System.Collections.Generic;

namespace JMCapstone
{

    public class Piece
    {

        public int X;
        public int Y;
        public int Type; //Corresponds to ints listed above
        public int Id;

        public Piece(int x, int y, int type, int id)
        {
            X = x;
            Y = y;
            Type = type;
            Id = id;
        }

        public void ChangePosition(int x, int y)
        {
            X = x;
            Y = y;
        }


        public void Upgrade(int type)
        {
            Type = type;
        }


        public int GetTypeofPiece()
        {
            return Type;
        }

    }
}
