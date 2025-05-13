using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MoveTile : MonoBehaviour
{

    private float leftLimit;
    private float rightLimit;
    private bool liftMovement = true;

    [SerializeField] private float leftBind;
    [SerializeField] private float rightBind;
    [SerializeField] private float waitTime;

    private int direction = -1; // -1 = ¿ÞÂÊ, 1 = ¿À¸¥ÂÊ

    [SerializeField] private float liftSpeed = 5f;

    [SerializeField] private Transform liftTransform;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isWaiting = false;

    public static GravityHandler instance { get; private set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb.gravityScale = 0f;
        float posX = liftTransform.localPosition.x;
        leftLimit = posX - leftBind;
        rightLimit = posX + rightBind;
    }
    

    private void MoveLift()
    {
        if (isWaiting) return;

        liftTransform.Translate(Vector3.right * direction * liftSpeed * Time.deltaTime);

        float posX = liftTransform.localPosition.x;
        if (posX <= leftLimit)
        {
            direction = 0;
            isWaiting = true;
            Invoke("WaitAtLeft", waitTime);
        }
        else if (posX >= rightLimit)
        {
            direction = 0;
            isWaiting = true;
            Invoke("WaitAtRight", waitTime);
        }
    }

    void WaitAtLeft()
    {
        direction = 1;
        isWaiting = false;
    }

    void WaitAtRight()
    {
        direction = -1;
        isWaiting = false;
    }

    void FixedUpdate()
    {
        MoveLift();
    }
}
