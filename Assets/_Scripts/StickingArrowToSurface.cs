using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.Experimental.GraphView.GraphView;


public class StickingArrowToSurface : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private SphereCollider myCollider;
    [SerializeField] private GameObject stickingArrow;

    public LayerMask layer;
    public Transform attackRoot;
    public float WeaponLenth;
    public float damage;

    public AudioClip hitAudio;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
        myCollider.isTrigger = true;

        GameObject arrow = Instantiate(stickingArrow);
        arrow.transform.position = transform.position;
        arrow.transform.forward = transform.forward;
        Manager.Haptic.VibrateBothControllers(HapticController.objectStrength, HapticController.objectDuration);

        if (collision.collider.attachedRigidbody != null)
        {
            arrow.transform.parent = collision.collider.attachedRigidbody.transform;
            var attackTargetEntity = collision.collider.GetComponent<CreatureController>();

            if (attackTargetEntity != null)
            {
                var message = new DamageMessage();
                message.amount = damage;
                message.damager = gameObject;
                message.hitPoint = collision.contacts[0].point;
                message.hitNormal = attackRoot.TransformDirection(collision.contacts[0].normal);
                Manager.Haptic.VibrateBothControllers(HapticController.targerSterngth, HapticController.targerDuration);
                HitCreatureEffect();

                attackTargetEntity.ApplyDamage(message);
            }
        }

        Destroy(gameObject);
        Destroy(arrow, 5.0f);
    }

    public void HitCreatureEffect()
    {
        if (audioSource == null)
        {
            Debug.Log("audioSource is null");
        }

        audioSource.pitch = 1.5f;
        audioSource.PlayOneShot(hitAudio);
    }
}

