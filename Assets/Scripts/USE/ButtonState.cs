using Leap.Unity.Interaction;
using UnityEngine;

[RequireComponent(typeof(InteractionButton))]
public class ButtonState : MonoBehaviour
{

    OptionsMenuMeneger optionsMenuMeneger;

    //.............
    InteractionToggle interactionToggle;



    //.........
    InteractionBehaviour interactionButton;

    public bool isPressed;
    public bool isNearby;
    public bool isDef;

    public bool turnOn = false;

    [Tooltip("Если этот параметр включен, объект будет менять свой цвет при наведении, когда рука находится рядом.")]
    public bool useHover = true;

    [Tooltip("Если этот параметр включен, объект будет использовать свой primaryHoverColor при первичном наведении InteractionHand.")]
    public bool usePrimaryHover = false;

    //public string buttonName;

    private void Start()
    {
        optionsMenuMeneger = GetComponent<OptionsMenuMeneger>();
        interactionToggle = GetComponent<InteractionToggle>();
        
        
        //......
        interactionButton = GetComponent<InteractionBehaviour>();
    }

    public void Update()
    {
        ButtonDefault();
        PressedButton();
        ButtonNearby();

        ToggleButton();
    }
    public void PressedButton()
    {
        if (interactionButton is InteractionButton && (interactionButton as InteractionButton).isPressed)
        {
            isPressed = true;
            isDef = false;
            isNearby = false;

            NameofButton();
        }
    }
    public void ButtonNearby()
    {
        if (interactionButton.isPrimaryHovered && usePrimaryHover)
        {
            isNearby = true;
            isDef = false;
        }
        else
        {
            if (interactionButton.isHovered && useHover)
            {
                isNearby = true;
                isDef = false;
            }
        }
    }

    public void ButtonDefault()
    {
        isDef = true;
        isNearby = false;
        isPressed = false;
    }

    public void ToggleButton()
    {
        if((interactionToggle as InteractionToggle).isToggled)
        {
            turnOn = true;
        }
        else
        {
            turnOn = false;
        }
    }

    public void NameofButton()
    {
        if(turnOn == true)
        {
            //if (gameObject.name == "MusicButtonTest")
            //    optionsMenuMeneger.isMusic = true;
            //if (gameObject.name == "FemaleHandsTest")
            //    optionsMenuMeneger.isRealHands = true;
            //if (gameObject.name == "MaleHandsTest")
            //    optionsMenuMeneger.isLowHands = true;
            DetermineName();
        }
        else
        {
            optionsMenuMeneger.isRealHands = false;
            optionsMenuMeneger.isLowHands = false;
            optionsMenuMeneger.isMusic = false;

            optionsMenuMeneger.isInsectRotate = false;
        }

        //if (gameObject.name == "BackButtonTest")
        //    optionsMenuMeneger.isBack = true;

        //// Активация кнопок для главного меню
        //if (gameObject.name == "PlayButton")
        //    optionsMenuMeneger.isPlay = true;

        //if (gameObject.name == "OptionsButton")
        //    optionsMenuMeneger.isOptions = true;

        //if (gameObject.name == "QuitButton")
        //    optionsMenuMeneger.isQuit = true;
        DetermineName();
    }

    public void DetermineName()
    {
        switch(gameObject.name)
        {
            // Options.......................................................
            case "MusicButtonTest": 
                optionsMenuMeneger.isMusic = true;
                break;
            case "FemaleHandsTest":
                optionsMenuMeneger.isRealHands = true;
                break;
            case "MaleHandsTest":
                optionsMenuMeneger.isLowHands = true;
                break;
            case "BackButtonTest":
                optionsMenuMeneger.isBack = true;
                break;
                // MainMenu ................................................
            case "PlayButton":
                optionsMenuMeneger.isPlay = true;
                break;
            case "OptionsButton":
                optionsMenuMeneger.isOptions = true;
                break;
            case "QuitButton":
                optionsMenuMeneger.isQuit = true;
                break;
                // Plushka InsectsScene ..............................................
            //case "TheBack":
            //    optionsMenuMeneger.isInsectBack = true;
            //    break;
            case "TheRotate":
                optionsMenuMeneger.isInsectRotate = true;
                break;
            case "Animation":
                optionsMenuMeneger.isInsectAnime = true;
                break;
            case "TheBack":
                optionsMenuMeneger.isInsectBack = true;
                break;

            case "NextScene":
                optionsMenuMeneger.isInsectNextScene = true;
                break;
        }
    }
}
