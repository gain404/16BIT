using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class ThunderLaser : Laser
{
    private void Update()
    {
        DrawLaser();
        CheckHit();
    }

    private void CheckHit()
    {
        Vector2 origin = transform.position;
        Vector2 dir = Vector2.down;

        RaycastHit2D hit = Physics2D.Raycast(origin, dir, maxDistance, mask);
        if (hit.collider != null)
        {
            Vector3 hitPoint = hit.point;
            lineRenderer.SetPosition(1, hitPoint);

            if (hit.collider.TryGetComponent<PlayerController>(out var pt)
                && pt.playerType == PlayerType.Soil)
            {
                GameManager.instance.GameOver();
            }
        }
    }
}
