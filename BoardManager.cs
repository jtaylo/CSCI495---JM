
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class BoardManager : MonoBehaviour {

	private const float TILE_SIZE = 1.0f;
	private const float TILE_OFFSET = 0.5f;

	private int selectionX = -1;// minus 1 when no pieces are selected
	private int selectionY = -1;

    public List<GameObject> pieces;
	private List<GameObject> activePieces = new List<GameObject>();

	//create property to dertermine if chess pieces is avaliable take in two parameters
	public MasterChess [,] chess{set;get;}
	private MasterChess selectedPiece; //chess piece that is currently seelcted

   

	private Quaternion view = Quaternion.Euler(0, 180, 0);//Returns a rotation that rotates 
	//z degrees around the z axis, x degrees around the x axis, and y degrees around 
	//the y axis (in that order).

    // Use this for initialization
    void Start () {

		setUpBoard ();
		createAllPieces ();





    }
	
	// Update is called once per frame
	void Update () {
		

		//refreshSelected ();
		createBoard();
		//controller for VR needs to be in place of mouse functions
		if (Input.GetMouseButtonDown (0)) {	//Must create 2 methods to perform selection and movement
		
			if (selectionX >= 0 && selectionY >= 0) {

				if (selectedPiece == null) {
					//select the chess piece
					bottomBae(selectionX, selectionY); // use those two selections because a "X Y" is 
					//not avaliable
				} else {
					//move chess piece
					byeBae(selectionX, selectionY);
				}
			}
		}
		
		
	}
	private void bottomBae(int x, int y)// selects the chess piece 
	{
		if (chess == null)
			return;
		selectedPiece = chess [x, y];
	}

	private void byeBae(int x, int y)// moves the chess piece 
	{
		chess [selectedPiece.CurrentX, selectedPiece.CurrentY] = null; //must be set to null since the 
		//chess piece is about to move 
		//migth have to add a transform.position - confused right here 
		//selectedPiece.transform.position = getCenter(x,y);------------*******confused right here too********
		chess[x,y] = selectedPiece;

		selectedPiece = null;// if incorrect move ?
	}


	private void refreshSelected()
	{
		//check main camera 
		if(!Camera.main)
			return;
		//Casts a ray, from point origin, in direction direction, 
		//of length maxDistance, against all colliders in the scene.
		RaycastHit hit;
		if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 35.0f, LayerMask.GetMask("Board")))	//possible issue here for selection	
		{
			
				//Debug.log(hit.point); 
				selectionX = (int)hit.point.x;
				//shows where the collision happens	
				selectionY = (int)hit.point.z;
		}
			else
			{
		
				selectionX = -1;//reset back if nothing is selected
				selectionY = -1;
			}

	}

	private void createBoard()
	{
		Vector3 xLine = Vector3.right * 8;
		Vector3 yLine = Vector3.forward * 8;
		for(int i= 0; i <=8; i ++)
		{
			Vector3 start = Vector3.forward * i;
			Debug.DrawLine (start, start + xLine);
			for(int j = 0; j <= 8; j++)
			{
				start = Vector3.right * j;
				Debug.DrawLine (start, start + yLine);

			}

		}
		//time to draw some lines
		int selectX = -1;
		int selectY = -1;


		if (selectX >= 0 && selectY >= 0) {
		
					
			Debug.DrawLine(
				Vector3.forward * selectY + Vector3.right * selectX, 
				Vector3.forward * (selectY +1) + Vector3.right * (selectX + 1));
		}


	}


    private void SpawnPiece(int x, int y, int index)
    {
        Vector3 incPos = BoardPosition.getPosition(x, y);

       Vector3 pos = new Vector3(incPos.x, 6, incPos.y);

		//cast it as a game object
		//The Transform component determines the Position, Rotation, and Scale 
		//of each object in the scene. Every GameObject has a Transform.


		GameObject newPiece = Instantiate (pieces [index], pos, view) as GameObject;
		newPiece.transform.SetParent (transform); 
		chess [x, y] = newPiece.GetComponent<MasterChess> ();
		chess [x, y].setPosition (x, y);//locking the pieces to always be casted intot he array by calling 
		activePieces.Add (newPiece);
    }
	//private Vector3 getCenter(int x, int y)*****if any issues arise with chess piece placement to adjust add this ***

	//	Vector3 placement = Vector3.zero;
	//	placement.x += (TILE_SIZE * x) + TILE_OFFSET;
	//	placement.z += (TILE_SIZE * y) + TILE_OFFSET;
	//	return placement;
	//}

    private void setUpBoard()
    {
       // SpawnPiece(0, 0, 0);
        

        for(int i = 0; i < 8; i++)
        {
           //SpawnPiece(i, 1, BlackPawn);
            //SpawnPiece(i, 0, defaultPosition[i]);

            //SpawnPiece(i, 6, WhitePawn);
            //SpawnPiece(i, 7, defaultPosition[i] + 6);


        }

    }
	public void createAllPieces (){
		
		// this function is only gonna get called at the beginning of the game
		activePieces = new List<GameObject> ();
		chess = new MasterChess[8, 8]; //initializing "chess" variable 
		
	//start with the white pieces
	//create pieces
		//King index 9
		SpawnPiece(3,7,9);

		//queen index 10
		SpawnPiece(4,7,10);

		//rooks don't forget 2 for each team - index 6
		SpawnPiece(0,7,6);
		SpawnPiece(7,7,6);

		//bishop index 8
		SpawnPiece(2,7,8);
		SpawnPiece(5,7,8);
	

		//Knight index 7
		SpawnPiece(1,7,7);
		SpawnPiece(6,7,7);

		//pawn index 11
		for(int i=0; i<8; i++){
			SpawnPiece(i,6,11);
		}


		//create the black pieces
		//King index 3
		SpawnPiece(4,0,3);
		//queen index 4
		SpawnPiece(3,0,4);
		//rooks index 0
		SpawnPiece(0, 0, 0);
		SpawnPiece(7, 0, 0);
		//bishop index 2
		SpawnPiece(2,0,2);
		SpawnPiece(5,0,2);
		//knight index 1
		SpawnPiece(1,0,1);
		SpawnPiece(6,0,1);
		//pawn index 5
		for(int i=0; i<8; i++){
			SpawnPiece(i,1,5);
		}

	


		 
		//White King using x, y, ??
	//SpawnPiece(index,int x,int y);  //this is only an example how that paramerters will be the only thing that identiying chess pieces 	
	//Do this for all the chess pieces on the board

//}
		
	;}
}
