using Leap.Unity;
using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//!

[AddComponentMenu("ButtonColor")]
[RequireComponent(typeof(InteractionBehaviour))]
public class ButtonColor : MonoBehaviour
{
    private MenuManager menuManager;
    private InteractionBehaviour interactionCube;
    private Image _image;

    //public Material[] materials;
    public bool interactIconPressed;
    public string pressedButtonTag;

    [Tooltip("Если этот параметр включен, объект будет менять свой цвет при наведении, когда рука находится рядом.")]
    public bool useHover = true;

    [Tooltip("Если этот параметр включен, объект будет использовать свой primaryHoverColor при первичном наведении InteractionHand.")]
    public bool usePrimaryHover = false;

    [Header("InteractionButton Colors")]
    public Material _defMat;
    public Material _nearby;
    public Material _toched;
    private Material _dop1;
    private Material _dop2;

    public Sprite image1;

    void Start()
    {
        interactionCube = GetComponent<InteractionBehaviour>();
        _image = GetComponent<Image>();
        menuManager = GetComponent<MenuManager>();

        //new
        if (_image == null)
        {
            _image = GetComponentInChildren<Image>();
        }
        if (_image != null)
        {
            _defMat = _image.material;
        }
        _image.sprite = image1;
    }

    public void Update()
    {
        if (_defMat != null)
        {
            //_image.material = materials[0];
            _image.material = _defMat;

            if (interactionCube.isPrimaryHovered && usePrimaryHover)
            {
                _image.material = _nearby;
            }
            else
            {
                // Конечно, любое количество объектов может быть наведено любым количеством рук взаимодействия.
                // Поведение взаимодействия предоставляет API для доступа к различным взаимодействиям, связанным с взаимодействием
                // информация о состоянии, такая как ближайшая рука, которая находится поблизости, если объект
                // is hovered at all.
                if (interactionCube.isHovered && useHover)
                {
                    _image.material = _dop1;
                }
            }

            //Если объект удерживается только одной рукой и эта рука перестает отслеживать,
            //объект "приостанавливается." Поведение взаимодействия обеспечивает обратные вызовы
            //приостановки, если вы хотите, чтобы объект, например, исчез, когда объект приостановлен.
            //В качестве альтернативы вы можете проверить "Приостановлено" в любое время.
            if (interactionCube.isSuspended)
            {
                _image.material = _dop2;
            }

            if (interactionCube is InteractionButton && (interactionCube as InteractionButton).isPressed)
            {
                _image.material = _toched;
                interactIconPressed = true; // кнопка нажата!
                if(gameObject.tag != "Untagged")
                {
                    menuManager.tag = (interactionCube as InteractionButton).tag;
                    if (gameObject.tag == "OptionsButton")
                    {
                        menuManager._options = true;
                    }
                }
            }
            else
            {
                interactIconPressed = false;
                //pressedButtonTag = null;
            }
        }

        //_image.material = materials[0];
        ////если рука будет рядом
        //if (interactionCube.isPrimaryHovered && usePrimaryHover)
        //{
        //    _image.material = materials[1];
        //}
        //else
        //{
        //    // Конечно, любое количество объектов может быть наведено любым количеством рук взаимодействия.
        //    // Поведение взаимодействия предоставляет API для доступа к различным взаимодействиям, связанным с взаимодействием
        //    // информация о состоянии, такая как ближайшая рука, которая находится поблизости, если объект
        //    // is hovered at all.
        //    if (interactionCube.isHovered && useHover)
        //    {
        //        _image.material = materials[1];
        //    }
        //    //_image.material = materials[1];
        //}

        //if (interactionCube is InteractionButton && (interactionCube as InteractionButton).isPressed)
        //{
        //    _image.material = materials[2];
        //}
    }
}
