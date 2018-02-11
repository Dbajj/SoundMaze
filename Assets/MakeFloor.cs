using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MakeFloor : MonoBehaviour {

	public GameObject floor;
	public GameObject wall;
	private GameObject currentFloor;
	public Material mMaterial;

	public static List<List<Floor>> floorTiles = new List<List<Floor>>();
	public static Mover controller;

	Byte[,] maze;

	// Use this for initialization
	void Start () {
		int n = 25;

		maze = new Maze(n, n).BuildMap();

		for(int i = 0; i < n; i = i+1)
		{
			List<Floor> row = new List<Floor>();
			floorTiles.Add(row);
			for(int j = 0; j < n; j = j+1)
			{
				currentFloor = Instantiate(floor, new Vector3(j, 0, i), Quaternion.identity);

				Floor floorObject = new Floor(currentFloor);

				row.Add(floorObject);
				mMaterial = currentFloor.GetComponent<Renderer>().material;

				if ((maze[j, i]!= 0))
				{
					mMaterial.color = Color.blue;
					floorObject.setWall(true);
					for(int k = 1; k < 5; k++)
					{
						Instantiate(floor, new Vector3(j, k, i), Quaternion.identity);
					}
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