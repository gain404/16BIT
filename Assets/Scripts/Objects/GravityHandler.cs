using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityHandler : MonoBehaviour
{
    public float reverseGravity = 9.81f;
    public bool gravityReversed = true;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public static GravityHandler instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
       // rb.gravityScale = 0f;
    }

    void FixedUpdate()
    {
        Vector2 direction = gravityReversed ? Vector2.up : Vector2.down;
        rb.AddForce(direction * reverseGravity, ForceMode2D.Force);
    }

    void Update()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.flipY = gravityReversed;
        }
    }
}
