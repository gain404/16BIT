using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;

public class LeverLiftController : MonoBehaviour
{
    //레버마다 bool값 할당
    [SerializeField] private List<Lever> levers; //레버 할당
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
        if (isMoving)
        {
            liftTransform.Translate(Vector3.up * liftSpeed * Time.deltaTime);
            Vector3 localLift = liftTransform.localPosition;
            localLift.y = Mathf.Clamp(localLift.y, 0f, 3f); //3f만큼 올라가도록 제한
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
