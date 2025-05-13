using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        transform.localScale += player.transform.localScale;
    }

    protected void ChangeLaserLength()
    {
        //�÷��̾� ��ġ��ŭ �پ���
        Vector3 currentScale = transform.localScale;
        currentScale -= player.transform.localScale;
        transform.localScale = currentScale;
    }
}
