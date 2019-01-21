using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class growArms : MonoBehaviour {

    public GameObject anArm;
   
	// Use this for initialization
	void Start () {
        anArm =  GameObject.Find("Cube");
        LinkedList<GameObject> newArms = new LinkedList<GameObject>();
        GameObject newArm;
        for(int i = 0; i < 5; i++) { 
         newArm = (GameObject)Instantiate(anArm, transform.position, Quaternion.Euler((float)0.0, Random.Range((float)0.0, (float)360.0), (float)0.0));
            newArms.AddFirst(newArm);
             }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

