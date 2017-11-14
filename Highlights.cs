using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlights : MonoBehaviour {

	public static Highlights Instance{ set; get; }

	public GameObject createdHighlight;
	private List<GameObject> highlight; //list for all the highlights present on the board.

	// Use this for initialization
	private void Start () 
	{
		Instance = this;
		highlight = new List<GameObject> (); //instantiate 

	}

	private GameObject GetLight()
	{
								// find and return the first object that matches the condition !g.activeSelf
		GameObject go = highlight.Find (g => !g.activeSelf);
		//This returns the local active state of this GameObject, 
		//which is set using GameObject.SetActive. Note that a GameObject 
		//may be inactive because a parent is not active, even if this returns true. 
		//This state will then be used once all parents are active. 
		//Use GameObject.activeInHierarchy if you want to check if the GameObject 
		//is actually treated as active in the scene.
		if (go == null) 
		{
			go = Instantiate (createdHighlight);
			//clones and sends a copy back if one isn't present 
			highlight.Add(go);
		}
		return go;

	}
	public void highlightMove(bool[,] moves)//unsure parameters
	{
		for(int i = 0; i < 8 ; i++)
		{
			for(int j = 0; j<8 ;j++)
			{
				GameObject go = GetLight ();
				go.SetActive(true);
				go.transform.position = new Vector3(i,0,j);

			}
		}
	}
	public void lightsOff()
	{
		foreach (GameObject go in highlight)
			go.SetActive (false);
		}



}
