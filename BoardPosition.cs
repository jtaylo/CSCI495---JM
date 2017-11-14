using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPosition : MonoBehaviour {


    public static Vector3 getPosition(int x, int z)
    {
        float xPosition = 0;

        if (x > 3)
        {
            x = x - 4;

            xPosition = (x * -9) - 4.5f;

        }
        else
        {
            x = 3 - x;
            xPosition = (x * 9) + 4.5f;
        }

        float zPosition = 0;

        if (z > 3)
        {
            z = z - 4;

            zPosition = (z * -9) - 4.5f;

        }
        else
        {
            z = 3 - z;
            zPosition = (z * 9) + 4.5f;
        }


        return new Vector2(xPosition, zPosition);

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
