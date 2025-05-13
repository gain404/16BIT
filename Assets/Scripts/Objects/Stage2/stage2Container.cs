using UnityEngine;

public class stage2Container : MonoBehaviour
{
    private bool isOnLeft = true;

    [SerializeField] private Vector3 leftPos;
    [SerializeField] private Vector3 rightPos;

    // 버튼 눌릴 때 이 메서드만 호출하면 된다.
    public void MoveContainer()
    {
        transform.position = isOnLeft ? rightPos : leftPos;
        isOnLeft = !isOnLeft;

        Debug.Log("컨테이너가 " + (isOnLeft ? "좌측" : "우측") + "으로 이동했습니다.");
    }
}