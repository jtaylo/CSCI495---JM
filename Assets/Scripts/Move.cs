using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JMCapstone
{
    public class Move
    {

        public int PieceType;
        public int CurrentX;
        public int CurrentY;
        public int NewX;
        public int NewY;
        public bool IsCapture;
        public bool IsUpgrade;
        //public bool isCastle;

        public Move(int pieceType, int currentX, int currentY, int newX, int newY, bool isCapture, bool isUpgrade)
        {
            PieceType = pieceType;
            CurrentX = currentX;
            CurrentY = currentY;
            NewX = newX;
            NewY = newY;
            IsCapture = isCapture;
            IsUpgrade = isUpgrade;
        }

        public Move(int pieceType, int currentX, int currentY, int newX, int newY, bool isCapture)
        {
            PieceType = pieceType;
            CurrentX = currentX;
            CurrentY = currentY;
            NewX = newX;
            NewY = newY;
            IsCapture = isCapture;
            IsUpgrade = false;
        }

        public Move(int pieceType, int currentX, int currentY, int newX, int newY)
        {
            PieceType = pieceType;
            CurrentX = currentX;
            CurrentY = currentY;
            NewX = newX;
            NewY = newY;
            IsCapture = false;
        }


    }
}