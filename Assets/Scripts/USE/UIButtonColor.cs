using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap.Unity.Interaction;

[RequireComponent(typeof(InteractionButton))]
public class UIButtonColor : MonoBehaviour
{
    public Sprite defPcture;
    public Sprite nearbyPicture;
    public Sprite touchPicture;

    ButtonState buttonState;
    Image image;

    private void Start()
    {
        buttonState = GetComponent<ButtonState>();
        image = GetComponent<Image>();
    }

    void PressedColor()
    {
        if (buttonState.isPressed == true)
            image.sprite = touchPicture;
    }

    void DefColor()
    {
        if (buttonState.isDef == true)
        {
            image.sprite = defPcture;
        }
    }

    void NearbyColor()
    {
        if(buttonState.isNearby == true)
        {
            //image.sprite = defPcture;
            image.sprite = nearbyPicture;
        }
    }

    void ToggledColor()
    {
        if (buttonState.turnOn == true)
            image.sprite = touchPicture;
        else image.sprite = defPcture;
    }

    private void Update()
    {
        //DefColor();
        //NearbyColor();
        //PressedColor();


        //if (gameObject.name != "MusicButtonTest")
        //{
        //    DefColor();
        //    NearbyColor();
        //    PressedColor();
        //}
        //else
        //{
        //    ToggledColor();
        //}

        if ((gameObject.name == "MusicButtonTest") || (gameObject.name == "FemaleHandsTest") || (gameObject.name == "MaleHandsTest") || (gameObject.name == "TheRotate"))
            ToggledColor();
        else
        {
            DefColor();
            NearbyColor();
            PressedColor();
        }
    }
}
