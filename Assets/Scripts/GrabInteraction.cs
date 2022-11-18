using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabInteraction : MonoBehaviour
{
    private GameObject collidedVector = null;
    private GameObject collidedTip = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collidedVector != null && collidedVector.transform.parent.gameObject.GetComponent<VectorController>().grabbingFlag)
        {
            Vector3 handPosition = transform.position;
            Vector3 tipPosition = collidedTip.transform.position;
            collidedVector.GetComponent<VectorRenderer>().vector += handPosition - tipPosition;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        collidedVector = collision.gameObject.transform.parent.gameObject;
        collidedTip = collision.gameObject;

        // collision.gameObject.transform.parent.parent.gameObject.GetComponent<VectorRenderer>().vector = transform.position;
    }

    private void OnCollisionExit(Collision other)
    {
        collidedVector = null;
        collidedTip = null;
    }
}
