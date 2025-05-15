using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameTimeUI : MonoBehaviour
{
    Text timeT; //TimeText ������Ʈ�� ��Ƶ� ���� 
    float t = 0;//�÷��� Ÿ��. 


    // Start is called before the first frame update
    void Start()
    {
        timeT = GameObject.Find("TimeText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        timeT.text = SetTime((int)t);
    }

    string SetTime(int t)
    {
        string min = (t / 60).ToString();

        if (int.Parse(min) < 10) min = "0" + min;

        string sec = (t % 60).ToString();

        if (int.Parse(sec) < 10) sec = "0" + sec;

        return min + ":" + sec;
    }
}
