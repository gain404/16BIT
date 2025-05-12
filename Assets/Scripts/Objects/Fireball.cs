using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fireball : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //일정 이하로 내려가면 삭제
        if(this.gameObject.transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }

        //아래로 내려갈 때 방향전환
        if (_rigidbody.velocity.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(_rigidbody.velocity.y, _rigidbody.velocity.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 8f * Time.deltaTime);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null && player.playerType == PlayerType.Water)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
