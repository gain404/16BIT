using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class stage2Container : MonoBehaviour
{

    private float leftLimit;
    private float rightLimit;

    [SerializeField] private float leftBind;
    [SerializeField] private float rightBind;
    [SerializeField] private float waitTime;

    private int direction = -1; // -1 = ����, 1 = ������

    [SerializeField] private float liftSpeed = 5f;

    [SerializeField] private Transform liftTransform;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isWaiting = false;

    //public static GravityHandler instance { get; private set; }

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        //rb.gravityScale = 0f;

        // ���� ��ġ �������� �¿� ���� ����
        float startX = liftTransform.position.x;
        leftLimit = startX - Mathf.Abs(leftBind);
        rightLimit = startX + Mathf.Abs(rightBind);
    }

    private void MoveLift()
    {
        if (isWaiting) return;

        liftTransform.Translate(Vector3.right * direction * liftSpeed * Time.deltaTime);

        float posX = liftTransform.position.x;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // �÷��̾ �� ����Ʈ�� �ڽ����� ���� (���� �����̰�)
            collision.transform.SetParent(this.liftTransform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // �θ� ���� ���� (����Ʈ���� �������� ��)
            collision.transform.SetParent(null);
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
