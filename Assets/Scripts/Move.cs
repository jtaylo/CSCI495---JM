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
        public bool IsPawnLeap;
        //public bool isCastle;

        //dealwithPawns
        public Move(int pieceType, int currentX, int currentY, int newX, int newY, bool isCapture, bool isUpgrade, bool isPawnLeap)
        {
            PieceType = pieceType;
            CurrentX = currentX;
            CurrentY = currentY;
            NewX = newX;
            NewY = newY;
            IsCapture = isCapture;
            IsUpgrade = isUpgrade;
            IsPawnLeap = isPawnLeap;
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
            IsPawnLeap = false;
        }

        public Move(int pieceType, int currentX, int currentY, int newX, int newY)
        {
            PieceType = pieceType;
            CurrentX = currentX;
            CurrentY = currentY;
            NewX = newX;
            NewY = newY;
            IsCapture = false;
            IsUpgrade = false;
            IsPawnLeap = false;
        }
    }
}