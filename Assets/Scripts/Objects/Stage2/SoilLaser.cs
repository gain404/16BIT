using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilLaser : Laser
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<PlayerController>(out var pt))
        {
            if (pt.playerType == PlayerType.Thunder)
            {
                GameManager.instance.GameOver();
            }
            else if (pt.playerType == PlayerType.Soil)
            {
                ChangeLaserLength();
            }
        }
    }
}
