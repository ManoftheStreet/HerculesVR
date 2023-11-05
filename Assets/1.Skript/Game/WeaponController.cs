using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class WeaponController : MonoBehaviour
{
    public LayerMask layer;
    public float damage = 10f; // 기본 데미지
    public float adjustDamage = 10f; // 기본 데미지
    public float distanceMultiplier = 2f; // 거리에 따른 데미지 배율
    public Transform attackRoot;
    public float WeaponLenth;

    Rigidbody rb;
    public AudioClip hitClip;
    public AudioClip swingClip;
    TrailRenderer trailRenderer;
    protected AudioSource audioSource;
    private RaycastHit[] hits = new RaycastHit[10];

    protected List<CreatureController> lastAttackedTargets = new List<CreatureController>();

    protected Vector3 prevPos;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        trailRenderer = GetComponentInChildren<TrailRenderer>();
        audioSource.pitch = 1.5f;
    }

    private void Update()
    {
        WeaponRay();
    }

#if UNITY_EDITOR

    protected virtual void OnDrawGizmosSelected()
    {
        if (attackRoot != null)
        {
            Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
            Gizmos.DrawRay(attackRoot.position, transform.up * WeaponLenth);
        }
    }

#endif

    public virtual void HitCreatureEffect()
    {
        if (audioSource == null)
        {
            Debug.Log("audioSource is null");
        }
        audioSource.PlayOneShot(hitClip);
    }


    protected IEnumerator AccessInfoAfterDelay()
    {
        yield return new WaitForSeconds(0.6f);
        lastAttackedTargets.Clear();
    }

    public virtual void WeaponRay()
    {
        float currentSpeed = (transform.position - prevPos).magnitude / Time.deltaTime;

        if (currentSpeed > 5.5f)
        {
            trailRenderer.enabled = true;
            adjustDamage = damage * currentSpeed;

            // RaycastNonAlloc 호출로 변경
            int hitCount = Physics.RaycastNonAlloc(attackRoot.position, transform.up, hits, WeaponLenth, layer);

            for (int i = 0; i < hitCount; i++)
            {
                var hit = hits[i]; // 배열에서 hit 정보를 가져옴
                var attackTargetEntity = hit.collider.GetComponent<CreatureController>();

                if (attackTargetEntity != null && !lastAttackedTargets.Contains(attackTargetEntity))
                {
                    var message = new DamageMessage();
                    message.amount = adjustDamage;
                    Debug.Log(adjustDamage);
                    message.damager = gameObject;
                    message.hitPoint = hit.point;
                    message.hitNormal = attackRoot.TransformDirection(hit.normal);
                    Manager.Haptic.Haptic(transform);
                    audioSource.PlayOneShot(swingClip);
                    HitCreatureEffect();

                    attackTargetEntity.ApplyDamage(message);
                    lastAttackedTargets.Add(attackTargetEntity);

                    StartCoroutine(AccessInfoAfterDelay());
                    // 하나의 타겟에 히트한 후 바로 루프를 종료
                    break;
                }
            }

            /*RaycastHit hit;

            if (Physics.Raycast(attackRoot.position, transform.up, out hit, WeaponLenth, layer))
            {
                var attackTargetEntity = hit.collider.GetComponent<CreatureController>();

                if (attackTargetEntity != null && !lastAttackedTargets.Contains(attackTargetEntity))
                {
                    var message = new DamageMessage();
                    message.amount = adjustDamage;
                    Debug.Log(adjustDamage);
                    message.damager = gameObject;
                    message.hitPoint = hit.point;
                    message.hitNormal = attackRoot.TransformDirection(hit.normal);
                    audioSource.PlayOneShot(swingClip);
                    Manager.Haptic.Haptic(transform);
                    HitCreatureEffect();

                    attackTargetEntity.ApplyDamage(message);
                    lastAttackedTargets.Add(attackTargetEntity);

                    StartCoroutine(AccessInfoAfterDelay());
                }
            }*/
        }
        else
        {
            trailRenderer.enabled = false;
        }

        prevPos = transform.position;
    }

}
