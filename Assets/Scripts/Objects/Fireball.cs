using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fireball : MonoBehaviour
{
    private void Update()
    {
        //일정 이하로 내려가면 삭제
        if(this.gameObject.transform.position.y < -10)
        {
            Destroy(this.gameObject);
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
