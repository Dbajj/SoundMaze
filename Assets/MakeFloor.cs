using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeFloor : MonoBehaviour {

    public GameObject floor;
    private GameObject currentFloor;
    public Material mMaterial;

    static ArrayList floorTiles = new ArrayList();

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 24; i = i+1)
        {
            for(int j = 0; j < 24; j = j+1)
            {
                currentFloor = Instantiate(floor, new Vector3(i, 0, j), Quaternion.identity);

                mMaterial = currentFloor.GetComponent<Renderer>().material;

                floorTiles.Add(currentFloor);

                Debug.Log(floorTiles.Count);


                if ((j+i) % 2 == 0)
                {
                    mMaterial.color = Color.blue;
                }
                else
                {
                    mMaterial.color = Color.white;
                }

            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
