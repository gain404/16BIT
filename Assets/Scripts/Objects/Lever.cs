using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public delegate void LiftChange(Lever lever, bool isPressed);
    public event LiftChange OnLiftChanged;
    private GameObject[] players;

    public Sprite activatedLever;
    public Sprite defaultLever;
    private bool isActivated;
    private SpriteRenderer spriteRenderer;

    private bool isPush = false;

    private void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateLeverSprite();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPush = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPush = false;
        }
    }

    private void Update()
    {
        PushLever();
    }

    private void PushLever()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPush)
        {
            OnLiftChanged?.Invoke(this, true);
            isActivated = !isActivated;
            UpdateLeverSprite();
        }
    }

    private void UpdateLeverSprite()
    {
        spriteRenderer.sprite = isActivated ? activatedLever : defaultLever;
    }
}
