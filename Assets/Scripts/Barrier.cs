using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class Barrier : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material.color = Color.yellow;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    private void Update()
    {
        int numberOfPoints = transform.childCount;

        if (numberOfPoints >= 2)
        {
            Vector3 startingPosition = transform.GetChild(0).position;
            Vector3 targetPosition = transform.GetChild(numberOfPoints - 1).position;

            lineRenderer.SetPosition(0, startingPosition);
            lineRenderer.SetPosition(1, targetPosition);
        }
    }
}
