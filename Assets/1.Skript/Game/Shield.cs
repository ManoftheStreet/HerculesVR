using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : WeaponController
{
    public float radius = 2.0f; // 원형 레이의 반경 설정
    RaycastHit[] hitInfos = new RaycastHit[10]; // 예를 들어 최대 10개의 충돌을 저장할 수 있음

    public override void WeaponRay()
    {
        // 속도가 5.5 초과일 경우 SphereCast 실행
        if ((transform.position - prevPos).magnitude / Time.deltaTime > 1f)
        {
            float currentSpeed = (transform.position - prevPos).magnitude / Time.deltaTime;
            adjustDamage = damage * currentSpeed;

            // 충돌 정보를 저장할 배열 준비
            
            int hitCount = Physics.SphereCastNonAlloc(attackRoot.position, radius, transform.up, hitInfos, WeaponLenth, layer);

            for (int i = 0; i < hitCount; i++)
            {
                RaycastHit hitInfo = hitInfos[i];
                var attackTargetEntity = hitInfo.collider.GetComponent<CreatureController>();

                if (attackTargetEntity != null && !lastAttackedTargets.Contains(attackTargetEntity))
                {
                    var message = new DamageMessage();
                    Debug.Log(adjustDamage);
                    message.amount = adjustDamage; // 데미지 양 설정
                    message.damager = gameObject; // 데미지를 입힌 객체 설정
                    message.hitPoint = hitInfo.point; // 충돌 위치
                    message.hitNormal = attackRoot.TransformDirection(hitInfo.normal); // 충돌한 표면의 노멀 벡터
                    Manager.Haptic.Haptic(transform); // 진동 효과
                    HitCreatureEffect(); // 크리처에 히트 효과

                    attackTargetEntity.ApplyDamage(message); // 데미지 적용
                    lastAttackedTargets.Add(attackTargetEntity); // 공격한 대상 목록에 추가
                    StartCoroutine(AccessInfoAfterDelay());

                    // 하나의 타겟에 히트한 후 바로 루프를 종료할 것인지, 여러 대상을 처리할 것인지 결정 필요
                    // break; // 여기에 break를 넣을 경우 첫 번째 충돌에 대해서만 처리
                }
            }

            // 이전 위치 업데이트
            prevPos = transform.position;
        }
    }

    public override void HitCreatureEffect()
    {
        if (audioSource == null)
        {
            Debug.Log("audioSource is null");
        }
        audioSource.PlayOneShot(hitClip);
    }

#if UNITY_EDITOR
    protected override void OnDrawGizmosSelected()
    {
        if (attackRoot != null)
        {
            Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
            // 레이 대신 구체를 그려서 SphereCast를 시각화합니다.
            Vector3 direction = transform.up * WeaponLenth;
            Vector3 endPoint = attackRoot.position + direction;

            // 구체의 시작 부분을 그립니다.
            Gizmos.DrawWireSphere(attackRoot.position, radius);
            // 구체의 끝 부분을 그립니다.
            Gizmos.DrawWireSphere(endPoint, radius);
            // 구체의 경로를 그립니다.
            Gizmos.DrawLine(attackRoot.position, endPoint);
        }
    }
#endif
}