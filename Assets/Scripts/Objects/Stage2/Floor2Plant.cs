using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Floor2Plant : MonoBehaviour
{
    [SerializeField] private GameObject plantObject;

    private void Awake()
    {
        plantObject = GameObject.FindGameObjectWithTag("Plant");
        if (plantObject == null)
            Debug.Log("게임오브젝트를 찾지 못했습니다.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out var pt))
        {
            if (pt.playerType == PlayerType.Soil)
            {
                //블록 옆으로 줄줄이 스폰
                SpawnPlant();
                GameObject[] plantObjects = GameObject.FindGameObjectsWithTag("Plant");
                int count = plantObjects.Length;
                count = Mathf.Clamp(count, 0, 2);
                if (plantObjects.Length > 3) return;
            }
        }
    }

    private void SpawnPlant()
    {
        //블록 세 개 옆으로 줄줄이 스폰
        for (int i = 0; i < 3; i++)
        {
            Vector3 flantPosition = plantObject.transform.position + Vector3.right * (i * 1f); 
            Instantiate(plantObject, flantPosition, Quaternion.identity);
        }
    }
}
