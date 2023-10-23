using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask layer;
    public float baseDamage = 10f; // �⺻ ������
    public float distanceMultiplier = 2f; // �Ÿ��� ���� ������ ����
    public AudioClip audioClip;


    AudioSource audioSource;
    ParticleSystem paticle;
    //float movedDistance = 0f;
    float adjustedDamage = 30f;


    Vector3 prevPos;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        paticle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        Attack();
        //Debug.DrawRay(transform.position, transform.forward * 100f, Color.red);
    }

    public void Attack()
    {
       
        /*RaycastHit hit;

        movedDistance = (transform.position - prevPos).magnitude; // ������ �Ÿ�
        adjustedDamage = baseDamage + movedDistance * distanceMultiplier; // ������ ������


        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.2f, layer))
        {
            *//*if (Vector3.Angle(transform.position - prevPos, hit.transform.up) > 130)
            {*//*
                Monster monster = hit.transform.GetComponent<Monster>();

                if (monster != null)
                {
                    monster.TakeDamage(adjustedDamage);

                }
            *//*}*//*
        }

        prevPos = transform.position;*/
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other} in");
        if(other.tag == "Monster")
        {
            MonsterHit(other);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log($"{other} out");
        if (other.tag == "Monster")
        {
            Monster monster = other.gameObject.GetComponent<Monster>();

            if (monster != null)  // Monster ������Ʈ�� ������
            {
                monster.ResetDamageFlag();  // ������ �÷��׸� �缳���մϴ�.
            }
        }
    }

    public void MonsterHit(Collider other)
    {
        Monster monster = other.gameObject.GetComponent<Monster>();

        if (monster != null) // Monster ������Ʈ�� �ִ��� Ȯ��
        {
            monster.SetDamageFlag();
            monster.TakeDamage(adjustedDamage);
            Debug.Log("monster Entered!");
            audioSource.pitch = 1.3f;
            audioSource.PlayOneShot(audioClip);
            paticle.Play();
        }
    }
}
