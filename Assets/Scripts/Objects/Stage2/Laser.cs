using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public enum LaserType
{
    Yellow,
    Brown
}

public class Laser : MonoBehaviour
{
    [SerializeField] private Vector3 startPos; //�ν����� â���� ��ġ ����
    [SerializeField] private Vector3 endPos;
    [SerializeField] private Vector3 direction; 

    [SerializeField] private float distance = 2f;

    private LayerMask mask; //���̾�� �÷��̾� �±׸� �޾ƾ� ��
    private LineRenderer lineRenderer;

    private void Awake()
    {
        mask = LayerMask.GetMask("Player");
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        SpawnLaser();
    }

    private void SpawnLaser()
    {
        Vector3 direction = (endPos - startPos).normalized;
        RaycastHit2D hit =  Physics2D.Raycast(startPos, direction, distance, mask);

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }
}
