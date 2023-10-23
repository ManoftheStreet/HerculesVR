using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public Transform target;
    
    public float _hp = 100;
    CapsuleCollider bodyCol;
    SphereCollider headCol;
    Animator anim;
    bool isDamaged = false;
    bool isDead = false;
    NavMeshAgent agent;

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
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        ChaseTarget();
    }

    public void ChaseTarget()
    {
        if (target == null) return;

        if (_hp > 0 && !isDamaged)
        {
            agent.destination = target.position;
            anim.SetBool("isRunning", true);
        }
        
    }

    #region Hit
    public void SetDamageFlag()
    {
        isDamaged = true;
    }

    public void ResetDamageFlag()
    {
        isDamaged = false;
    }

    public void TakeDamage(float damage, Collider hitBox)
    {

        _hp -= damage;
        HitEffect();
        Debug.Log($"남은체력{_hp}");

        if (_hp <= 0)
        {
            Die();
        }
        SetDamageFlag();
        hitBox.enabled = false;
        StartCoroutine(ResetDamageFlagCoroutine(hitBox));

    }

    public void Die()
    {
        if (!isDead)
        {
            anim.SetTrigger("isDead");
            isDead = true;
        }
        
    }

    public void HitEffect()
    {
        audioSource.pitch = 1.3f;
        audioSource.PlayOneShot(hitAudio);
        hitPaticle.Play();
    }

    IEnumerator ResetDamageFlagCoroutine(Collider hitBox)
    {
        yield return new WaitForSeconds(1.5f);
        hitBox.enabled = true;
        ResetDamageFlag();
    }
    #endregion
}
