using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

// UI 관련 코드
[System.Serializable]
public class AnimationInput
{
    public string animationPropertyName;
    public InputActionProperty action;
}

// 플레이어 캐릭터의 생명체로서의 동작을 담당
public class PlayerHealth : CreatureController
{
    [SerializeField] private InputActionReference move;
    private Animator anim;
    private AudioSource audioSource; // 플레이어 소리 재생기
    public List<AnimationInput> animationInputs;

    public AudioClip deathClip; // 사망 소리
    public AudioClip hitClip; // 피격 소리
    public UI_InteractionController UIcontroller;

    RigBuilder rigBuilder;
    LowerBodyAnimation lowerBodyAnimation;
    CharacterController characterController;
    AvatarController avatarController;
    LocomotionSystem locomotionSystem;
    ContinuousMoveProviderBase continuousMoveProvider;
    ContinuousTurnProviderBase continuousTurnProvider;


    private void Awake()
    {
        // 사용할 컴포넌트를 가져오기
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        move.action.started += AnimateLegs;
        move.action.canceled += StopAnimation;
        rigBuilder = GetComponent<RigBuilder>();
        lowerBodyAnimation = GetComponent<LowerBodyAnimation>();
        avatarController = GetComponent<AvatarController>();
        characterController = transform.parent.GetComponent<CharacterController>();
        locomotionSystem = transform.parent.GetComponent<LocomotionSystem>();
        continuousMoveProvider = transform.parent.GetComponent<ContinuousMoveProviderBase>();
        continuousTurnProvider = transform.parent.GetComponent<ContinuousTurnProviderBase>();
    }

    public void Update()
    {
        HandAnimation();
    }

    protected override void OnEnable()
    {
        // LivingEntity의 OnEnable() 실행 (상태 초기화)
        base.OnEnable();
        UpdateUI();
    }

    // 체력 회복
    public override void RestoreHealth(float newHealth)
    {
        // LivingEntity의 RestoreHealth() 실행 (체력 증가)
        base.RestoreHealth(newHealth);
        // 체력 갱신
        UpdateUI();
    }

    private void UpdateUI()
    {
        //UIManager.Instance.UpdateHealthText(dead ? 0f : health);
    }

    // 데미지 처리
    public override bool ApplyDamage(DamageMessage damageMessage)
    {
        if (!base.ApplyDamage(damageMessage)) return false;

        EffectManager.Instance.PlayHitEffect(damageMessage.hitPoint, damageMessage.hitNormal, transform, EffectManager.EffectType.Flesh);

        if (hitClip != null)
        {
            audioSource.PlayOneShot(hitClip);
        }

        // LivingEntity의 OnDamage() 실행(데미지 적용)
        // 갱신된 체력을 체력 슬라이더에 반영
        UpdateUI();
        return true;
    }

    // 사망 처리
    public override void Die()
    {
        // LivingEntity의 Die() 실행(사망 적용)
        base.Die();

        // 체력 슬라이더 비활성화
        UpdateUI();
        // 사망음 재생
        if (deathClip != null)
        {
            audioSource.PlayOneShot(deathClip);
        }
        // 애니메이터의 Die 트리거를 발동시켜 사망 애니메이션 재생
        lowerBodyAnimation.enabled = false;
        rigBuilder.enabled = false;
        characterController.enabled = false;
        avatarController.enabled = false;
        locomotionSystem.enabled = false;
        transform.position += new Vector3(0, 0.6f, 0);
        continuousTurnProvider.enabled = false;
        continuousMoveProvider.enabled = false;
        anim.SetTrigger("isDead");
        Manager.Instance.GameOver();
        UIcontroller.GameOverText();
    }

    private void AnimateLegs(InputAction.CallbackContext obj)
    {
        bool isMovingForward = move.action.ReadValue<Vector2>().y > 0;
        //Debug.Log("AnimateLegs On");
        if (anim != null && !dead)
        {
            if (isMovingForward)
            {
                //Debug.Log("isWalking True");
                anim.SetBool("isWalking", true);
                anim.SetFloat("animSpeed", 2f);
            }
            else
            {
                //Debug.Log("isWalking false");
                anim.SetBool("isWalking", true);
                anim.SetFloat("animSpeed", -2f);
            }
        }
    }

    private void StopAnimation(InputAction.CallbackContext obj)
    {
        if (anim != null)
        {
            anim.SetBool("isWalking", false);
            anim.SetFloat("animSpeed", 0);
        }
    }

    public void HandAnimation()
    {

        if (!dead)
        {
            foreach (var item in animationInputs)
            {
                float actionValue = item.action.action.ReadValue<float>();
                anim.SetFloat(item.animationPropertyName, actionValue);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 'other'가 플레이어인지 확인합니다.
        if (other.CompareTag("EndCube"))
        {
            // 게임 클리어 로직을 여기에 작성합니다.
            // 예를 들어, 랭크를 결정하고 저장하는 코드 등이 될 수 있습니다.
            float playerHealthPoints = health; // 플레이어의 현재 체력을 가져옵니다.
            int rank = DetermineRank(playerHealthPoints); // 랭크를 결정하는 함수를 호출합니다.

            // 랭크를 텍스트로 출력하는 로직은 별도로 구현하시면 됩니다.
            // 예: someUITextElement.text = "Your rank: " + rank;
            UIcontroller.WinText(rank);
        }
    }

    // 플레이어의 체력 점수에 따라 랭크를 결정하는 메소드입니다.
    private int DetermineRank(float health)
    {
        if (health >= 80) return 3;

        if (health >= 60) return 2;

        return 1;
    }

    public void FootStep()
    {
        if (audioSource != null && footStepClip != null)
        {
            audioSource.PlayOneShot(footStepClip);
        }
    }
}