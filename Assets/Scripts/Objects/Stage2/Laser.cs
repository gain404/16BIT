using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [Header("레이저 설정")]
    [SerializeField] protected float maxDistance = 2f;
    [SerializeField] protected LayerMask mask;

    protected LineRenderer lineRenderer;
    protected Vector3 origin;
    protected Vector3 dir;
    protected Vector3 endPos;


    protected void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
    }

    protected void DrawLaser()
    {
        origin = transform.position;
        dir = Vector3.down;
        endPos = origin + dir * maxDistance;

        lineRenderer.SetPosition(0, origin);
        lineRenderer.SetPosition(1, endPos);
    }
}
