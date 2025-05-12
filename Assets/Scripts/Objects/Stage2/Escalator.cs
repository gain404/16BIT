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
        //에스컬레이터 밑에 공백의 오브젝트가 생성되어 좌표 이동
        //0.5초마다? 계속 생성되어 좌표가 이동되고
        //좌표에 도착한 오브젝트는 1초 후에 사라지도록
        Vector3 spawnPos = new Vector3(6.12f, -5.02f);
        Vector3 arrivePos = new Vector3(8.1f, -3.2f);
        Instantiate(escalatorPrefabs, spawnPos, Quaternion.identity);

        Vector3 elscalatorPos = Vector3.Lerp(spawnPos, arrivePos, 1f);
    }

}
