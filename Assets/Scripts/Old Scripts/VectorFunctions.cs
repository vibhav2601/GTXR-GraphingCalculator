using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VectorFunctions : MonoBehaviour
{
    public float VectA_x;
    public float VectA_y;
    public float VectA_z;
    public float VectB_x;
    public float VectB_y;
    public float VectB_z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        Debug.DrawLine(Vector3.zero, new Vector3(VectA_x, VectA_y, VectA_z), Color.red, 10.0f);
        Debug.DrawLine(Vector3.zero, new Vector3(VectB_x, VectB_y, VectB_z), Color.blue, 10.0f);
       if (Input.GetKeyDown(KeyCode.A))
       {
            
            Vector3 Added= new Vector3(VectA_x+VectB_x, VectA_y+VectB_y, VectA_z+VectB_z);
            Debug.DrawLine(Vector3.zero, Added, Color.black, 100.0f);
            Debug.Log(Added.magnitude);
       }
       if (Input.GetKeyDown(KeyCode.S))
       {
            
            Vector3 Subtracted= new Vector3(VectB_x-VectA_x, VectB_y-VectA_y, VectB_z-VectA_z);
            Debug.DrawLine(Vector3.zero, Subtracted, Color.yellow, 100.0f);
            Debug.Log(Subtracted.magnitude);
       }
        if (Input.GetKeyDown(KeyCode.M))
       {
            Vector3 Multiply= new Vector3(VectA_y * VectB_z - VectA_z * VectB_y, VectA_z * VectB_x - VectA_x * VectB_z, VectA_x * VectB_y - VectA_y * VectB_x);
            Debug.DrawLine(Vector3.zero, Multiply, Color.green, 100.0f);
            Debug.Log(Multiply.magnitude);
       }
    }
}