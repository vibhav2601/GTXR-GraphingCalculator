using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRenderer : MonoBehaviour
{
    [SerializeField]
    private Vector3 position;
    [SerializeField] 
    private Vector3 normal;
    [SerializeField]
    private GameObject plane;

    // Start is called before the first frame update
    void Start()
    {
        plane = Instantiate(plane);
        plane.transform.SetParent(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        var ts = plane.transform;

        ts.position = position;

        Debug.Log("Frw: " + ts.forward);

        ts.LookAt(normal);

        Debug.Log("Frw: " + ts.forward);

        //ts.Rotate(new Vector3(90.0f, 0.0f, 0.0f));
    }
}
