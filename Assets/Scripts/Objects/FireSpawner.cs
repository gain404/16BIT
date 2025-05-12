using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    public GameObject fire;
    //발사 힘
    public float launchForce = 10f;
    //발사 간격
    public int launchInterval = 2;
    private void Start()
    {
        StartCoroutine(SpawnFire());
    }

    private IEnumerator SpawnFire()
    {
        while (true)
        {
            GameObject fireball = Instantiate(fire, this.gameObject.transform.position, Quaternion.identity);

            //위로 발사되게 설정
            Rigidbody2D _rigidbody = fireball.GetComponent<Rigidbody2D>();
            if (fireball != null)
            {
                _rigidbody.AddForce(Vector2.up * launchForce, ForceMode2D.Impulse);
            }

            yield return new WaitForSeconds(launchInterval);
        }
    }
}
