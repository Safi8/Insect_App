using Leap.Unity.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicOn : MonoBehaviour
{
    RectTransform iconPos;
    //public float posX;

    public GameObject go;
    public float transformPositionX;
    public Vector3 transformPosition;
    void Start()
    {
        iconPos = GetComponent<RectTransform>();
        go.GetComponent<InteractionToggle>().isToggled = true;
    }

    void Update()
    {
        if (iconPos.localPosition.x < 0)
        {
            GetComponent<AudioSource>().volume = 0.08f;
            if (gameObject.name == "MusicCanvas")
                go.GetComponent<InteractionToggle>().isToggled = true;
        }
        else
        {
            if (gameObject.name == "MusicCanvas")
                go.GetComponent<InteractionToggle>().isToggled = false;

            GetComponent<AudioSource>().volume = 0f;
        }
        ////posX = (float)Math.Round(GetComponent<RectTransform>().localPosition.x, 2);

        transformPosition.x = -0.05f;
        transformPosition.z = (float)Math.Round(iconPos.localPosition.z, 2);


    }

    void SoundOn()
    {
        GetComponent<AudioSource>().volume = 0.08f;
    }
    void SoundOff()
    {
        GetComponent<AudioSource>().volume = 0f;
    }
}
