using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


/**
 * Written by Ilkin Mammadli, Jack English, Eddie Valverde
 *  
 * - Controller script that has functionality to create, modify, and do operations with the VectorRenderer
 * - Contains Vector Buffer of objects with VectorRenderer script, allowing for control and modification of already created vectors
 */

public class VectorController : MonoBehaviour
{
    private List<GameObject> m_VectorBuffer;

    public InputActionReference toggleReference = null;

    // Start is called before the first frame update
    void Start()
    {
        m_VectorBuffer = new List<GameObject>();
        toggleReference.action.started += Trigger;
        SpawnVector(Vector3.one, Color.yellow);
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     SpawnVector();
        // }

        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     SpawnVector();
        //     m_VectorBuffer[m_VectorBuffer.Count - 1].GetComponent<VectorRenderer>().vector = GetVector(0) + GetVector(1);
        // }
        // if (Input.GetKeyDown(KeyCode.S))
        // {
        //     SpawnVector();
        //     m_VectorBuffer[m_VectorBuffer.Count - 1].GetComponent<VectorRenderer>().vector = GetVector(0) - GetVector(1);
        // }
        // if (Input.GetKeyDown(KeyCode.C))
        // {
        //     SpawnVector();
        //     Vector3 a = GetVector(0);
        //     Vector3 b = GetVector(1);
        //     Vector3 cross = Vector3.zero;
        //     cross.x = a.y * b.z - a.z * b.y;
        //     cross.y = a.z * b.x - a.x * b.z;
        //     cross.z = a.x * b.y - a.y * b.x;
        //     m_VectorBuffer[m_VectorBuffer.Count - 1].GetComponent<VectorRenderer>().vector = cross;
        // }
    }

    void OnDestroy() 
    {
        toggleReference.action.started -= Trigger;
    }

    private Vector3 GetVector(int index)
    {
        return m_VectorBuffer[index].GetComponent<VectorRenderer>().vector;
    }

    // When left trigger is pressed (defined in the script inspector), a default vector is spawned
    private void Trigger(InputAction.CallbackContext context) 
    {
        SpawnVector(new Vector3(1, 2, 3), Color.magenta);
    }

    public void ChangeColor(int vectorIndex, Color color)
    {
        var material = m_VectorBuffer[vectorIndex].GetComponent<VectorRenderer>().GetMaterial();
        material.SetColor("_EmissionColor", color);
        material.SetColor("_BaseColor", color);
        m_VectorBuffer[vectorIndex].GetComponent<VectorRenderer>().SetMaterial(material);
    }

    public void SpawnVector(Vector3 vector, Color color)
    {
        GameObject vectorCylinder = Resources.Load("VectorCylinder") as GameObject;
        GameObject instance = new GameObject($"Vector{m_VectorBuffer.Count}");
        instance.AddComponent<VectorRenderer>();
        instance.transform.parent = transform;
        instance.transform.localScale = Vector3.one;
        instance.transform.localPosition = Vector3.zero;
        instance.SetActive(true);
        instance.GetComponent<VectorRenderer>().vector = vector;

        m_VectorBuffer.Add(instance);
        ChangeColor(m_VectorBuffer.Count - 1, color);
    }
}
