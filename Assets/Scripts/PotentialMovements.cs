using System.Collections;
using System.Collections.Generic;

namespace JMCapstone
{
    public class PotentialMovements
    {
        private List<Move> Movements;
        private bool IsBlackPlayer;
        private int[,] BoardState;
        private bool CanCastle;

        public List<Move> GetPotentialMovements(int[,] boardState, bool isBlackPlayer, bool canCastle)
        {
            Movements = new List<Move>();
            BoardState = boardState;
            IsBlackPlayer = isBlackPlayer;
            CanCastle = canCastle;

            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    switch (boardState[i, j])
                    {

                        case Constants.BlackRook:
                            GetHorizontalVerticalMovements(i, j);
                            break;
                        case Constants.BlackKnight:

                            break;
                        case Constants.BlackBishop:
                            GetDiagonalMovments(i, j);
                            break;
                        case Constants.BlackKing:
                            
                            break;
                        case Constants.BlackQueen:
                            GetHorizontalVerticalMovements(i, j);
                            GetDiagonalMovments(i, j);
                            break;
                        case Constants.BlackPawn:

                            break;
                    }
                }
            }


            return Movements;
        }



        private bool IsCapturable(int type, int otherType)
        {//         white 
            if( (type < 5 && otherType >= 5) || (type >= 5 && otherType < 5))
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }


        private void GetHorizontalVerticalMovements(int x, int y)
        {
            int type = BoardState[x, y];

            //Handle horizontal movement to the right
            for (int q = x + 1; q < 8; q++) //if q = 7 loop never executes so no need to worry about out of bounds on array
            {
                if (BoardState[q, y] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, q, y));
                }
                else
                {
                    if (IsCapturable(type, BoardState[q, y]))
                    {
                        Movements.Add(new Move(type, x, y, q, y, true));
                    }
                    break;
                }
            }

            //Handle horizontal movement to the left
            for (int q = x - 1; q >= 0; q--) //if q = 0 loop never executes so no need to worry about out of bounds on array
            {
                if (BoardState[q, y] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, q, y));
                }
                else
                {
                    if (IsCapturable(type, BoardState[q, y]))
                    {
                        Movements.Add(new Move(type, x, y, q, y, true));
                    }
                    break;
                }
            }

            //Handle upwards vertical movement
            for (int q = y + 1; q < 8; q++)
            {
                if (BoardState[x, q] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, x, q));
                }
                else
                {
                    if (IsCapturable(type, BoardState[x, q]))
                    {
                        Movements.Add(new Move(type, x, y, x, q, true));
                    }
                    break;
                }
            }

            //Handle downwards vertical movement
            for (int q = y - 1; q >= 0; q--)
            {
                if (BoardState[x, q] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, x, q));
                }
                else
                {
                    if (IsCapturable(type, BoardState[x, q]))
                    {
                        Movements.Add(new Move(type, x, y, x, q, true));
                    }
                    break;
                }
            }
        }//getHorizontalVerticalMovements

        private void GetDiagonalMovments(int x, int y)
        {
            int type = BoardState[x, y];
            int temp;

            //Handle diagonal  (+1, +1)
            if (x > y) { temp = x; } else { temp = y; } /* We reach the last spot when the first number hits seven.
            So the larger number determines many iterations this loop can run. */
            for (int q = 1; q < (8 - temp); q++)
            {
                if (BoardState[x + q, y + q] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, x + q, y + q));
                }
                else
                {
                    if (IsCapturable(type, BoardState[x+q, y + q]))
                    {
                        Movements.Add(new Move(type, x, y, x+q, y+q, true));
                    }
                    break;
                }
            }

            //Handle diagonal  (+1, -1) (x,y)
            if ((7-x) <= y) {
                // if x has less time to hit an end x determines the number of iterations we can do
                // If both have equal times to hit an end it doesn't matter so we use x so that we don't have to go into the else statement 
                temp = x;
            } else {
                temp = 7-y; //I don't want to deal with counting down so I convert it to something that lets me count up
                
            }
            for (int q = 1; q < (8 - temp); q++)
            {
                if (BoardState[x + q, y - q] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, x + q, y - q));
                }
                else
                {
                    if (IsCapturable(type, BoardState[x + q, y - q]))
                    {
                        Movements.Add(new Move(type, x, y, x + q, y - q, true));
                    }
                    break;
                }
            }

            //Handle diagonal  (-1, -1) (x,y)
            if(x < y) { temp = x; } else { temp = y; } /* We reach the last spot when the first number hits 0. */
            for (int q = 1; q >= temp; q--)
            {
                if (BoardState[x - q, y - q] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, x - q, y - q));
                }
                else
                {
                    if (IsCapturable(type, BoardState[x - q, y - q]))
                    {
                        Movements.Add(new Move(type, x, y, x - q, y - q, true));
                    }
                    break;
                }
            }

            //Handle diagonal  (-1, +1) (x,y)
            if (x <= (7-y))
            {
                // if x has less time to hit an end x determines the number of iterations we can do
                // If both have equal times to hit an end it doesn't matter so we use x so that we don't have to go into the else statement 
                temp = 7-x; //I don't want to deal with counting down so I convert it to something that lets me count up
            }
            else
            {
                temp = y; 
            }
            for (int q = 1; q < (8 - temp); q++)
            {
                if (BoardState[x - q, y + q] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, x - q, y + q));
                }
                else
                {
                    if (IsCapturable(type, BoardState[x - q, y + q]))
                    {
                        Movements.Add(new Move(type, x, y, x - q, y + q, true));
                    }
                    break;
                }
            }


        }//getDiagonalMovements


        private void GetPawnMovements()
        {
            if (IsBlackPlayer)
            {

            }
        }

        private void GetKnightMovements()
        {

        }

        private void GetKingMovements()
        {

        }





        


    }//PotentialMovements class
}//NameSpace