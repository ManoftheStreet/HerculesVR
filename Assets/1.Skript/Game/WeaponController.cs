using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class WeaponController : MonoBehaviour
{
    public LayerMask layer;
    public float baseDamage = 10f; // �⺻ ������
    public float distanceMultiplier = 2f; // �Ÿ��� ���� ������ ����

    float adjustedDamage = 30f;


    Vector3 prevPos;


    void Start()
    {
    }

    void Update()
    {
        Attack();
    }

    public void Attack()
    {

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

        if (monster != null) // Monster ������Ʈ�� �ִ��� Ȯ��
        {
            monster.TakeDamage(adjustedDamage, other);
            Haptic();
            Debug.Log("monster Entered!");
        }
        else
        {
            Debug.Log($"{other}Componentis null");
        }
    }

    #region Haptic
    public void Haptic()
    {
        foreach (Transform child in transform)
        {
            if (child.name.Contains("Right"))
            {
                VibrateRightController(0.3f, 0.2f);
                break;
            }
            else if (child.name.Contains("Left"))
            {
                VibrateLeftController(0.3f, 0.2f);
                break;
            }
        }
    }

    public void VibrateRightController(float strength, float duration)
    {
        // ������ ��Ʈ�ѷ��� ã�´�.
        UnityEngine.XR.InputDevice device = GetDeviceByCharacteristics(InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller);
        if (device.isValid)
        {
            device.SendHapticImpulse(0, strength, duration);
        }
    }

    public void VibrateLeftController(float strength, float duration)
    {
        // ���� ��Ʈ�ѷ��� ã�´�.
        UnityEngine.XR.InputDevice device = GetDeviceByCharacteristics(InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller);
        if (device.isValid)
        {
            device.SendHapticImpulse(0, strength, duration);
        }
    }
    private UnityEngine.XR.InputDevice GetDeviceByCharacteristics(InputDeviceCharacteristics characteristics)
    {
        List<UnityEngine.XR.InputDevice> devices = new List<UnityEngine.XR.InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices);

        if (devices.Count > 0)
        {
            return devices[0];  // ù ��° ����̽��� ��ȯ. �Ϲ������� �ϳ��� ��Ʈ�ѷ��� ����Ǿ� ���� ���̴�.
        }

        return new UnityEngine.XR.InputDevice();  // ��ȿ���� ���� ����̽��� ��ȯ
    }
    #endregion

}
