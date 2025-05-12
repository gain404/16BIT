using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalator : MonoBehaviour
{

    private GameObject escalatorPrefabs;

    private void Awake()
    {
        escalatorPrefabs = Resources.Load<GameObject>("Prefabs/Escalator");
        if (escalatorPrefabs == null)
            Debug.LogError("프리펩 로드 실패");
        else
            Debug.Log("로드 성공");
    }

    private void Start()
    {
        
    }

    internal void PlayEscalator()
    {
        Vector3 spawnPos = new Vector3(6.12f, -5.02f);
        Vector3 arrivePos = new Vector3(8.1f, -3.2f);
        GameObject obj = Instantiate(escalatorPrefabs, spawnPos, Quaternion.identity);

        StartCoroutine(Move(obj, spawnPos,arrivePos, 1f));
    }

    //이동하고 1초 이후 파괴
    private IEnumerator Move(GameObject obj, Vector3 from, Vector3 to, float duration)
    {
        float elapsed = 0f;

        while(elapsed < duration) //이동하는 동안
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            obj.transform.position = Vector3.Lerp(from, to, t);
            yield return null; //이동하는 동안은 return null
        }

        //도착 후 1초 대기 & 파괴
        yield return new WaitForSecondsRealtime(0.5f);
        Debug.Log("도착!");
        Destroy(obj);
    }
}
