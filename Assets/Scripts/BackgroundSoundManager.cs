using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSoundManager : MonoBehaviour
{
    AudioSource audio;
    public GameObject Handmenucanvas;

    bool isSound = false;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Handmenucanvas.activeSelf)
        {
            if (!isSound)
            {
                audio.Play();
                isSound = true;
            }
        }
    }
}
