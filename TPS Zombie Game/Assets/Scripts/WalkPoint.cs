using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkPoint : MonoBehaviour
{
    [Header("WalkPoint Status")]
    public WalkPoint previousWalkPoint;
    public WalkPoint nextWalkPoint;

    [Range(0f, 5f)]
    public float walkpointWidth = 1f;

    public Vector3 GetPosition()
    {
        Vector3 minBound = transform.position + transform.right * walkpointWidth / 2f;
        Vector3 maxBound = transform.position - transform.right * walkpointWidth / 2f;

        return Vector3.Lerp(minBound, maxBound, Random.Range(0f, 1f));
    }
}
