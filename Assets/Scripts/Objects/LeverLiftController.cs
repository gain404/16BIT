using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;

public class LeverLiftController : MonoBehaviour
{
    //�������� bool�� �Ҵ�
    [SerializeField] private List<Lever> levers; //���� �Ҵ�
    public Dictionary<Lever, bool> dict;

    [SerializeField] private Transform Lift;

    private float liftSpeed = 1f;
    private bool isMoving;

    private void Start()
    {
        dict = new Dictionary<Lever, bool>();
        foreach (var lever in levers)
        {
            dict[lever] = false;
            lever.OnLiftChanged += (isPressed) =>
            {
                dict[lever] = isPressed;
                isMoving = dict.Values.All(v => v); //������ ��� ������ ����Ʈ�� �ö󰡰� ����
                //�ϳ��� ������ �ö󰡰� ����� ������ isMoving = isPressed
            };
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            Lift.Translate(Vector3.up * liftSpeed * Time.deltaTime);
        }
    }
}
