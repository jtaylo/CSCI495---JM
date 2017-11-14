using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is parent class of all chess pieces below 
// for the VR project in IS Capstone

public abstract class MasterChess : MonoBehaviour 
{
	public int CurrentX{ set; get;}
	public int CurrentY{ set; get;}
	public bool isWhite;

	public void setPosition(int x, int y)// this is gonna set up each pieces to assigned location within board
	{
		CurrentX = x;
		CurrentY = y;
	}
	public virtual bool possibleMoves(int x, int y)
	{
		//this will double check if the move is avaliable

	return true;
	}

}
