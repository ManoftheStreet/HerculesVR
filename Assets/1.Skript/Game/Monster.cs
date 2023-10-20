using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Monster : MonoBehaviour
{
    public float _hp = 100;
    Rigidbody rb;
    MeshCollider meshCol;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        meshCol = rb.GetComponent<MeshCollider>();
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        _hp -= damage;
        Debug.Log($"남은체력{_hp}");

        if(_hp <= 0)
        {
            anim.SetBool("isDead", true);
        }
    }

    public void Die()
    {

    }
}
