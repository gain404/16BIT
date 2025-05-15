using UnityEngine;

public class stage2VentThunderButton : MonoBehaviour
{
    private stage2Vent vent;

    private void Awake()
    {
        vent = FindObjectOfType<stage2Vent>(); // 씬에 존재하는 환풍구 컴포넌트 참조
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<PlayerController>(out var pt))
        {
            if (pt.playerType == PlayerType.Thunder)
            {
                Debug.Log("thunder타입 플레이어와 충돌");

                if (vent != null)
                    vent.SetSafeForSoil(true); // 환풍구에 흙 통과 허용
            }
        }
    }
}