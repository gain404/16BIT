using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;

public class LeverLiftController : MonoBehaviour
{
    //레버마다 bool값 할당
    [SerializeField] private List<Lever> levers; //인스펙터에서 레버 할당
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
            lever.OnLiftChanged += LiftPressed; //구독
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
            pos.y = Mathf.Clamp(pos.y, pos.y, 3f); //3f만큼 올라가도록 제한
            liftTransform.localPosition = pos;

            if (Mathf.Approximately(pos.y, 3f)) //worldPos가 3f에 가까워졌으면
            {
                isMoving = false; //움직임 멈춤
            }
        }
    }

    private void OnDestroy()
    {
        foreach( var lever in levers)
        {
            lever.OnLiftChanged -= LiftPressed; //구독 해제
        }
    }

}
