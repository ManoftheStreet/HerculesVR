using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Enemy : CreatureController
{
    private State state;

    private NavMeshAgent agent; // 경로계산 AI 에이전트
    private Animator anim; // 애니메이터 컴포넌트

    public Transform attackRoot;
    public Transform eyeTransform;
    public float attackRange = 2.0f;

    private AudioSource audioSource; // 오디오 소스 컴포넌트
    public AudioClip hitClip; // 피격시 재생할 소리
    public AudioClip deathClip; // 사망시 재생할 소리
    public AudioClip shieldClip;
    public AudioClip swingVoice;
    public AudioClip swingClip;

    private Renderer skinRenderer; // 렌더러 컴포넌트

    public float runSpeed = 10f;
    [Range(0.01f, 2f)] public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    public float damage = 30f;
    public float attackRadius = 2f;
    private float attackDistance;

    public float fieldOfView = 50f;
    public float viewDistance = 10f;
    public float patrolSpeed = 3f;

    CreatureController targetEntity; // 추적할 대상

    public LayerMask playerLayer; // 추적 대상 레이어
    public LayerMask shieldLayer; // 추적 대상 레이어
    LayerMask whatIsTarget;

    private RaycastHit[] hits = new RaycastHit[10];

    private bool shieldHitRegistered = false;

    private bool hasTarget => targetEntity != null && !targetEntity.dead;


#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        if (attackRoot != null)
        {
            Gizmos.color = new Color(1f,0f,0f,0.5f);
            Gizmos.DrawRay(attackRoot.position, transform.forward * attackRange);
        }

        if (eyeTransform != null)
        {
            var leftRayRotation = Quaternion.AngleAxis(-fieldOfView * 0.5f, Vector3.up);
            var leftRayDirection = leftRayRotation * transform.forward;
            Handles.color = new Color(1f, 1f, 1f, 0.2f);
            Handles.DrawSolidArc(eyeTransform.position, Vector3.up, leftRayDirection, fieldOfView, viewDistance);
        }
        
    }

