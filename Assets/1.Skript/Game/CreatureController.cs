using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CreatureController : MonoBehaviour
{
    public enum State
    {
        Idle,
        Patrol,
        Tracking,
        AttackBegin,
        Attacking,
        Hit,
        Dead,
    }

    public float startingHealth = 100f; // ���� ü��
    public float health { get; protected set; } // ���� ü��
    public bool dead { get; protected set; } // ��� ����

    public event Action OnDeath; // ����� �ߵ��� �̺�Ʈ
    public CreatureController PlayertargetEntity; // ������ ���
    public AudioClip footStepClip;
    private const float minTimeBetDamaged = 0.1f;
    private float lastDamagedTime;
    protected bool IsInvulnerable
    {
        get
        {
            if (Time.time >= lastDamagedTime + minTimeBetDamaged) return false;

            return true;
        }
    }

    // ����ü�� Ȱ��ȭ�ɶ� ���¸� ����
    protected virtual void OnEnable()
    {
        // ������� ���� ���·� ����
        dead = false;
        // ü���� ���� ü������ �ʱ�ȭ
        health = startingHealth;
    }

    // �������� �Դ� ���
    public virtual bool ApplyDamage(DamageMessage damageMessage)
    {
        if (IsInvulnerable || damageMessage.damager == gameObject || dead) return false;

        lastDamagedTime = Time.time;

        // ��������ŭ ü�� ����
        health -= damageMessage.amount;

        // ü���� 0 ���� && ���� ���� �ʾҴٸ� ��� ó�� ����
        if (health <= 0) Die();

        return true;
    }

    // ü���� ȸ���ϴ� ���
    public virtual void RestoreHealth(float newHealth)
    {
        if (dead) return;

        // ü�� �߰�
        health += newHealth;
    }

    // ��� ó��
    public virtual void Die()
    {
        // onDeath �̺�Ʈ�� ��ϵ� �޼��尡 �ִٸ� ����
        if (OnDeath != null) OnDeath();

        // ��� ���¸� ������ ����
        dead = true;
    }
}
