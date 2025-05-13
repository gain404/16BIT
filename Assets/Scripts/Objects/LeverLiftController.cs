using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;

public class LeverLiftController : MonoBehaviour
{
    //�������� bool�� �Ҵ�
    [SerializeField] private List<Lever> levers; //�ν����Ϳ��� ���� �Ҵ�
    private Dictionary<Lever, bool> dict;

    [SerializeField] private Transform liftTransform;

    private float liftSpeed = 5f;
    private bool isMoving;
    public bool isUP = false;

    public float liftUpMove = 3f;
    public float liftDownMove = -3f;
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
        isMoving = isPressed;
    }

    private void Update()
    {
        if (isUP == false)
        {
            UpLift();
        }
        else if (isUP == true)
        {
            DownLift();
        }
    }

    private void UpLift()
    {
        if (isMoving)
        {
            liftTransform.Translate(Vector3.up * liftSpeed * Time.deltaTime);

            Vector3 pos = liftTransform.localPosition;
            pos.y = Mathf.Clamp(pos.y, pos.y, liftUpMove); //3f��ŭ �ö󰡵��� ����
            liftTransform.localPosition = pos;

            if (Mathf.Approximately(pos.y, liftUpMove)) //worldPos�� 3f�� �����������
            {
                isMoving = false; //������ ����
                isUP = true;
            }
            
        }
    }

    private void DownLift()
    {
        if (isMoving)
        {
            liftTransform.Translate(Vector3.down * liftSpeed * Time.deltaTime);

            Vector3 pos = liftTransform.localPosition;
            pos.y = Mathf.Clamp(pos.y, liftDownMove, liftUpMove);
            liftTransform.localPosition = pos;

            if (Mathf.Approximately(pos.y, liftDownMove))
            {
                isMoving = false;
                isUP = false;
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
