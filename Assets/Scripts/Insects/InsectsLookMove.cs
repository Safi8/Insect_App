using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectsLookMove : MonoBehaviour
{
    OptionsMenuMeneger optionsMenuMeneger;
    public GameObject goAnimeIcon;
    public GameObject goRotateIcon;
    public Transform target;

    private void Start()
    {
        optionsMenuMeneger = GetComponent<OptionsMenuMeneger>();
    }
    private void Update()
    {
        if (goAnimeIcon.GetComponent<OptionsMenuMeneger>().isInsectAnime == true)
            GetComponent<AnimaotrManager>().AnimeRun();
        else GetComponent<AnimaotrManager>().AnimeIdle();

        if (goRotateIcon.GetComponent<OptionsMenuMeneger>().isInsectRotate == true)
            transform.LookAt(target);
    }
}
