using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCharacterController : PlayerController
{
    // Fire ���� �̵����
    public override void PlayerMove()
    {
        base.PlayerMove();  // �⺻ PlayerMove ȣ��
        // Fire ���� �̵� ó�� (�ʿ�� �߰��� Fire ĳ���͸��� �̵� ����� ����)
    }

    // Fire ���� ���� (���� Ư�� ������ �ʿ��� ��� ����)
    public override void PlayerJump()
    {
        base.PlayerJump();  // �⺻ PlayerJump ȣ��
        // Fire ���� ���� ó�� (�ʿ�� �߰��� Fire ĳ���͸��� ���� Ư�� ����)
    }

    // Fire ���� �浹 ó��
    public override void PlayerCollision()
    {
        base.PlayerCollision();  // �⺻ �浹 ó�� ȣ��
        // Fire ĳ���� Ư���� �´� �浹 ó�� �߰�
        Debug.Log("Fire Collision Detected");

        // ���÷� Fire ĳ���Ϳ� �浹 �� Ư�� �ൿ �߰�
        // ��: Fire ĳ���Ͱ� �ҿ� ���� ������Ʈ�� �浹���� �� �������� �ְų�, ���� �Ѵ� ��
    }
}
