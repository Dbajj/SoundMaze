using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor {
    private bool isWall;
    private GameObject floorObject;

    public Floor(GameObject floorObject)
    {
        this.isWall = false;
        this.floorObject = floorObject;
    }

    public GameObject getFloorObject()
    {
        return floorObject;
    }

    public bool checkWall()
    {
        return isWall;
    }

}
