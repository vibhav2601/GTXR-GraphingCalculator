using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Written by Ilkin Mammadli, Jack English, Moses Lim, and Hai Dao

- Parameters: vector coordinates and diameter of vector cylinder.
- If script is placed on a new empty object, make sure you drag the "VectorCylinder" prefab into the Cylinder parameter.
- You can replace the Cylinder parameter GameObject, as long as the y scale of the object is 1.
- Vector is tied to the Graph Origin transform and the coordinate positions update live. 
*/

public class VectorRenderer : MonoBehaviour
{
    // Create variables for vector, cylinder, and diameter.
    [SerializeField] private Vector3 vector;
    [SerializeField] private GameObject cylinder;
    [SerializeField] private float diameter = 0.05f;
    //Rotated 90 degrees on x axis because for some reason that makes the rotation correct. 
    private Vector3 rotation = new Vector3(90, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        // Instantiates cylinder game object
        cylinder = Instantiate(cylinder, transform.position, Quaternion.identity);
        cylinder.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        var ts = cylinder.transform;

        // Sets the position to the midpoint of the origin and the vector coordinate.
        var pos = vector;
        pos.x /= 2.0f;
        pos.y /= 2.0f;
        pos.z /= 2.0f;
        ts.localPosition = pos;

        // Sets diameter and the length of the cylinder to the vector magnitude.
        ts.localScale = new Vector3(diameter, vector.magnitude, diameter);

        // Looks at the Vector in relation to the cylinde perpendicularly 
        ts.LookAt(vector + ts.position);
        // Rotates it 90 degrees to make it parallel 
        ts.Rotate(rotation);
    }
}
