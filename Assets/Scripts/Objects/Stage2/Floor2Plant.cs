using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Floor2Plant : MonoBehaviour
{
    [SerializeField] private GameObject plantObject;

    private void Awake()
    {
        if (plantObject == null)
            Debug.Log("���ӿ�����Ʈ�� ã�� ���߽��ϴ�.");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<PlayerController>(out var pt) && pt.playerType == PlayerType.Soil)
        {
            int plantCount = GameObject.FindGameObjectsWithTag("Plant").Length;

            if (plantCount >= 3)
                return;
           
            SpawnPlant();
        }
    }

    private void SpawnPlant()
    {
        //��� �� �� ������ ������ ����
        for (int i = 0; i < 3; i++)
        {
            Vector3 flantPosition = plantObject.transform.position + Vector3.right * (i * 0.5f);
            Instantiate(plantObject, flantPosition, Quaternion.identity);
        }
    }
}
