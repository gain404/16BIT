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
                isMoving = dict.Values.All(v => v); //레버를 모두 눌러야 리프트가 올라가게 만듦
                //하나만 눌러도 올라가게 만들고 싶으면 isMoving = isPressed
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
