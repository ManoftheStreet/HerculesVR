using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HapticController
{
    public static float objectStrength = 0.2f;
    public static float objectDuration = 0.1f;
    public static float targerSterngth = 0.8f;
    public static float targerDuration = 0.2f;

    public void Haptic(Transform transform)
    {
        foreach (Transform child in transform)
        {
            if (child.name.Contains("Right"))
            {
                VibrateController(0.3f, 0.2f, InputDeviceCharacteristics.Right);
                break;
            }
            else if (child.name.Contains("Left"))
            {
                VibrateController(0.3f, 0.2f, InputDeviceCharacteristics.Left);
                break;
            }
        }
    }

    private void VibrateController(float strength, float duration, InputDeviceCharacteristics hand)
    {
        UnityEngine.XR.InputDevice device = GetDeviceByCharacteristics(hand | InputDeviceCharacteristics.Controller);
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
            return devices[0];
        }
        return new UnityEngine.XR.InputDevice();
    }

    public void VibrateBothControllers(float strength, float duration)
    {
        VibrateController(strength, duration, InputDeviceCharacteristics.Right);
        VibrateController(strength, duration, InputDeviceCharacteristics.Left);
    }
}
