using UnityEngine;
using UnityEngine.UI;
using Leap.Unity.Interaction;

[AddComponentMenu("UI Color")]
[RequireComponent(typeof(InteractionButton))]
public class UIColor : MonoBehaviour
{
    public Sprite defPicture;
    public Sprite nearPicture;
    public Sprite touchPicture;
    public Sprite dop;


    private Image image;
    private InteractionBehaviour interactionCube;

    private bool musicIs;
    private bool maleHandsIs;
    private bool femaleHandsIs;

    [Tooltip("Если этот параметр включен, объект будет менять свой цвет при наведении, когда рука находится рядом.")]
    public bool useHover = true;

    [Tooltip("Если этот параметр включен, объект будет использовать свой primaryHoverColor при первичном наведении InteractionHand.")]
    public bool usePrimaryHover = false;

    void Start()
    {
        image = GetComponent<Image>();
        interactionCube = GetComponent<InteractionBehaviour>();
        defPicture = image.sprite;
    }

    void Update()
    {
        if (defPicture != null)
        {
            image.sprite = defPicture;

            if (interactionCube.isPrimaryHovered && usePrimaryHover)
            {
                image.sprite = nearPicture;
            }
            else
            {
                if (interactionCube.isHovered && useHover)
                {
                    image.sprite = nearPicture;
                }
            }
            //ButtonNearby();
            PressedButton();
        }
    }

    // Кнопка нажата
    public void PressedButton()
    {
        if (interactionCube is InteractionButton && (interactionCube as InteractionButton).isPressed)
        {
            image.sprite = touchPicture;
        }
    }

    // Рука рядом с кнопкой
    public void ButtonNearby()
    {
        if (interactionCube.isPrimaryHovered && usePrimaryHover)
        {
            image.sprite = nearPicture;
        }
        else
        {
            if (interactionCube.isHovered && useHover)
            {
                image.sprite = dop;
            }
        }
    }
}
