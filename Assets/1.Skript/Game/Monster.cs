using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Monster : MonoBehaviour
{
    public float _hp = 100;
    CapsuleCollider bodyCol;
    SphereCollider headCol;
    Animator anim;
    bool isDamaged = true;

    public AudioClip hitAudio;
    AudioSource audioSource;
    ParticleSystem hitPaticle;

    void Start()
    {
        bodyCol = GetComponentInChildren<CapsuleCollider>();
        headCol = GetComponentInChildren<SphereCollider>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        hitPaticle = GetComponent<ParticleSystem>();
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
        HitEffect();
        Debug.Log($"남은체력{_hp}");

        if (_hp <= 0)
        {
            Die();
        }
        ResetDamageFlag();
        StartCoroutine(ResetDamageFlagCoroutine());

    }

    public void Die()
    {
        anim.SetBool("isDead", true);
    }

    public void HitEffect()
    {
        audioSource.pitch = 1.3f;
        audioSource.PlayOneShot(hitAudio);
        hitPaticle.Play();
    }

    IEnumerator ResetDamageFlagCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        SetDamageFlag();
    }
}
