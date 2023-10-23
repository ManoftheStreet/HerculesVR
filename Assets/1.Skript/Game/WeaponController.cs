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

        if (monster != null) // Monster 컴포넌트가 있는지 확인
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
        // 오른쪽 컨트롤러를 찾는다.
        UnityEngine.XR.InputDevice device = GetDeviceByCharacteristics(InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller);
        if (device.isValid)
        {
            device.SendHapticImpulse(0, strength, duration);
        }
    }

    public void VibrateLeftController(float strength, float duration)
    {
        // 왼쪽 컨트롤러를 찾는다.
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
            return devices[0];  // 첫 번째 디바이스를 반환. 일반적으로 하나의 컨트롤러만 연결되어 있을 것이다.
        }

        return new UnityEngine.XR.InputDevice();  // 유효하지 않은 디바이스를 반환
    }
    #endregion

}
