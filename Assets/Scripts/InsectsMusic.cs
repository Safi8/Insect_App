using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectsMusic : MonoBehaviour
{
    RectTransform iconPos;

    private void Start()
    {
        iconPos = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (iconPos.localPosition.x < 0)
        {
            GetComponent<AudioSource>().volume = 0.08f;
        }
        else
        {
            GetComponent<AudioSource>().volume = 0f;
        }
    }
}
