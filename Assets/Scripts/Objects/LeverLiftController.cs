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

    [SerializeField] private Transform liftTransform;

    private float liftSpeed = 1f;
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
        if (isMoving)
        {
            liftTransform.Translate(Vector3.up * liftSpeed * Time.deltaTime);
            Vector3 localLift = liftTransform.localPosition;
            localLift.y = Mathf.Clamp(localLift.y, 0f, 3f); //3f��ŭ �ö󰡵��� ����
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
