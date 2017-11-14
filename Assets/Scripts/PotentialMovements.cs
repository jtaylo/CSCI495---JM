using System.Collections;
using System.Collections.Generic;

namespace JMCapstone
{
    public class PotentialMovements
    {
        private List<Move> Movements;

        private int[,] BoardState;
        private bool IsBlackPlayer;
        private bool CanCastle;
        private bool PawnLeaped;

        public List<Move> GetPotentialMovements(int[,] boardState, bool isBlackPlayer, bool canCastle, bool pawnLeaped)
        {
            Movements = new List<Move>();
            BoardState = boardState;
            IsBlackPlayer = isBlackPlayer;
            CanCastle = canCastle;
            PawnLeaped = pawnLeaped;

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
                            GetKnightMovements(i, j);
                            break;
                        case Constants.BlackBishop:
                            GetDiagonalMovments(i, j);
                            break;
                        case Constants.BlackKing:
                            GetKingMovements(i, j);
                            break;
                        case Constants.BlackQueen:
                            GetHorizontalVerticalMovements(i, j);
                            GetDiagonalMovments(i, j);
                            break;
                        case Constants.BlackPawn:
                            GetPawnMovements(i, j);
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


        private void GetPawnMovements(int x, int y)
        {

            int type = BoardState[x, y];
            bool potentialUpgrade;

            if (IsBlackPlayer)
            {                
                if(y == 6)
                {
                    potentialUpgrade = true;
                }
                else
                {
                    potentialUpgrade = false;
                }
                                
                //check for forwards movement                
                if (BoardState[x, y + 1] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, x, y + 1, false, potentialUpgrade, false)); //if area in front of it is clear it can move forward
                    
                    // if pawn is in the starting position and the area in front of it is clear it can move 2 spaces forwards
                    if (y == 1 && BoardState[x, y + 2] == Constants.None) 
                    {
                        Movements.Add(new Move(type, x, y, x, y + 2, false, false, true));
                    }

                }

                //check for pieces to the sides of the square in front of it for it to capture
                if (x > 0)
                {
                    if (IsCapturable(type, BoardState[x + 1, y + 1]))
                    {
                        Movements.Add(new Move(type, x, y, x + 1, y + 1, true, potentialUpgrade, false));
                    }
                }
                if (x < 7)
                {
                    if (IsCapturable(type, BoardState[x - 1, y + 1]))
                    {
                        Movements.Add(new Move(type, x, y, x - 1, y + 1, true, potentialUpgrade, false));
                    }
                }
            }
            else
            {
                if (y == 1)
                {
                    potentialUpgrade = true;
                }
                else
                {
                    potentialUpgrade = false;
                }

                //check for pieces to the sides of the square in front of it for it to capture
                if (IsCapturable(type, BoardState[x + 1, y - 1]))
                {
                    Movements.Add(new Move(type, x, y, x + 1, y - 1, true, potentialUpgrade, false));
                }
                if (IsCapturable(type, BoardState[x - 1, y - 1]))
                {
                    Movements.Add(new Move(type, x, y, x - 1, y - 1, true, potentialUpgrade, false));
                }

                //check for forwards movement
                if (BoardState[x, y - 1] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, x, y - 1, false, potentialUpgrade, false)); //if area in front of it is clear it can move forward

