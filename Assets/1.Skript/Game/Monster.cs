using ExitGames.Client.Photon;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86;

public class Monster : CreatureController
{
    public GameObject target;
    [SerializeField]
    public float _hp = 100;
    [SerializeField]
    float _scanRange = 10f;
    [SerializeField]
    float _attackRange = 5f;

    [SerializeField]
    float moveSpeed = 10f;



    CapsuleCollider bodyCol;
    SphereCollider headCol;
    Animator anim;
    bool isDamaged = false;
    bool isDead = false;
    NavMeshAgent agent;

    //public AudioClip hitAudio;
    AudioSource audioSource;
    ParticleSystem hitPaticle;

   

    void Start()
    {
        bodyCol = GetComponentInChildren<CapsuleCollider>();
        headCol = GetComponentInChildren<SphereCollider>();
        audioSource = GetComponent<AudioSource>();
        hitPaticle = GetComponent<ParticleSystem>();
        agent = GetComponent<NavMeshAgent>();
    }

    protected override void UpdateIdle()
    {
        if (target == null)
            return;

        float distance = (target.transform.position - transform.position).magnitude;
        if (distance < _scanRange)
        {
            _lockTarget = target;
            Debug.Log($" {_lockTarget.name} in Idle");
            state = State.Moving;
            return;
        }
    }

    protected override void UpdateMoving()
    {
        if (_lockTarget != null)
        {
            Debug.Log($" {_lockTarget.name} in Moving");
            _destPos = _lockTarget.transform.position; 
            Debug.Log($" {_lockTarget.name} after 64");
            float distance = (_destPos - transform.position).magnitude;
            if (distance <= _attackRange)
            {
                agent.SetDestination(transform.position);
                state = State.Attack;
                return;
            }
        }


        //이동
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.1f)
        {
            state = State.Idle;
        }
        else
        {
            agent.SetDestination(_destPos);
            agent.speed = moveSpeed;
            agent.acceleration = moveSpeed * 2f;
            agent.angularSpeed = 300f;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
        }
    }

    protected override void UpdateAttack()
    {
        if(_lockTarget == null) return;

        Vector3 dir = _lockTarget.transform.position - transform.position;
        Quaternion quat = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, quat, 20 * Time.deltaTime);
    }

    public void OnHitEvent()
    {
        if (_lockTarget == null)
        {
            state = State.Idle;
        }
        else
        {
            float distance = (_lockTarget.transform.position - transform.position).magnitude;
            if (distance <= _attackRange)
            {
                state = State.Attack;
            }

            else
            {
                state = State.Moving;
            }
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

        if (_hp <= 0 && !isDead)
        {
            state = State.Die;
        }


        SetDamageFlag();
        hitBox.enabled = false;
        StartCoroutine(ResetDamageFlagCoroutine(hitBox));

    }

    protected override void UpdateDie()
    {
 
    }

    public void HitEffect()
    {
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
