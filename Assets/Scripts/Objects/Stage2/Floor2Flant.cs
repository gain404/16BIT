using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Floor2Flant : MonoBehaviour
{
    [SerializeField] private GameObject flantObject;

    private void Awake()
    {
        flantObject = GameObject.FindGameObjectWithTag("Flant");
        if (flantObject == null)
            Debug.Log("���ӿ�����Ʈ�� ã�� ���߽��ϴ�.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out var pt))
        {
            if (pt.playerType == PlayerType.Soil)
            {
                //��� ������ ������ ����
                SpawnFlant();
                GameObject[] flantObjects = GameObject.FindGameObjectsWithTag("Flant");
                int count = flantObjects.Length;
                count = Mathf.Clamp(count, 0, 2);
                if (flantObjects.Length > 3) return;
            }
        }
    }

    private void SpawnFlant()
    {
        //��� �� �� ������ ������ ����
        for (int i = 0; i < 3; i++)
        {
            Vector3 flantPosition = flantObject.transform.position + Vector3.right * (i * 1f); 
            Instantiate(flantObject, flantPosition, Quaternion.identity);
        }
    }
}
