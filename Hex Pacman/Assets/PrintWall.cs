using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintWall : MonoBehaviour
{
    public GameObject aWall;
 //   public sumdum s;
    // Start is called before the first frame update
    void Start()
    {
        aWall = GameObject.Find("trapezoid02");
        LinkedList<GameObject> newArms = new LinkedList<GameObject>();
        GameObject newArm;
        for (int i = 0; i < 5; i++)
        {
            newArm = createWall();
            newArms.AddFirst(newArm);
        }

        // Sumdum s = aWall.GetComponent("Sumdum");//typeof(sumdum));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject createWall()
    {
        return (GameObject)Instantiate(aWall, transform.position, Quaternion.Euler((float)0.0, Random.Range((float)0.0, (float)360.0), (float)0.0));
    }
}
