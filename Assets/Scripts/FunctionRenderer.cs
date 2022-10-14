using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionRenderer : MonoBehaviour
{
    /**
     * Plane specific fields
     */
    [SerializeField]
    private Vector3 planePosition;
    [SerializeField]
    private Vector3 planeNormal = new Vector3(1.0f, 1.0f, 1.0f);

    [SerializeField]
    private float span;
    [SerializeField]
    private GameObject point;

    // Start is called before the first frame update
    void Start()
    {
        DrawPlane();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DrawPlane()
    {
        for (float x = -span; x <= span; x += 0.1f)
        {
            for (float y = -span; y <= span; y += 0.1f)
            {
                // Apply equation of a plain, using z as dependent variable
                float z = (1.0f / planeNormal.z) * ((planeNormal.x * planePosition.x + planeNormal.y * planePosition.y + planeNormal.z * planePosition.z) - planeNormal.x * x - planeNormal.y * y);

                // Instantiate point prefab and sets its position to calculated <x, y, z>
                GameObject currPoint = Instantiate(point);
                currPoint.transform.position = new Vector3(x, y, z);
            }
        }
    }
}
