using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer _lineRenderer;

    //example list, should probably be made private in the future if passing in vectors from a function
    public Vector3[] _lineVectors;

    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();

        //for each lineVector set the position on the lineRenderer object, displays on game runtime
        _lineRenderer.positionCount = _lineVectors.Length;
        for (int i = 0; i < _lineVectors.Length; i++) {
            _lineRenderer.SetPosition(i, _lineVectors[i]);
        }
    }
}
