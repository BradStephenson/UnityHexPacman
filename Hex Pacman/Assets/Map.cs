using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public MapNode[,] gridMap;
    public GameObject aWall;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Thing started");

        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Brad\Documents\GitHub\UnityHexPacman\Hex Pacman\Assets\mapfile.txt");
        int xSize, ySize;
        string[] lineOneItems = lines[0].Split(' ');
        xSize = Convert.ToInt32(lineOneItems[0]);
        ySize = Convert.ToInt32(lineOneItems[1]);
        gridMap = new MapNode[xSize,ySize];

        //aWall = GameObject.Find("trapezoid02");
        //LinkedList<GameObject> newArms = new LinkedList<GameObject>();

        int iX, iY;
        string[] row;
        for (iY = 0; iY < ySize; iY++)
        {
           // row = lines[iY+1].Split(" ");
            for (iX = 0; iX < xSize; iX++)
            {
                gridMap[iX, iY] = new MapNode(iX,iY,gridMap,this);
            }
        }

        //int iX, iY;
        //string[] row;
        for (iY = 0; iY < ySize; iY++)
        {
            row = lines[iY + 1].Split(' ');
            for (iX = 0; iX < xSize; iX++)
            {
                gridMap[iX, iY].setNeighbors(row[iX]); //new MapNode(iX, iY, gridMap);
            }
        }

        for (iY = 0; iY < ySize; iY++)
        {
           // row = lines[iY + 1].Split(" ");
            for (iX = 0; iX < xSize; iX++)
            {
                gridMap[iX, iY].printBarriers(); //new MapNode(iX, iY, gridMap);
            }
        }
    }
    public void createWall(double posX, double posY, int whichWall)
    {
        Instantiate(aWall, new Vector3((float)posX, 0.0f, (float)posY), Quaternion.AngleAxis((30 + 60 * whichWall), Vector3.up));
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

public class basicCreateMapStrategy : createMapStrategy
{
   // public Map createMap(File input)

}

public interface createMapStrategy
{
    // Map createMap(File input);
}

public class MapNode
{
    public MapNode[] neighbors;//0:E, 1:NE, 2:NW, 3:W, 4:SW, 5:SE
    public int[] coord;
    public double[] realCoord;
    private MapNode[,] gridMapLocal;
    
    public Map map;

    public MapNode(int x,int y,MapNode[,] gridMapPoint, Map m)
    {
        gridMapLocal = gridMapPoint;
        neighbors = new MapNode[6];
        coord = new int[2];
        coord[0] = x;
        coord[1] = y;
        realCoord = new double[2];
        realCoord[0] = 2 * Math.Cos(Math.PI/3) * (coord[0] + 2* coord[1]) + 2 * coord[0];
        realCoord[1] = 4 * Math.Sin(Math.PI / 3) * coord[1];
        map = m;
    }

    public void setNeighbors(string data)
    {
        //string second = data.Split(":")[1];
        //second[3];
        if (data[0 + 2] == 1)
            neighbors[0] = gridMapLocal[(coord[0] + 1), (coord[1] + 0)];
        if (data[1 + 2] == 1)
            neighbors[1] = gridMapLocal[(coord[0] + 1), (coord[1] - 1)];
        if (data[2 + 2] == 1)
            neighbors[2] = gridMapLocal[(coord[0] + 0), (coord[1] - 1)];
        if (data[3 + 2] == 1)
            neighbors[3] = gridMapLocal[(coord[0] - 1), (coord[1] + 0)];
        if (data[4 + 2] == 1)
            neighbors[4] = gridMapLocal[(coord[0] - 1), (coord[1] + 1)];
        if (data[5 + 2] == 1)
            neighbors[5] = gridMapLocal[(coord[0] + 0), (coord[1] + 1)];
    }

    
    public void printBarriers()
    {
        
     //   GameObject newArm;
     /*   for (int i = 0; i < 5; i++)
        {
            newArm = createWall();
            newArms.AddFirst(newArm);
        }*/

        if (neighbors[0] ==null && neighbors[1] == null)
        {
            map.createWall(realCoord[0], realCoord[1], 0);
        }
        /*if (neighbors[1] == null && neighbors[2] == null)
        {
            map.createWall(realCoord[0], realCoord[1], 1);
        }
        if (neighbors[2] == null && neighbors[3] == null)
        {
            map.createWall(realCoord[0], realCoord[1], 2);
        }*/
        if (neighbors[3] == null && neighbors[4] == null)
        {
            map.createWall(realCoord[0], realCoord[1], 3);
        }
        /*if (neighbors[4] == null && neighbors[5] == null)
        {
            map.createWall(realCoord[0], realCoord[1], 4);
        }
        if (neighbors[5] == null && neighbors[0] == null)
        {
            map.createWall(realCoord[0], realCoord[1], 5);
        }*/
    }

    
}