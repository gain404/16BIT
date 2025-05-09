using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;

public class LeverLiftController : MonoBehaviour
{
    //�������� bool�� �Ҵ�
    [SerializeField] private List<Lever> levers; //�ν����Ϳ��� ���� �Ҵ�
    public Dictionary<Lever, bool> dict;

    [SerializeField] private Transform liftTransform;

    private float liftSpeed = 5f;
    private bool isMoving;

    private void Start()
    {
        dict = new Dictionary<Lever, bool>();
        foreach (var lever in levers)
        {
            dict[lever] = false;
            lever.OnLiftChanged += LiftPressed; //����
        }
    }

    private void LiftPressed(Lever lever, bool isPressed)
    {
        dict[lever] = isPressed;
        isMoving = dict.Values.All(v => v);
    }

    private void Update()
    {
        Invoke("UPLift", 1f);
    }

    private void UPLift()
    {
        if (isMoving)
        {
            liftTransform.Translate(Vector3.up * liftSpeed * Time.deltaTime);

            Vector3 pos = liftTransform.localPosition;
            pos.y = Mathf.Clamp(pos.y, pos.y, 3f); //3f��ŭ �ö󰡵��� ����
            liftTransform.localPosition = pos;

            if (Mathf.Approximately(pos.y, 3f)) //worldPos�� 3f�� �����������
            {
                isMoving = false; //������ ����
            }
        }
    }

    private void OnDestroy()
    {
        foreach( var lever in levers)
        {
            lever.OnLiftChanged -= LiftPressed; //���� ����
        }
    }

}
