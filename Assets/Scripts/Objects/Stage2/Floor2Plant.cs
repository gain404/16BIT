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
            Debug.Log("게임오브젝트를 찾지 못했습니다.");
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
        //블록 세 개 옆으로 줄줄이 스폰
        for (int i = 0; i < 3; i++)
        {
            Vector3 flantPosition = plantObject.transform.position + Vector3.right * (i * 0.5f);
            Instantiate(plantObject, flantPosition, Quaternion.identity);
        }
    }
}
