using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask layer;
    public float baseDamage = 10f; // 기본 데미지
    public float distanceMultiplier = 2f; // 거리에 따른 데미지 배율
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

        movedDistance = (transform.position - prevPos).magnitude; // 움직인 거리
        adjustedDamage = baseDamage + movedDistance * distanceMultiplier; // 조정된 데미지


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

            if (monster != null)  // Monster 컴포넌트가 있으면
            {
                monster.ResetDamageFlag();  // 데미지 플래그를 재설정합니다.
            }
        }
    }

    public void MonsterHit(Collider other)
    {
        Monster monster = other.gameObject.GetComponent<Monster>();

        if (monster != null) // Monster 컴포넌트가 있는지 확인
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