#endif

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        skinRenderer = GetComponentInChildren<Renderer>();

        var attackPivot = attackRoot.position;
        attackPivot.y = transform.position.y;
        attackDistance = Vector3.Distance(attackRoot.position, attackPivot) + attackRange * 0.5f;
        agent.stoppingDistance = attackDistance;
        agent.speed = patrolSpeed;
        whatIsTarget = playerLayer | shieldLayer;
        PlayertargetEntity = GameObject.Find("Player").GetComponent<CreatureController>();
    }

    // 적 AI의 초기 스펙을 결정하는 셋업 메서드
    public void Setup(float health, float damage, float runSpeed, float patrolSpeed, Color skinColor)
    {
        // 체력 설정
        this.startingHealth = health;
        this.health = health;

        // 내비메쉬 에이전트의 이동 속도 설정
        this.runSpeed = runSpeed;
        this.patrolSpeed = patrolSpeed;

        this.damage = damage;

        // 렌더러가 사용중인 머테리얼의 컬러를 변경, 외형 색이 변함
        skinRenderer.material.color = skinColor;
    }

    private void Start()
    {
        // 게임 오브젝트 활성화와 동시에 AI의 추적 루틴 시작
        StartCoroutine(UpdatePath());
    }

    private void Update()
    {
        if (dead) return;

        if (state == State.Tracking)
        {
            var distance = Vector3.Distance(targetEntity.transform.position, transform.position);
            if (distance <= attackDistance)
            {
                BeginAttack();
            }
        }
        // 추적 대상의 존재 여부에 따라 다른 애니메이션을 재생
        anim.SetFloat("Speed", agent.desiredVelocity.magnitude);
    }

    private void FixedUpdate()
    {
        if (dead) return;

        if ((state == State.AttackBegin || state == State.Attacking) && targetEntity != null)
        {
            var lookRotation =
                Quaternion.LookRotation(targetEntity.transform.position - transform.position, Vector3.up);
            var targetAngleY = lookRotation.eulerAngles.y;

            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngleY,
                                        ref turnSmoothVelocity, turnSmoothTime);
        }
    }

    // 주기적으로 추적할 대상의 위치를 찾아 경로를 갱신
    private IEnumerator UpdatePath()
    {
        // 살아있는 동안 무한 루프
        while (!dead)
        {
            if (hasTarget)
            {
                if (state == State.Patrol)
                {
                    state = State.Tracking;
                    agent.speed = runSpeed;
                }

                // 추적 대상 존재 : 경로를 갱신하고 AI 이동을 계속 진행
                agent.SetDestination(targetEntity.transform.position);
            }
            else
            {
                if (targetEntity != null) targetEntity = null;

                if (state != State.Patrol)
                {
                    state = State.Patrol;
                    agent.speed = patrolSpeed;
                }

                if (agent.remainingDistance <= 2f)
                {
                    var patrolPosition = Utility.GetRandomPointOnNavMesh(transform.position, 20f, NavMesh.AllAreas);
                    agent.SetDestination(patrolPosition);
                }

                // 20 유닛의 반지름을 가진 가상의 구를 그렸을때, 구와 겹치는 모든 콜라이더를 가져옴
                // 단, whatIsTarget 레이어를 가진 콜라이더만 가져오도록 필터링
                var colliders = Physics.OverlapSphere(eyeTransform.position, viewDistance, whatIsTarget);

                // 모든 콜라이더들을 순회하면서, 살아있는 LivingEntity 찾기
                foreach (var collider in colliders)
                {
                    if (!IsTargetOnSight(collider.transform)) continue;

                    var livingEntity = collider.GetComponent<CreatureController>();

                    // LivingEntity 컴포넌트가 존재하며, 해당 LivingEntity가 살아있다면,
                    if (livingEntity != null && !livingEntity.dead)
                    {
                        // 추적 대상을 해당 LivingEntity로 설정
                        targetEntity = livingEntity;

                        // for문 루프 즉시 정지
                        break;
                    }
                }
            }

            // 0.2 초 주기로 처리 반복
            yield return new WaitForSeconds(0.05f);
        }
    }

    // 데미지를 입었을때 실행할 처리
    public override bool ApplyDamage(DamageMessage damageMessage)
    {
        if (!base.ApplyDamage(damageMessage)) return false;

        if (targetEntity == null)
        {
            targetEntity = damageMessage.damager.GetComponent<CreatureController>();
        }

        EffectManager.Instance.PlayHitEffect(damageMessage.hitPoint, damageMessage.hitNormal, transform, EffectManager.EffectType.Flesh);
        audioSource.PlayOneShot(hitClip);

        return true;
    }

    public void BeginAttack()
    {
        state = State.AttackBegin;

        agent.isStopped = true;
        anim.SetTrigger("Attack");
        audioSource.PlayOneShot(swingVoice);
    }

    public void EnableAttack()
    {
        state = State.Attacking;

        RaycastHit hit;

        if (Physics.Raycast(attackRoot.position, transform.forward, out hit, attackRange, whatIsTarget))
        {
            var hitCollider = hit.collider;
            var attackTargetEntity = hit.collider.GetComponent<CreatureController>();

            if ((shieldLayer.value & (1 << hit.collider.gameObject.layer)) != 0)
            {
                HandleShieldHit();
                return; // 추가 공격 처리 중단
            }
            else if (attackTargetEntity != null)
            {
                var message = new DamageMessage();
                message.amount = damage;
                message.damager = gameObject;
                message.hitPoint = hit.point;
                message.hitNormal = attackRoot.TransformDirection(hit.normal);
                audioSource.PlayOneShot(swingClip);
                Manager.Haptic.Haptic(transform);

                attackTargetEntity.ApplyDamage(message);
            }
        }
    }

    public void DisableAttack()
    {
        if (hasTarget)
        {
            state = State.Patrol;
        }
        else
        {
            state = State.Patrol;
        }

        if (agent != null && agent.isOnNavMesh)
        {
            agent.isStopped = false;
        }
    }

    private bool IsTargetOnSight(Transform target)
    {
        var direction = target.position - eyeTransform.position;
        direction.y = eyeTransform.forward.y;

        if (Vector3.Angle(direction, eyeTransform.forward) > fieldOfView * 0.5f)
        {
            return false;
        }

        direction = target.position - eyeTransform.position;

        RaycastHit hit;

        if (Physics.Raycast(eyeTransform.position, direction, out hit, viewDistance, whatIsTarget))
        {
            if (hit.transform == target) return true;
        }

        return false;
    }

    // 사망 처리
    public override void Die()
    {
        // LivingEntity의 Die()를 실행하여 기본 사망 처리 실행
        base.Die();

        // 다른 AI들을 방해하지 않도록 자신의 모든 콜라이더들을 비활성화
        GetComponent<Collider>().enabled = false;

        // AI 추적을 중지하고 내비메쉬 컴포넌트를 비활성화
        agent.enabled = false;

        // 사망 애니메이션 재생
        anim.applyRootMotion = true;
        anim.SetTrigger("Die");

        // 사망 효과음 재생
        if (deathClip != null) audioSource.PlayOneShot(deathClip);
    }


    public void HandleShieldHit()
    {
        // 이미 방패에 히트한 경우 더 이상 처리하지 않음
        if (shieldHitRegistered) return;

        // 방패에 히트 처리를 했다는 표시
        shieldHitRegistered = true;

        // 오디오 재생
        if (audioSource != null && shieldClip != null)
        {
            audioSource.PlayOneShot(shieldClip);
        }
        else
        {
            Debug.Log("audioSource or shieldClip is null");
        }

        // 일정 시간 후에 shieldHitRegistered를 다시 false로 설정
        StartCoroutine(ResetShieldHit());
    }
    private IEnumerator ResetShieldHit()
    {
        yield return new WaitForSeconds(0.5f); // 쿨다운 시간
        shieldHitRegistered = false;
    }

    public void FootStep()
    {
        if (audioSource != null && footStepClip != null)
        {
            audioSource.PlayOneShot(footStepClip);
        }
    }
}