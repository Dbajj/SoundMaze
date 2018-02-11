using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeFloor : MonoBehaviour {

    public GameObject floor;
    public GameObject wall;
    private GameObject currentFloor;
    public Material mMaterial;

    public static List<List<Floor>> floorTiles = new List<List<Floor>>();
    public static Mover controller;

	// Use this for initialization
	void Start () {

        List<List<int>> mazeData = MazeData.Mazeref();

		for(int i = 0; i < 25; i = i+1)
        {
            List<Floor> row = new List<Floor>();
            floorTiles.Add(row);
            for(int j = 0; j < 25; j = j+1)
            {
                currentFloor = Instantiate(floor, new Vector3(j, 0, i), Quaternion.identity);

                Floor floorObject = new Floor(currentFloor);

                row.Add(floorObject);
                mMaterial = currentFloor.GetComponent<Renderer>().material;


                
                if (mazeData[j][mazeData.Count-i-1] == 1)
                {
                    mMaterial.color = Color.blue;
                    floorObject.setWall(true);
                }
                else
                {
                    mMaterial.color = Color.white;
                }

            }
        }

        Vector3 wallPositionCenter = gameObject.transform.position;

        GameObject frontWall = Instantiate(wall, new Vector3(wallPositionCenter.x, wallPositionCenter.y, wallPositionCenter.z+0.5f), Quaternion.identity);
        GameObject backWall = Instantiate(wall, new Vector3(wallPositionCenter.x, wallPositionCenter.y, wallPositionCenter.z - 0.5f), Quaternion.identity);
        GameObject leftWall = Instantiate(wall, new Vector3(wallPositionCenter.x - 0.5f, wallPositionCenter.y, wallPositionCenter.z), Quaternion.identity);
        GameObject rightWall = Instantiate(wall, new Vector3(wallPositionCenter.x + 0.5f, wallPositionCenter.y, wallPositionCenter.z), Quaternion.identity);

        frontWall.name = "Front";
        backWall.name = "Back";
        leftWall.name = "Left";
        rightWall.name = "Right";

        frontWall.GetComponent<Renderer>().material.color = Color.red;

        Coordinate c = new Coordinate(1,1);

        controller = new Mover(frontWall, backWall, leftWall, rightWall,c);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

