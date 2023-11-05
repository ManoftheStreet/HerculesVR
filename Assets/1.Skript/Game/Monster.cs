using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Monster : CreatureController
{
    /*public GameObject target;
    [SerializeField]
    int _attack = 50;
    [SerializeField]
    public float _hp = 100;
    [SerializeField]
    float _scanRange = 10f;
    [SerializeField]
    float _attackRange = 5f;

    [SerializeField]
    float _moveSpeed = 10f;

    [SerializeField]
    float _xValue = 1.5f;
    [SerializeField]
    float _yValue = 1.1f;
    [SerializeField]
    float _lenth = 0.5f;


    CapsuleCollider bodyCol;
    SphereCollider headCol;
    bool isDead = false;
    bool isAttack = false;
    NavMeshAgent agent;

    //public AudioClip hitAudio;
    AudioSource audioSource;
    ParticleSystem hitPaticle;



    private void Awake()
    {
        bodyCol = GetComponentInChildren<CapsuleCollider>();
        headCol = GetComponentInChildren<SphereCollider>();
        audioSource = GetComponent<AudioSource>();
        hitPaticle = GetComponent<ParticleSystem>();
        agent = GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();
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
            //state = States.Moving;
            return;
        }
    }

    protected override void UpdateMoving()
    {
        if (_lockTarget != null)
        {
            _destPos = _lockTarget.transform.position; 
            float distance = (_destPos - transform.position).magnitude;
            if (distance <= _attackRange)
            {
                agent.SetDestination(transform.position);
                //state = States.Attack;
                
                return;
            }
        }


        //이동
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.1f)
        {
            //state = States.Idle;
        }
        else
        {
            agent.SetDestination(_destPos);
            agent.speed = _moveSpeed;
            agent.acceleration = _moveSpeed * 2f;
            agent.angularSpeed = 300f;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
        }
    }
 

    protected override void UpdateAttack()
    {
        if(_lockTarget == null) return;

        if (!isAttack) // 공격 중이 아닐 때만 코루틴을 시작
        {
            StartCoroutine(AttackRoutine());
        }
        Debug.DrawRay(new Vector3(transform.position.x + _xValue, transform.position.y + _yValue, transform.position.z), transform.forward, Color.red);
        Vector3 dir = _lockTarget.transform.position - transform.position;
        Quaternion quat = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, quat, 20 * Time.deltaTime);
    }

    IEnumerator AttackRoutine()
    {
        isAttack = true;
        //animator.CrossFade("Attack", 0.05f, -1, 0);
        yield return new WaitForSeconds(2.0f);
        isAttack = false;
    }


    public void OnHitEvent()
    {
        if (_lockTarget == null)
        {
            //state = States.Idle;
        }
        else
        {
            float distance = (_lockTarget.transform.position - transform.position).magnitude;
            if (distance <= _attackRange)
            {
               // state = States.Attack;
            }

            else
            {
               //state = States.Moving;
            }
        }

        RaycastHit hit;
        Vector3 rayOrigin = new Vector3(transform.position.x + _xValue, transform.position.y + _yValue, transform.position.z);
        Vector3 rayDirection = transform.forward * 10f;  // 앞쪽 방향으로 10 유닛
        LayerMask mask = ~((1 << 8) | (1 << 9));

        Physics.Raycast(rayOrigin, rayDirection, out hit, _lenth,mask);
        if (hit.collider == null) return;
        Debug.Log(hit.collider);
        if (hit.collider.CompareTag("Player"))
        {
            
        }
    }


    #region Hit

    public void TakeDamage(float damage, Collider hitBox)
    {

        _hp -= damage;
        HitEffect();
        Debug.Log($"남은체력{_hp}");

        if (_hp <= 0 && !isDead)
        {
            //state = States.Die;
        }

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
    }

    #endregion*/
}
