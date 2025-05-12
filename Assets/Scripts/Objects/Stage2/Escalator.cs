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
            Debug.LogError("������ �ε� ����");
        else
            Debug.Log("�ε� ����");
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

    //�̵��ϰ� 1�� ���� �ı�
    private IEnumerator Move(GameObject obj, Vector3 from, Vector3 to, float duration)
    {
        float elapsed = 0f;

        while(elapsed < duration) //�̵��ϴ� ����
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            obj.transform.position = Vector3.Lerp(from, to, t);
            yield return null; //�̵��ϴ� ������ return null
        }

        //���� �� 1�� ��� & �ı�
        yield return new WaitForSecondsRealtime(0.5f);
        Debug.Log("����!");
        Destroy(obj);
    }
}
