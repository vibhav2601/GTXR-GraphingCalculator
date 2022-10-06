using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorRenderer : MonoBehaviour
{
    public Vector3 vector;
    private Vector3 rotation = new Vector3(90, 0, 0);
    private GameObject cylinder;

    // Start is called before the first frame update
    void Start()
    {
        cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.transform.SetParent(transform);

        var ts = cylinder.transform;

        ts.localScale = new Vector3(0.05f, 10.0f, 0.05f);

        var scale = ts.localScale;
        scale.y = vector.magnitude;

        var pos = vector;
        pos.x /= 2.0f;
        pos.y /= 2.0f;
        pos.z /= 2.0f;
        ts.localPosition = pos;

        ts.localScale = scale;

        ts.localPosition = vector;

        ts.LookAt(vector + ts.position);
        ts.Rotate(rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
