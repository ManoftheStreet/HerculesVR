using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Monster : MonoBehaviour
{
    public float _hp = 100;
    BoxCollider meshCol;
    Animator anim;
    bool isDamaged = false;

    void Start()
    {
        meshCol = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {

    }

    public void SetDamageFlag()
    {
        isDamaged = true;
    }

    public void ResetDamageFlag()
    {
        isDamaged = false;
    }

    public void TakeDamage(float damage)
    {
        if (!isDamaged) return;

        _hp -= damage;
        Debug.Log($"남은체력{_hp}");

        if(_hp <= 0)
        {
            Die();
        }
        ResetDamageFlag();
    }

    public void Die()
    {
        anim.SetBool("isDead", true);
    }
}
