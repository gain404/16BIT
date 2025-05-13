using UnityEngine;

public class stage2Container : MonoBehaviour
{
    private bool isOnLeft = true;

    [SerializeField] private Vector3 leftPos;
    [SerializeField] private Vector3 rightPos;

    // ��ư ���� �� �� �޼��常 ȣ���ϸ� �ȴ�.
    public void MoveContainer()
    {
        transform.position = isOnLeft ? rightPos : leftPos;
        isOnLeft = !isOnLeft;

        Debug.Log("�����̳ʰ� " + (isOnLeft ? "����" : "����") + "���� �̵��߽��ϴ�.");
    }
}