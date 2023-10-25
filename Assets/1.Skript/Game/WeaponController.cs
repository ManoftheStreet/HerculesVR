using CSCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class WeaponController : MonoBehaviour
{
    public LayerMask layer;
    public float baseDamage = 10f; // 기본 데미지
    public float distanceMultiplier = 2f; // 거리에 따른 데미지 배율

    float adjustedDamage = 30f;
    public AudioClip hitAudio;
    AudioSource audioSource;
    private HapticController hapticController;

    Vector3 prevPos;


    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        hapticController = GetComponent<HapticController>();
    }


    public void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other} in");
       
        if (other.tag == "Monster")
        {
            HitMonster(other);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log($"{other} out");
    }

    public void HitMonster(Collider other)
    {

        Monster monster = other.gameObject.GetComponentInParent<Monster>();

        if (monster != null) // Monster 컴포넌트가 있는지 확인
        {
            monster.TakeDamage(adjustedDamage, other);
            hapticController.Haptic(transform);
            HitCreatureEffect();
            Debug.Log("monster Entered!");
        }
        else
        {
            Debug.Log($"{other}Componentis null");
        }
    }

    public void HitCreatureEffect()
    {
        Debug.Log("서걱");
        if(audioSource == null)
        {
            Debug.Log("audioSource is null");
        }
        if (hitAudio == null)
        {
            Debug.Log("hitAudio is null");
        }
        Debug.Log("audioSource volume: " + audioSource.volume);
        if (audioSource.mute)
        {
            Debug.Log("audioSource is muted");
        }
        Debug.Log("audioSource Spatial Blend: " + audioSource.spatialBlend);
        Debug.Log("hitAudio length: " + hitAudio.length);
        audioSource.pitch = 1.5f;
        audioSource.clip = hitAudio;
        audioSource.Play();
    }
}
