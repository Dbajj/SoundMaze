using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover
{
    private GameObject front;
    private GameObject back;
    private GameObject left;
    private GameObject right;
    private Coordinate position;
    private Coordinate nextPosition;

    public Mover(GameObject front, GameObject back, GameObject left, GameObject right, Coordinate c)
    {
        this.front = front;
        this.back = back;
        this.left = left;
        this.right = right;
        this.position = c;
        nextPosition = new Coordinate(0, 0);
    }

    public bool moveForward()
    {
        nextPosition.x = position.x;
        nextPosition.z = position.z + 1;

        if(notBlocked(nextPosition))
        {
            Debug.Log("reached");
            GameObject player = GameObject.Find("Player");

            Floor destTile = MakeFloor.floorTiles[nextPosition.z][nextPosition.x];

            GameObject destTileObject = destTile.getFloorObject();

            Vector3 newPlayerPos = new Vector3(destTileObject.transform.position.x, player.transform.position.y, destTileObject.transform.position.z);

            player.transform.position = newPlayerPos;

            position = nextPosition;

            centerOnObject(player);

            return true;

        }

        return false;
    }
    public bool moveBackward()
    {
        nextPosition.x = position.x;
        nextPosition.z = position.z-1;

        if (notBlocked(nextPosition))
        {
            GameObject player = GameObject.Find("Player");

            Floor destTile = MakeFloor.floorTiles[nextPosition.z][nextPosition.x];

            GameObject destTileObject = destTile.getFloorObject();

            Vector3 newPlayerPos = new Vector3(destTileObject.transform.position.x, player.transform.position.y, destTileObject.transform.position.z);

            player.transform.position = newPlayerPos;
            position = nextPosition;
            centerOnObject(player);
            return true;

        }

        return false;
    }
    public bool moveRight()
    {
        nextPosition.x = position.x + 1;
        nextPosition.z = position.z;

        if (notBlocked(nextPosition))
        {
            GameObject player = GameObject.Find("Player");

            Floor destTile = MakeFloor.floorTiles[nextPosition.z][nextPosition.x];

            GameObject destTileObject = destTile.getFloorObject();

            Vector3 newPlayerPos = new Vector3(destTileObject.transform.position.x, player.transform.position.y, destTileObject.transform.position.z);

            player.transform.position = newPlayerPos;

            position = nextPosition;
            centerOnObject(player);
            return true;

        }

        return false;
    }
    public bool moveLeft()
    {
        nextPosition.x = position.x -1;
        nextPosition.z = position.z;

        if (notBlocked(nextPosition))
        {
            GameObject player = GameObject.Find("Player");

            Floor destTile = MakeFloor.floorTiles[nextPosition.z][nextPosition.x];

            GameObject destTileObject = destTile.getFloorObject();

            Vector3 newPlayerPos = new Vector3(destTileObject.transform.position.x, player.transform.position.y, destTileObject.transform.position.z);

            player.transform.position = newPlayerPos;

            position = nextPosition;
            centerOnObject(player);
            return true;

        }

        return false;
    }
    private bool notBlocked(Coordinate c)
    {
        Floor destTile = MakeFloor.floorTiles[c.z][c.x];

        return !destTile.checkWall();
    }

    private void centerOnObject(GameObject input)
    {
        Vector3 inputPosition = input.transform.position;
        front.transform.position = new Vector3(inputPosition.x, 0.5f, inputPosition.z + 0.5f);
        back.transform.position = new Vector3(inputPosition.x, 0.5f, inputPosition.z - 0.5f);
        right.transform.position = new Vector3(inputPosition.x+0.5f, 0.5f, inputPosition.z);
        left.transform.position = new Vector3(inputPosition.x-0.5f, 0.5f, inputPosition.z);
    }


}
