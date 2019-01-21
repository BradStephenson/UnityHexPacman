using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinates : MonoBehaviour {

    private int[,] map;
	// Use this for initialization
	void Start () {

        int[,] map = new int[,]{ { 1, 1, 1, 0, 0},{ 1, 1, 1, 1, 0},{ 1, 1, 1, 1, 1},{ 0, 1, 1, 1, 1},{ 0, 0, 1, 1, 1} };

        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 5; j++)
                Debug.Log(""+InHex(5,i,j));
            Debug.Log("\n");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private bool InHex(int size,int x, int y)    {
        if (y < size)//upper
        {
            if (x < size + y)
                return true;
        }
        else//lower
        {

        }
        return false;
    }
}