                    // if pawn is in the starting position and the area in front of it is clear it can move 2 spaces forwards
                    if (y == 6 && BoardState[x, y - 2] == Constants.None)
                    {
                        Movements.Add(new Move(type, x, y, x, y - 2, false, false, true));                        
                    }
                }
            }
        }

        private void GetKnightMovements(int x, int y)
        {
            int type = BoardState[x, y];

            // +1x, +2y
            if(y < 6 && x != 7)
            {
                if (BoardState[x + 1, y + 2] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, x + 1, y + 2, false));
                }else if(IsCapturable(type, BoardState[x + 1, y + 2])){
                    Movements.Add(new Move(type, x, y, x + 1, y + 2, true));

                }
            }

            // +1x, -2y
            if (y > 1 && x != 7)
            {
                if (BoardState[x + 1, y - 2] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, x + 1, y - 2, false));
                }
                else if (IsCapturable(type, BoardState[x + 1, y - 2]))
                {
                    Movements.Add(new Move(type, x, y, x + 1, y - 2, true));

                }
            }

            // -1x, +2y
            if (y < 6 && x > 0)
            {
                if (BoardState[x - 1, y + 2] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, x - 1, y + 2, false));
                }
                else if (IsCapturable(type, BoardState[x - 1, y + 2]))
                {
                    Movements.Add(new Move(type, x, y, x - 1, y + 2, true));

                }
            }

            // -1x, -2y
            if (y > 1 && x > 0)
            {
                if (BoardState[x - 1, y - 2] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, x - 1, y - 2, false));
                }
                else if (IsCapturable(type, BoardState[x - 1, y - 2]))
                {
                    Movements.Add(new Move(type, x, y, x - 1, y - 2, true));

                }
            }

            // +2x, +1y
            if (y < 7 && x < 6)
            {
                if (BoardState[x + 2, y + 1] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, x + 2, y + 1, false));
                }
                else if (IsCapturable(type, BoardState[x + 2, y +1]))
                {
                    Movements.Add(new Move(type, x, y, x + 2, y + 1, true));

                }
            }

            // +2x, -1y
            if (y > 0 && x < 6)
            {
                if (BoardState[x + 2, y - 1] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, x + 2, y - 1, false));
                }
                else if (IsCapturable(type, BoardState[x + 2, y - 1]))
                {
                    Movements.Add(new Move(type, x, y, x + 2, y - 1, true));

                }
            }

            // -2x, +1y
            if (y < 7 && x > 1)
            {
                if (BoardState[x - 2, y + 1] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, x - 2, y + 1, false));
                }
                else if (IsCapturable(type, BoardState[x - 2, y + 1]))
                {
                    Movements.Add(new Move(type, x, y, x - 2, y + 1, true));

                }
            }


            // -2x, -1y
            if (y > 0 && x > 1)
            {
                if (BoardState[x - 2, y + 1] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, x - 2, y - 1, false));
                }
                else if (IsCapturable(type, BoardState[x - 2, y - 1]))
                {
                    Movements.Add(new Move(type, x, y, x - 2, y - 1, true));

                }
            }

        }

        //Needs to deal with check. doesn't now
        private void GetKingMovements(int x, int y)
        {
            int type = BoardState[x, y];
            //up
            if (y != 7)
            {
                if(BoardState[x, y + 1] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, x , y + 1, false));
                }
                else if (IsCapturable(type, BoardState[x, y + 1]))
                {
                    Movements.Add(new Move(type, x, y, x, y + 1, true));
                }

                if(x != 7)
                {
                    if (BoardState[x + 1, y + 1] == Constants.None)
                    {
                        Movements.Add(new Move(type, x, y, x + 1, y + 1, false));
                    }
                    else if (IsCapturable(type, BoardState[x + 1, y + 1]))
                    {
                        Movements.Add(new Move(type, x, y, x + 1, y + 1, true));
                    }
                }

                if(x!= 0)
                {
                    if (BoardState[x - 1, y + 1] == Constants.None)
                    {
                        Movements.Add(new Move(type, x, y, x - 1, y + 1, false));
                    }
                    else if (IsCapturable(type, BoardState[x - 1, y + 1]))
                    {
                        Movements.Add(new Move(type, x, y, x - 1, y + 1, true));
                    }
                }
            }

            if (x != 0)
            {
                if (BoardState[x - 1, y] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, x - 1, y, false));
                }
                else if (IsCapturable(type, BoardState[x - 1, y]))
                {
                    Movements.Add(new Move(type, x, y, x - 1, y, true));
                }
            }

            if (x != 7)
            {
                if (BoardState[x + 1, y] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, x + 1, y, false));
                }
                else if (IsCapturable(type, BoardState[x + 1, y]))
                {
                    Movements.Add(new Move(type, x, y, x + 1, y, true));
                }
            }

            if(y != 0)
            {
                if (BoardState[x, y - 1] == Constants.None)
                {
                    Movements.Add(new Move(type, x, y, x, y - 1, false));
                }
                else if (IsCapturable(type, BoardState[x, y - 1]))
                {
                    Movements.Add(new Move(type, x, y, x, y - 1, true));
                }


                if (x != 0)
                {
                    if (BoardState[x - 1, y - 1] == Constants.None)
                    {
                        Movements.Add(new Move(type, x, y, x - 1, y - 1, false));
                    }
                    else if (IsCapturable(type, BoardState[x - 1, y]))
                    {
                        Movements.Add(new Move(type, x, y, x - 1, y - 1, true));
                    }
                }

                if (x != 7)
                {
                    if (BoardState[x + 1, y - 1] == Constants.None)
                    {
                        Movements.Add(new Move(type, x, y, x + 1, y - 1, false));
                    }
                    else if (IsCapturable(type, BoardState[x + 1, y - 1]))
                    {
                        Movements.Add(new Move(type, x, y, x + 1, y - 1, true));
                    }
                }
            }
        }


    }//PotentialMovements class
}//NameSpace

//if(BoardState[(((i%4) >> 1)%-3) * (((i >> 2) + 1)), (((i%2)%-3)+1) * (2-(i >> 2))] C# doesn't support negative mod operations :(