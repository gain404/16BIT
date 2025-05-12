using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalator : MonoBehaviour
{

    private GameObject escalatorPrefabs;

    private void Awake()
    {
        escalatorPrefabs = Resources.Load<GameObject>("Prefabs/escalator");
    }

    private void Start()
    {
        InvokeRepeating(nameof(PlayEscalator), 0f, 0.5f);
    }

    private void PlayEscalator()
    {
        //�����÷����� �ؿ� ������ ������Ʈ�� �����Ǿ� ��ǥ �̵�
        //0.5�ʸ���? ��� �����Ǿ� ��ǥ�� �̵��ǰ�
        //��ǥ�� ������ ������Ʈ�� 1�� �Ŀ� ���������
        Vector3 spawnPos = new Vector3(6.12f, -5.02f);
        Vector3 arrivePos = new Vector3(8.1f, -3.2f);
        Instantiate(escalatorPrefabs, spawnPos, Quaternion.identity);

        Vector3 elscalatorPos = Vector3.Lerp(spawnPos, arrivePos, 1f);
    }

}
