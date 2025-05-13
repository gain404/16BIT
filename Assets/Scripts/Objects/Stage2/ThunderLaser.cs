using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class ThunderLaser : Laser
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<PlayerController>(out var pt))
        {
            if (pt.playerType == PlayerType.Soil)
            {
                GameManager.instance.GameOver();
            }
            else if (pt.playerType == PlayerType.Thunder)
            {
                ChangeLaserLength();
            }
        }
    }
}
